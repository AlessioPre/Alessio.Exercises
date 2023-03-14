using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class NATO : Organizzazione
    {
        private int _nPaesi_aderenti;

        public NATO(Paese paese)
        {
            Console.WriteLine("paese aggiunto alla Nato: {0}", paese.Nome);
        }

        public int Paesi_Aderenti
        {
            get { return _nPaesi_aderenti; }
            set
            {
                _nPaesi_aderenti = value;
            }
        }

        public void StuzicaRussia()
        {

        }

        public void OrganizzaIncontro()
        {

        }
    }
}
