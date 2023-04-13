using Alessio.Exercises4.Classi;
using Alessio.Exercises4.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises4
{
    internal class StockMarket :StockIntermediary
    {
        #region var
        string      _name;
        string      _currentOperationDateTime;
        string      _country;
        CultureInfo _coltureInfo;
        STOCK[]     _stocks;
        TimeSpan    _openTime;
        TimeSpan    _closeTime;

        CommercialBank[] _commercialBanks;
        #endregion
        #region property
        public string Name { get => _name; set => _name = value; }
        internal STOCK[] Stocks { get => _stocks; set => _stocks = value; }
        internal CommercialBank[] CommercialBanks { get => _commercialBanks; set => _commercialBanks = value; }
        public TimeSpan OpenTime { get => _openTime; set => _openTime = value; }
        public TimeSpan CloseTime { get => _closeTime; set => _closeTime = value; }
        public string Country { get => _country; set => _country = value; }
        #endregion
        #region constructor
        public StockMarket(string name,string country)
        {
            Name = name;
            Country = country;
            OpenTime = TimeSpan.Parse("9:00");
            CloseTime = TimeSpan.Parse("17:30");
            Stocks = new STOCK[0];
            CommercialBanks = new CommercialBank[0];
        }
        #endregion
        #region Method
        protected override Asset Buy(Stock name, int amount, FinancialIntermediary interme)
        {
        DateTime dateTime = DateTime.Now;
            STOCK stockAsset = FindStockAsset(name.ToString().ToLower());
            if (stockAsset is null) return null;

            if (CheckTime(dateTime))
            {
                _currentOperationDateTime = dateTime.ToString("dddd,dd MMMM yyyy HH:mm:ss",new CultureInfo("it"));
                return stockAsset;
            }
            else 
            {
                Console.WriteLine("operazione impossibile riprovare dopo le ore {0}",OpenTime.ToString());
                return null;
            }
        }

        private STOCK FindStockAsset(string assetName)
        {
            STOCK stockAsset = Array.Find(Stocks, stock => stock.Name == assetName);
            return stockAsset;
        }

        public bool CheckTime(DateTime dateTime)
        {
            TimeSpan actualTime = DateTime.Now.TimeOfDay;

            if (this.OpenTime <= actualTime && CloseTime >= actualTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region StockMethod
        internal void CreateStock(Stock type, int quantity, decimal amount)
        {
            STOCK stock = new STOCK(type,amount,DateTime.Now.ToString(),this._coltureInfo);
            AddStockAsset(stock); 
        }
        private void AddStockAsset(STOCK stock)
        {
            STOCK [] temporaryArray = new STOCK[Stocks.Length + 1];
            Array.Copy(Stocks, temporaryArray,Stocks.Length);
            Stocks = temporaryArray;
            Stocks[Stocks.Length - 1] = stock;

            stock.AddStockMarket(this);
        }
        #endregion
        public void AddCommercialBank(CommercialBank commercialBank)
        {
            CommercialBank[] temporaryArray = new CommercialBank[CommercialBanks.Length + 1];
            Array.Copy(CommercialBanks, temporaryArray, CommercialBanks.Length);
            CommercialBanks = temporaryArray;
            CommercialBanks[CommercialBanks.Length - 1] = commercialBank;

            commercialBank.AddStockMarket(this);
        }
        #endregion
        public class STOCK : Asset
        {
            #region var
            decimal _stockAmount;
            decimal _stockPrice ;
            CultureInfo _cultureInfo;
            StockMarket _stockMarket;
            string _currentOperationDateTime;
            // public override decimal AmountInEuro { get => _stockAmount * _stockPrice; }
            public decimal StockAmount { get => _stockAmount; set => _stockAmount = value; }
            internal StockMarket StockMarket { get => _stockMarket; set => _stockMarket = value; }
            public decimal StockPrice { get => _stockPrice; set => _stockPrice = value; }
            public CultureInfo CultureInfo { get => _cultureInfo; set => _cultureInfo = value; }

            public STOCK(Stock type, decimal Amount,string dateoperation,CultureInfo cultureInfo) : base(type.ToString().ToLower())
            {
                _currentOperationDateTime=dateoperation;
                _stockAmount = Amount;
                CultureInfo = cultureInfo;        
            }

            internal void AddStockMarket(StockMarket stockMarket)
            {
               this.StockMarket = stockMarket;
            }
        }
        #endregion
    }
}
