using NotationTranslator.Enums;
using NotationTranslator.Models;
using NotationTranslator.Tree;

namespace NotationTranslator.Services
{
    /// The Translator class is responsible for converting between different notations (infix, prefix, postfix).
    /// It uses a binary expression tree to parse the expression and transform it into the desired notation.
    /// Within this class, methods are provided to reverse braces, check operator precedence, and determine if a token is an operator or operand.
    public class Translator
    {
        Tokenizer Tokenizer = new Tokenizer(); 

        /// Reverse the braces in the expression
        public static List<Tokens> ReverseBraces(List<Tokens> expression)
        {
            for (int i = 0; i < expression.Count; i++)
            {
               expression[i] = expression[i].Type switch
               {
                   TokenType.LeftParen => new Tokens(TokenType.RightParen, ")"),
                   TokenType.RightParen => new Tokens(TokenType.LeftParen, "("),
                   _ => expression[i]
               };
            }

            return expression;
        }

        /// Reverse the order of the tokens in the expression
        public static List<Tokens> Reverse(List<Tokens> expression)
        {
            var myStack = new Stack<Tokens>(expression);
            var reversedExpression = new List<Tokens>(myStack.ToList());
            return reversedExpression;
        }

        /// Check if the token is an operator
        public static bool IsOperator(Tokens token)
        {
            return token.Type == TokenType.Plus ||
                   token.Type == TokenType.Minus ||
                   token.Type == TokenType.Multiply ||
                   token.Type == TokenType.Divide ||
                   token.Type == TokenType.Power;
        }
        /// Check if the token is an operand
        public static bool IsOperand(Tokens token)
        {
            return token.Type == TokenType.Number ||
                   token.Type == TokenType.Identifier;
        }

        //Check the Precedence of an operator
        public static int Precedence(Tokens token)
        {
            return token.Type switch
            {
                TokenType.Plus => 1,
                TokenType.Minus => 1,
                TokenType.Multiply => 2,
                TokenType.Divide => 2,
                TokenType.Power => 3,
                _ => 0
            };
        }

       



     private readonly Trees _tree = new Trees();


        /// Translate the expression from one notation to another
        public void Translate(string expression, Notation from, Notation to)
        {
            List<Tokens> tokens = Tokenizer.Tokenize(expression); // Your own method
            Console.WriteLine();
            Console.WriteLine($"From ({from}) translating [{expression}] to ({to}).");

            Node? root = from switch
            {
                Notation.infix => _tree.BuildTreeFromInfix(tokens),
                Notation.prefix => _tree.BuildTreeFromPrefix(tokens),
                Notation.postfix => _tree.BuildTreeFromPostfix(tokens),
                _ => throw new InvalidOperationException("Unsupported notation")
            };

            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (to)
            {
                case Notation.infix:
                    // Convert to infix
                    Console.Write("Coverted expression to Infix: ");
                    _tree.Inorder(root); // Will print the equivalent infix expression
                    Console.WriteLine();
                    break;
                case Notation.prefix:
                    // Convert to prefix
                    Console.Write("Coverted expression to Prefix: ");
                    _tree.Preorder(root);
                    Console.WriteLine();
                    break;
                case Notation.postfix:
                    // Convert to postfix

                    Console.Write("Coverted expression to Postfix: ");
                    _tree.Postorder(root);
                    Console.WriteLine();

                    break;

            }
            Console.ForegroundColor = ConsoleColor.White;
        }


       

  


    }
}
