using NotationTranslator.Enums;
using NotationTranslator.Services;


namespace NotationTranslator
{
    public class Program
    {
        //Make async later
        static void Main(string[] args)
        {
            try
            {
                ArgParse Parser = new ArgParse(args);
                Parser.Parse();

                Console.WriteLine();

            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Argument error: {ex.Message}", Console.ForegroundColor);
                Console.WriteLine("Use \"NotationTranslator --help\" for more information.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(1);
            }

        }
    }
}
