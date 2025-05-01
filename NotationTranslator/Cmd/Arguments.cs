using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator.Cmd
{
    public class Arguments
    {
        public string Name { get; }
        public string? Value { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; } = false;
        public Arguments(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Require()
        {
            IsRequired = true;
        }

        public void SetValue(string value)
        {
            Value = value;
        }
    }
}
