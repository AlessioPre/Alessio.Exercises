using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises4
{
    internal class StockIntermediary : FinancialIntermediary
    {
        string _name;
        public StockIntermediary(string name)
        {
            _name = name.ToLower();
        }

        protected override Asset Buy(int amount, FinancialIntermediary interme,CultureInfo info)
        {
            StockIntermediary stockMarket = (StockIntermediary)interme;
            StockMarket stockMarkets = (StockMarket)stockMarket;
            return stockMarkets.Buy(amount, stockMarket,info);
        }
    }
}
