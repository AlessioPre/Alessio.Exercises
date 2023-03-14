using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Regione : Area_Geografica
    {
        private string _capoluogo;
        private string _presidente_regionale;
        private int _nprovincie;
        private Paese _paese;

        public Regione(Paese paese, string nome)
        {
            _paese = paese;
            this.Nome = nome;
            Console.WriteLine("la regione {0} , fa parte del paese {1}", this.Nome, _paese.Nome);
        }

        public string Capoluogo
        {
            get { return _capoluogo; }
            set
            {
                _capoluogo = value;
            }
        }

        public string Presidente_regionale
        {
            get { return _presidente_regionale; }
            set
            {
                _presidente_regionale = value;
            }
        }

        public int Nprovincie
        {
            get { return _nprovincie; }
            set
            {
                _nprovincie = value;
            }
        }


        public void IstanziaConcorsiRegionali()
        {

        }
    }
}
