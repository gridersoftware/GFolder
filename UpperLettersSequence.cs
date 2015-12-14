using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFolder
{
    class UpperLettersSequence : CharSequence, ISequence
    {
        public UpperLettersSequence(char from, char to)
            : base(from, to, 'A', 'Z', "UL")
        {

        }

        public new ISequence NewSequence()
        {
            return new UpperLettersSequence(From[0], To[0]);
        }

        public override string ToString()
        {
            return "Uppercase Letters";
        }
    }
}
