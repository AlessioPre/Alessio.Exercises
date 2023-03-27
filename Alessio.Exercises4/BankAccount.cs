using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4
{
    public class BankAccount
    {
        private Asset _asset;
        private CRYPTO _assetCrypto;
        private STOCK _assetStock;
        private FIAT _assetFiat;
        private string _accountName;
        private Client _client;
        private int _amount;
        private string _currency;
        private int _id;


        public BankAccount() { }
        public BankAccount(string name,int id) 
        {
            this.Id = Id;
            CreateClientAccount(name);
        }

        public CRYPTO AssetCrypto { get => _assetCrypto; set => _assetCrypto = value; }
        public STOCK AssetStock { get => _assetStock; set => _assetStock = value; }
        public string AccountName { get => _accountName; set => _accountName = value; }
        public FIAT AssetFiat { get => _assetFiat; set => _assetFiat = value; }
        public int Id { get => _id; set => _id = value; }
        private Client ClientAccount { get => _client; set => _client = value; }

        void CreateClientAccount(string name)
        {
            ClientAccount = new Client(name);
        }

        void DeleteAccount(string name, int id)
        {

        }

        /// <summary>
        /// Metodi aggiunta Asset
        /// </summary>
        /// <param name="asset"></param>
        public void AddAssetFiat(FIAT asset)
        {
            AssetFiat = asset;
        }

        public void RemoveAssetFiat(FIAT asset)
        {
            AssetFiat = null;
        }

        public void AddAssetStock(STOCK asset)
        {
            AssetStock = asset;
        }

        public void RemoveStock(STOCK asset)
        {
            AssetStock = null;
        }
        public void AddCrypto(CRYPTO asset)
        {
            AssetCrypto = asset;
        }

        public void RemoveCrypto(CRYPTO asset)
        {
            AssetCrypto = null;
        }

        internal void TransfertAssetFiat()
        {
          
        }

        class Client
        {
            static int count=0;
            int _id;
            string _name;

            public Client() { }
            public Client(string name)
            {
                _name = name;
                _id += count;
            }

            public string Name { get => _name; set => _name = value; }
            public int Id { get { return _id; } }
        }
    }
}