using System;
using System.Collections.Generic;

namespace PROG7312_MunicipalServiceApp.DataStructures
{

    public class CustomHashTable<TKey, TValue>
    {
        // The size of the internal array. A prime number is often good for distribution.
        private const int InitialCapacity = 17;
        private readonly CustomLinkedList<KeyValuePair<TKey, TValue>>[] buckets;

        public CustomHashTable()
        {
            buckets = new CustomLinkedList<KeyValuePair<TKey, TValue>>[InitialCapacity];
        }

        // A simple hash function to map a key to an index in our array.
        private int GetBucketIndex(TKey key)
        {
            // We use absolute value to ensure the index is never negative.
            int hashCode = key.GetHashCode();
            int index = Math.Abs(hashCode) % buckets.Length;
            return index;
        }

        // Adds a key-value pair to the hash table.
        public void Add(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);

            // If this bucket is empty, initialize a new linked list for it.
            if (buckets[index] == null)
            {
                buckets[index] = new CustomLinkedList<KeyValuePair<TKey, TValue>>();
            }

            buckets[index].Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        // Tries to find a value associated with the given key.
        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];

            if (bucket != null)
            {
                var current = bucket.head;
                while (current != null)
                {
                    if (current.Data.Key.Equals(key))
                    {
                        value = current.Data.Value;
                        return true; // Found it!
                    }
                    current = current.Next;
                }
            }

            value = default(TValue);
            return false; // Not found.
        }
    }
}
