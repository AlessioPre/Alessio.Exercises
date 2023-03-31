using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alessio.Exercises4.Classi;
using static Alessio.Exercises4.Classi.CommercialBank;

namespace Alessio.Exercises4
{
    public abstract class Bank
    {
        int    _id;
        string _name;
        string _country;

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Country { get { return _country; } set { _country = value; } }

        public Bank() { }

        public Bank(string name,string country)
        {
            Name = name;
            Country = country;
        }
        public virtual bool Transfer(Bank to, FiatTransferRequest data)
        {
            return false;
        }
        public virtual bool Transfer(Bank to, BankAccount account, FiatTransferRequest data)
        {
            return false;
        }
    }
}