using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises4
{
    internal class FinancialIntermediary
    {
        private CultureInfo _cultureInfo;
        protected virtual Asset Buy(int amount,FinancialIntermediary type,CultureInfo cultureInfo)
        {
            if (type._cultureInfo == cultureInfo)
            {
                if (type is StockMarket)
                {
                    StockIntermediary intermediary = (StockIntermediary)type;
                    return intermediary.Buy(amount, intermediary,cultureInfo);
                }
                else
                {
                    CryptoIntermediaty intermediary = (CryptoIntermediaty)type;
                    return intermediary.Buy(amount, intermediary, cultureInfo);
                }
            }
            Console.WriteLine("transazione impossibile");
            return null;
        }

        public abstract class Asset
        {
            decimal _valueAsset;
            string _name;

            public decimal ValueAsset { get { return _valueAsset; } set { _valueAsset = value; } }
            public string Name { get { return _name; } set { _name = value; } }

            public Asset(string name, decimal valueAsset)
            {
                Name = name;
                ValueAsset = valueAsset;
            }
        }
    }
}
