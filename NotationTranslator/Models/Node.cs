namespace NotationTranslator.Models
{
    public class Node
    {
        public string Data { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }


        public Node()
        {
            Left = null;
            Right = null;
        }

        public Node(string data)
        {
            Data = data;
            Left = null;
            Right = null;
        }


    }
}
