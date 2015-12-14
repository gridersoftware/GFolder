using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFolder
{
    abstract class CharSequence : Sequence
    {
        public CharSequence(char from, char to, char min, char max, string header)
            : base(from.ToString(), to.ToString())
        {
            Minimum = min.ToString();
            Maximum = max.ToString();
            Header = header;

            SetRange();
        }

        protected override string GenerateCode()
        {
            return string.Format("[{0}:{1}-{2}]", Header, From, To);
        }

        protected override void SetRange()
        {
            try
            {
                range = new string[Maximum[0] - Minimum[0] + 1];

                char c = Minimum[0];
                for (int i = 0; i < range.Length; i++)
                {
                    range[i] = c.ToString();
                    c++;
                }
            }
            catch
            {
            }
        }

        protected override void GenerateSequence()
        {
            List<string> output = new List<string>();

            int incr = (From[0] <= To[0] ? 1 : -1);

            for (char c = From[0]; c != To[0] + incr; c = (char)(c + incr))
            {
                output.Add(c.ToString());
            }

            Output = output.ToArray();
        }

        bool IsValidChar(string value)
        {
            return (value.Length == 1) & (Range.Contains(value));
        }

        public new bool TrySetFrom(string value)
        {
            if (IsValidChar(value))
            {
                From = value;
                return true;
            }

            return false;
        }

        public new bool TrySetTo(string value)
        {
            if (IsValidChar(value))
            {
                To = value;
                return true;
            }

            return false;
        }

        
    }
}
