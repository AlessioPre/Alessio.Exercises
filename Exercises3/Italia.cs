using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises3
{
    internal class Italia : Paese, IUE, IEuroZona, IONU
    {
        public object MonetaValore { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Italia() { }

    }
}