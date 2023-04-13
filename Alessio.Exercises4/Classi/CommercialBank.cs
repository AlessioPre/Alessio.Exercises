using Alessio.Exercises4.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static Alessio.Exercises4.Classi.CommercialBank;
using static Alessio.Exercises4.CriptoExenge;
using static Alessio.Exercises4.FinancialIntermediary;
using static Alessio.Exercises4.StockMarket;

namespace Alessio.Exercises4.Classi
{
    ///////////////////////////COMMERCIALBANK\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    internal class CommercialBank : Bank
    {
        #region Var
        int _interest;
        static int _counter;
        int _counterAccount;

        BankAccount _account;
        BankAccount[] _Accounts;
        CentralBank _centralBank;
        
        StockMarket _stockMarket;
        #endregion
        #region Property
        public static int Counter { get => _counter; }
        public int Interest { get => _interest; set => _interest = value; }
        public int CounterAccount { get => _counterAccount; set => _counterAccount = value; }

        public BankAccount   Account { get { return _account; } }
        public BankAccount[] Accounts { get => _Accounts; set => _Accounts = value; }
        public CentralBank   cEntralBank { get => _centralBank; set => _centralBank = value; }
        
        public StockMarket   StockMarket { get => _stockMarket; set => _stockMarket = value; }
        #endregion
        #region contructor
        public CommercialBank()
        {

        }
        public CommercialBank(string name, string country, CentralBank uECentralBank) : base(name, country)
        {
            _counter++;//-> Tiene il conto di tutte le banche create dal programma e lo utilizza come Id per le benche commerciali
            Id = Counter;
            CounterAccount = 0;// -> tiene il conto di tutti gli account creati dalla banca
            Accounts = new BankAccount[CounterAccount];
        }

        public CommercialBank(string name, string country, string city, string street) : base(name, country, city, street)
        {
            _counter++;//-> Tiene il conto di tutte le banche create dal programma e lo utilizza come Id per le benche commerciali
            Id = Counter;
            CounterAccount = 0;// -> tiene il conto di tutti gli account creati dalla banca
            Accounts = new BankAccount[CounterAccount];
        }
        #endregion
        #region Method
        #region Account Method
        //Creo un nuovo Account
        public void CreateAccount(string name, string cf, DateTime dateTime)
        {
            //Controllo se il codice fiscale è gia nell'array di account
            if ((Array.Find(Accounts, Account => Account.ClientAccount.Cf == cf) == null) && CheckedAge(dateTime))//se l'elemento account ha un cliente con lo stesso codice fiscale non creare l'account
            {
                _account = new BankAccount(name, cf, dateTime, this);

                AddAccount(_account);
            }
            else
            {
                if (!CheckedAge(dateTime))
                {
                    Console.WriteLine("utente minorenne impossibile aprire il conto");
                }
                else
                {
                    Console.WriteLine("Cliente già esistente");
                }
            }
        }
        //Aggiungo un nuovo Account All'ARRAY accounts
        public void AddAccount(BankAccount account)
        {
            BankAccount[] items = new BankAccount[CounterAccount+ 1];
            Array.Copy(Accounts, items, Accounts.Length);
            Accounts = items;
            Accounts[CounterAccount] = account;
            account.AddAccounts(account.ClientAccount.ClientId);
            CounterAccount++;
        }
        private bool CheckedAge(DateTime dateTime)
        {
            DateTime dateTime1 = DateTime.Now;
            int age = dateTime1.Year - dateTime.Year;
            if (age >= 18)
            {
                return true;
            }
            return false;
        }
        public void RemoveAccount(long accountNumber)
        {
            if (Array.Exists(Accounts, i => i.Id == accountNumber))
            {
                var result = Accounts.Where(i => Id != accountNumber).ToArray();//Se esiste Allora ricreo l'array di account eliminando l'elemento passato
                Accounts = result;
            }
        }
        public BankAccount FindAccount(BankAccount account)
        {
            var result = Array.Find(Accounts, i => i.Equals(account.Id));
            if (result != null)
            {

                Console.WriteLine(result);
                return result;
            }
            else
            {
                Console.WriteLine("Account non trovato");
                return null;
            }
        }
        internal long GetIban(string cf)
        {
            var client = Array.Find(Accounts, client => client.ClientAccount.Cf == cf);
            return client.Iban;
        }

        #endregion
        #region// Controllo  Se il Transfer tra Account di diversi paesi è possibile
        public override bool Transfer(Bank to, FiatTransferRequest data)
        {
            //DownCasting il dato in ingresso
           CommercialBank commercialBank = (CommercialBank)to;
            _account = Array.Find(Accounts, account => account.Iban == data._accountfrom);
            if (_account is null) return false;

            if (this.cEntralBank.CheckTransfer(this, to, data))
            {
                /// 
                //Prima di procedere con il versamento verificare che sia possibile e che i saldo sia sufficente
                ///
                if (this.CheckTransfer(data._amount, _account))
                {
                    var accountfrom = Array.Find(Accounts, account => account.Iban == data._accountfrom);
                    var accountTo = Array.Find(commercialBank.Accounts, account => account.Iban == data._accountTo);
                    if (accountfrom != null)
                    {
                        //int index = Array.IndexOf(Accounts, account);

                        // confronto le due cifr dopo il prelievo. 
                        Utility.GetAccountInfo(ConsoleColor.Red, this, false, data);

                        //transferTo.account.DepositFIAT(data._amount);
                        Utility.GetAccountInfo(ConsoleColor.Green,commercialBank, true, data);

                        //Console.BackgroundColor = ConsoleColor.Green;
                        //Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"The  amount {data._amount} from the account {data._accountfrom} from the Bank {this.Name} to " +
                            $"account {data._accountTo} of from the Bank {to.Name} has been made! ");
                        //Console.ResetColor();

                        FileLog.WriteFile(FileLog.Dir, FileLog.Filename+accountfrom.ClientAccount.Name+FileLog.Format, DateTime.Now, this.Name, Account, data._amount,false);
                        FileLog.WriteFile(FileLog.Dir, FileLog.Filename+accountTo.ClientAccount.Name + FileLog.Format, DateTime.Now, commercialBank.Name, Account, data._amount, true);
                        return true;
                    }
                }
            }
            // return base.Transfer(to, account, data);
            return false;
        }
        private bool CheckTransfer(decimal amount, BankAccount bankAccount)
        {
            int index = Array.IndexOf(Accounts, bankAccount);
            if (index == -1) return false;
            if (amount > Accounts[index].AssetFiat.FiatAmount)
            {
                Console.WriteLine("transazione impossibile");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion//
        #region Deposit And draw Asset
        #region fiat Method
        internal void AddFiat(Fiat fiatType, long iBAN)
        {
            this._account = Array.Find(Accounts, account => account.Iban == iBAN);
            if (Account == null) { return; }
            _account.AddFiatAsset(fiatType);
        }
        public void DepositFiat(long Amount, long iban, Fiat type)
        {
            var result = Array.Find(Accounts, i => i.Iban == iban);
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].DepositFiat(type.ToString().ToLower(),Amount);
            }
        }
        public void WithdrawFIAT(decimal Amount, Fiat type, string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);

