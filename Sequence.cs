using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFolder
{
    abstract class Sequence : ISequence<string>
    {
        protected string[] range;

        public string[] Range { get { return range; } }
        public string[] Output { get; protected set; }

        string from, to;

        public string Minimum { get; protected set; }
        public string Maximum { get; protected set; }

        public string From
        {
            get
            {
                return from;
            }
            set
            {
                if (!range.Contains(value))
                    throw new ArgumentOutOfRangeException();

                from = value;
                GenerateSequence();
            }
        }

        public string To
        {
            get
            {
                return to;
            }
            set
            {
                if (!range.Contains(value))
                    throw new ArgumentOutOfRangeException();

                to = value;
                GenerateSequence();
            }
        }

        public string Code
        {
            get
            {
                return GenerateCode();
            }
        }

        public Sequence(string from, string to)
        {
            SetRange();

            this.from = from;
            this.to = to;

            GenerateSequence();
        }

        protected abstract void GenerateSequence();

        protected abstract void SetRange();

        protected abstract string GenerateCode();


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
                if (value is string)
                    From = (string)value;
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
                if (value is string)
                    To = (string)value;
                else
                    throw new NotSupportedException();
            }
        }


        public string Header
        {
            get;
            protected set;
        }

        public ISequence NewSequence()
        {
            throw new NotImplementedException();
        }

        public bool TrySetFrom(string value)
        {
            throw new NotImplementedException();
        }

        public bool TrySetTo(string value)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
