using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4
{
    public class FIAT : Asset
    {
        public FIAT(string name, int valueAsset) : base(name, valueAsset)
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