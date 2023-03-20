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
            Lavoratore _persona =(Lavoratore)persona;
         
                if (_persona.Maturita >= 90)
                {
                    Punteggio += 7;
                }
                if (_persona.Age >= 18 && _persona.Age <= 28)
                {
                    Punteggio += 6;
                }
                if (_persona.Universita >= 28)
                {
                    Punteggio += 6;
                }
                if (!_persona.FedinaPenale)
                {
                    Punteggio += 4;
                }
                switch (_persona.Figli)
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
                if (_persona.Militare)
                {
                    Punteggio += 4;
                }
                if (!(_persona.Debiti))
                {
                    Punteggio += 8;
                }
                if (_persona.PilComune < 1000000M)
                {
                    Punteggio += 8;
                }

                  if (Punteggio >= indeceBonus && _persona.IsAdult)
                {
                Console.WriteLine("Premio raggiunto");
                _persona.Bonus += 1000;
                _persona.BonusRicevuto = true;
                }
                else
                {
                    _persona.Bonus = 0;
                }
            
        }
    }
}
