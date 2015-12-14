using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFolder
{
    class CustomSequence : Sequence, ISequence
    {
        public CustomSequence()
            : base("", "")
        {
            range = new string[0];
            Header = "CS";
        }

        public CustomSequence(string[] items)
            : base(items[0], items[items.Length - 1])
        {
            Header = "CS";
            range = items;

            GenerateSequence();
        }

        public CustomSequence(string[] items, string from, string to)
            : base(from, to)
        {
            Header = "CS";
            range = items;

            GenerateSequence();
        }

        public override string ToString()
        {
            return "Custom Sequence";
        }

        protected override void SetRange()
        {
            // Do nothing!
        }

        int CompareItems(string a, string b)
        {
            int indexA = GetRangeIndexOf(a);
            int indexB = GetRangeIndexOf(b);

            if ((indexA < 0) | (indexB < 0))
                throw new ArgumentOutOfRangeException();
            return indexB - indexA;
        }

        /// <summary>
        /// Gets the index of the item in range.
        /// </summary>
        /// <param name="item">Item to check for.</param>
        /// <returns>Returns the index if the item was found. If the item was not found, returns less than zero.</returns>
        int GetRangeIndexOf(string item)
        {
            for (int i = 0; i < range.Length; i++)
            {
                if (range[i] == item)
                    return i;
            }
            return -1;
        }

        protected override void GenerateSequence()
        {
            if (range == null)
                return;
            if (range.Length == 0)
            {
                Output = new string[] { "" };
            }
            else
            {
                List<string> output = new List<string>();

                int incr = (CompareItems(From, To) >= 0 ? 1 : -1);

                for (int i = GetRangeIndexOf(From); i != GetRangeIndexOf(To) + 1; i += incr)
                {
                    output.Add(range[i]);
                }

                Output = output.ToArray();
            }
        }

        protected override string GenerateCode()
        {
            if (range.Length == 0)
                return "";
            else
                return string.Format("[{0}:{1}-{2}]", Header, From, To);
        }

        public new bool TrySetFrom(string value)
        {
            if (Range.Contains(value))
            {
                From = value;
                return true;
            }
            return false;
        }

        public new bool TrySetTo(string value)
        {
            if (Range.Contains(value))
            {
                To = value;
                return true;
            }
            return false;
        }

        public new ISequence NewSequence()
        {
            return new CustomSequence(range, From, To);
        }
    }
}
