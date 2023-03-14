using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercist
{
    public class ONU : Organizzazione
    {
        private int _nCaschi_blu;
        private int _nAiuti_schierati;

        public ONU(Paese paese)
        {
            Console.WriteLine("paese aggiunto all ONU: {0}", paese.Nome);
        }
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

        public void AiutiUmanitari()
        {

        }
    }
}
