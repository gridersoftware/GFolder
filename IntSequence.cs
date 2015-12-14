using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFolder
{
    class IntSequence : ISequence<int>
    {
        int from, to;

        public string Header { get { return "NU"; } }

        public string[] Output
        {
            get;
            private set;
        }

        public int Minimum
        {
            get { return int.MinValue; }
        }

        public int Maximum
        {
            get { return int.MaxValue; }
        }

        public int From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
                GenerateOutput();
            }
        }

        public int To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
                GenerateOutput();
            }
        }

        public string Code
        {
            get
            {
                return string.Format("[NU:{0}-{1}]", From, To);
            }
        }

        public IntSequence(int from, int to)
        {
            this.from = from;
            this.to = to;
            GenerateOutput();
        }

        void GenerateOutput()
        {
            int incr = (from <= to ? 1 : -1);

            List<string> output = new List<string>();

            for (int i = from; i != to + incr; i += incr)
            {
                output.Add(i.ToString());
            }

            Output = output.ToArray();
        }

        public ISequence NewSequence()
        {
            return new IntSequence(From, To);
        }

        public override string ToString()
        {
            return "Integers";
        }

        public bool TrySetFrom(string value)
        {
            int output;
            bool result = int.TryParse(value, out output);
            if (result)
                From = output;
            return result;
        }

        public bool TrySetTo(string value)
        {
            int output;
            bool result = int.TryParse(value, out output);
            if (result)
                To = output;
            return result;
        }

        object ISequence.Minimum
        {
            get { return Minimum; }
        }

        object ISequence.Maximum
        {
            get { return Maximum; }
        }

        object ISequence.From
        {
            get
            {
                return From;
            }
            set
            {
                if (value is int)
                    From = (int)value;
                else
                    throw new NotSupportedException();
            }
        }

        object ISequence.To
        {
            get
            {
                return To;
            }
            set
            {
                if (value is int)
                    To = (int)value;
                else
                    throw new NotSupportedException();
            }
        }
    }
}
