using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator
{
    public class Tokenizer
    {
        private static readonly List<(TokenType Type, string Pattern)> TokenDefinitions = new()
    {
        (TokenType.Whitespace, @"^\s+"),
        (TokenType.Number, @"^\d+(\.\d+)?"),
        (TokenType.Identifier, @"^[a-zA-Z_][a-zA-Z0-9_]*"),
        (TokenType.Plus, @"^\+"),
        (TokenType.Minus, @"^-"),
        (TokenType.Multiply, @"^\*"),
        (TokenType.Divide, @"^/"),
        (TokenType.Power, @"^\^"),
        (TokenType.LeftParen, @"^\("),
        (TokenType.RightParen, @"^\)"),
        (TokenType.Comma, @"^,"),
        (TokenType.Equals, @"^=")
    };

    } 
}
