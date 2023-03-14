using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Paese : Area_Geografica
    {
        //var
        private string  _forma_di_governo;
        private string  _capo_di_stato;
        private string  _capitale;
        private int     _numero_Regioni;
        private int     _numero_Province;
        private string  _lingua;
        private Regione _regione;
        //Property
        public string   FormaDiGoverno
        {
            get { return _forma_di_governo; }
            set
            {
                _forma_di_governo = value;
            }
        }
        public string   CapoDiStato
        {
            get { return _capo_di_stato; }
            set
            {
                _capo_di_stato = value;
            }
        }
        public string   Capitale
        {
            get
            {
                return _capitale;
            }
            set
            {
                _capitale = value;
            }
        }
        public int      NumeroRegioni
        {
            get { return _numero_Regioni; }
            set
            {
                _numero_Regioni = value;
            }
        }
        public string   Lingua
        {
            get { return _lingua; }
            set
            {
                _lingua = value;
            }
        }
        public int      NumeroProvince
        {
            get { return _numero_Province; }
            set
            {
                _numero_Province = value;
            }
        }

        //Costruttore
        public Paese(string name)
        {
            this.Nome = name;
            Console.WriteLine("il paese {0} è stato creato", this.Nome);
        }

        //Metodi
        public void CreaLegge()
        {

        }
        public void ModificaLegge()
        {

        }
        public void EliminaLegge()
        {

        }
        public void IniziaGuerra()
        {

        }
        public void TrattatoPace()
        {

        }
        internal void AddRegione(Regione regione)
        {
            _regione= regione;
            Console.WriteLine(" Regione aggiunta{0}", _regione.Nome);
        }
    }
}
