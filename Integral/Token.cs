using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    class Token
    {
        public string Value { get; }
      
        public int Type { get; }

        public Token(string value, int type)
        {
            Value = value;
            Type = type;
        }
    }
}
