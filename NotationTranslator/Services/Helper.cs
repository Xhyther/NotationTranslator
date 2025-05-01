using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator.Services
{
    public static class Helper
    {
        public static void PrintHelpMain()
        {
            Console.WriteLine("This is Notation Translator. No arguments provided!");
            Console.WriteLine();
            Console.WriteLine("Usage: NotationTranslator [commands] [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("\t--version \t\tShow version information.");
            Console.WriteLine("\t--g --guide \t\tShow a detailed guide on how to use this tool.");
            Console.WriteLine("\t--? --h, --help \t\tShow this help message and usage information.");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine("\tconvert <expression> \t\tConvert Notation from one format to another.");
            Console.WriteLine();
        }


        public static void printHelpConvert()
        {
            Console.WriteLine("Description:");
            Console.WriteLine();
            Console.WriteLine("\tConvert Notation from one format to another.");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("\tNotationTranslator convert [options]  <expression>");
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine("\t<expression>  The mathematical expression to convert");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("\t--f, --from\t<infix|postfix|prefix>\t(REQUIRED)\tThe notation to convert from.");
            Console.WriteLine("\t--t, --to\t<infix|postfix|prefix>\t(REQUIRED)\tThe notation to convert to");
            Console.WriteLine("\t--?, --h, --help\t\t\t\t\t\tShow help and usage information");
            Console.WriteLine();
        }


        public static void printGuide()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Notation Translator - Command Line Guide");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();

            Console.WriteLine("This tool converts mathematical expressions between infix, prefix, and postfix notations.");
            Console.WriteLine("It uses a binary expression tree internally to parse the expression and transform it into the desired notation.");
            Console.WriteLine();

            Console.WriteLine("What is an Expression Tree?");
            Console.WriteLine("- An expression tree is a binary tree where:");
            Console.WriteLine("    • Operands (variables, constants) are leaf nodes.");
            Console.WriteLine("    • Operators (+, -, *, /, etc.) are internal nodes.");
            Console.WriteLine("- This tree allows us to easily traverse it in different orders to output different notations.");
            Console.WriteLine();

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("USAGE OVERVIEW");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Basic syntax:");
            Console.WriteLine("  NotationTranslator convert [options] <expression>");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("  dotnet run convert --from infix --to postfix \"a + b * c\"");
            Console.WriteLine("  dotnet run convert --from prefix --to infix \"+ a * b c\"");
            Console.WriteLine("  dotnet run convert --from postfix --to prefix \"a b c * +\"");
            Console.WriteLine();
            Console.WriteLine("Always wrap expressions with quotes to avoid command line parsing errors.");
            Console.WriteLine();

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("OPTIONS");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("  --from, -f   <notation>   REQUIRED   Notation to convert FROM");
            Console.WriteLine("  --to,   -t   <notation>   REQUIRED   Notation to convert TO");
            Console.WriteLine("  --help, -h, -?                        Show this help guide");
            Console.WriteLine();

            Console.WriteLine("Accepted Notation Values:");
            Console.WriteLine("  infix      - Standard math notation: a + b");
            Console.WriteLine("  prefix     - Operator first: + a b");
            Console.WriteLine("  postfix    - Operator last: a b +");
            Console.WriteLine();

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("INTERNAL MECHANISM (for developers or curious users)");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("1. Your input expression is parsed into an expression tree.");
            Console.WriteLine("2. Depending on the input notation, the tree is built using stack-based logic.");
            Console.WriteLine("3. The output is generated by traversing the tree:");
            Console.WriteLine("     - Inorder traversal   → infix output");
            Console.WriteLine("     - Preorder traversal  → prefix output");
            Console.WriteLine("     - Postorder traversal → postfix output");
            Console.WriteLine();

            Console.WriteLine("This approach guarantees syntactically correct and fully parenthesized output.");
            Console.WriteLine();

            Console.WriteLine("Tips:");
            Console.WriteLine("- Use quotes to group multi-character expressions.");
            Console.WriteLine("- Use variables or digits (like a, b, x, 1, 2) consistently.");
            Console.WriteLine();

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("For more help, use: dotnet run --help");
            Console.WriteLine("Developed by VHON - Notation Translator CLI");
            Console.WriteLine(new string('=', 50));
        }

    }
}
