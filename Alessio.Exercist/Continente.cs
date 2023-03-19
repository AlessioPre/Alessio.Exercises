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
        private string          _emisfero;
        private List<Paese>    _listaPaesi;
        private Paese           _paese;
        private static int      _nstati;
        private Continente      _continente;
        //property
        public int Nstati
        {
            get { return _nStati; }
            set { _nStati = value; }
        }
        public string Emisfero
        {
            get { return _emisfero; }
            set { _emisfero = value; }
        }
       // public Paese Paese 
        //{ get { return _paese;} 
        //  set { _paese = value;}
        //}

        //public List<Paese> ListaPaesi { get => _listaPaesi; set => _listaPaesi = value; }

        //costruttore
        public Continente(string continentenome, string clima, decimal popolazione , string etnia ,string emisfero):base (continentenome, clima,popolazione,etnia)
        {
            Nome    =   continentenome;  
            Clima   =   clima;
            Etnia   =   etnia;
            Emisfero =  emisfero;
            Popolazione= popolazione;
           _listaPaesi = new List<Paese>();
        }
        public Continente(string continentenome)
        {
            Nome= continentenome;
            _listaPaesi= new List<Paese>();
        }
        //Metodi

        public override void CreateState(string nomestato)
        {
            _paese = new Paese(nomestato);
            this.Add(_paese);
        }


       protected override void Add(Area_Geografica paese)
        {
            Paese paesse = (Paese)paese;
            _listaPaesi.Add(paesse);
            _paese = null;
        }

        public void GetListaPaesi()
        {
            Console.WriteLine("I Paesi appartenenti al continente {0} sono :",this.Nome);
            for (int i = 0; i < _listaPaesi.Count; i++)
            {
                Console.WriteLine(" {0} \n",_listaPaesi[i].Nome );
            }      
        }

        public override void ChangeState(Area_Geografica area_Geografica)
        {
            _continente = (Continente)area_Geografica;
            if (_continente.GetType()==this.GetType())
            {
                area_Geografica.CreateState(this._listaPaesi[0].Nome);
                this._listaPaesi[0] = null;
            }
        }


    }




    class Paese : Area_Geografica
    {
        //var
        private string _forma_di_governo;
        private string _capo_di_stato;
        private string _capitale;
        private int _numero_Regioni;
        private int _numero_Province;
        private string _lingua;
        private Regione _regione;
        private Unione_europea _unioneEuropea;
        private ONU _onu;
        private NATO _nato;
        //Property
        public string FormaDiGoverno
        {
            get { return _forma_di_governo; }
            set
            {
                _forma_di_governo = value;
            }
        }
        public string CapoDiStato
        {
            get { return _capo_di_stato; }
            set
            {
                _capo_di_stato = value;
            }
        }
        public string Capitale
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
        public int NumeroRegioni
        {
            get { return _numero_Regioni; }
            set
            {
                _numero_Regioni = value;
            }
        }
        public string Lingua
        {
            get { return _lingua; }
            set
            {
                _lingua = value;
            }
        }
        public int NumeroProvince
        {
            get { return _numero_Province; }
            set
            {
                _numero_Province = value;
            }
        }

        //Costruttore
        public Paese(string name, decimal popolazione) : base(name, popolazione)
        {
            this.Nome = name;
            this.Popolazione = popolazione;
        }
        public Paese(string name) : base(name)
        {
            this.Nome = name;
            Console.WriteLine("Paese creato");
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
            _regione = regione;
            Console.WriteLine(" Regione aggiunta{0}", _regione.Nome);
        }
        internal void AddOrganizationUE(Unione_europea organizzazione)
        {
            _unioneEuropea = organizzazione;
            Console.WriteLine("rischiesta inviata a organizzazione {0}", _unioneEuropea.Nome);
            _unioneEuropea.AggiungiStato(this);
        }
        internal void AddOrganizationONU(ONU organizzazione)
        {
            _onu = organizzazione;
            Console.WriteLine("rischiesta inviata a organizzazione {0}", _onu.Nome);
            _onu.AggiungiStato(this);
        }
        internal void AddOrganizationNATO(NATO organizzazione)
        {
            _nato = organizzazione;
            Console.WriteLine("rischiesta inviata a organizzazione {0}", _nato.Nome);
            _nato.AggiungiStato(this);
        }

        internal void CreaRegione(string nomeregione)
        {
            throw new NotImplementedException();
        }

        internal void RegioneCreaProvincia(string nomeprovincia)
        {
            throw new NotImplementedException();
        }

        internal void ProvinciaCreaComune(string nomecomune)
        {
            throw new NotImplementedException();
        }

        internal void ChangeRegione(Paese paese)
        {
            throw new NotImplementedException();
        }

        internal void GetRegioneName()
        {
            throw new NotImplementedException();
        }
    }
}
