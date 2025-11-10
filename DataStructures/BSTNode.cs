namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // This is the basic node for my Binary Search Tree.
    // It needs to be generic (using <T>) to hold any type of data.
    public class BSTNode<T>
    {
        public T Data { get; set; }
        public BSTNode<T> Left { get; set; }
        public BSTNode<T> Right { get; set; }

        public BSTNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
