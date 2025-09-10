namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // This is the basic building block for my linked list. 
    // It holds the actual data (T) and a reference to the next node in the chain.
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            this.Data = data;
            this.Next = null; // When a new node is created, it doesn't point to anything yet.
        }
    }

    // My own implementation of a singly linked list.
    public class CustomLinkedList<T>
    {
        // This is the entry point, the first node in the list.
        private Node<T> head;

        // My implementation of the Add method.
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            // If the list is empty, the new node just becomes the head.
            if (head == null)
            {
                head = newNode;
                return;
            }

            // If the list isn't empty, I have to find the last node.
            // This is O(n) because I have to walk the whole list. Could be O(1) if I also kept track of the tail.
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            // Once at the end, I'll link the new node.
            current.Next = newNode; 
        }
    }
}


