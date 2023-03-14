using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class Comune : Area_Geografica
    {
        private string _municipio;
        private int _cap;
        private Provincia _provincia;
        public Comune(Provincia provincia, string name)
        {
            this.Nome = name;
            this._provincia = provincia;
            Console.WriteLine("il comune {0} fa parte della provincia: {1}", this.Nome, _provincia.Nome);
        }

        public int CAP
        {
            get { return _cap; }
            set
            {
                _cap = value;
            }
        }

        public string Municipio
        {
            get { return _municipio; }
            set
            {
                _municipio = value;
            }
        }

        public void EmettiSanzione()
        {

        }

        public void AddCittadino(Abitanti abitanti)
        {

        }
    }
}
