using Alessio.Exercises4.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Alessio.Exercises4.FinancialIntermediary;

namespace Alessio.Exercises4.Classi
{
    internal class FIAT : Asset
    {
        public static decimal _euroPrice = 1;
        decimal _gbpPrice = 0.89M;
        private decimal _fiatAmount;

        DateTime _curretDate;
        private decimal _curretAmount;
        private decimal _daylyDrawMax;
        private decimal _mounthlyDrawMax;

        //public override decimal AmountInEuro { get => EuroAmount + (GbpAmount * _gbpPrice); } // Converti in EURO. Per esempio, se ho altre FIAT come Dollari, Yen , Sterline 
        public decimal FiatAmount { get => _fiatAmount; set => _fiatAmount = value; }
        public FIAT(string name, Fiat type, decimal value) : base(name, value)
        {
            FiatAmount += value;
        }
    }
}