using System.CommandLine;

namespace NotationTranslator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var rootCommand = new RootCommand("ds2");
            var convertCommand = new Command("convert", "Convert notation from one format to another");




            rootCommand.SetHandler(rootCommand =>
            {
                Console.WriteLine("A project for DS2");
            });

            await rootCommand.InvokeAsync(args);
        }
    }
}