            if (result != null && !result._isBlocked)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].WithdrawFIAT(Amount, type);
            }
        }
        public void RemoveFiat(Fiat type, long iban)
        {
            BankAccount account = Array.Find(Accounts, account => account.Iban == iban);
            if (account is null) return;
            account.RemoveFiat(type.ToString());
        }
        #endregion
        #region crypto Method
        internal void AddCrypto(string cryptoType, long iBAN)
        {
            this._account = Array.Find(Accounts, account => account.Iban == iBAN);
            if (Account != null) { return; }
            _account.AddCrypto(cryptoType);
        }
        public void DepositCrypto(decimal Amount, long accountID, Crypto type)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
         
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].DepositCrypto(Amount, type);
            }
        }
        public void WithdrawCrypto(decimal Amount, string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
        
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].WithdrawCrypto(Amount, kindOfValue);
            }
        }
        public void RemoveCrypto(Crypto cryptoAsset, long iban)
        {
            BankAccount account = Array.Find(Accounts, account => account.Iban == iban);
            if (account is null) return;
            account.RemoveCrypto(cryptoAsset);
        }
        #endregion
        #region stock Method
        // public void InvestInStock(decimal Amount,Stock type, string name, long accountID)
        //{
        //    var result = Array.Find(Accounts, i => i.Id == accountID);

        //    if (result != null)
        //    {
        //        var index = Array.IndexOf(this.Accounts, result);
        //        Accounts[index].SellStoks(Amount, name, type);
        //    }
        //}
        public void SellStoks(decimal Amount, string kindOfValue, Stock type, long accountID)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].SellStoks(Amount, kindOfValue, type);
            }
        }
        
        internal void BuyStock(Stock stocktype,Fiat fiattype,int amount,long Iban) // acquisto di stock in commercial bank, la banca dovrà controllare se il la transazione è possibile per via del paese,se ci sono i fondi 
        {

            _account = Array.Find(Accounts, item => item.Iban == Iban);// ricerco l'account tramite iban
            if (_account is null) return;// controllo se esiste

            if ((_account.WithdrawFIAT(amount, fiattype)))// controllo se è possibile ritirare
            {
                var asset = base.Buy(stocktype, amount,_stockMarket);
                if (asset != null)
                {
                    Account.AddStock(asset);
                    FileLog.WriteFile(FileLog.Dir, FileLog.Filename+_account.ClientAccount.Name+FileLog.Format,DateTime.Now,this.Name,_account,amount,false);
                    return;
                }
               // FileLog.WriteFile(FileLog.Dir, FileLog.Filename + _account.ClientAccount.Name + FileLog.Format, DateTime.Now, this.Name, _account, amount);
            }
            else
            {
               // FileLog.WriteFile(FileLog.Dir, FileLog.Filename + _account.ClientAccount.Name + FileLog.Format, DateTime.Now, this.Name, _account, amount);
            }
        }
        #endregion
        internal void CalcolateInteres(BankAccount account)
        {
            throw new NotImplementedException();
        }
        internal void GetInterest()
        {
            throw new NotImplementedException();
        }
        internal void AddStockMarket(StockMarket market)
        {
            if (Country != market.Country)
            { return; }
            StockMarket = market;
        }
        internal void AddCentralBank(CentralBank centralBank)// associo la central bank
        {
            cEntralBank = centralBank;
        }
        protected override Asset Buy(Stock name ,int amount, FinancialIntermediary type)
        {
            return base.Buy(name,amount, type);
        }
        internal void RemoveAsset(string v, long iBAN)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
        ///////////////////////////BANKACCOUNT\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        public class BankAccount
        {
            #region var
            long _id;
            int _count;
            static int _accountCount;
            CultureInfo _culture;
            CommercialBank _commercialBank;
            Client _client;
            ///
            CRYPTO _crypto;
            STOCK _stock;
            FIAT _fiat;
            Asset[] _assets;
            //Asset   stockASSET;

            decimal _totAmount;
            decimal _interests;
            string _currency;
            decimal _balance;
            const decimal _daylyDrawMax = 10000;
            decimal _daylyDraw;

            public bool IsDailyExeed { get; private set; }

            const decimal _mounthlyDrawMax = 30000;
            decimal _mountlyDraw;
            public bool _isBlocked = false;
            DateTime _lastDraw;
            DateTime _blockTime;
            #endregion
            #region property
            internal CRYPTO AssetCrypto { get => _crypto; set => _crypto = value; }
            internal STOCK AssetStock { get => _stock; set => _stock = value; }
            internal FIAT AssetFiat { get => _fiat; set => _fiat = value; }
            public long Id { get => _id; set => _id = value; }
            public Client ClientAccount { get => _client; }
            public decimal TotAmount { get => _totAmount; set => _totAmount = value; }
            public string Currency { get => _currency; set => _currency = value; }
            internal Asset[] Assets { get => _assets; set => _assets = value; }
            public decimal Interests { get => _interests; set => _interests = value; }
            public decimal Balance { get => _balance; set => _balance = value; }
            public CommercialBank CommercialBank { get => _commercialBank; set => _commercialBank = value; }
            public int Count { get => _count; }
            public static int AccountCount { get => _accountCount; }
            public long Iban { get; internal set; }
            public object DayBlocked { get; private set; }
            public bool IsMonthyExeed { get; private set; }
            #endregion
            #region constructor 
            public BankAccount() { }
            public BankAccount(string Clientname, string ClientCf,DateTime birthday, CommercialBank commercialBank)
            {
                this.CommercialBank = commercialBank;
                this._client = new Client(Clientname, ClientCf,this,birthday);
                Iban = new Random().Next(10000, 1000000);
                Assets = new Asset[Count];
                _accountCount++;
            }
            #endregion
            #region Method
                #region account
            public void AddAccounts(long clientId)
            {
                if (clientId == this.ClientAccount.ClientId)
                {
                    this.ClientAccount.AddAccounts(this);
                }
            }
            void DeleteAccount(long clientId)
            {
                if (clientId == this.ClientAccount.ClientId)
                {
                    this.ClientAccount.RemoveAccounts(this);
                }
            }
            #endregion
            decimal CalcAmount()
            {
                decimal _fiatTotalAmount = 0;
                decimal _cryptoTotalAmount = 0;
                decimal _stockTotalAmount = 0;
                foreach (var item in this.Assets)
                {
                    if (item is FIAT)
                    {
                        _fiatTotalAmount += item.ValueAsset;
                    }
                }
                return _fiatTotalAmount + _cryptoTotalAmount + _stockTotalAmount;

            }
            #region fiatMethod
            public void AddFiatAsset(Fiat type)
            {
                _fiat = new FIAT(type);

                Asset[] temporaryArray = new Asset[Assets.Length + 1];
                Array.Copy(Assets, temporaryArray, Assets.Length);
                Assets = temporaryArray;
                Assets[Assets.Length - 1] = _fiat;
            }
            public void DepositFiat(string fiatName, decimal fiatAmount)
            {
                Asset asset = Array.Find(Assets, asset => asset.Name == fiatName);
                if (asset is null) return;

                asset.Deposit(fiatAmount,this);
            }
            //public void DepositFIAT(decimal Amount, Fiat type, string kindof)
            //{
            //    _fiat = new FIAT(kindof, type, Amount);
            //    var asset = Array.Find(Assets, A => A.Name == kindof);
            //    if (asset == null)
            //    {
            //        Asset[] assets1 = new Asset[Assets.Length + 1];
            //        Array.Copy(Assets, assets1, Assets.Length);
            //        Assets = assets1;
            //        Assets[Assets.Length - 1] = _fiat;
            //    }
            //}
            public bool WithdrawFIAT(decimal Amount, Fiat type)
            {
                var asset = Array.Find(Assets, A => A.Name == type.ToString().ToLower());
              
                if (asset is not null) 
                { if (CheckWithDraw(Amount,asset)) return true; }
                return false;
            }
            #endregion
            #region CryptoMethod
            public void DepositCrypto(decimal Amount, Crypto type)
            {
                _crypto = new CRYPTO(type, Amount);
                var asset = Array.Find(Assets, A => A.Name == type.ToString().ToLower());
                if (asset == null)
                {
                    Asset[] assets1 = new Asset[Assets.Length + 1];
                    Array.Copy(Assets, assets1, Assets.Length);
                    Assets = assets1;
                    Assets[Assets.Length - 1] = _crypto;
                }
            }
            public void WithdrawCrypto(decimal Amount, string kindOf)
            {
                var asset = Array.Find(Assets, A => A.Name == kindOf);
                if (asset != null)
                {
                    int index = Array.IndexOf(Assets, asset);
                    Assets[index].ValueAsset -= Amount;
                }
            }
            internal void AddCrypto(string cryptoType)
            {
                throw new NotImplementedException();
            }
            internal void RemoveCrypto(Crypto cryptoAsset)
            {
                throw new NotImplementedException();
            }
            #endregion
            #region StockMethod
            internal void AddStock(Asset stockAsset)
            {
                Asset[] temporaryArray = new Asset[Assets.Length + 1];
                Array.Copy(Assets, temporaryArray, Assets.Length);
                Assets = temporaryArray;
                Assets[Assets.Length - 1] = stockAsset;

                Console.WriteLine($"Nuova stock aggiunta al conto con numero {Iban} di {ClientAccount.Name}. Comprate {stockAsset.Name}");
            }
            public void InvestInStoks(decimal Amount, Stock type)
            {
                _stock = new STOCK(type, Amount, DateTime.Now.ToString(), this._culture);
                var asset = Array.Find(Assets, A => A.Name == type.ToString().ToLower());
                if (asset == null)
                {
                    Assets[_assets.Length] = _stock;
                }
                else
                {
                    var index = Array.IndexOf(Assets, _stock);
                    Assets[index].ValueAsset += _stock.ValueAsset;
                }
            }
            public void SellStoks(decimal Amount, string kindOf, Stock type)
            {
                var asset = Array.Find(Assets, A => A.Name == kindOf);
                if (asset != null)
                {
                    int index = Array.IndexOf(Assets, asset);
                    Assets[index].ValueAsset -= Amount;
                }
            }
            #endregion
            private bool CheckWithDraw(decimal amount, Asset asset)
            {
                if (asset is FIAT)
                {
                    this.AssetFiat = asset as FIAT;
                CheckIsChangeDay();
                CheckIsChangeMonth();
                CheckLimit(amount);
                
                if (IsMonthyExeed)
                {
                    UnlockAccount();
                    return false;
                }
                if (_isBlocked)
                {
                    Console.WriteLine("ACCOUNT BLOCCATO PER  {0}",DayBlocked);
                    return false;
                }
                if (IsDailyExeed)
                {
                    Console.WriteLine("LIMITE GIORNALIERO SUPERATO");
                    return false;
                }
                bool isDrawable = CheckCredit(amount, AssetFiat);
                if (!isDrawable)
                {
                    Console.WriteLine("fondi non sufficenti");
                    return false;
                }
                else
                {
                        this.AssetFiat.FiatAmount -= amount;
                        _daylyDraw += amount;
                        _mountlyDraw+= amount;
                        _lastDraw = DateTime.Now;

                    Console.WriteLine($"Sono stati prelevati {amount} euro. Saldo contabile: {this.AssetFiat.FiatAmount}");
                    return true;
                }

                }
                return false;
            }

            private bool CheckCredit(decimal amount,FIAT fiatasset)
            {
                if (fiatasset.FiatAmount <= 0 || amount > fiatasset.FiatAmount) return false;
                return true;
            }

            private void UnlockAccount()
            {
                if (DateTime.Now > this._blockTime)
                {
                    _isBlocked = false;
                }
            }

            private void CheckLimit(decimal amount)
            {
                DrawUpdateDayly(amount);
                DrawUpdateMountly(amount);
                _lastDraw = DateTime.Now;
            }

            private void CheckIsChangeMonth()
            {
                if (DateTime.Now.Month > _lastDraw.Month)
                {
                    _mountlyDraw = 0;
                    IsMonthyExeed = false;
                }
            }

            private void CheckIsChangeDay()
            {
                if (_lastDraw.Day < DateTime.Now.Day)
                {
                    _daylyDraw = 0;
                    IsDailyExeed = false;
                }
            }

            private void DrawUpdateMountly(decimal amount)
            {
                if (_lastDraw != DateTime.Now)
                {
                    decimal monthlyTot = _mountlyDraw + amount;
                    if (monthlyTot > _mounthlyDrawMax && _mountlyDraw < _mounthlyDrawMax)
                    {
                        DayBlocked = DateTime.Now.AddDays(3);
                        _isBlocked = true;
                        IsMonthyExeed = true;
                    }
                }
           

        }
        private void DrawUpdateDayly(decimal amount)
            {
                if (_lastDraw != DateTime.Now)
                {
                    decimal dailyTot = _daylyDraw += amount;
                    if (dailyTot > _daylyDrawMax) IsDailyExeed = true;
                }
            }

            internal void RemoveFiat(string v)
            {
                throw new NotImplementedException();
            }
            #endregion
            ///////////////////////////CLIENT\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            public class Client :Person
            {
                #region var
                static int count = 0;
                //string _name;
                //string _cf;
                //int _Age;
                long _clientId;
                int _counter;

                CommercialBank _commercialBank;
                BankAccount _account;
                BankAccount[] _accounts;
                #endregion
                #region property
                //public string Name { get => _name; set => _name = value; }
                public long ClientId { get => _clientId; }
                //public string Cf { get => _cf; set => _cf = value; }
                public BankAccount[] Accounts { get => _accounts; set => _accounts = value; }
                internal CommercialBank CommercialBank { get => _commercialBank; set => _commercialBank = value; }


                //public int Age { get => _Age; set => _Age = value; }
                #endregion
                public Client(string ClientName,string cf, BankAccount account,DateTime birthday):base (ClientName,cf,birthday)
                {
                    _account = account;
                    _clientId = new Random().Next(10000, 100000);
                    CommercialBank = _account.CommercialBank;
                    Accounts = new BankAccount[0];
                    //AddAccounts(account);
                }
                public void AddAccounts(BankAccount account)
                {
                    if (!Array.Exists(Accounts, i => i.Id == account.Id))
                    {
                        BankAccount[] items = new BankAccount[_counter + 1];
                        Array.Copy(Accounts, items, Accounts.Length);
                        Accounts = items;
                        Accounts[_counter] = account;
                        _counter++;
                    }
                    else
                    {
                        Console.WriteLine("conto gia esistente");
                    }
                }
                public void RemoveAccounts(BankAccount account)
                {
                    if (!Array.Exists(Accounts, i => i.Id == account.Id))
                    {
                        Accounts[Accounts.Length] = account;
                    }

                }
            }
        }
        ///////////////////////////FIAT\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        internal class FIAT : Asset
        {
            #region var
            public static decimal _euroPrice = 1;
            decimal _gbpPrice = 0.89M;
            private decimal _fiatAmount;

            DateTime _curretDate;
            decimal _curretAmount;
            private Fiat type;
            private decimal amount;
            #endregion
            //public override decimal AmountInEuro { get => EuroAmount + (GbpAmount * _gbpPrice); } // Converti in EURO. Per esempio, se ho altre FIAT come Dollari, Yen , Sterline 
            public decimal FiatAmount { get => _fiatAmount; set => _fiatAmount = value; }

            public FIAT(Fiat type) : base(type.ToString().ToLower())
            {
                this.type = type;
               
            }

            //public override void Deposit(decimal amount)
            //{
            //    FiatAmount += amount;
            //    Console.WriteLine($"Sono stati depositati {amount} euro. Saldo contabile: {FiatAmount}, dal conto di {account.ClientAccount.Name} ,della banca{ account.CommercialBank.Name}");
            //}
            public override void Deposit(decimal amount, BankAccount account)
            {
                FiatAmount += amount;
                Console.WriteLine($"Sono stati depositati {amount} euro. Saldo contabile: {FiatAmount}, dal conto di {account.ClientAccount.Name} ,della banca{account.CommercialBank.Name}");
            }
        }
    }
}