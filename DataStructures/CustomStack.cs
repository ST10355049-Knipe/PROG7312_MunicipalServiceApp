namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // A standard LIFO (Last-In, First-Out) stack.
    // I'm using my CustomLinkedList internally to store the items.
    public class CustomStack<T>
    {
        private readonly CustomLinkedList<T> items;

        public CustomStack()
        {
            items = new CustomLinkedList<T>();
        }

        // Pushes a new item onto the top of the stack.
        public void Push(T item)
        {
            // Adding to the front of the linked list makes it behave like a stack.
            items.AddFirst(item);
        }

        // Peeks at the item on top of the stack without removing it.
        public T Peek()
        {
            if (items.head == null)
            {
                return default(T); // Stack is empty.
            }
            return items.head.Data;
        }

        public bool IsEmpty()
        {
            return items.head == null;
        }
    }
}