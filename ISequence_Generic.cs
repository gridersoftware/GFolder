using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFolder
{
    interface ISequence<T> : ISequence
    {
        new T Minimum { get; }
        new T Maximum { get; }

        new T From { get; set; }
        new T To { get; set; }
    }
}
