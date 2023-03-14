using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Area_Geografica
    {
        //var
        private string          _nome;
        private string          _clima;
        private decimal         _popolazione;
        private string          _etnia;

        private List<string>    _listaFauna;
        private List<string>    _listaFlora;

        // property
        public string Clima
        {
            get { return _clima; }
            set
            {
                _clima = value;
            }
        }

        public decimal Popolazione
        {
            get { return _popolazione; }
            set
            {
                _popolazione = value;
            }
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
            }
        }

        public string Etnia
        {
            get { return _etnia; }
            set
            {
                _etnia = value;
            }
        }

        //costruttore


        public void Definisci_confini()
        {

        }

        public void gestione_fondi()
        {

        }

        public string PrintListFauna()
        {
            return _listaFauna[0];

        }
        public string PrintListFlora()
        {
            return _listaFlora[0];

        }
    }
}
