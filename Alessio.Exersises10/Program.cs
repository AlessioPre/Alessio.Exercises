using System;
using static Alessio.Exersises10.CentralBank;

namespace Alessio.Exersises10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommercialBank mediolanum = new CommercialBank("mediolanum", "Antonio", "Bruno");
            StockMarket piazzaAffari = new StockMarket("piazzaAffari", "Luca", "Mikami");
            CryptoEx Etoro = new CryptoEx("Etoro", "Andrea", "Giusti");

            CentralBank bancaCentraleItaliana = new CentralBank("Banca d'Italia", "Ignazio", "Visco");
            bancaCentraleItaliana.ChangedCEO += mediolanum.NotifyCentralBankCEOChanged;
            bancaCentraleItaliana.ChangedCEO += piazzaAffari.NotifyCentralBankCEOChanged;
            bancaCentraleItaliana.ChangedCEO += Etoro.NotifyCentralBankCEOChanged;


            bancaCentraleItaliana.ChangeCEO("Mario", "Rossi");
        }
    }
}
