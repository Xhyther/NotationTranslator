using System.CommandLine;
using System.CommandLine.Parsing;
using System.Linq.Expressions;

//Trees
//Comments
//Cleanup
//Readme.md
//--guide

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


            //Handles the sub command "convert"s
            convertCommand.SetHandler((Notation from, Notation to, string expr) =>
            {
                Console.WriteLine($"\tConvert {expr} from {from} to {to}");
                Console.WriteLine($"\t{from}: {expr}");
                Translator.Translate(expr, from, to);

            },fromOption, toOption, expressionArg);

            //set handler for the root command
            rootCommand.SetHandler(() =>
            {
                try
                {
                    Console.WriteLine("\nThis is NotationTranslator.");
                    rootCommand.InvokeAsync("--help");
                    Console.WriteLine("\nFor more info about a command use: \nNotationTranslator [command] --h\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            });



            //Invoke the command line parser
            await rootCommand.InvokeAsync(args);
        }
    }
}
