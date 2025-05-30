﻿using System.Text.RegularExpressions;
using NotationTranslator.Enums;
using NotationTranslator.Models;

namespace NotationTranslator.Services
{
    /// The Tokenizer class is responsible for tokenizing the input string into a list of tokens.
    
    public class Tokenizer
    {
        /// Define the token types with TokenType enum and corresponding regex patterns
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


        /// Tokenize the input string into a list of tokens
        public static List<Tokens> Tokenize(string input)
        {
            var tokens = new List<Tokens>();
            int index = 0;

            try
            {
                while (index < input.Length)
                {
                    bool matched = false;

                    foreach (var (type, pattern) in TokenDefinitions)
                    {
                        var regex = new Regex(pattern);
                        var match = regex.Match(input.Substring(index));

                        if (match.Success)
                        {
                            if (type != TokenType.Whitespace)
                                tokens.Add(new Tokens(type, match.Value));

                            index += match.Length;
                            matched = true;
                            break;
                        }
                    }

                    if (!matched)
                    {
                        // Handle unknown tokens (invalid input)
                        tokens.Add(new Tokens(TokenType.Unknown, input[index].ToString()));
                        index++;
                    }
                }

                return tokens;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during tokenization
                throw new ArgumentException($"Error during tokenization: {ex.Message}");
            }
        }

    } 
}
