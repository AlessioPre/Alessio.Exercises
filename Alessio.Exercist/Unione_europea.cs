using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
     class Unione_europea : Organizzazione
    {
        private string  _moneta;
        Paese _paese;
        private List<Paese>     _paesi_partecipanti;

        public Unione_europea(Paese paese)
        {
            _paese = paese;
            Console.WriteLine("paese ha fatto richiesta al UE: {0}", _paese.Nome);
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
