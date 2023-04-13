using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Alessio.Exercises4.Classi;
using Alessio.Exercises4.Enum;

namespace Alessio.Exercises4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creo la bancha centrale swift
            SwiftCentralBank UECentralBank = new SwiftCentralBank("Bank Italia", "Italia","roma","via vittorio emanuele");

            // Creo stock market
            StockMarket market = new StockMarket("piazzaffari","italia");

            // creo la banca centrale no swift
            CentralBank RuCentralBank = new CentralBank("ru","russia");

            //creo la banca commerciale
            CommercialBank mediolanumBank = new CommercialBank("Mediolanum", "italia","Roma","via piazzale roma");
            CommercialBank intesa = new CommercialBank("intesa", "italia", "milano","via cavalieri vittorio veneto");


            CommercialBank rucommercialBank = new CommercialBank("falceEmartello","mongolia","imalaya","strada del picco nevoso ");
            // Aggiungo la banca commerciale alla banca centrale
            UECentralBank.AddCommercialBank(mediolanumBank);
            UECentralBank.AddCommercialBank(intesa);
            RuCentralBank.AddCommercialBank(rucommercialBank);
            // Aggiungo lo stock Market alla banca
            mediolanumBank.AddStockMarket(market);

            //creo l'account e successivamente creo un client per lui
            mediolanumBank.CreateAccount("Alessio", "prslss92l10f499q", new DateTime(1992, 07, 10));
            long IBAN = mediolanumBank.GetIban("prslss92l10f499q");// ID account Meglio
            intesa.CreateAccount("alex", "dddalx98r17t555y", new DateTime(1998,11,17));
            long Iban3 = intesa.GetIban("dddalx98r17t555y");
            //////////////
            rucommercialBank.CreateAccount("vlad", "cccp999Urss64", new DateTime(1000, 01, 19));
            long IBAN2 = rucommercialBank.GetIban("cccp999Urss64");
           
            //Creo lo stock da associare al market
            market.CreateStock(Stock.DINSNEY, 12, 3000);
          
            //Aggungo asset all account
            mediolanumBank.AddFiat(Fiat.EURO,IBAN);//stringa da sostituire con enum 
            mediolanumBank.AddFiat(Fiat.YEN,IBAN);
            mediolanumBank.AddCrypto("Bitcoin",IBAN);

            intesa.AddFiat(Fiat.EURO, Iban3);
            //DEPOSITo asset nell'account

            //Aggiungo all'account un asset fiat di tipo euro con un valore di....
            mediolanumBank.DepositFiat(10000,IBAN, Fiat.EURO);
            intesa.DepositFiat(10000, Iban3, Fiat.EURO);
            mediolanumBank.DepositFiat(10000, IBAN, Fiat.YEN);
            //Aggiungo all'account un asset crypto di tipo btc con un valore di....
            mediolanumBank.DepositCrypto(10000, IBAN, Crypto.BTC);
            
            //Creo un nuovo stock nello stock market
            market.CreateStock(Stock.TESLA ,11000, 340M);
            //Compro stock asset
            mediolanumBank.BuyStock(Stock.TESLA,Fiat.EURO,1000,IBAN);
            //Aggiungo all'account un asset Stock di tipo euro con un valore di....
            //mediolanumBank.InvestInStock(10000, Stock.DINSNEY,"Disney", IBAN);

            intesa.AddStockMarket(market);
            intesa.BuyStock(Stock.TESLA,Fiat.EURO,10,Iban3);
            ///////////////////// Transfer
            /// trasferimento  impossibile
            mediolanumBank.Transfer(rucommercialBank, new FiatTransferRequest{_amount = 10,_accountfrom = IBAN , _accountTo = IBAN2 });
            //trasferimento possibile
            mediolanumBank.Transfer(intesa, new FiatTransferRequest { _amount = 20, _accountfrom = IBAN, _accountTo = Iban3 });


            //rimuovo banca commerciale dal circuito
           UECentralBank.RemoveCommercialBank(intesa);

            //rimuovo Account dalla banca
            rucommercialBank.RemoveAccount(IBAN2);

            //rimuovi asset da un account
            //mediolanumBank.RemoveAsset("euro",IBAN);



            //string path = "E:\\FileBanca";
            //string filename = $"{mediolanumBank.Accounts[0].ClientAccount.Name}.txt";
            ////FileWriter.CreateFile(path,filename);
            //FileWriter.WriteFile(path, filename, DateTime.Now, mediolanumBank.Name, mediolanumBank.Accounts[0],+1000);

        }
    }
}
