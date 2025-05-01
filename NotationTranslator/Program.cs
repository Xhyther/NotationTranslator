using NotationTranslator.Cmd;
using NotationTranslator.Enums;
using NotationTranslator.Services;


namespace NotationTranslator
{
    public class Program
    {
        static async Task Main(string[] args)
        {
           var RootCommand = new Command
            (   "NotationTranslaor", 
                "The Root Command of the CLI Application"
            );


            var ConvertCommand = new Subcommand
            (
                "convert",
                "Convert notation from one format to another"
            );

            var Argument = new Arguments
            (
                name: "expression",
                description: "The mathematical expression to convert"
            );

            Argument.Require();


            var fromOption = new Option
            (
                name: "--from",
                description: "The notation to convert from"
            );

            fromOption.AddAlias("--f");
            fromOption.Require();
            fromOption.SetType(typeof(Notation));

            var toOption = new Option
            (
                name: "--to",
                description: "The notation to convert to"
            );
            toOption.AddAlias("--t");
            toOption.Require();
            toOption.SetType(typeof(Notation));

            ConvertCommand.AddArgument(Argument);
            ConvertCommand.AddOption(fromOption);
            ConvertCommand.AddOption(toOption);
            RootCommand.AddSubcommand(ConvertCommand);

           
        }
    }
}
