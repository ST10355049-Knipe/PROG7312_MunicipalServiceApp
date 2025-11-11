using System.Collections.Generic;

namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // This class represents a single node in my graph.
    // It will hold a piece of data (like a status string, e.g. "Submitted")
    // and a list of all its neighbors.
    public class GraphNode<T>
    {
        public T Data { get; set; }

        // This list holds all the other nodes that this node has an edge to.
        public CustomLinkedList<GraphNode<T>> Neighbors { get; private set; }

        public GraphNode(T data)
        {
            Data = data;
            Neighbors = new CustomLinkedList<GraphNode<T>>();
        }

        // A simple helper method to add a connection to another node.
        public void AddNeighbor(GraphNode<T> node)
        {
            Neighbors.Add(node);
        }
    }
}
