using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class NATO : Organizzazione
    {
        //var
        private int     _nPaesi_aderenti;
        
        public int Paesi_Aderenti
        {
            get { return _nPaesi_aderenti; }
            set
            {
                _nPaesi_aderenti = value;
            }
        }
        //costruttore
        public NATO()
        {
            //Paese= paese;
            //Console.WriteLine("paese ha fatto richiesta alla Nato: {0}", Paese.Nome);
            ////this.AggiungiStato(paese);
        }

        //metodi
        public void StuzicaRussia()
        {

        }
        public void OrganizzaIncontro()
        {

        }

       

    }
}
