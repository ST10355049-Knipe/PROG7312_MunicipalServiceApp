namespace PROG7312_MunicipalServiceApp.DataStructures
{

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }

    public class CustomLinkedList<T>
    {
        private Node<T> head; // Head of the list

        // Method to add a new node at the end of the list
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            // Method to add a new node at the end of the list
            if (head == null)
            {
                head = newNode;
                return;
            }

            // Otherwise, find the last node in the list
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode; // Link the new node at the end
        }
    }
}


