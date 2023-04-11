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


        const int   _timeOpen = 13;
        const int   _timeClose = 21;
        string      _currentOperationDateTime;
        CultureInfo _coltureInfo;

        public StockMarket() : base("")
        {

        }

        protected override Asset Buy(int amount, FinancialIntermediary interme,CultureInfo info)
        {
            DateTime dateTime = DateTime.Now;
           
            if (CheckTime(dateTime))
            {
                _currentOperationDateTime = dateTime.ToString("dddd,dd MMMM yyyy HH:mm:ss",new CultureInfo("it"));
                return new STOCK("",Stock.DINSNEY,amount,_currentOperationDateTime,this._coltureInfo);

            }
            else 
            {
                Console.WriteLine("operazione impossibile riprovare dopo le ore {0}",_timeOpen);
                return null;
            }
        }

        public bool CheckTime(DateTime dateTime)
        {
            
            int hour = dateTime.Hour;
            if (hour >= _timeOpen && hour <= _timeClose)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class STOCK : Asset
        {
            decimal _stockAmount;
            decimal _stockPrice = 500;
            CultureInfo _cultureInfo;
            string _currentOperationDateTime;
            // public override decimal AmountInEuro { get => _stockAmount * _stockPrice; }
            public decimal StockAmount { get => _stockAmount; set => _stockAmount = value; }
            public STOCK(string name, Stock type, decimal Amount,string dateoperation,CultureInfo cultureInfo) : base(name, Amount)
            {
                _currentOperationDateTime=dateoperation;
                _stockAmount = Amount;
                _cultureInfo = cultureInfo;
            }
        }
    }
}
