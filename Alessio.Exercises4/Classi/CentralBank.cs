using Alessio.Exercises4.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4.Classi
{

    internal class CentralBank : Bank
    {
        #region Var
        const int _interestmax = 5; //%
        int _interstRate;
        int _countComBank;
        static int _count;
        CommercialBank _commercialBank;
        CommercialBank[] _commercialBanks;
        #endregion
        #region Property
        public static int Interestmax => _interestmax;
        public int InterstRate { get => _interstRate; set => _interstRate = value; }
        public CommercialBank _CommercialBank { get => _commercialBank; set => _commercialBank = value; }
        public int CountComBank { get => _countComBank; set => _countComBank = value; }
        public CommercialBank[] CommercialBanks { get => _commercialBanks; set => _commercialBanks = value; }
        #endregion
        #region Costructor
        public CentralBank() { }

        public CentralBank(string name, string country) : base(name, country)
        { 
                Id  = _count+1;
                CommercialBanks = new CommercialBank[0];
               _count ++;
        }

        public CentralBank(string name, string country, CultureInfo culture)
        {
            CommercialBanks = new CommercialBank[0];
        }

        public CentralBank(string name, string country, string city, string street) : base(name, country, city, street)
        {
            Id = _count + 1;
            CommercialBanks = new CommercialBank[0];
            _countComBank = CommercialBanks.Length;
            _count++;
        }
        #endregion
        #region Method
        public void AddCommercialBank(CommercialBank bank)// aggiunge la banca
        {
            _CommercialBank = bank; //passo il valore di riferimento
             // controllo se l'id è già esistete ,se non esiste lo aggiungo all'array... 
           if (Array.Find(CommercialBanks, i => i.Id == _CommercialBank.Id) == null)
            {
                Array.Resize(ref _commercialBanks, CountComBank + 1);
                CommercialBanks[CountComBank] = _CommercialBank;
                CountComBank++;

                bank.AddCentralBank(this);//associo la banca centrale alla banca commerciale
            }
            else{ Console.WriteLine("Siamo spiacenti ma la banca è gia stata inserita nel circuito"); }//...altrimento segnalo la sua esistenza   
        }

        public void RemoveCommercialBank(CommercialBank bank)
        {
            var result = CommercialBanks.Where(i => i.Id != bank.Id).ToArray();
            CommercialBanks = result;
        }
        #endregion
        #region Function
        public bool CheckTransfer(Bank from, Bank to, FiatTransferRequest data)
        {
            if (from.Country == to.Country)
            {
                return true;
            }
            else
            {
                if (WorldBank.Transfer((CommercialBank)from, (CommercialBank)to, data))
                {
                    return true;
                }
                return false;
            }
        }
        #endregion
    }


}