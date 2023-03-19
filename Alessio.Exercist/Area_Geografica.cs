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
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
            }
        }
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
        public string Etnia
        {
            get { return _etnia; }
            set
            {
                _etnia = value;
            }
        }

        //costruttore
         public Area_Geografica(string nome, string clima ,decimal popolazione , string etnia)
        {
            Nome    = nome;
            Clima   = clima; 
            Etnia   = etnia; 
            Popolazione = popolazione;
        }

        public Area_Geografica(string nome, string clima, decimal popolazione)
        {
            Nome    = nome;
            Clima   = clima;
            Popolazione = popolazione;
        }

        public Area_Geografica(string nome, decimal popolazione)
        {
            Nome = nome;
            Popolazione = popolazione;
        }

        public Area_Geografica(string nome)
        {
            Nome = nome;
        }

        public Area_Geografica() { }

        public void Definisci_confini()
        {

        }
        public void gestione_fondi()
        {

        }
        public string PrintListFauna()
        {
            return "methodo non implementato";

        }
        public string PrintListFlora()
        {
            return "methodo non implementato";
        }
        //Create
        public  virtual void CreateState(string nomestato) 
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        public virtual void CreateRegion(string nomestato) 
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        public virtual void CreateProvince(string nomestato) 
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        public virtual void CreateMunicipality(string nomestato) 
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        //Change
        public virtual void ChangeState(Area_Geografica area_Geografica) 
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        //
        public virtual void ChangeRegion(string vecchistato, string nuovostato ,string nomeregione) 
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        ///
        public virtual void ChangeProvince(string stato, string nuovaregione, string vecchiaregione, string nomeProvincia)
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        public virtual void ChangeProvince(string nuovaregione, string vecchiaregione, string nomeProvincia)

        { Console.WriteLine("Metodo virtual dell'area geografica"); } 
        ///
        public virtual void ChangeMunicipality(string nomeregione,string vecchiaprovincia, string nuovaprovincia, string nomecomune)
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        public virtual void ChangeMunicipality(string nomepaese, string nomeregione, string vecchiaprovincia ,string nuovaprovincia , string nomecomune)
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
        public virtual void ChangeMunicipality(string vecchiaprovincia, string nuovaprovincia, string nomecomune)
        { Console.WriteLine("Metodo virtual dell'area geografica"); }
       //Add
       protected virtual void Add(Area_Geografica area)
        { Console.WriteLine("Metodo virtual dell'area geografica"); }

        protected virtual void Add(string nome) { Console.WriteLine("Metodo virtual dell'area geografica"); }
    }
}
