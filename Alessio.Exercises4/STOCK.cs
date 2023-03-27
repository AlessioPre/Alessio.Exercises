using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4
{
    public class STOCK : Asset
    {
        public STOCK(string name, int valueAsset) : base(name, valueAsset)
        {
        }

        public BankAccount Client
        {
            get => default(BankAccount);
            set
            {
            }
        }
    }
}