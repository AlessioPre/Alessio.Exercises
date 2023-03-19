using System;

namespace Alessio.Exercises2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona paolo = new Persona("Paolo", "Fumagalli", 26, 97, 24, false, 14, false, false, 12300000M);
            Persona gianluca = new Disoccupato("Gianluca", "Rossi", 33, 89, 26, false, 0, false, false, 30000000M, "Indeterminato", "Part-time", 22,2022);

            AssegnoSociale naspi = new NASPI();
            AssegnoSociale bonus = new Bonus();

            //naspi.CalcolaBonus(paolo);
            bonus.CalcolaBonus(paolo);
            naspi.CalcolaBonus(gianluca);

            paolo.GetValues();
            gianluca.GetValues();
        }
    }
}
