using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
    public class SortedListCachePolicy<TKey, TValue> : ICachePolicy<TKey, TValue>
    {
        private readonly LinkedList<TKey> list;
        private readonly Func<LinkedList<TKey>, LinkedListNode<TKey>> chooseFunction;

        public SortedListCachePolicy(Func<LinkedList<TKey>, LinkedListNode<TKey>> chooseFunction)
        {
            this.list = new LinkedList<TKey>();
            this.chooseFunction = chooseFunction;
        }

        /// <summary>
        /// Creates a new entry and adds it to the head of the list.
        /// </summary>
        public ICacheEntry<TKey, TValue> NewEntry(TKey key, TValue value)
        {
            var node = new LinkedListNode<TKey>(key);
            var entry = new NodeCacheEntry<TKey, TValue>() { Key = key, Value = value, Node = node };

            list.AddFirst(node);
            return entry;
        }

        /// <summary>
        /// Moves the latest hit entry to the head of the list.
        /// </summary>
        public void Hit(ICacheEntry<TKey, TValue> entry)
        {
            //an InvalidCastException is an acceptable behavior here for programmatic errors
            var nodeEntry = (NodeCacheEntry<TKey, TValue>) entry;

            //move node from its current position to head in constant time
            list.Remove(nodeEntry.Node);
            list.AddFirst(nodeEntry.Node);
        }

        /// <summary>
        /// Removes an entry if available.
        /// </summary>
        public bool Purge(out TKey key)
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

        /// <summary>
        /// Deletes a specific node from the list.
        /// </summary>
        public void Delete(ICacheEntry<TKey, TValue> entry)
        {
            //an InvalidCastException is an acceptable behavior here for programmatic errors
            var nodeEntry = (NodeCacheEntry<TKey, TValue>) entry;

            list.Remove(nodeEntry.Node);
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
