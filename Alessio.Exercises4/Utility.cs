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
        public static void GetAccountInfo(ConsoleColor consoleColor, CommercialBank bank, bool isDeposit,FiatTransferRequest data)
        {
            if (!isDeposit)
            {
                var account = Array.Find(bank.Accounts, account => account.Iban == data._accountfrom);
                int index = Array.IndexOf(bank.Accounts, account);
                Console.WriteLine($"Account Number: {bank.Accounts[index].Iban}");
                Console.WriteLine($"Account Client: {bank.Accounts[index].ClientAccount.Name}");
                Console.ForegroundColor = consoleColor;
                Console.WriteLine($"Amount {(isDeposit ? "Deposited" : "Withdrawn")}: {data._amount}");
                Console.ResetColor();
                // Console.WriteLine($"Account Balance: {bank.account.Balance}");

                Console.WriteLine("-------------------------------------");
            }
            else
            {
                var account = Array.Find(bank.Accounts, account => account.Iban == data._accountTo);
                int index = Array.IndexOf(bank.Accounts, account);
                Console.WriteLine($"Account Number: {bank.Accounts[index].Iban}");
                Console.WriteLine($"Account Client: {bank.Accounts[index].ClientAccount.Name}");
                Console.ForegroundColor = consoleColor;
                Console.WriteLine($"Amount {(isDeposit ? "Deposited" : "Withdrawn")}: {data._amount}");
                Console.ResetColor();
                // Console.WriteLine($"Account Balance: {bank.account.Balance}");

                Console.WriteLine("-------------------------------------");
            }
        }
    }
}
