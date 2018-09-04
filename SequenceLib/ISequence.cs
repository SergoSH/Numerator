using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceLib
{
    interface ISequence
    {
        bool Load(string Name);
        Sequence GetCurrent();
        string NextValue();
    }
}
