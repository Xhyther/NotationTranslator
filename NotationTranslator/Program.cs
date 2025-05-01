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
                Console.WriteLine($"Argument error: {ex.Message}");
                Environment.Exit(1);
            }

        }
    }
}
