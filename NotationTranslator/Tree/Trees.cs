using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotationTranslator.Models;

namespace NotationTranslator.Tree
{
    //A class for parsing the expression into a tree instaed of using a stack
    public class Trees
    {
        public Node BuildTreeFromPostfix(string expression)
        {
            Stack<Node> stack = new Stack<Node>();

            foreach (char c in expression)
            {
                if (char.IsLetterOrDigit(c)) // Operand
                {
                    stack.Push(new Node(c));
                }
                else // Operator
                {
                    Node right = stack.Pop();
                    Node left = stack.Pop();
                    Node newNode = new Node(c)
                    {
                        Left = left,
                        Right = right
                    };
                    stack.Push(newNode);
                }
            }

            return stack.Pop(); // Root of the tree
        }


        public Node BuildTreeFromPrefix(string expression)
        {
            Stack<Node> stack = new Stack<Node>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                char c = expression[i];

                if (char.IsLetterOrDigit(c)) // Operand
                {
                    stack.Push(new Node(c));
                }
                else // Operator
                {
                    Node left = stack.Pop();
                    Node right = stack.Pop();
                    Node newNode = new Node(c)
                    {
                        Left = left,
                        Right = right
                    };
                    stack.Push(newNode);
                }
            }

            return stack.Pop(); // Root of the tree
        }


        public Node BuildTreeFromInfix(string expression)
        {
            Stack<Node> operands = new Stack<Node>();
            Stack<char> operators = new Stack<char>();

            foreach (char c in expression)
            {
                if (c == ' ')
                    continue;

                if (c == '(')
                {
                    operators.Push(c);
                }
                else if (char.IsLetterOrDigit(c))
                {
                    operands.Push(new Node(c));
                }
                else if (c == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        ProcessOperator(operators, operands);
                    }
                    operators.Pop(); // Pop '('
                }
                else // Operator (+, -, *, /)
                {
                    while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(c))
                    {
                        ProcessOperator(operators, operands);
                    }
                    operators.Push(c);
                }
            }

            while (operators.Count > 0)
            {
                ProcessOperator(operators, operands);
            }

            return operands.Pop(); // Root
        }

        private void ProcessOperator(Stack<char> operators, Stack<Node> operands)
        {
            char op = operators.Pop();
            Node right = operands.Pop();
            Node left = operands.Pop();
            Node newNode = new Node(op)
            {
                Left = left,
                Right = right
            };
            operands.Push(newNode);
        }

        private int Precedence(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
        }


        public void Inorder(Node? node)
        {
            if (node == null)
                return;

            bool isOperator = !char.IsLetterOrDigit(node.Data);

            if (isOperator) Console.Write("("); // Optional: add '(' before left subtree

            Inorder(node.Left);
            Console.Write(node.Data);
            Inorder(node.Right);

            if (isOperator) Console.Write(")"); // Optional: add ')' after right subtree
        }

        public void Preorder(Node? node)
        {
            if (node == null)
                return;

            Console.Write(node.Data);
            Preorder(node.Left);
            Preorder(node.Right);
        }

        public void Postorder(Node? node)
        {
            if (node == null)
                return;

            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Data);
        }


    }
}
