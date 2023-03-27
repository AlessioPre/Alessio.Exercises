using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4
{ 

    public class CentralBank:Bank
    {

        static int interestmax = 5; //%

        CommercialBank _commmercialBank;
        public CentralBank() { }
        public void AddCommercialBank(CommercialBank bank)
        {
            _commmercialBank = bank;
        }

        public void RemoveCommercialBank(CommercialBank bank)
        {
            if (_commmercialBank.Id == bank.Id)
            {
                _commmercialBank = null;
            }
        }
        public void CheckTranferPossibily(ISansionable country)
        {

        }
    }


}