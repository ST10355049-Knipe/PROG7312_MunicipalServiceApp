using System;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    public class CustomSortedDictionary<TKey, TValue> where TKey : IComparable<TKey>
    {
        private readonly CustomLinkedList<KeyValuePair<TKey, TValue>> items;

        public CustomSortedDictionary()
        {
            items = new CustomLinkedList<KeyValuePair<TKey, TValue>>();
        }

        // This method finds the correct place in the list to put the new item to keep everything sorted.
        public void Add(TKey key, TValue value)
        {
            var newItem = new KeyValuePair<TKey, TValue>(key, value);

            // Case 1: The list is empty, so this new item is the first one.
            if (items.head == null)
            {
                items.AddFirst(newItem);
                return;
            }

            // Case 2: The new item's key is smaller than the first item's key,
            // so it should become the new head of the list.
            if (key.CompareTo(items.head.Data.Key) < 0)
            {
                items.AddFirst(newItem);
                return;
            }

            // Case 3: We need to find the correct spot to insert the new item.
            // We look for the first node that is 'bigger' than our new item.
            var current = items.head;
            while (current.Next != null && current.Next.Data.Key.CompareTo(key) < 0)
            {
                current = current.Next;
            }

            // Once we find the right spot, we insert our new item after the 'current' node.
            items.InsertAfter(current, newItem);
        }

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
