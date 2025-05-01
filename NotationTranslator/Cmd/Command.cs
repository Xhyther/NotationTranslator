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
        public List<Subcommand> Subcommands {get; } = new();
        public Arguments? Arguments { get; set; }

        public Func<Dictionary<string, string>, Task>? Handler { get; private set; }

        public Command(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddSubcommand(Subcommand subcommand)
        {
            Subcommands.Add(subcommand);
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
