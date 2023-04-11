using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Alessio.Exercises4.Classi;
using Alessio.Exercises4.Enum;
using static Alessio.Exercises4.Classi.CommercialBank;

namespace Alessio.Exercises4
{
    internal abstract class Bank:FinancialIntermediary
    {
        int    _id;
        string _name;
        string _country;
        CultureInfo _cultureInfo;
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Country { get { return _country; } set { _country = value; } }

        public Bank() { }

        public Bank(string name,string country)
        {
            Name = name;
            Country = country;
            SetCulture(country);
        }

        private void SetCulture(string country)
        {
            switch (country.ToLower())
            {
                case "italia":
                    _cultureInfo = new CultureInfo("it");
                    break;
                case "usa":
                    _cultureInfo = new CultureInfo("en-US");
                    break;
                case "japan":
                    _cultureInfo = new CultureInfo("jpn");
                    break;
                case "spagna":
                    _cultureInfo= new CultureInfo("es-ES");
                    break;

            }
        }

        public virtual bool Transfer(Bank to, FiatTransferRequest data)
        {
            return false;
        }
        public virtual bool Transfer(Bank to, BankAccount account, FiatTransferRequest data)
        {
            return false;
        }

        //internal override Ass Buy(StockMarket marketname, int value,CultureInfo info)
        //{
        //    base.Buy(value, marketname,info);
        //}

        protected override Asset Buy(int amount, FinancialIntermediary type, CultureInfo cultureInfo)
        {
            return base.Buy(amount, type, cultureInfo);
        }
    }
}