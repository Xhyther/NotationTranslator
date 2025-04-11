using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator
{
    internal static class Tokenizer
    {
        private static string args { get; set; }
        

        public static void getArgument(string s)
        {
            args = s;
        }

        public static void printArgs()
        {
            Console.WriteLine("This is the expression to be Tokenized: " + args);
        }

    }
}
