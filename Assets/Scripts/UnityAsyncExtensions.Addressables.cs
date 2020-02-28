using System;
using System.Threading;
using UniRx.Async.Internal;
using UnityEngine.ResourceManagement.AsyncOperations;

// ReSharper disable ConvertIfStatementToSwitchStatement
// ReSharper disable UnusedMember.Global
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable InvertIf

namespace UniRx.Async
{
    public static partial class UnityAsyncExtensions
    {
        public static AsyncOperationHandleAwaiter<T> GetAwaiter<T>(this AsyncOperationHandle<T> asyncOperationHandle)
        {
            Error.ThrowArgumentDefaultException(asyncOperationHandle, nameof(asyncOperationHandle));
            return new AsyncOperationHandleAwaiter<T>(asyncOperationHandle);
        }

        public static UniTask<T> ToUniTask<T>(this AsyncOperationHandle<T> asyncOperation)
        {
            Error.ThrowArgumentDefaultException(asyncOperation, nameof(asyncOperation));
            return new UniTask<T>(new AsyncOperationHandleAwaiter<T>(asyncOperation));
        }

        public static UniTask<T> ConfigureAwait<T>(this AsyncOperationHandle<T> asyncOperationHandle, IProgress<float> progress = null, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellation = default)
        {
            Error.ThrowArgumentDefaultException(asyncOperationHandle, nameof(asyncOperationHandle));

            var awaiter = new AsyncOperationHandleConfiguredAwaiter<T>(asyncOperationHandle, progress, cancellation);
            if (!awaiter.IsCompleted)
            {
                PlayerLoopHelper.AddAction(timing, awaiter);
            }

            return new UniTask<T>(awaiter);
        }

        public struct AsyncOperationHandleAwaiter<T> : IAwaiter<T>
        {
            private AsyncOperationHandle<T> asyncOperationHandle;
            private Action<AsyncOperationHandle<T>> continuationAction;
            private T result;

            public AsyncOperationHandleAwaiter(AsyncOperationHandle<T> asyncOperationHandle)
            {
                Status = asyncOperationHandle.IsDone ? AwaiterStatus.Succeeded : AwaiterStatus.Pending;
                this.asyncOperationHandle = Status.IsCompleted() ? default : asyncOperationHandle;
                continuationAction = null;
                result = Status.IsCompletedSuccessfully() ? asyncOperationHandle.Result : default;
            }

            public bool IsCompleted => Status.IsCompleted();

            public AwaiterStatus Status { get; private set; }

            void IAwaiter.GetResult()
            {
                ((IAwaiter<T>) this).GetResult();
            }

            // Cannot use explicitly implementation
            public T GetResult()
            {
                if (Status == AwaiterStatus.Succeeded)
                {
                    return result;
                }

                if (Status == AwaiterStatus.Pending)
                {
                    if (asyncOperationHandle.IsDone)
                    {
                        Status = AwaiterStatus.Succeeded;
                    }
                    else
                    {
                        Error.ThrowNotYetCompleted();
                    }
                }

                result = asyncOperationHandle.Result;

                if (continuationAction != null)
                {
                    asyncOperationHandle.Completed -= continuationAction;
                    asyncOperationHandle = default;
                    continuationAction = null;
                }
                else
                {
                    asyncOperationHandle = default;
                }

                return result;
            }

            public void OnCompleted(Action continuation)
            {
                UnsafeOnCompleted(continuation);
            }

            public void UnsafeOnCompleted(Action continuation)
            {
                Error.ThrowWhenContinuationIsAlreadyRegistered(continuationAction);
                continuationAction = _ => continuation.Invoke();
                asyncOperationHandle.Completed += continuationAction;
            }
        }

        class AsyncOperationHandleConfiguredAwaiter<T> : IAwaiter<T>, IPlayerLoopItem
        {
            private AsyncOperationHandle<T> asyncOperationHandle;
            private IProgress<float> progress;
            private CancellationToken cancellationToken;
            private Action continuation;
            private T result;

            public AsyncOperationHandleConfiguredAwaiter(AsyncOperationHandle<T> asyncOperationHandle, IProgress<float> progress, CancellationToken cancellationToken)
            {
                Status = cancellationToken.IsCancellationRequested ? AwaiterStatus.Canceled
                    : asyncOperationHandle.IsDone ? AwaiterStatus.Succeeded
                    : AwaiterStatus.Pending;

                if (Status.IsCompletedSuccessfully())
                {
                    result = asyncOperationHandle.Result;
                }

                if (Status.IsCompleted())
                {
                    return;
                }

                this.asyncOperationHandle = asyncOperationHandle;
                this.progress = progress;
                this.cancellationToken = cancellationToken;
                continuation = null;
                result = default;

                TaskTracker.TrackActiveTask(this, 2);
            }

            public bool IsCompleted => Status.IsCompleted();
            public AwaiterStatus Status { get; private set; }

            void IAwaiter.GetResult() => GetResult();

            public T GetResult()
            {
                if (Status == AwaiterStatus.Succeeded)
                {
                    return result;
                }

                if (Status == AwaiterStatus.Canceled)
                {
                    Error.ThrowOperationCanceledException();
                }

                return Error.ThrowNotYetCompleted<T>();
            }

            public bool MoveNext()
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    InvokeContinuation(AwaiterStatus.Canceled);
                    return false;
                }

                progress?.Report(asyncOperationHandle.PercentComplete);

                if (asyncOperationHandle.IsDone)
                {
                    result = asyncOperationHandle.Result;
                    InvokeContinuation(AwaiterStatus.Succeeded);
                    return false;
                }

                return true;
            }

            private void InvokeContinuation(AwaiterStatus awaiterStatus)
            {
                Status = awaiterStatus;
                var continuationAction = continuation;

                // cleanup
                TaskTracker.RemoveTracking(this);
                continuation = null;
                cancellationToken = CancellationToken.None;
                progress = null;
                asyncOperationHandle = default;

                continuationAction?.Invoke();
            }

            public void OnCompleted(Action continuationAction)
            {
                Error.ThrowWhenContinuationIsAlreadyRegistered(continuation);
                continuation = continuationAction;
            }

            public void UnsafeOnCompleted(Action continuationAction)
            {
                Error.ThrowWhenContinuationIsAlreadyRegistered(continuation);
                continuation = continuationAction;
            }
        }
    }
}