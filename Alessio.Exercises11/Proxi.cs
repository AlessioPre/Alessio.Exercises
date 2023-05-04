using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises11
{
    public sealed class Proxi
    {

        const int _numberServer = 4;
        Server server = null;
        //membro privato che rappresenta l'instanza della classe
        private static Proxi _instance;
        List<Server> servers = new List<Server>();
        //membro privato per la sincronizzaz dei thread
        private static readonly Object _sync = new Object();

        //costruttore privato non accessibile dall'esterno della classe
        private Proxi() 
        {
            for (int i = 0; i < _numberServer; i++)
            {
                server = new Server();
                server.IPSection01 = new Random().Next(100,999).ToString();
                server.IPSection02 = new Random().Next(100,999).ToString();
                server.IPSection03 = new Random().Next(1000,9999).ToString();
                servers.Add(server);
                server.setIp();
            }
        
        }

        //Entry-Point: proprietà esterna che ritorna l'istanza della classe
        public static Proxi Instance
        {
            get
            {
                //per evitare richieste di lock successive alla prima istanza
                if (_instance == null)
                {
                    lock (_sync) //area critica per la sincronizz dei thread
                    {
                        //vale sempre per la prima istanza
                        if (_instance == null)
                        {
                            _instance = new Proxi();
                        }
                    }
                }
                return _instance;
            }
        }

        public void GetIp()
        {
            int x = new Random().Next(0, _numberServer);

            Console.WriteLine( servers[x].GetIp());

        }
    }
}
