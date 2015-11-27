using System;
using System.Threading;

namespace TheTradeDesk.Caching.Policy
{
    /// <summary>
    /// Defines a simple interface to control thread access to a resource.
    /// </summary>
    public interface ICacheLock : IDisposable
    {
        void Release();
        void Wait();
    }

    /// <summary>
    /// Provides a No-Op version ILock which doesn't control thread access.
    /// </summary>
    public class NoOpLock : ICacheLock
    {
        public void Release()
        {
        }

        public void Wait()
        {
        }

        public void Dispose()
        {
        }
    }

    /// <summary>
    /// Provides single thread access lock.
    /// </summary>
    public class SemaphoreWriteLock : ICacheLock
    {
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public void Release()
        {
            semaphore.Release();
        }

        public void Wait()
        {
            semaphore.Wait();
        }

        public void Dispose()
        {
            semaphore.Dispose();
        }
    }
}
