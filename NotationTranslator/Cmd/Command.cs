using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator.Cmd
{
    public class Command
    {
        public string Name { get; }
        public string Description { get; }
        public List<Command> Subcommands {get; } = new();
        public List<Option> Options { get; } = new();
        public Arguments? Arguments { get; set; }

        public Func<Dictionary<string, string>, Task>? Handler { get; private set; }

        public Command(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddSubcommand(Command subcommand)
        {
            Subcommands.Add(subcommand);
        }

        public void AddOption(Option option)
        {
            Options.Add(option);
        }

        public void AddArgument(Arguments argument)
        {
            Arguments = argument;
        }


        public void SetHandler(Func<Dictionary<string, string>,Task> handler)
        {        
            Handler = handler;
        }
    }
}
