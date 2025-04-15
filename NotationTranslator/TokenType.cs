using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator
{
    //The tokens are used to represent the different types of tokens in the input string
    public enum TokenType
    {
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,
        LeftParen,
        RightParen,
        Identifier,
        Power,
        Function,
        Comma,
        Equals,
        Whitespace,
        Unknown
    }

}
