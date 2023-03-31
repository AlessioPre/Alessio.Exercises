using System;
using Alessio.Exercises4.Classi;
using Alessio.Exercises4.Enum;

namespace Alessio.Exercises4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// creo le banche centrali
            /// 
            CentralBank UECentralBank = new CentralBank("Bank Italia","Italia");
            //creo la banca commerciale
            CommercialBank mediolanumBank = new CommercialBank("Mediolanum","Firenze",UECentralBank);
            // Aggiungo la banca commerciale alla banca centrale
            UECentralBank.AddCommercialBank(mediolanumBank);
            //creo l'account e successivamente creo un client per lui
           mediolanumBank.CreateAccount("Alessio","PRSLSS92L10F499Q");
            //Aggiungo all'account un asset fiat di tipo euro con un valore di....
            mediolanumBank.DepositFiat(10000, mediolanumBank.Accounts[0].Id, Fiat.EURO,"");
            //Aggiungo all'account un asset crypto di tipo btc con un valore di....
           mediolanumBank.DepositCrypto(10000, mediolanumBank.Accounts[0].Id, Crypto.BTC, "");
            //Aggiungo all'account un asset Stock di tipo euro con un valore di....
           mediolanumBank.InvestInStock(10000, Stock.DINSNEY,"", mediolanumBank.Accounts[0].Id);
            // mostro l'account richiesto e tutto quello che possiede...
           
            StockMarket market = new StockMarket();
            
        }
    }
}
