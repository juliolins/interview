using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheTradeDesk.Caching;

namespace Cache.Test
{
    [TestFixture]
    public class CacheUT
    {
        [TestCase(CacheType.LRU_Non_ThreadSafe)]
        [TestCase(CacheType.LRU_ThreadSafe)]
        [TestCase(CacheType.MRU_Non_ThreadSafe)]
        [TestCase(CacheType.MRU_ThreadSafe)]
        public void Basic(CacheType cacheType)
        {
            var cache = GetCache(cacheType, 3);

            cache[1] = 10;
            cache[2] = 20;
            cache[3] = 30;

            Assert.AreEqual(10, cache[1]);
            Assert.AreEqual(20, cache[2]);
            Assert.AreEqual(30, cache[3]);
        }

        [Test]
        public void ThrowsRightExceptions()
        {
            var cache = CacheBuilder.LRU_ThreadSafe<string, string>(3);

            Assert.Throws<ArgumentNullException>(() => { cache[null] = ""; });
            Assert.Throws<KeyNotFoundException>(() => { var no = cache["not present"]; });
        }

        [Test]
        public void LruOverCapacity()
        {
            var cache = CacheBuilder.LRU_ThreadSafe<int, int>(3);

            cache[1] = 10;
            cache[2] = 20;
            cache[3] = 30;

            Assert.IsTrue(cache.ContainsKey(1));
            cache[4] = 40;
            Assert.IsFalse(cache.ContainsKey(1));
        }

        [Test]
        public void MruOverCapacity()
        {
            var cache = CacheBuilder.MRU_ThreadSafe<int, int>(3);

            cache[1] = 10;
            cache[2] = 20;
            cache[3] = 30;

            Assert.IsTrue(cache.ContainsKey(3));
            cache[4] = 40;
            Assert.IsFalse(cache.ContainsKey(3));
        }

        [Test]
        public void LruRollingPuts()
        {
            const int capacity = 3;
            var cache = CacheBuilder.LRU_ThreadSafe<int, int>(capacity);

            cache[1] = 10;
            cache[2] = 20;
            cache[3] = 30;

            for (int i = 4; i < 100; i++)
            {
                Assert.IsTrue(cache.ContainsKey(i - capacity));
                cache[i] = 10 * i;
                Assert.IsFalse(cache.ContainsKey(i - capacity));         
            }
        }

        [Test]
        public void MruRollingPuts()
        {
            const int capacity = 3;
            var cache = CacheBuilder.MRU_ThreadSafe<int, int>(capacity);

            cache[1] = 10;
            cache[2] = 20;
            cache[3] = 30;

            for (int i = 4; i < 100; i++)
            {
                Assert.IsTrue(cache.ContainsKey(i - 1));
                cache[i] = 10 * i;
                Assert.IsFalse(cache.ContainsKey(i - 1));
            }
        }

        private ICache<int, int> GetCache(CacheType cacheType, int capacity)
        {
            switch (cacheType)
            {
                case CacheType.LRU_ThreadSafe:
                    return CacheBuilder.LRU_ThreadSafe<int, int>(capacity);
                case CacheType.LRU_Non_ThreadSafe:
                    return CacheBuilder.LRU_NonThreadSafe<int, int>(capacity);
                case CacheType.MRU_ThreadSafe:
                    return CacheBuilder.MRU_ThreadSafe<int, int>(capacity);
                case CacheType.MRU_Non_ThreadSafe:
                    return CacheBuilder.MRU_NonThreadSafe<int, int>(capacity);
                default:
                    throw new NotSupportedException(cacheType.ToString());
            }
        }

        public enum CacheType
        {
            LRU_ThreadSafe,
            LRU_Non_ThreadSafe,
            MRU_ThreadSafe,
            MRU_Non_ThreadSafe
        }
    }
}
