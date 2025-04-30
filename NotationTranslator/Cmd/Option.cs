using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator.Cmd
{
    public class Option
    {
        public string Name { get; }
        public string? Alias { get; set; }
        public string description { get; }

        public Option(string name, string description)
        {
            Name = name;
            this.description = description;
        }

        public void AddAlias(string alias)
        {
            Alias = alias;
        }
    }
}
