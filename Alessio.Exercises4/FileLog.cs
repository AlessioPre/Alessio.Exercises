using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alessio.Exercises4.Classi.CommercialBank;

namespace Alessio.Exercises4
{
    internal static class FileLog
    {
        static string   _dir = "E:\\FileBanca";
        static string   _filename = "AccountOperation";
        static string _format = ".txt";
        static FileLog() { }

        public static string Dir { get => _dir; }
        public static string Filename { get => _filename; set => _filename = value; }
        public static string Format { get => _format; set => _format = value; }

        public static void WriteFile(string path, string FileName,DateTime dateTime, string bankname,BankAccount account,decimal operation)
        {
            StringBuilder sb = new StringBuilder();
            string FilePath = Path.Combine(path, FileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(FilePath))
            {
                string heater = string.Format("Movimenti del conto di {0} {1} della banca {2}", account.ClientAccount.Name, account.ClientAccount.ClientId, account.CommercialBank.Name);
                sb.AppendLine(heater);
               
            }
            else
            {
                string body = string.Format("Data : {0} Movimento : {1} saldo Attuale {2}",dateTime,operation,account.AssetFiat.FiatAmount += operation);
                sb.AppendLine(body);
            }
                File.AppendAllText(FilePath, sb.ToString());
        }

        static void ReadFile(string dir , string filename)
        {
            var text = File.ReadAllText(System.IO.Path.Combine(dir, filename));

            Console.WriteLine(text);
        }

        public static void DeleteLogFile(string dir, string fileName)
        {
            File.Delete(Path.Combine(_dir,fileName));
        }
    }
}
