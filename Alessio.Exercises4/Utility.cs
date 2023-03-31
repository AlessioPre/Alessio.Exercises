using Alessio.Exercises4.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises4
{
    internal class Utility
    {
        public static void GetAccountInfo(ConsoleColor consoleColor, CommercialBank bank, bool isDeposit, FiatTransferRequest data)
        {
            int index = Array.IndexOf(bank.Accounts, data._accountTo);
            Console.WriteLine($"Account Number: {bank.Accounts[index].Id}");
            Console.WriteLine($"Account Client: {bank.Accounts[index].ClientAccount.Name}");
            Console.ForegroundColor = consoleColor;
            Console.WriteLine($"Amount {(isDeposit ? "Deposited" : "Withdrawn")}: {data._amount}");
            Console.ResetColor();
            // Console.WriteLine($"Account Balance: {bank.account.Balance}");

            Console.WriteLine("-------------------------------------");
        }
    }
}
