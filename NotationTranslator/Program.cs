using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Parsing;




namespace NotationTranslator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Option for the notation to convert from
            // has default value of infix
            var fromOption = new Option<Notation>
                (
                name: "--from",
                description: "C"
                ){IsRequired = true};

            //Aliases for the from option
            fromOption.AddAlias("--f");
            fromOption.AddAlias("-f");
             
            //Option for the notation to convert to
            // is required
            var toOption = new Option<Notation>
                 (
                 name: "--to",
                 description: "The notation to convert to"
                 ){IsRequired = true};

            //Aliases for the to option
            toOption.AddAlias("--t");
            toOption.AddAlias("-t");

            var expressionArg = new Argument<string>(
                  name: "expression",
                  description: "The mathematical expression to convert")
                        {
                            Arity = ArgumentArity.ExactlyOne
                        };

            //Register the from option with the comman
            var convertCommand = new Command("convert", "Convert notation from one format to another")
            {
                fromOption,
                toOption,
                expressionArg
            };


            //The rootCommand
            var rootCommand = new RootCommand("Notation Translator")
            {
                convertCommand
            };

            convertCommand.SetHandler((Notation from, Notation to, string expr) =>
            {
                Console.WriteLine($"Convert {expr} from {from} to {to}");

            },fromOption, toOption, expressionArg);

            rootCommand.SetHandler(() =>
            {
                Console.WriteLine("\nThis is NotationTranslator.");
                rootCommand.InvokeAsync("--help");
                Console.WriteLine("\nFor more info about a command use: \nNotationTranslator [command] --h\n");
            });

          


            await rootCommand.InvokeAsync(args);
        }
    }
}
