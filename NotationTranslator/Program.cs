using NotationTranslator.Enums;
using NotationTranslator.Services;


namespace NotationTranslator
{
    //Entry point of the application
    public class Program
    {
        //Make async later
        static void Main(string[] args)
        {
            //
            try
            {
                // Instantiate the ArgParse class with the command line arguments
                ArgParse Parser = new ArgParse(args);
                // Parse the command line arguments
                Parser.Parse();

                Console.WriteLine();

            }
            catch (ArgumentException ex)
            {
                // Handle any argument exceptions that occur during parsing
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
