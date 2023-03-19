using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class ONU : Organizzazione
    {
        //var
        private int     _nCaschi_blu;
        private int     _nAiuti_schierati;
      
        //property
        public int N_Caschi_Blu
        {
            get { return _nCaschi_blu; }
            set
            {
                _nCaschi_blu = value;
            }
        }
        public int N_Aiuti_schierati
        {
            get { return _nAiuti_schierati; }
            set
            {
                _nAiuti_schierati = value;
            }
        }
        //costruttore
        public ONU()
        {
            //Paese = paese;
            //Console.WriteLine("paese ha fatto richiesta alla ONU: {0}",Paese.Nome);
            //this.AggiungiStato(Paese);
        }

        public void AiutiUmanitari()
        {

        }
    }
}
