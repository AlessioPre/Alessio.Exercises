using Alessio.Exercises4.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4.Classi
{

    public class CentralBank : Bank
    {
        #region Var
        const int _interestmax = 5; //%
        int _interstRate    =   0;
        int _countComBank;
        static int _count   =   0;
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
            
                Name = name;
                Id  = _count+1;
                Country = country;
                CommercialBanks = new CommercialBank[0];
               _count ++;
        }
        #endregion
        #region Method
        public void AddCommercialBank(CommercialBank bank)
        {
            _CommercialBank = bank;
           if (Array.Find(CommercialBanks, i => i.Id == _CommercialBank.Id) == null)
            {
                Array.Resize(ref _commercialBanks, CountComBank + 1);
                CommercialBanks[CountComBank] = _CommercialBank;
                CountComBank++;
            }
            else{

                
                    Console.WriteLine("Siamo spiacenti ma la banca è gia stata inserita nel circuito");
                
            }
        }

        public void RemoveCommercialBank(CommercialBank bank)
        {
            var result = CommercialBanks.Where(i => i.Id != bank.Id).ToArray();
            CommercialBanks = result;
        }
        #endregion
        #region Funcion
        public bool CheckTransfer(Bank from, Bank to, FiatTransferRequest data)
        {
            if (from.Country == to.Country)
            {
                return from.Transfer(to, data);
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