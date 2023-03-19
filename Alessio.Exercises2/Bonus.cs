using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises2
{
    internal class Bonus:AssegnoSociale
    {
        const int indeceBonus = 35;

        public Bonus()
        {
            
        }


        public override void CalcolaBonus(Persona persona)
        {
            try
            {
                Persona nonLavoratore = (Disoccupato)persona;

                if (true)
                {

                }
                if (persona.Maturita >= 90)
                {
                    Punteggio += 7;
                }
                if (persona.Age >= 18 && persona.Age <= 28)
                {
                    Punteggio += 6;
                }
                if (persona.Universita >= 28)
                {
                    Punteggio += 6;
                }
                if (!persona.FedinaPenale)
                {
                    Punteggio += 4;
                }
                switch (persona.Figli)
                {
                    case 1:
                        Punteggio += 2;
                        break;
                    case 2:
                        Punteggio += 4;
                        break;
                    case 3:
                        Punteggio += 4;
                        break;
                    case 4:
                        Punteggio += 4;
                        break;
                    case 5:
                        Punteggio += 6;
                        break;
                    case >6:
                        Punteggio += 8;
                        break;
                    default:
                        Punteggio += 0;
                        break;
                }
                if (persona.Militare)
                {
                    Punteggio += 4;
                }
                if (persona.Debiti)
                {
                    Punteggio += 8;
                }
                if (persona.PilComune < 1000000M)
                {
                    Punteggio += 8;
                }

                if (Punteggio >= indeceBonus && persona.IsAdult)
                {
                    persona.Bonus += 1000;
                }
                else
                {
                    persona.Bonus = 0;
                }
            }
        }
    }
}
