using System;
using System.Runtime.InteropServices;
using Alessio.Exercises4.Classi;
using Alessio.Exercises4.Enum;

namespace Alessio.Exercises4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// creo la bancha centrale
            CentralBank UECentralBank = new CentralBank("Bank Italia", "Italia");
            //creo la banca commerciale
            CommercialBank mediolanumBank = new CommercialBank("Mediolanum", "Firenze", UECentralBank);
            // Aggiungo la banca commerciale alla banca centrale
            UECentralBank.AddCommercialBank(mediolanumBank);
            //creo l'account e successivamente creo un client per lui
            mediolanumBank.CreateAccount("Alessio", "PRSLSS92L10F499Q", new DateTime(1992, 07, 10));
            //Aggiungo all'account un asset fiat di tipo euro con un valore di....
            mediolanumBank.DepositFiat(10000, mediolanumBank.Accounts[0].Id, Fiat.EURO, "");
            //Aggiungo all'account un asset crypto di tipo btc con un valore di....
            mediolanumBank.DepositCrypto(10000, mediolanumBank.Accounts[0].Id, Crypto.BTC, "");
            //Aggiungo all'account un asset Stock di tipo euro con un valore di....
            //mediolanumBank.InvestInStock(10000, Stock.DINSNEY,"", mediolanumBank.Accounts[0].Id);

            StockMarket market = new StockMarket();
            mediolanumBank.BuyStock(1,market,mediolanumBank.Culture);


            string path = "E:\\FileBanca";
            string filename = $"{mediolanumBank.Accounts[0].ClientAccount.Name}.txt";
            //FileWriter.CreateFile(path,filename);
            FileWriter.WriteFile(path, filename, DateTime.Now, mediolanumBank.Name, mediolanumBank.Accounts[0],+1000);

        }
    }
}
