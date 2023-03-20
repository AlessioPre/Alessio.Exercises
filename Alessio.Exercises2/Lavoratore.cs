using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises2
{
    internal class Lavoratore : Persona
    {
        
        decimal _stipendio;
        string _contratto;

        public decimal Stipendio { get { return _stipendio; } set { _stipendio = value; } }
        public string Contratto { get { return _contratto; } set { _contratto = value; } }

      

        public Lavoratore(string name, string surname, int age, int maturita, bool militare, decimal pilcomune, int figli, int università,bool fedinaPenale, bool debiti,decimal stipendio ,string contratto) : base(name, surname, age,maturita,università,fedinaPenale ,figli,militare,debiti,pilcomune)
        {
            Stipendio = stipendio;
            Contratto = contratto;
        }

        public override void GetValues()
        {
            base.GetValues();

            Console.WriteLine($"Lavoratore con contratto {this.Contratto}");
            Console.WriteLine($"Stipendio {this.Stipendio}");

            if (this.BonusRicevuto)
            {
                Console.WriteLine($"Bonus ricevuto: {Bonus}\n");
            }
            else
            {
                Console.WriteLine("Nessun bonus ricevuto\n");
            }
        }
    }
}
