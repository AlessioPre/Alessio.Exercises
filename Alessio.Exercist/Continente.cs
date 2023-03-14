using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Continente : Area_Geografica
    {
        //VAR   
        private int             _nStati;
        private int             _emisfero;
        private List<string>    _listaPaesi;
        public Paese            _paese;
        //property
        public int Nstati
        {
            get => default;
            set
            {
            }
        }
        public int Emisfero
        {
            get => default;
            set
            {
            }
        }

        //costruttore
        public Continente(string nome)
        {
            this.Nome   = "CONTINENTE";
            Console.WriteLine("Continente {0}",Nome);
            _paese      = new Paese(nome);
            Console.WriteLine("Continente {0} contiene un nuovo paese : {1} ", this.Nome, _paese.Nome);

        }
        //Metodi
        public string GetList_Confini()
        {
            return _listaPaesi[0];
        }

    }
}
