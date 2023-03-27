using System;

namespace Alessio.Exercises4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            CentralBank UECentralBank = new CentralBank();
            CommercialBank mediolanumBank = new CommercialBank();
            BankAccount account = new BankAccount();
            FIAT fiat  = new FIAT("contanti",100);
            CRYPTO crypto = new CRYPTO("", 1);
            STOCK  stock = new STOCK("microsoft", 100);
            UECentralBank.AddCommercialBank(mediolanumBank);
            mediolanumBank.AddAccount(account);
            account.AddAssetFiat(fiat);       
            account.TransfertAssetFiat();
            mediolanumBank.CalcolateInteres(account);
            mediolanumBank.GetInterest();
           
        }
    }
}
