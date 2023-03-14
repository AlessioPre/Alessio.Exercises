using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Provincia : Area_Geografica
    {
        //var
        private string  _assessore_provinciale;
        private string  _iniziali_provincia;
        private Regione _regione;
        private Comune  _comune;
        //property
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
        //metodi
        public Provincia(Regione regione, string name)
        {
            this.Nome = name;
            _regione = regione;
            Console.WriteLine("la provincia {0} è stata creata ", this.Nome);
            _regione.AddProvincia(this);
        }
        public void GestioneEventiProvinciali()
        {

        }
        public void CreaEventi()
        {

        }
        internal void AddComune(Comune comune)
        {
            _comune = comune;
            Console.WriteLine("Il comune {0} è stato aggiunto ", _comune.Nome);
        }
        internal  void ChangeRegione(Regione regione)
        {
            _regione = regione;
            Console.WriteLine("la Regione è stata cambiata {0} ", _regione.Nome);
        }
    }
}
