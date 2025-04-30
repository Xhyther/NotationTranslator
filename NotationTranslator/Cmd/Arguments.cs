using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotationTranslator.Cmd
{
    public class Arguments
    {
        public string value { get; }

        public Arguments(string value)
        {
            this.value = value;
        }
    }
}
