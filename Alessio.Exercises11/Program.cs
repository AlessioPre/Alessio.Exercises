using System;

namespace Alessio.Exercises11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Proxi proxi = Proxi.Instance;


            for (int i = 0; i < 10; i++) 
            {
                proxi.GetIp();
            }

            Proxi proxi2 = Proxi.Instance;

            for (int i = 0; i < 10; i++)
            {
                proxi.GetIp();
            }
        }
    }
}
