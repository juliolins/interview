using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheTradeDesk.Caching;

namespace Cache.Test
{
    [TestFixture]
    public class SetAssociativeUT
    {
        [Test]
        public void HoldsCapacity()
        {
            var cache = CacheBuilder.SetAssociative_LRU<int, int>(3, 3);

            //add 1 to 9
            for (int i = 1; i <= 9; i++)
            {
                cache.Add(i, i);
            }

            //verify all keys are there
            for (int i = 1; i <= 9; i++)
            {
                Assert.IsTrue(cache.ContainsKey(i));
            }
        }

        [Test]
        public void EvenDistributionLRU()
        {
            var cache = CacheBuilder.SetAssociative_LRU<int, int>(3, 3);

            //add 1 to 12
            for (int i = 1; i <= 12; i++)
            {
                cache.Add(i, i);
            }

            //verify keys 1 to 3 are gone
            for (int i = 1; i <= 3; i++)
            {
                Assert.False(cache.ContainsKey(i));
            }
        }

        [Test]
        public void EvenDistributionMRU()
        {
            var cache = CacheBuilder.SetAssociative_MRU<int, int>(3, 3);

            //add 1 to 12
            for (int i = 1; i <= 12; i++)
            {
                cache.Add(i, i);
            }

            //verify keys 7 to 9 are gone
            for (int i = 7; i <= 9; i++)
            {
                Assert.False(cache.ContainsKey(i));
            }
        }
    }
}
