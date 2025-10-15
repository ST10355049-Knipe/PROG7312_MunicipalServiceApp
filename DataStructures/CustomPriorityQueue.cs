using System;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // My Event model needs a way to be compared, so I'm using this interface.
    // It tells the Priority Queue how to handle the Event objects.
    public interface IPrioritizable
    {
        int Priority { get; }
    }

    // I've made my Priority Queue generic, but it can only work with types
    // that have a 'Priority' property, which is enforced by the IPrioritizable constraint.
    public class CustomPriorityQueue<T> where T : IPrioritizable
    {
        private readonly CustomLinkedList<T> items;

        public CustomPriorityQueue()
        {
            items = new CustomLinkedList<T>();
        }

        // The Enqueue method adds an item to the queue based on its priority level.
        public void Enqueue(T item)
        {
            // Case 1: If the queue is empty, the new item becomes the first one.
            if (items.head == null)
            {
                items.AddFirst(item);
                return;
            }

            // Case 2: If the new item has a higher priority (a lower number)
            // than the head, it becomes the new head.
            if (item.Priority < items.head.Data.Priority)
            {
                items.AddFirst(item);
                return;
            }

            // Case 3: Find the correct spot to insert the new item.
            // I need to look for the first item in the list that has a
            // lower or equal priority than my new item.
            var current = items.head;
            while (current.Next != null && current.Next.Data.Priority <= item.Priority)
            {
                current = current.Next;
            }

            // Once I find the right spot, I insert the new item.
            items.InsertAfter(current, item);
        }
    }
}