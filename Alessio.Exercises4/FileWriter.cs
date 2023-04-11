using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alessio.Exercises4.Classi.CommercialBank;

namespace Alessio.Exercises4
{
    internal static class FileWriter
    {
        static DateTime _datetime;
        static string   _bankName;
        static string   _clientName;

        static decimal _accountNumber;
        static decimal _operation;
        static decimal _Totalamount;

        static FileWriter() { }


        public static void CreateFile(string filepath,string filename)
        {
            string[] names = new string[] {"Alessio","marco"};

            if (!File.Exists(Path.Combine(filepath, filename)))
            {

                //File.Create(filepath);
                //DirectoryInfo info = new DirectoryInfo(filepath);
                File.WriteAllLines(filepath, names);
            }
        }

        public static void WriteFile(string path, string FileName,DateTime dateTime, string bankname,BankAccount account,decimal operation)
        {

            StringBuilder sb = new StringBuilder();
            string FilePath = Path.Combine(path,FileName);

            if (!File.Exists(FilePath))
            {
                string heater = string.Format("Movimenti del conto di {0} {1} della banca {2}", account.ClientAccount.Name, account.ClientAccount.ClientId, account.CommercialBank.Name);
                sb.AppendLine(heater);
                File.AppendAllText(FilePath, sb.ToString());
            }
            else
            {
                string body = string.Format("Data : {0} Movimento : {1} saldo Attuale {2}",dateTime,operation,account.TotAmount += operation);
                sb.AppendLine(body);
                File.AppendAllText(FilePath, sb.ToString());
            }
        }
        static void ReadFile(string dir , string filename)
        {
            var text = File.ReadAllText(Path.Combine(dir, filename));

            Console.WriteLine(text);
        }
    }
}
