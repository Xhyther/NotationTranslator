using System.CommandLine;

namespace NotationTranslator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var rootCommand = new RootCommand("fixNotation");

            //Need to define commands for translating between notations
            //Infix to Postfix
            //Infix to Prefix
            //Prefix to Postfix

            //Option or Arugment that reverses that Operation
            //i.e. Postfix to Infix -f ==  Infix to Postfix




            rootCommand.SetHandler(rootCommand =>
            {
                Console.WriteLine("fixNotation");
            });

            await rootCommand.InvokeAsync(args);
        }
    }
}
