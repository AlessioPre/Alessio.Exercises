using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
     class Regione : Area_Geografica
    {
        //var
        private string  _capoluogo;
        private string  _presidente_regionale;
        private int     _nprovincie;
        private Paese   _paese;
        Provincia       _provincia;
        //property
        public string   Capoluogo
        {
            get { return _capoluogo; }
            set
            {
                _capoluogo = value;
            }
        }
        public string   Presidente_regionale
        {
            get { return _presidente_regionale; }
            set
            {
                _presidente_regionale = value;
            }
        }
        public int      Nprovincie
        {
            get { return _nprovincie; }
            set
            {
                _nprovincie = value;
            }
        }

        public Regione(Paese paese, string nome)
        {
            _paese      = paese;
            this.Nome   = nome;
            Console.WriteLine("la regione {0} è stata creata ", this.Nome);
            _paese.AddRegione(this);
        }

        public void IstanziaConcorsiRegionali()
        {

        }

        internal void AddProvincia(Provincia provincia)
        {
            _provincia = provincia;
            Console.WriteLine("la Provincia è stata aggiunta {0} ", _provincia.Nome);
        }

        internal void ChaingPaese(Paese paese)
        {
            _paese= paese;
            Console.WriteLine("il paese è stato cambiato {0} ", _paese.Nome);
        }
    }
}
