using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Unione_europea : Organizzazione
    {
        private string  _moneta;
      
        private List<Paese>     _paesi_partecipanti;

        public Unione_europea(Paese paese)
        {
            Paese = paese;
            Console.WriteLine("paese ha fatto richiesta al UE: {0}", Paese.Nome);
            //this.AggiungiStato(paese);
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
