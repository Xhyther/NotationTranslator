using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator
{
    public class Translator
    {

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

        public static List<Tokens> Reverse(List<Tokens> expression)
        {
            var myStack = new Stack<Tokens>(expression);
            var reversedExpression = new List<Tokens>(myStack.ToList());
            return reversedExpression;
        }

        public static bool IsOperator(Tokens token)
        {
            return token.Type == TokenType.Plus ||
                   token.Type == TokenType.Minus ||
                   token.Type == TokenType.Multiply ||
                   token.Type == TokenType.Divide ||
                   token.Type == TokenType.Power;
        }

        public static bool IsOperand(Tokens token)
        {
            return token.Type == TokenType.Number ||
                   token.Type == TokenType.Identifier;
        }

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

        public static List<Tokens> ConvertInfixToPostfix(List<Tokens> expression)
        {
            
            var operatorStack = new Stack<Tokens>();
            var output = new List<Tokens>();


            int i;
            for (i = 0; i < expression.Count(); i++)
            {
                if (IsOperand(expression[i]))
                {
                    output.Add(expression[i]);

                }
                else if (expression[i].Type == TokenType.LeftParen)
                    operatorStack.Push(expression[i]);
                else if (expression[i].Type == TokenType.RightParen)
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek().Type != TokenType.LeftParen)
                    {
                        output.Add(operatorStack.Pop());

                    }
                    if (operatorStack.Count > 0 && operatorStack.Peek().Type == TokenType.LeftParen)
                        operatorStack.Pop();
                    // discard left parenthesis

                }
                else
                {
                    while (operatorStack.Count > 0 && Precedence(expression[i]) <= Precedence(operatorStack.Peek()))
                    {
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(expression[i]);
                }
            }

            while (operatorStack.Count > 0)
            {
                output.Add(operatorStack.Pop());
            }
           

            return output;
            
        }

        public static List<Tokens> ConvertInfixToPrefix(List<Tokens> expression)
        {
            // Reverse the expression
            var reversedExpression = Reverse(expression);
            // Reverse the parentheses
            var reversedBraces = ReverseBraces(reversedExpression);
            // Convert to postfix
            var postfix = ConvertInfixToPostfix(reversedBraces);
            // Reverse the postfix expression to get prefix
            var prefix = Reverse(postfix);
            return prefix;
        }

        public static void Translate(string expression, Notation from, Notation to)
        {
            // Tokenize the input expression
            var tokens = Tokenizer.Tokenize(expression);
            ConvertInfixToPostfix(tokens);



            
            // Convert the tokens based on the specified notations
            if (from == Notation.infix && to == Notation.prefix)
            {
                var IPF = ConvertInfixToPrefix(tokens);
                foreach (var token in IPF)
                {
                    Console.Write(token.Value + " ");
                }
            }
            else if (from == Notation.infix && to == Notation.postfix)
            {
                var IFP = ConvertInfixToPostfix(tokens);
                foreach (var token in IFP)
                {
                    Console.Write(token.Value + " ");
                }
            }
            else if (from == Notation.postfix && to == Notation.prefix)
            {
                //return ConvertPostfixToPrefix(tokens);
            }
            else if (from == Notation.postfix && to == Notation.infix)
            {
                //return ConvertPostfixToInfix(tokens);
            }
            else if (from == Notation.prefix && to == Notation.infix)
            {
                //return ConvertPrefixToInfix(tokens);
            }
            else if (from == Notation.prefix && to == Notation.postfix)
            {
               // return ConvertPrefixToPostfix(tokens);
            }
            else if (from == to)
            {
               // return expression; // No conversion needed
            }
            else
            {
               // throw new NotSupportedException($"Conversion from {from} to {to} is not supported.");
            }
            

        }

        
    }
}
