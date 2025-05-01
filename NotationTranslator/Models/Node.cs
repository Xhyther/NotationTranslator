namespace NotationTranslator.Models
{
    public class Node
    {
        public char Data { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }


        public Node()
        {
            Left = null;
            Right = null;
        }

        public Node(char data)
        {
            Data = data;
            Left = null;
            Right = null;
        }


    }
}
