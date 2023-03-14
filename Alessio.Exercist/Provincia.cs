using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Provincia : Area_Geografica
    {
        private string _assessore_provinciale;
        private string _iniziali_provincia;
        private Regione _regione;
        public Provincia(Regione regione, string name)
        {
            this.Nome = name;
            _regione = regione;
            Console.WriteLine("la provincia  di {0} fa parte della regione: {1}", this.Nome, _regione.Nome);
        }

        public string Assessore_Provinciale
        {
            get { return _assessore_provinciale; }
            set
            {
                _assessore_provinciale = value;
            }
        }

        public string Iniziali_Provincia
        {
            get { return _iniziali_provincia; }
            set
            {
                _iniziali_provincia = value;
            }
        }

        public void GestioneEventiProvinciali()
        {

        }

        public void CreaEventi()
        {

        }
    }
}
