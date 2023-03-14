using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Unione_europea : Organizzazione
    {
        private string _moneta;
        private List<Paese> _paesi_partecipanti;

        public Unione_europea(Paese paese)
        {
            Console.WriteLine("paese aggiunto all'unione: {0}", paese.Nome);

        }

        public string Moneta
        {
            get { return _moneta; }
            set
            {
                _moneta = value;
            }
        }

        public void CreaNuovaMoneta()
        {

        }
    }
}
