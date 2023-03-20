using System;

namespace Alessio.Exercises2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona paolo = new Lavoratore("Paolo", "Fumagalli",26,91,true,1000000M,4,28,false,false,200000,"part-time");
            Persona gianluca = new Disoccupato("Gianluca", "Rossi", 33, 89, 26, false, 0, false, false, 30000000M, "Indeterminato", "Part-time", 22,2022);

            AssegnoSociale naspi = new NASPI();
            AssegnoSociale bonus = new Bonus();

            bonus.CalcolaBonus(paolo);
            paolo.GetValues();
            //naspi.CalcolaBonus(paolo);

            naspi.CalcolaBonus(gianluca);
            gianluca.GetValues();

        }
    }
}
