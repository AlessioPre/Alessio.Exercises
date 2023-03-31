using Alessio.Exercises4.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises4.Classi
{
    public class WorldBank
    {
        public static bool Transfer(CommercialBank from, CommercialBank to, FiatTransferRequest data)
        {
            if (from.cEntralBank is ISansionable && to.cEntralBank is ISansionable)
            {
                return true;
            }
            else
            {
                if (from.cEntralBank is not ISansionable)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"The Source bank {from.Name}  from {from.Country} is not in the Swift System. " +
                        $"It's prpbably under Sanction! ");
                    Console.ResetColor();
                }
                if (to.cEntralBank is not ISansionable)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"The destination bank {to.Name}  from {to.Country} is not in the Swift System. " +
                        $"It's prpbably under Sanction! ");
                    Console.ResetColor();

                }
                return false;
            }
        }

    }
}
