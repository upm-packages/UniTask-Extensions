using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using JetBrains.Annotations;
using UniRx.Async.Internal;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

// ReSharper disable ConvertIfStatementToSwitchStatement
// ReSharper disable UnusedMember.Global
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable InvertIf

namespace UniRx.Async
{
    public static class AwaitableAddressables
    {
        public static async UniTask InitializeAsync(IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            await Addressables.InitializeAsync().ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<GameObject> InstantiateAsync(IResourceLocation location, InstantiationParameters instantiationParameters, bool trackHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.InstantiateAsync(location, instantiationParameters, trackHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<GameObject> InstantiateAsync(IResourceLocation location, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.InstantiateAsync(location, parent, instantiateInWorldSpace, trackHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<GameObject> InstantiateAsync(IResourceLocation location, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.InstantiateAsync(location, position, rotation, parent, trackHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<GameObject> InstantiateAsync(object key, InstantiationParameters instantiationParameters, bool trackHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.InstantiateAsync(key, instantiationParameters, trackHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<GameObject> InstantiateAsync(object key, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.InstantiateAsync(key, parent, instantiateInWorldSpace, trackHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<GameObject> InstantiateAsync(object key, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.InstantiateAsync(key, position, rotation, parent, trackHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask DownloadDependenciesAsync(IList<IResourceLocation> locations, bool autoReleaseHandle = false, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            await Addressables.DownloadDependenciesAsync(locations, autoReleaseHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask DownloadDependenciesAsync(IList<object> keys, bool autoReleaseHandle = false, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            await Addressables.DownloadDependenciesAsync(keys, autoReleaseHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask DownloadDependenciesAsync(object key, bool autoReleaseHandle = false, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            await Addressables.DownloadDependenciesAsync(key, autoReleaseHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<T> LoadAssetAsync<T>(IResourceLocation location, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadAssetAsync<T>(location).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<T> LoadAssetAsync<T>(object key, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadAssetAsync<T>(key).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<IList<T>> LoadAssetsAllAsync<T>(IList<IResourceLocation> locations, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadAssetsAsync(locations, (T x) => {}).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<IList<T>> LoadAssetsAllAsync<T>(IList<object> keys, Addressables.MergeMode mode, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadAssetsAsync(keys, (T x) => {}, mode).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<IList<T>> LoadAssetsAllAsync<T>(object key, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadAssetsAsync(key, (T x) => {}).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneMode loadSceneMode = LoadSceneMode.Single, bool activateOnLoad = true, int priority = 100, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadSceneAsync(location, loadSceneMode, activateOnLoad, priority).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadSceneMode = LoadSceneMode.Single, bool activateOnLoad = true, int priority = 100, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadSceneAsync(key, loadSceneMode, activateOnLoad, priority).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<SceneInstance> UnloadSceneAsync(AsyncOperationHandle handle, bool autoReleaseHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.UnloadSceneAsync(handle, autoReleaseHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<SceneInstance> UnloadSceneAsync(AsyncOperationHandle<SceneInstance> handle, bool autoReleaseHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.UnloadSceneAsync(handle, autoReleaseHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<SceneInstance> UnloadSceneAsync(SceneInstance scene, bool autoReleaseHandle = true, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.UnloadSceneAsync(scene, autoReleaseHandle).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<long> GetDownloadSizeAsync(IList<object> keys, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.GetDownloadSizeAsync(keys).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<long> GetDownloadSizeAsync(object key, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.GetDownloadSizeAsync(key).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<IResourceLocator> LoadContentCatalogAsync(string catalogPath, string providerSuffix = null, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadContentCatalogAsync(catalogPath, providerSuffix).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<IList<IResourceLocation>> LoadResourceLocationsAsync(IList<object> keys, Addressables.MergeMode mode, Type type = null, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadResourceLocationsAsync(keys, mode, type).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        public static async UniTask<IList<IResourceLocation>> LoadResourceLocationsAsync(object key, Type type = null, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            return await Addressables.LoadResourceLocationsAsync(key, type).ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }
    }

    [PublicAPI]
    public static partial class UnityAsyncExtensions
    {
        public static IAwaiter<T> GetAwaiter<T>(this AsyncOperationHandle<T> asyncOperationHandle)
        {
            Error.ThrowArgumentDefaultException(asyncOperationHandle, nameof(asyncOperationHandle));
            return new AsyncOperationHandleAwaiter<T>(asyncOperationHandle);
        }

        public static UniTask<T> ToUniTask<T>(this AsyncOperationHandle<T> asyncOperation)
        {
            Error.ThrowArgumentDefaultException(asyncOperation, nameof(asyncOperation));
            return new UniTask<T>(new AsyncOperationHandleAwaiter<T>(asyncOperation));
        }

        public static UniTask ConfigureAwait(this AsyncOperationHandle asyncOperationHandle, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentDefaultException(asyncOperationHandle, nameof(asyncOperationHandle));

            var awaiter = new AsyncOperationHandleConfiguredAwaiter(asyncOperationHandle, progress, cancellationToken);
            if (!((IAwaiter) awaiter).IsCompleted)
            {
                PlayerLoopHelper.AddAction(playerLoopTiming, awaiter);
            }

            return new UniTask(awaiter);
        }

        public static UniTask<T> ConfigureAwait<T>(this AsyncOperationHandle<T> asyncOperationHandle, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default)
        {
            Error.ThrowArgumentDefaultException(asyncOperationHandle, nameof(asyncOperationHandle));

            var awaiter = new AsyncOperationHandleConfiguredAwaiter<T>(asyncOperationHandle, progress, cancellationToken);
            if (!((IAwaiter<T>) awaiter).IsCompleted)
            {
                PlayerLoopHelper.AddAction(playerLoopTiming, awaiter);
            }

            return new UniTask<T>(awaiter);
        }

        public static UniTask<T> LoadAssetAsync<T>(this AssetReferenceT<T> assetReference, IProgress<float> progress = null, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update, CancellationToken cancellationToken = default) where T : UnityEngine.Object
        {
            return assetReference.LoadAssetAsync<T>().ConfigureAwait(progress, playerLoopTiming, cancellationToken);
        }

        private struct AsyncOperationHandleAwaiter<T> : IAwaiter<T>
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
            T IAwaiter<T>.GetResult()
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

            void INotifyCompletion.OnCompleted(Action continuation)
            {
                ((ICriticalNotifyCompletion) this).UnsafeOnCompleted(continuation);
            }

            void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation)
            {
                Error.ThrowWhenContinuationIsAlreadyRegistered(continuationAction);
                continuationAction = _ => continuation.Invoke();
                asyncOperationHandle.Completed += continuationAction;
            }
        }

        private class AsyncOperationHandleConfiguredAwaiter : IAwaiter, IPlayerLoopItem
        {
            private AsyncOperationHandle asyncOperationHandle;
            private IProgress<float> progress;
            private CancellationToken cancellationToken;
            private Action<AsyncOperationHandle> continuationAction;
            private AwaiterStatus status;

            AwaiterStatus IAwaiter.Status => status;
            bool IAwaiter.IsCompleted => ((IAwaiter) this).Status.IsCompleted();

            public AsyncOperationHandleConfiguredAwaiter(AsyncOperationHandle asyncOperationHandle, IProgress<float> progress, CancellationToken cancellationToken)
            {
                status = cancellationToken.IsCancellationRequested ? AwaiterStatus.Canceled
                    : asyncOperationHandle.IsDone ? AwaiterStatus.Succeeded
                    : AwaiterStatus.Pending;

                if (status.IsCompleted())
                {
                    return;
                }

                this.asyncOperationHandle = asyncOperationHandle;
                this.progress = progress;
                this.cancellationToken = cancellationToken;

                continuationAction = null;

                TaskTracker.TrackActiveTask(this, 2);
            }

            void IAwaiter.GetResult()
            {
                if (status == AwaiterStatus.Succeeded)
                {
                    return;
                }

                if (status == AwaiterStatus.Pending)
                {
                    if (asyncOperationHandle.IsDone)
                    {
                        status = AwaiterStatus.Succeeded;
                    }
                    else
                    {
                        Error.ThrowNotYetCompleted();
                    }
                }

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
            }

            void INotifyCompletion.OnCompleted(Action continuation)
            {
                ((ICriticalNotifyCompletion) this).UnsafeOnCompleted(continuation);
            }

            void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation)
            {
                Error.ThrowWhenContinuationIsAlreadyRegistered(continuationAction);
                continuationAction = _ => continuation.Invoke();
                asyncOperationHandle.Completed += continuationAction;
            }

            bool IPlayerLoopItem.MoveNext()
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    InvokeContinuation(AwaiterStatus.Canceled);
                    return false;
                }

                if (asyncOperationHandle.IsDone)
                {
                    progress?.Report(1.0f);
                    InvokeContinuation(AwaiterStatus.Succeeded);
                    return false;
                }

                progress?.Report(asyncOperationHandle.PercentComplete);

                return true;
            }

            private void InvokeContinuation(AwaiterStatus awaiterStatus)
            {
                status = awaiterStatus;
                var handle = asyncOperationHandle;
                var continuation = continuationAction;

                // cleanup
                TaskTracker.RemoveTracking(this);
                continuationAction = null;
                cancellationToken = CancellationToken.None;
                progress = null;
                asyncOperationHandle = default;

                continuation?.Invoke(handle);
            }
        }

        private class AsyncOperationHandleConfiguredAwaiter<T> : IAwaiter<T>, IPlayerLoopItem
        {
            private AsyncOperationHandle<T> asyncOperationHandle;
            private IProgress<float> progress;
            private CancellationToken cancellationToken;
            private Action continuationAction;
            private T result;
            private AwaiterStatus status;

            AwaiterStatus IAwaiter.Status => status;
            bool IAwaiter.IsCompleted => status.IsCompleted();
            void IAwaiter.GetResult() => ((IAwaiter<T>) this).GetResult();

            public AsyncOperationHandleConfiguredAwaiter(AsyncOperationHandle<T> asyncOperationHandle, IProgress<float> progress, CancellationToken cancellationToken)
            {
                status = cancellationToken.IsCancellationRequested ? AwaiterStatus.Canceled
                    : asyncOperationHandle.IsDone ? AwaiterStatus.Succeeded
                    : AwaiterStatus.Pending;

                if (status.IsCompletedSuccessfully())
                {
                    result = asyncOperationHandle.Result;
                }

                if (status.IsCompleted())
                {
                    return;
                }

                this.asyncOperationHandle = asyncOperationHandle;
                this.progress = progress;
                this.cancellationToken = cancellationToken;
                continuationAction = null;
                result = default;

                TaskTracker.TrackActiveTask(this, 2);
            }

            T IAwaiter<T>.GetResult()
            {
                if (status == AwaiterStatus.Succeeded)
                {
                    return result;
                }

                if (status == AwaiterStatus.Canceled)
                {
                    Error.ThrowOperationCanceledException();
                }

                return Error.ThrowNotYetCompleted<T>();
            }

            bool IPlayerLoopItem.MoveNext()
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

            void INotifyCompletion.OnCompleted(Action continuation)
            {
                Error.ThrowWhenContinuationIsAlreadyRegistered(this.continuationAction);
                continuationAction = continuation;
            }

            void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation)
            {
                Error.ThrowWhenContinuationIsAlreadyRegistered(this.continuationAction);
                continuationAction = continuation;
            }

            private void InvokeContinuation(AwaiterStatus awaiterStatus)
            {
                status = awaiterStatus;
                var continuation = continuationAction;

                // cleanup
                TaskTracker.RemoveTracking(this);
                continuationAction = null;
                cancellationToken = CancellationToken.None;
                progress = null;
                asyncOperationHandle = default;

                continuation?.Invoke();
            }
        }
    }
}