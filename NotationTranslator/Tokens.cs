using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator
{
    //Token class is used to represent a token in the input string
    public class Tokens
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Tokens(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => $"{Type}: {Value}";
    }
}
