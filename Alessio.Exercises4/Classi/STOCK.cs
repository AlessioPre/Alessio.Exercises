using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alessio.Exercises4.Classi;
using Alessio.Exercises4.Enum;

namespace Alessio.Exercises4.Classi
{
    public class STOCK : Asset
    {
        decimal _stockAmount;
        decimal _stockPrice = 500;
        // public override decimal AmountInEuro { get => _stockAmount * _stockPrice; }
        public decimal StockAmount { get => _stockAmount; set => _stockAmount = value; }
        public STOCK(string name,Stock type ,decimal Amount) : base(name, Amount)
        {

        }
    }
}