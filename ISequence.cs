using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFolder
{
    interface ISequence
    {
        string[] Output { get; }

        object Minimum { get; }
        object Maximum { get; }

        object From { get; set; }
        object To { get; set; }

        string Code { get; }

        string Header { get; }

        ISequence NewSequence();

        bool TrySetFrom(string value);
        bool TrySetTo(string value);
    }
}
