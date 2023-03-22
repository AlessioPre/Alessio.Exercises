using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises3
{
    internal class BancaUE
    {

        public BancaUE() { }

        public BancaUE(string name)
        {

        }

        public void Spead(IEuroZona paese)
        {
            Console.WriteLine("lo spead del paese {0} è pari a {1}", paese.MonetaValore);
        }
    }
}
