using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheTradeDesk.Caching.Policy;

namespace TheTradeDesk.Caching
{
    /// <summary>
    /// Keeps cache entries sorted by last hit in constant time by moving the latest entry 
    /// to the head of the list. Cache policy strategies should choose where to remove
    /// from the list. 
    /// 
    /// For example:
    /// Least Recently Used (LRU): remove from tail.
    /// Most Recently Used (MRU): remove from head.
    /// </summary>
    /// 
    /// <remarks>
    ///     This policy can be either thread-safe or not depending on the ICacheLock implementation.
    /// </remarks>
    public class LinkedListCachePolicy<TKey, TValue> : ICachePolicy<TKey, TValue>
    {
        private readonly LinkedList<TKey> list;
        private readonly ICacheLock listLock;
        private readonly Func<LinkedList<TKey>, LinkedListNode<TKey>> chooseFunction;

        public LinkedListCachePolicy(ICacheLock listLock, Func<LinkedList<TKey>, LinkedListNode<TKey>> chooseFunction)
        {
            this.list = new LinkedList<TKey>();
            this.listLock = listLock;
            this.chooseFunction = chooseFunction;
        }

        /// <summary>
        /// Creates a new entry and adds it to the head of the list.
        /// </summary>
        public ICacheEntry<TKey, TValue> NewEntry(TKey key, TValue value)
        {
            var node = new LinkedListNode<TKey>(key);
            var entry = new NodeCacheEntry<TKey, TValue>() { Key = key, Value = value, Node = node };

            listLock.Wait();
            try
            {
                list.AddFirst(node);
            }
            finally
            {
                listLock.Release();
            }

            return entry;
        }

        /// <summary>
        /// Moves the latest hit entry to the head of the list.
        /// </summary>
        public void Hit(ICacheEntry<TKey, TValue> entry)
        {
            //an InvalidCastException is an acceptable behavior here for programmatic errors
            var nodeEntry = (NodeCacheEntry<TKey, TValue>) entry;

            listLock.Wait();
            try
            {
                //move node from its current position to head in constant time
                list.Remove(nodeEntry.Node);
                list.AddFirst(nodeEntry.Node);
            }
            finally
            {
                listLock.Release();
            }
        }

        /// <summary>
        /// Removes an entry if available.
        /// </summary>
        public bool Purge(out TKey key)
        {
            listLock.Wait();
            try
            {
                //only try to purge if there's an available entry
                if (list.Count > 0)
                {
                    //let the function choose which node to remove
                    var node = chooseFunction(list);
                    list.Remove(node);
                    key = node.Value;
                    return true;
                }
                else
                {
                    key = default(TKey);
                    return false;
                }
            }
            finally
            {
                listLock.Release();
            }            
        }

        /// <summary>
        /// Implementation of ICacheEntry which allows for the entry to
        /// point directly to a node in a doubly liked-list, allowing for
        /// a constant time access to the key being hit.
        /// </summary>
        class NodeCacheEntry<UKey, UValue> : ICacheEntry<UKey, UValue>
        {
            public UKey Key { get; set; }
            public UValue Value { get; set; }
            public LinkedListNode<UKey> Node { get; set; }
        }
    }
}
