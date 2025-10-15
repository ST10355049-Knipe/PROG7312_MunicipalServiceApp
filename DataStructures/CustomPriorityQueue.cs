using System;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // Defines a contract for objects that can be used in the priority queue.
    // This ensures any object stored has a 'Priority' property.
    public interface IPrioritizable
    {
        int Priority { get; }
    }

    // A generic priority queue, constrained to types that implement IPrioritizable.
    // Lower priority numbers are considered higher priority.
    public class CustomPriorityQueue<T> where T : IPrioritizable
    {
        private readonly CustomLinkedList<T> items;

        public CustomPriorityQueue()
        {
            items = new CustomLinkedList<T>();
        }

        // Inserts an item into the queue, maintaining sorted order by priority.
        public void Enqueue(T item)
        {
            // Handle case for an empty queue.
            if (items.head == null)
            {
                items.AddFirst(item);
                return;
            }

            // Handle case where the new item has the highest priority (lowest value).
            if (item.Priority < items.head.Data.Priority)
            {
                items.AddFirst(item);
                return;
            }

            // Find the correct insertion point in the list.
            var current = items.head;
            while (current.Next != null && current.Next.Data.Priority <= item.Priority)
            {
                current = current.Next;
            }

            // Insert the new item after the found node.
            items.InsertAfter(current, item);
        }

        // This method gets the top N highest-priority items without removing them.
        public List<T> PeekTop(int count)
        {
            var topItems = new List<T>();
            var current = items.head;
            int i = 0;
            while (current != null && i < count)
            {
                topItems.Add(current.Data);
                current = current.Next;
                i++;
            }
            return topItems;
        }
    }
}