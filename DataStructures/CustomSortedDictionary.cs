using System;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // A generic sorted dictionary where keys must be comparable (e.g., DateTime, int).
    // It maintains a list of key-value pairs sorted by the key.
    public class CustomSortedDictionary<TKey, TValue> where TKey : IComparable<TKey>
    {
        private readonly CustomLinkedList<KeyValuePair<TKey, TValue>> items;

        public CustomSortedDictionary()
        {
            items = new CustomLinkedList<KeyValuePair<TKey, TValue>>();
        }

        // Adds a key-value pair, inserting it in the correct position to maintain sort order.
        public void Add(TKey key, TValue value)
        {
            var newItem = new KeyValuePair<TKey, TValue>(key, value);

            // Handle case for an empty list.
            if (items.head == null)
            {
                items.AddFirst(newItem);
                return;
            }

            // Handle case where the new key is smaller than the heads key, making it the new head.
            if (key.CompareTo(items.head.Data.Key) < 0)
            {
                items.AddFirst(newItem);
                return;
            }

            // Find the correct node to insert the new item after.
            var current = items.head;
            while (current.Next != null && current.Next.Data.Key.CompareTo(key) < 0)
            {
                current = current.Next;
            }

            items.InsertAfter(current, newItem);
        }

        // Returns all the values in the dictionary as a standard List.
        public List<TValue> GetAllValues()
        {
            var list = new List<TValue>();
            var current = items.head;
            while (current != null)
            {
                list.Add(current.Data.Value);
                current = current.Next;
            }
            return list;
        }

        // Returns the total number of items in the dictionary.
        public int Count()
        {
            int count = 0;
            var current = items.head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}