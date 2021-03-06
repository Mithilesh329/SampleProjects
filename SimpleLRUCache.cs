using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Design and implement a data structure for Least Recently Used(LRU) cache.
// It should support the following operations: get and set.
// get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
// set(key, value) - Set or insert the value if the key is not already present.
// When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

namespace SampleProjects
{
    public class LRUCache
    {
        public class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public int Key { get; set; }
            public int Value { get; set; }
        }
        
        private Dictionary<int, Node> map = new Dictionary<int, Node>();
        private Node head;
        private Node tail;
        private int cap;

        public LRUCache(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(
                    "capacity",
                    "Capacity should be greater than zero");
            cap = capacity;
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key))
            {
                return -1;
            }

            Node entry = map[key];
            MoveToHead(entry);
            return entry.Value;
        }

        public void Set(int key, int value)
        {
            Node entry;
            if (!map.ContainsKey(key))
            {
                entry = new Node();
                entry.Key = key;
                entry.Value = value;
                map[key] = entry;

                if (map.Count == cap)
                {
                    map.Remove(tail.Key);
                    tail = tail.Previous;
                    if (tail != null) tail.Next = null;
                }
            }
            else
            {
                entry = map[key];
            }

            MoveToHead(entry);
            if (tail == null)
            {
                tail = head;
            }
        }

        private void MoveToHead(Node entry)
        {
            // Corner case when entry is head or null
            if (entry == head || entry == null)
            {
                return;
            }

            Node previous = entry.Previous;
            Node next = entry.Next;

            // Delete the entry if present
            if (previous != null)
            {
                previous.Next = next;
            }

            if (next != null)
            {
                next.Previous = previous;
            }

            // Insert the entry at start
            entry.Next = head;
            entry.Previous = null;

            if (head != null)
            {
                head.Previous = entry;
            }

            // New head
            head = entry;

            // Corner case when entry is tail
            if (entry == tail)
            {
                tail = tail.Previous;
            }
        }
    }
}
