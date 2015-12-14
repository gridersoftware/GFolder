using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFolder
{
    class LowerLettersSequence : CharSequence, ISequence
    {
        public LowerLettersSequence(char from, char to)
            : base(from, to, 'a', 'z', "LL")
        {

        }

        public new ISequence NewSequence()
        {
            return new LowerLettersSequence(From[0], To[0]);
        }

        public override string ToString()
        {
            return "Lowercase Letters";
        }
    }
}
