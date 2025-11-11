using PROG7312_MunicipalServiceApp.Models;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // My custom Binary Search Tree.
    // The 'where T : IIdentifiable' part is a constraint that forces
    // any object 'T' stored in this tree to have an 'Id' property.
    public class CustomBinarySearchTree<T> where T : IIdentifiable
    {
        private BSTNode<T> root;

        public CustomBinarySearchTree()
        {
            root = null;
        }

        // Add Method
        // Starting point for adding new data.
        public void Add(T data)
        {
            // It calls the private, recursive Add method to do the real work.
            root = Add(root, data);
        }

        // This method finds the correct spot in the tree to insert the new node.
        private BSTNode<T> Add(BSTNode<T> node, T data)
        {
            // Base case: If the current node is null, we've found our spot.
            if (node == null)
            {
                node = new BSTNode<T>(data);
                return node;
            }
            // Compares new data's ID with current node's ID.
            if (data.Id < node.Data.Id)
            {
                // If the new ID is smaller, go down the left path.
                node.Left = Add(node.Left, data);
            }
            else if (data.Id > node.Data.Id)
            {
                // If the new ID is larger, go down the right path.
                node.Right = Add(node.Right, data);
            }

            return node;
        }

        // This lets other parts of the app find a request by its ID.
        public T Find(int id)
        {
            BSTNode<T> resultNode = Find(root, id);
            if (resultNode == null)
            {
                return default(T); // Not found
            }
            return resultNode.Data; // Found, return the data.
        }

        // This method efficiently searches the tree for a specific ID.
        private BSTNode<T> Find(BSTNode<T> node, int id)
        {
            // Base case 1: The node is null, so the ID isn't in this branch.
            if (node == null)
            {
                return null;
            }

            // Base case 2: We found the node with the matching ID.
            if (node.Data.Id == id)
            {
                return node;
            }
            // Decide to go left or right
            if (id < node.Data.Id)
            {
                // The ID we're looking for is smaller, so go left.
                return Find(node.Left, id);
            }
            else
            {
                // The ID we're looking for is larger, so go right.
                return Find(node.Right, id);
            }
        }

        // Public method that starts the traversal.
        public List<T> GetAllRequests()
        {
            var requestList = new List<T>();
            InOrderTraversal(root, requestList);
            return requestList;
        }

        // It visits the left child, then the node itself, then the right child.
        private void InOrderTraversal(BSTNode<T> node, List<T> requestList)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, requestList);
                requestList.Add(node.Data);
                InOrderTraversal(node.Right, requestList);
            }
        }

    }
}
