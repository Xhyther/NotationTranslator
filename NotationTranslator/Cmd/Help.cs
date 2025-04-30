using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator.Cmd
{
    internal class Help
    {
        public void PrintHelpMain()
        {
            Console.WriteLine("This is Notation Translator. No arguments provided!");
            Console.WriteLine();
            Console.WriteLine("Usage: NotationTranslator [commands] [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("\t--version \t\tShow version information.");
            Console.WriteLine("\t-g --guide \t\tShow a detailed guide on how to use this tool.");
            Console.WriteLine("\t-? --help, -h \t\tShow this help message and usage information.");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine("\tconvert <expression> \t\tConvert Notation from one format to another.");
            Console.WriteLine();
        }


        public void printHelpConvert()
        {
            Console.WriteLine("Description:");
            Console.WriteLine();
            Console.WriteLine("\tConvert Notation from one format to another.");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("\tNotationTranslator convert <expression> [options]");
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine("\t<expression>  The mathematical expression to convert");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("\t-f, --from\t<infix|postfix|prefix>\t(REQUIRED)\tThe notation to convert from.");
            Console.WriteLine("\t-t, --to\t<infix|postfix|prefix>\t(REQUIRED)\tThe notation to convert to");
            Console.WriteLine("\t-?, -h, --help\t\t\t\t\t\tShow help and usage information");
            Console.WriteLine();
        }
    }
}
