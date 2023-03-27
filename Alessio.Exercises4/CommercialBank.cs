using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4
{
    public class CommercialBank:Bank
    {
        int interest;

        BankAccount _account;
        public BankAccount Account { get { return _account; } }

        public int Interest { get => interest; set => interest = value; }

        public CommercialBank()
        {
            
        }
        public void AddAccount(BankAccount account)
        {
            this._account = account;
        }


        public void RemoveAccount(BankAccount account)
        {
            this._account = null;
        }

        internal void CalcolateInteres(BankAccount account)
        {
            throw new NotImplementedException();
        }

        internal void GetInterest()
        {
            throw new NotImplementedException();
        }
    }
}