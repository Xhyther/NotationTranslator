using System.CommandLine;

namespace NotationTranslator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Option for the notation to convert from
            // has default value of infix
            var fromOption = new Option<string>
                (
                name: "--from",
                description: "The notation to convert from",
                getDefaultValue: () => "infix"
                );

            //Aliases for the from option
            fromOption.AddAlias("--f");
            fromOption.AddAlias("-f");

            //Option for the notation to convert to
            // is required
            var toOption = new Option<string>
                 (
                 name: "--to",
                 description: "The notation to convert to"
                 ){IsRequired = true};

            //Aliases for the to option
            toOption.AddAlias("--t");
            toOption.AddAlias("-t");

            //Register the from option with the comman
            var convertCommand = new Command("convert", "Convert notation from one format to another");
 
            convertCommand.AddOption(fromOption);
            convertCommand.AddOption(toOption);



            var rootCommand = new RootCommand("ds2");
            rootCommand.AddCommand(convertCommand);

            rootCommand.SetHandler(rootCommand =>
            {
                Console.WriteLine("A project for DS2");
            });

            await rootCommand.InvokeAsync(args);
        }
    }
}
