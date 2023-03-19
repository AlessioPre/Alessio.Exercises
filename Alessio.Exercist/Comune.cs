using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
     class Comune : Area_Geografica
    {
        private string      _municipio;
        private int         _cap;
        private Provincia   _provincia;
        private Abitanti    _abitanti;
        public Comune(Provincia provincia, string name)
        {
            this.Nome = name;
            this._provincia = provincia;
            Console.WriteLine("il comune  è stato creato {0} ", this.Nome);
            _provincia.AddComune(this);
        }
        public int      CAP
        {
            get { return _cap; }
            set
            {
                _cap = value;
            }
        }
        public string   Municipio
        {
            get { return _municipio; }
            set
            {
                _municipio = value;
            }
        }
        //Metodi
        public void EmettiSanzione()
        {

        }
        public void AddCittadino(Abitanti abitanti)
        {
            _abitanti = abitanti;
            Console.WriteLine("Cittadino aggiunto {0}",_abitanti.Nome ) ;
        }
        public void ChangeProvincia(Provincia provincia)
        {
            _provincia = provincia;
            Console.WriteLine("Provincia cambiata{0}", _provincia.Nome);
        }
    }
}
