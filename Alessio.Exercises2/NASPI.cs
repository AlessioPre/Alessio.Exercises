using System;

namespace Alessio.Exercises2
{
    internal class NASPI:AssegnoSociale
    {
        private const int _indiceNaspi= 20;

        public static int IndiceNaspi { get { return _indiceNaspi; } }


        public override void CalcolaBonus(Persona persona)
        {
            try
            {
                Disoccupato disoccupato = (Disoccupato)persona;

                if (disoccupato.AssengnoRicevuto || (2023 - disoccupato.AnnoUltimoLavoro) <= 1)
                {
                    Console.WriteLine("Assegno già ricevuto");
                }
                else
                {
                    if (disoccupato.TipoDiContratto == "determinato")
                    {

                        Punteggio += 3;

                    }
                    else if (disoccupato.TipoDiContratto == "indeterminato")
                    {
                        Punteggio += 3;
                    }
                    if (disoccupato.TempoImpiego == "full-time")
                    {
                        Punteggio += 5;
                    }
                    else if (disoccupato.TempoImpiego == "part-time")
                    {
                        Punteggio += 3;
                    }
                    if (disoccupato.SettimaneLavorate>= 30)
                    {
                        Punteggio += 3;
                        int settimanebonus = (disoccupato.SettimaneLavorate - 30)/4;
                        for (int i = 0; i < settimanebonus; i++)
                        {
                            Punteggio += 1;
                        }
                    }

                    if (Punteggio >= IndiceNaspi)
                    {
                        this.InviaBonus(disoccupato);
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Errore"); }
        }

        private void InviaBonus(Disoccupato disoccupato)
        {
            disoccupato.Bonus = 1000; 
            disoccupato.AssengnoRicevuto = true;
        }
    }
}
