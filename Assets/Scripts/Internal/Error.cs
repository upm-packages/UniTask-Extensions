using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace UniRx.Async.Internal
{
    /// <summary>
    /// Copy from UniRx.Async.Internal.Error
    /// https://github.com/Cysharp/UniTask/blob/master/Assets/UniRx.Async/Internal/Error.cs
    /// </summary>
    [PublicAPI]
    internal static class Error
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowArgumentNullException<T>(T value, string paramName)
            where T : class
        {
            if (value == null) ThrowArgumentNullExceptionCore(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowArgumentDefaultException<T>(T value, string paramName)
            where T : struct
        {
            if (Equals(value, default)) ThrowArgumentNullExceptionCore(paramName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void ThrowArgumentNullExceptionCore(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowArgumentException<T>(string message)
        {
            throw new ArgumentException(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowNotYetCompleted()
        {
            throw new InvalidOperationException("Not yet completed.");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T ThrowNotYetCompleted<T>()
        {
            throw new InvalidOperationException("Not yet completed.");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowWhenContinuationIsAlreadyRegistered<T>(T continuationField)
            where T : class
        {
            if (continuationField != null) ThrowInvalidOperationExceptionCore("continuation is already registered.");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void ThrowInvalidOperationExceptionCore(string message)
        {
            throw new InvalidOperationException(message);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowOperationCanceledException()
        {
            throw new OperationCanceledException();
        }
    }
}