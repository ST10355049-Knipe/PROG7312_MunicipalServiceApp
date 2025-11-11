using System.Collections.Generic;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // This is my main Graph class.
    // It uses a dictionary-like structure (my CustomHashTable) to store
    // all the nodes for quick lookups.
    public class CustomGraph<T>
    {
        // I'm using my CustomHashTable to store nodes.
        // The key will be the node's data (like the string "Submitted")
        // and the value will be the GraphNode object itself.
        private readonly CustomHashTable<T, GraphNode<T>> nodes;

        public CustomGraph()
        {
            nodes = new CustomHashTable<T, GraphNode<T>>();
        }

        // Adds a new node to the graph if it doesn't already exist.
        public GraphNode<T> AddNode(T data)
        {
            GraphNode<T> node;

            // Check if this node already exists in our hash table.
            if (!nodes.TryGetValue(data, out node))
            {
                // If not, create a new one and add it.
                node = new GraphNode<T>(data);
                nodes.Add(data, node);
            }
            return node;
        }

        // Creates a directed one-way connection from one node to another.
        public void AddEdge(T fromData, T toData)
        {
            // Get both nodes, creating them if they don't exist yet.
            var fromNode = AddNode(fromData);
            var toNode = AddNode(toData);

            // Add the 'to' node to the 'from' node's neighbor list.
            fromNode.AddNeighbor(toNode);
        }
    }
}