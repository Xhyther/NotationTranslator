
namespace NotationTranslator.Services
{
    /// Helper class provides methods to print help information and a user guide for the Notation Translator CLI.
    public static class Helper
    {
        public static void PrintHelpMain()
        {
            Console.WriteLine("Notation Translator CLI");
            Console.WriteLine();
            Console.WriteLine("Basic Syntax:");
            Console.WriteLine("  NotationTranslator <command> [options] <expression>");
            Console.WriteLine();
            Console.WriteLine("Available Commands:");
            Console.WriteLine("  convert       Convert a mathematical expression between notations.");
            Console.WriteLine();
            Console.WriteLine("Global Options:");
            Console.WriteLine("  --g, --guide           Show a detailed user guide.");
            Console.WriteLine("  --h, --help            Show this help message.");
            Console.WriteLine();
            Console.WriteLine("Use \"NotationTranslator <command> --help\" for more information on a specific command.");
            Console.WriteLine();
        }



        public static void printHelpConvert()
        {
            Console.WriteLine("Command: convert");
            Console.WriteLine();
            Console.WriteLine("Description:");
            Console.WriteLine("  Converts a mathematical expression from one notation to another.");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  NotationTranslator convert [options] <expression>");
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine("  <expression>           The mathematical expression to convert.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  --f, --from <notation>   (REQUIRED) The input notation: infix, postfix, or prefix.");
            Console.WriteLine("  --t, --to   <notation>   (REQUIRED) The output notation: infix, postfix, or prefix.");
            Console.WriteLine("  --h, --help                         Show help information for this command.");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("  dotnet run convert --from infix --to postfix \"a + b * c\"");
            Console.WriteLine("  dotnet run convert --from prefix --to infix \"+ a * b c\"");
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
            Console.WriteLine("  --from, --f   <notation>   REQUIRED   Notation to convert FROM");
            Console.WriteLine("  --to,   --t   <notation>   REQUIRED   Notation to convert TO");
            Console.WriteLine("  --help, --h,                          Show this help guide");
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
