using Alessio.Exercises4.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alessio.Exercises4.FinancialIntermediary;

namespace Alessio.Exercises4
{
    internal class CriptoExenge:CryptoIntermediaty
    {
        internal class CRYPTO : Asset
        {
            decimal _cryptoAmount;
            decimal _cryptoPrice = 28000;

            Crypto _type;


            //public override decimal AmountInEuro { get => _cryptoAmount * _cryptoPrice; }
            public decimal CryptoAmount { get => _cryptoAmount; set => _cryptoAmount += this.ValueAsset; }
            public Crypto Type { get => _type; set => _type = value; }

            public CRYPTO(Crypto type, decimal Amount) : base(type.ToString().ToLower())
            {
                this.Type = type;
            }
        }
    }
}
