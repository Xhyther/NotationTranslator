using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator.Services
{
    public class CommandLine
    {
        public void ParseArgs(string[] args)
        {
            if (args.Length == 0)
            {
               PrintHelpMain();
                return;
            }
            
        }



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
        }
    }
}
