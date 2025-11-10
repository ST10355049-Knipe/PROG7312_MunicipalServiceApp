using PROG7312_MunicipalServiceApp.Models;
using System.Collections.Generic;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // This is my custom Min-Heap.
    // It's constrained to only accept items that have an 'Urgency' property.
    // It uses a List to store the items in a way that mimics a tree structure.
    public class CustomBinaryHeap<T> where T : IPrioritizableByUrgency
    {
        private readonly List<T> items;

        public CustomBinaryHeap()
        {
            items = new List<T>();
        }

        // These methods find the "family members" of a node in our list.
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;

        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

        private bool HasParent(int index) => GetParentIndex(index) >= 0;

        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < items.Count;

        // Swaps two items in the list.
        private void Swap(int indexOne, int indexTwo)
        {
            (items[indexOne], items[indexTwo]) = (items[indexTwo], items[indexOne]);
        }

        // Adds a new item to the heap and puts it in the right place.
        public void Add(T item)
        {
            items.Add(item); // Add the item to the very end.
            HeapifyUp(); // "Bubble" the new item up to its correct spot.
        }

        // This method moves the last item up the tree until it's in the right spot.
        private void HeapifyUp()
        {
            int index = items.Count - 1; // Start with the last item.

            // Keep going as long as it has a parent and its urgency is
            // lower than its parent's (meaning it's higher priority).
            while (HasParent(index) && items[index].Urgency < items[GetParentIndex(index)].Urgency)
            {
                int parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex; // Move up to the parent's position.
            }
        }

        // This lets us see the top-priority item without removing it.
        public T Peek()
        {
            if (items.Count == 0)
            {
                return default(T); // The heap is empty.
            }
            return items[0]; // The root is always the min-urgency item.
        }
    }
}