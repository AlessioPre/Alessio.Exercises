using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises11
{
    internal class Server
    {
        string _ip;
        static int serverN;
        string _iPSection01;
        string _iPSection02;
        string _iPSection03;

        public Server()
        {
            serverN += 1;
            Console.WriteLine("Server creato{0}", serverN);
        }

        public string IPSection01 { get => _iPSection01; set => _iPSection01 = value; }
        public string IPSection02 { get => _iPSection02; set => _iPSection02 = value; }
        public string IPSection03 { get => _iPSection03; set => _iPSection03 = value; }
        public string Ip { get => _ip; private set 
            { _ip = value; } }

        public void setIp()
        {
            _ip = IPSection01+"."+ IPSection02 + "." + IPSection03 ;
            Console.WriteLine("Ip del Server {0}",_ip);
        }

        public string GetIp()
        {
            return Ip;
        }
      
    }
}
