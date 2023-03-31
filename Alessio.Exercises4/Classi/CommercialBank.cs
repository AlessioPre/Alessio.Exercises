using Alessio.Exercises4.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4.Classi
{
    public class CommercialBank : Bank
    {
        #region Var
        int _interest;
        BankAccount _account;
        BankAccount[] _Accounts;
        CentralBank _centralBank;
        static int _counter;
        int _counterAccount;
        #endregion
        #region Property
        public BankAccount _Account { get { return _account; } }
        public int Interest { get => _interest; set => _interest = value; }
        public BankAccount[] Accounts { get => _Accounts; set => _Accounts = value; }
        public CentralBank cEntralBank { get => _centralBank; set => _centralBank = value; }
        public static int Counter { get => _counter; }
        public int CounterAccount { get => _counterAccount; set => _counterAccount = value; }
        #endregion
        #region contructor
        public CommercialBank()
        {

        }

        public CommercialBank(string name, string country, CentralBank uECentralBank) : base(name, country)
        {
            _counter++;//-> Tiene il conto di tutte le banche create dal programma e lo utilizza come Id per le benche commerciali
            Name = name;
            Country = country;
            Id = Counter;
            Accounts = new BankAccount[CounterAccount];
            CounterAccount = 0;// -> tiene il conto di tutti gli account creati dalla banca
        }
        #endregion
        #region Method
        #region Creazione e Distruzione Account
        //Creo un nuovo Account
        public void CreateAccount(string name, string cf)
        {
            //Controllo se il codice fiscale è gia nell'array di account
            if (Array.Find(Accounts, Account => Account.ClientAccount.Cf == cf) == null)//se l'elemento account ha un cliente con lo stesso codice fiscale non creare l'account
            {
                _account = new BankAccount(name,cf, this);

                AddAccount(_account);
            }
            else
            {
                Console.WriteLine("Cliente già esistente");
            }
        }
        //Controllo se l'Id che ha ricevuto in ingesso esite
        public void RemoveAccount(long accountNumber)
        {
            if (Array.Exists(Accounts, i => i.Id == accountNumber))
            {
                var result = Accounts.Where(i => Id != accountNumber).ToArray();//Se esiste Allora ricreo l'array di account eliminando l'elemento passato
                Accounts = result;
            }
        }
        #endregion
        #region Aggiungo Account all'Array
        //Aggiungo un nuovo Account All'ARRAY accounts
        public void AddAccount(BankAccount account)
        {
            BankAccount[] items = new BankAccount[_counter + 1];
            Array.Copy(Accounts, items, Accounts.Length);
            Accounts = items;
            Accounts[CounterAccount] = account;
            account.AddAccounts(account.ClientAccount.ClientId);
            CounterAccount++;
        }
        #endregion


        // Controllo  Se il Transfer tra Account di diversi paesi è possibile
        public override bool Transfer(Bank to, BankAccount acTo, FiatTransferRequest data)
        {
            //DownCasting il dato in ingresso
            CommercialBank commercialBank = (CommercialBank)to;
            if (this.cEntralBank.CheckTransfer(this, to, data))
            {
                /// 
                //Prima di procedere con il versamento verificare che sia possibile e che i saldo sia sufficente
                ///
                if (this.CheckTransfer(data._amount, data._accountfrom))
                {
                    var account = Array.Find(Accounts, account => account.Id == data._accountfrom);
                    if (account != null)
                    {
                        int index = Array.IndexOf(Accounts, account);

                        // confronto le due cifr dopo il prelievo. 
                        Utility.GetAccountInfo(ConsoleColor.Red, this, false, data);

                        //transferTo.account.DepositFIAT(data._amount);
                        Utility.GetAccountInfo(ConsoleColor.Green, commercialBank, true, data);


                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"The  amount {data._amount} from the account {data._accountfrom} from the Bank {this.Name} to " +
                            $"account {data._accountTo} of from the Bank {to.Name} has been made! ");
                        Console.ResetColor();

                        return true;
                    }
                }


            }

            // return base.Transfer(to, account, data);
            return false;
        }

        private bool CheckTransfer(decimal amount, long accountfrom)
        {
            int index = Array.IndexOf(Accounts, accountfrom);
            if (amount > Accounts[index].AssetFiat.ValueAsset)
            {
                Console.WriteLine("transazione impossibile");
                return false;
            }
            else
            {
                return true;
            }
        }


        #region Deposit And draw Asset
        public void DepositFiat(long Amount, long accountID,Fiat type,string name)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].DepositFIAT(Amount,type,name);
            }
        }
        public void DepositCrypto(decimal Amount,long accountID,Crypto type,string name)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].DepositCrypto(Amount,type,name);
            }
        }
        public void InvestInStock(decimal Amount,Stock type, string name, long accountID)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].SellStoks(Amount, name, type);
            }
        }
        public void WithdrawFIAT(decimal Amount, Fiat type, string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].WithdrawFIAT(Amount,type, kindOfValue);
            }
        }
        public void WithdrawCrypto(decimal Amount, string kindOfValue, long accountID)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].WithdrawCrypto(Amount, kindOfValue);
            }
        }
        public void SellStoks(decimal Amount, string kindOfValue,Stock type ,long accountID)
        {
            var result = Array.Find(Accounts, i => i.Id == accountID);
            // Check Client // è biondo!
            if (result != null)
            {
                var index = Array.IndexOf(this.Accounts, result);
                Accounts[index].SellStoks(Amount, kindOfValue,type);
            }
        }
        #endregion

        public void FindAccount(BankAccount account)
        {
            var result = Array.Find(Accounts, i => i.Equals(account.Id));
            if (result != null)
            {

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Account non trovato");
            }
        }



        internal void CalcolateInteres(BankAccount account)
        {
            throw new NotImplementedException();
        }

        internal void GetInterest()
        {
            throw new NotImplementedException();
        }

        internal void InterestInStock(int v, long id, Stock dINSNEY)
        {
            throw new NotImplementedException();
        }
        #endregion

        public class BankAccount
        {
            #region var
            int _count;
            static int _accountCount;

            CommercialBank _commercialBank;
            Client _client;
            ///
            long _id;
            CRYPTO _crypto;
            STOCK _stock;
            FIAT _fiat;
            Asset[] _assets;

            
            decimal _totAmount;
            decimal _interests;
            string  _currency;
            decimal _balance;
            #endregion

            #region property
            public CRYPTO AssetCrypto { get => _crypto; set => _crypto = value; }
            public STOCK AssetStock { get => _stock; set => _stock = value; }
            public FIAT AssetFiat { get => _fiat; set => _fiat = value; }
            public long Id { get => _id; set => _id = value; }
            public Client ClientAccount { get => _client; }
            public decimal TotAmount { get => _totAmount; set => _totAmount = value; }
            public string Currency { get => _currency; set => _currency = value; }
            public Asset[] Assets { get => _assets; set => _assets = value; }
            public decimal Interests { get => _interests; set => _interests = value; }
            public decimal Balance { get => _balance; set => _balance = value; }
            public CommercialBank CommercialBank { get => _commercialBank; set => _commercialBank = value; }
            public int Count { get => _count; }
            public static int AccountCount { get => _accountCount; }
            #endregion
            public BankAccount() { }
            public BankAccount(string Clientname, string ClientCf,CommercialBank commercialBank)
            {
                this.CommercialBank = commercialBank;
                this._client = new Client(Clientname,ClientCf,this);
                this.Id = new Random().Next(10000,1000000);
                Assets = new Asset[Count];
                _accountCount++;
            }

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
            decimal CalcAmount()
            {
                decimal _fiatTotalAmount = 0;
                decimal _cryptoTotalAmount = 0;
                decimal _stockTotalAmount = 0;
                foreach (var item in this.Assets)
                {
                    if (item is Fiat)
                    {
                        _fiatTotalAmount += item.ValueAsset;
                    }
                }
                return _fiatTotalAmount + _cryptoTotalAmount + _stockTotalAmount;

            }
            /// <summary>
            /// Metodi aggiunta Asset
            /// </summary>
            /// <param name="asset"></param>
            public void DepositFIAT(decimal Amount,Fiat type, string kindof)
            {
                _fiat = new FIAT(kindof, type,Amount);
                var asset = Array.Find(Assets, A => A.Name == kindof);
                if (asset != null)
                {
                    Assets[Assets.Length] = _fiat;
                }
            }
            public void WithdrawFIAT(decimal Amount,Fiat type, string kindOf)
            {
                var asset = Array.Find(Assets, A => A.Name == kindOf);
                if (asset != null)
                {
                    int index = Array.IndexOf(Assets, asset);
                    ((FIAT)Assets[index]).FiatAmount -= Amount;
                }
            }
            public void InvestInStoks(decimal Amount,Stock type ,string kindof)
            {
                _stock = new STOCK (kindof,type,Amount);
                var asset = Array.Find(Assets, A => A.Name == kindof);
                if (asset == null)
                {
                    Assets[Assets.Length] = _stock;
                }
            }
            public void SellStoks(decimal Amount, string kindOf,Stock type)
            {
                var asset = Array.Find(Assets, A => A.Name == kindOf);
                if (asset != null)
                {
                    int index = Array.IndexOf(Assets, asset);
                    Assets[index].ValueAsset -= Amount;
                }
            }
            public void DepositCrypto(decimal Amount,Crypto type,string name)
            {
                _crypto = new CRYPTO(type, Amount,name);
                var asset = Array.Find(Assets, A =>((CRYPTO) A).Type == type);
                if (asset != null)
                {
                    Assets[Assets.Length] = _crypto;
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
            internal void TransfertAssetFiat()
            {

            }


           public class Client
            {
                #region var
                static int count = 0;
                string _name;
                string _cf;
                BankAccount _account;
                long _clientId;
                BankAccount[] _accounts;
                int _counter;
                #endregion
                #region property
                public string Name { get => _name; set => _name = value; }
                public long ClientId { get => _clientId; }
                public string Cf { get => _cf; set => _cf = value; }
                public BankAccount[] Accounts { get => _accounts; set => _accounts = value; }
                #endregion
                public Client(string ClientName, string ClientCF, BankAccount account)
                {
                    Cf = ClientCF;
                    Name = ClientName;
                    _account = account;
                    _clientId = new Random().Next(10000, 100000);
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
    }
}