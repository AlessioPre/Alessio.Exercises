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
        int         _id;
        string      _name;
        string      _country;
        string      _city;
        string      _street;
        CultureInfo _cultureInfo;
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public string City { get => _city; set => _city = value; }
        public string Street { get => _street; set => _street = value; }
        public CultureInfo CultureInfo { get => _cultureInfo; set => _cultureInfo = value; }

        public Bank() { }
        public Bank(string name,string country)
        {
            Name = name;
            Country = country;
            SetCulture(country);
        }

        public Bank(string name,string country,string city ,string street)
        {
            Name = name;
            Country = country;
            City = city;
            Street = street;
            SetCulture(country);
            
        }

        //Assegna la classe culture info
        private void SetCulture(string country)
        {
            switch (country.ToLower())
            {
                case "italia":
                    CultureInfo = new CultureInfo("it");
                    break;
                case "usa":
                    CultureInfo = new CultureInfo("en-US");
                    break;
                case "japan":
                    CultureInfo = new CultureInfo("jpn");
                    break;
                case "spagna":
                    CultureInfo= new CultureInfo("es-ES");
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

        protected override Asset Buy(Stock name ,int amount, FinancialIntermediary type)
        {
            return base.Buy(name,amount, type);
        }
    }
}