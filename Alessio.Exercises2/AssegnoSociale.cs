using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises2
{
    public class AssegnoSociale
    {
        private int punteggio;
        public AssegnoSociale()
        {
            
        }

        public int Punteggio { get => punteggio; set => punteggio = value; }

        public virtual void CalcolaBonus(Persona persona) { }  
    }
}
