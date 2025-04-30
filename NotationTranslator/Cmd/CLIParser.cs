using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator.Cmd
{
    public class CLIParser
    {
        private readonly List<string> _args;

        public CLIParser(string[] args)
        {
            _args = new List<string>(args);
        }

        public string ParseExecute()
        {
            if (_args.Count == 0) {
                Console.WriteLine("No command provided.");
                return;
            }
            string cmdName = _args[0];

        }
    }
}
