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

    public class CustomLinkedList<T>
    {
        public Node<T> head;

        // This method adds a new item to the end of the list.
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        // This method goes through the list to check if a specific item already exists.
        public bool Contains(T item)
        {
            Node<T> current = head;
            while (current != null)
            {
                // Use .Equals() to correctly compare the data.
                if (current.Data.Equals(item))
                {
                    return true; // We found the item.
                }
                current = current.Next;
            }
            return false; // We reached the end of the list without finding it.
        }

        // This method adds a new item to the very beginning of the list.
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = head;
            head = newNode;
        }

        // This method inserts a new item after a specific node in the list.
        public void InsertAfter(Node<T> previousNode, T data)
        {
            if (previousNode == null)
            {
                // Cannot insert after a non-existent node.
                return;
            }
            Node<T> newNode = new Node<T>(data);
            newNode.Next = previousNode.Next;
            previousNode.Next = newNode;
        }

        public List<T> GetAllNodesAsList()
        {
            var list = new List<T>();
            var current = head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }
    }
}