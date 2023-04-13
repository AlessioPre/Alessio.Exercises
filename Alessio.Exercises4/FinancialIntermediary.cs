using Alessio.Exercises4.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alessio.Exercises4.Classi.CommercialBank;

namespace Alessio.Exercises4
{
    internal abstract class FinancialIntermediary
    {
        protected virtual Asset Buy(Stock name,int amount,FinancialIntermediary type)
        {
                if (type is StockMarket)
                {
                    StockIntermediary intermediary = (StockIntermediary)type;
                    return intermediary.Buy(name,amount, intermediary);
                }
                else if (type is CryptoIntermediaty)
                {
                    CryptoIntermediaty intermediary = (CryptoIntermediaty)type;
                    return intermediary.Buy(name,amount, intermediary);
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

            public Asset(string name)
            {
                Name = name;
               
            }
            public virtual void Deposit(decimal amount, BankAccount bankAccount) { }
        }
    }
}
