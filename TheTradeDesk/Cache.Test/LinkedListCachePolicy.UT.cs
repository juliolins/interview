using NUnit.Framework;
using TheTradeDesk.Caching;
using TheTradeDesk.Caching.Policy;

namespace Cache.Test
{
    [TestFixture]
    public class LinkedListCachePolicyUT
    {
        /// <summary>
        /// Sanity test.
        /// </summary>
        [TestCase(true)]
        [TestCase(false)]
        public void LruPurgesLeastRecent(bool isLocked)
        {
            var lru = CacheBuilder.LRU_Policy<int, int>(GetLock(isLocked));

            lru.NewEntry(1, 10);
            lru.NewEntry(2, 20);
            lru.NewEntry(3, 30);

            AssertPurged(lru, 1);
        }

        /// <summary>
        /// Sanity test.
        /// </summary>
        [TestCase(true)]
        [TestCase(false)]
        public void MruPurgesMostRecent(bool isLocked)
        {
            var mru = CacheBuilder.MRU_Policy<int, int>(GetLock(isLocked));

            mru.NewEntry(1, 10);
            mru.NewEntry(2, 20);
            mru.NewEntry(3, 30);

            AssertPurged(mru, 3);
        }

        [Test]
        public void HitUpdatesPosition()
        {
            var lru = CacheBuilder.LRU_Policy<int, int>(new NoOpLock());

            var entry1 = lru.NewEntry(1, 10);
            lru.NewEntry(2, 20);
            lru.NewEntry(3, 30);

            //access 1
            lru.Hit(entry1);

            AssertPurged(lru, 2); //oldest now is 2, since 3 was added last and 1 was hit
        }

        [Test]
        public void SupportsConsecutiveHits()
        {
            var lru = CacheBuilder.LRU_Policy<int, int>(new NoOpLock());

            var entry1 = lru.NewEntry(1, 10);
            var entry2 = lru.NewEntry(2, 20);
            var entry3 = lru.NewEntry(3, 30);

            lru.Hit(entry1);
            lru.Hit(entry1);
            lru.Hit(entry3);
            lru.Hit(entry2);
            lru.Hit(entry1);
            lru.Hit(entry3);

            AssertPurged(lru, 2);
            AssertPurged(lru, 1);
            AssertPurged(lru, 3);
        }

        [Test]
        public void PurgeReturnsFalseWhenEmpty()
        {
            var lru = CacheBuilder.LRU_Policy<int, int>(new NoOpLock());

            int purgedKey = 0;
            Assert.IsFalse(lru.Purge(out purgedKey));
        }

        private void AssertPurged<TKey, TValue>(ICachePolicy<TKey, TValue> policy, TKey expectedKey)
        {
            TKey purgedKey = default(TKey);
            Assert.IsTrue(policy.Purge(out purgedKey));
            Assert.AreEqual(expectedKey, purgedKey);
        }

        private ICacheLock GetLock(bool isLocked)
        {
            if (isLocked)
            {
                return new SemaphoreWriteLock();
            }
            else
            {
                return new NoOpLock();
            }
        }
    }
}
