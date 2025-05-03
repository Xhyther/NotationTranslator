namespace NotationTranslator.Models
{
    // This class represents a node in a binary tree.
    // A binary tree is a data structure where each node has at most two children.
    public class Node
    {
        public string Data { get; set; }    // The data stored in the node
        public Node? Left { get; set; }     // The left child of the node
        public Node? Right { get; set; }    // The right child of the node


        public Node()                       //Default Constructor
        {
            Left = null;
            Right = null;
        }

        public Node(string data)            //Constructor with data
        {
            Data = data;
            Left = null;
            Right = null;
        }


    }
}
