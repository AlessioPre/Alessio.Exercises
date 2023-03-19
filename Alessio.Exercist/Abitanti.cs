using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
     class Abitanti
    {
        private string _nome;
        private string _cognome;
        private string _codice_fiscale;
        private string _data_di_nascita;
        private string _luogo_di_nascita;
        private Comune _comune;

        public Abitanti(Comune comune, string nome)
        {
            Nome            = nome;
            this._comune    = comune;
            Console.WriteLine("l'abitante{0} è stato creato", this.Nome);
            _comune.AddCittadino(this);

        }

        public string CodiceFiscale
        {
            get { return _codice_fiscale; }
            set
            {
                _codice_fiscale = value;
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
        public string Cognome
        {
            get { return _cognome; }
            set
            {
                _cognome = value;
            }
        }
        public string Luogo_di_Nascita
        {
            get { return _luogo_di_nascita; }
            set
            {
                _luogo_di_nascita = value;
            }
        }
        public string Data_di_Nascita
        {
            get { return _data_di_nascita; }
            set
            {
                _data_di_nascita = value;
            }
        }

        //Metodi
        public void Vota()
        {

        }

        public void ChangeComune( Comune comune)
        {
            _comune = comune;
            Console.WriteLine("Comune cambiato");
        }
    }
}
