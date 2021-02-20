using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_jaratkezezlo
{
    class NegativKesesException : Exception
    {
        public NegativKesesException(int keses) : base ("A járat nem indulhat korábban " + -keses + "perccel!")
        {
        }
    }
}
