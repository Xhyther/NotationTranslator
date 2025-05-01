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
        public Type? Type { get; set; } = null;
        public bool IsRequired { get; set; } = false;
        public bool IsFlag { get; set; } = true;
        public Arguments? Arguments { get; set; }

        public Option(string name, string description)
        {
            Name = name;
            this.description = description;
        }

        public void AddAlias(string alias)
        {
            Alias = alias;
        }

        public void AddArgument(Arguments argument)
        {
            Arguments = argument;
        }
        public void Require()
        {
            IsRequired = true;
        }

        public void SetFlag(bool isFlag)
        {
            IsFlag = isFlag;
            if (isFlag)
            {
                Arguments = null;
            }
        }

        public void SetType(Type type)
        {
            Type = type;
            if (type != null)
            {
                IsFlag = false;
            }
        }
    }
}
