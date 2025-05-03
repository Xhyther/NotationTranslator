using NotationTranslator.Enums;

namespace NotationTranslator.Models
{
    //Token class is used to represent a token in the input string
    public class Tokens
    {
        public TokenType Type { get; } // The type of the token (e.g., number, operator, etc.)
        public string Value { get; } // The value of the token (e.g., the actual number or operator)

        public Tokens(TokenType type, string value) // Constructor to initialize the token with a type and value
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => $"{Type}: {Value}"; // Override the ToString method to provide a string representation of the token
    }
}
