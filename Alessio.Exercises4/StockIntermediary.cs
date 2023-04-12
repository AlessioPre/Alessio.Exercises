using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises4
{
    internal abstract class StockIntermediary : FinancialIntermediary
    {
        protected override Asset Buy(string name ,int amount, FinancialIntermediary interme)
        {
            StockIntermediary stockMarket = (StockIntermediary)interme;
            StockMarket stockMarkets = (StockMarket)stockMarket;
            return base.Buy(name,amount, stockMarket);
        }
    }
}
