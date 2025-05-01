using NotationTranslator.Models;
using NotationTranslator.Enums;
using NotationTranslator.Services;

namespace NotationTranslator.Tree
{
    public class Trees
    {
        public Node BuildTreeFromPostfix(List<Tokens> expression)
        {
            Stack<Node> stack = new Stack<Node>();

            foreach (var token in expression)
            {
                if (Translator.IsOperand(token))
                {
                    stack.Push(new Node(token.Value));
                }
                else if (Translator.IsOperator(token))
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    Node newNode = new Node(token.Value)
                    {
                        Left = left,
                        Right = right
                    };
                    stack.Push(newNode);
                }
            }

            return stack.Pop();
        }

        public Node BuildTreeFromPrefix(List<Tokens> expression)
        {
            Stack<Node> stack = new Stack<Node>();

            for (int i = expression.Count - 1; i >= 0; i--)
            {
                var token = expression[i];

                if (Translator.IsOperand(token))
                {
                    stack.Push(new Node(token.Value));
                }
                else if (Translator.IsOperator(token))
                {
                    var left = stack.Pop();
                    var right = stack.Pop();
                    Node newNode = new Node(token.Value)
                    {
                        Left = left,
                        Right = right
                    };
                    stack.Push(newNode);
                }
            }

            return stack.Pop();
        }

        public Node BuildTreeFromInfix(List<Tokens> expression)
        {
            Stack<Node> operands = new Stack<Node>();
            Stack<Tokens> operators = new Stack<Tokens>();

            foreach (var token in expression)
            {
                if (token.Type == TokenType.LeftParen)
                {
                    operators.Push(token);
                }
                else if (Translator.IsOperand(token))
                {
                    operands.Push(new Node(token.Value));
                }
                else if (token.Type == TokenType.RightParen)
                {
                    while (operators.Peek().Type != TokenType.LeftParen)
                    {
                        ProcessOperator(operators, operands);
                    }
                    operators.Pop();
                }
                else if (Translator.IsOperator(token))
                {
                    while (operators.Count > 0 &&
                           Translator.IsOperator(operators.Peek()) &&
                           Translator.Precedence(operators.Peek()) >= Translator.Precedence(token))
                    {
                        ProcessOperator(operators, operands);
                    }
                    operators.Push(token);
                }
            }

            while (operators.Count > 0)
            {
                ProcessOperator(operators, operands);
            }

            return operands.Pop();
        }

        private void ProcessOperator(Stack<Tokens> operators, Stack<Node> operands)
        {
            var op = operators.Pop();
            var right = operands.Pop();
            var left = operands.Pop();
            Node newNode = new Node(op.Value)
            {
                Left = left,
                Right = right
            };
            operands.Push(newNode);
        }

        // Traversals
        public void Inorder(Node? node)
        {
            if (node == null) return;

            bool isOperator = !char.IsLetterOrDigit(node.Data[0]);

            if (isOperator) Console.Write("(");
            Inorder(node.Left);
            Console.Write(node.Data);
            Inorder(node.Right);
            if (isOperator) Console.Write(")");
        }

        public void Preorder(Node? node)
        {
            if (node == null) return;
            Console.Write(node.Data);
            Preorder(node.Left);
            Preorder(node.Right);
        }

        public void Postorder(Node? node)
        {
            if (node == null) return;
            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Data);
        }
    }
}
