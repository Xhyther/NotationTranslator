using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotationTranslator.Enums;

namespace NotationTranslator.Models
{
    public class Option
    {
        public string Name { get; set; }

        public Notation Notation { get; set; }


        public Option(string name, Notation notation)
        {
            Name = name;
            Notation = notation;
        }

        public void SetOptName(string name)
        {
            Name = name;
        }

        public void SetNotation(Notation notation)
        {
            Notation = notation;
        }

        public override string ToString()
        {
            return $"Option: {Name}, Notation: {Notation}";
        }
    }
}
