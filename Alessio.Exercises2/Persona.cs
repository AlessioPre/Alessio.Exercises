using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises2
{
    public class Persona
    {
        static int counter = 0;
        private string  _name;
        private string  _surname;
        private int     _age;
        private bool    _isAdult;
        private int     _bonus;
        private decimal _pilComune;
        private int     _maturita;
        private int     _universita;
        private bool    _fedinaPenale;
        private int     _figli;
        private bool    _militare;
        private bool    _debiti;
        private int     _punteggio;
        private int     _premio;
        bool            _bonusRicevuto = false;

        public bool BonusRicevuto { get { return _bonusRicevuto; } set { _bonusRicevuto = value; } }
        public string   Name { get { return _name; } set { _name = value; } }
        public string   Surname { get { return _surname; } set { _surname = value; } }
        public string   FullName { get { return _name + " " + _surname; }  }
        public bool     IsAdult { get { return _isAdult; } set { _isAdult= value; } }
        public int  Bonus { get => _bonus; set => _bonus = value; }
        public decimal  PilComune { get => _pilComune; set => _pilComune = value; }
        public int  Maturita { get => _maturita; set => _maturita = value; }
        public int  Universita { get => _universita; set => _universita = value; }
        public bool FedinaPenale { get => _fedinaPenale; set => _fedinaPenale = value; }
        public int  Figli { get => _figli; set => _figli = value; }
        public bool Militare { get => _militare; set => _militare = value; }
        public bool Debiti { get => _debiti; set => _debiti = value; }
        public int  Punteggio { get => _punteggio; set => _punteggio = value; }
        public int  Age { get => _age; set => _age = value; }
        public int  Premio { get => _premio; set => _premio = value; }

        public Persona(

            string Name,
            string Surname,
            int Age,
            int Maturita,
            int Universita,
            bool FedinaPenale,
            int Figli,
            bool Militare,
            bool Debiti,
            decimal PilComune

            )
        {
            this.Name       = Name;
            this.Surname    = Surname;
            this.Age        = Age;
            this.Maturita   = Maturita;
            this.Universita   = Universita;
            this.FedinaPenale = FedinaPenale;
            this.Figli      = Figli;
            this.Militare   = Militare;
            this.Debiti     = Debiti;
            this.PilComune  = PilComune;


            counter++;
            setIsAdult();
            //if (IsAdult)
            //{
            //    CalcolaBonus();
            //    Premio = Bonus;
            //}

        }
        public void getValues()
        {
            //Console.WriteLine(
            //$"Nome:{_name}\n " +
            //$"Cognome:{_surname}\n" +
            //$"Age:{_age}" +
            //$"Maturita:{_maturita}" +
            //$"FedinaPenale:{_fedinaPenale}" +
            //$"Debiti: {_debiti}"
            //);

            Console.WriteLine($"Age:{Age}");
            Console.WriteLine($"Maturita:{Maturita}");
            Console.WriteLine($"Debiti:{Debiti}");
            Console.WriteLine("FedinaPenale:{0}", FedinaPenale);
            Console.WriteLine($"Universita:{Universita}");
            Console.WriteLine($"FedinaPenale:{FedinaPenale}");
            Console.WriteLine($"Figli:{Figli}");
            Console.WriteLine($"Militare:{Militare}");
            Console.WriteLine($"PilComune:{PilComune}");
        }
        public int getCounter()
        {
            return counter;
        }

        private void setIsAdult()
        {
            if (Age > 18)
            {
                _isAdult = true;
            }
            else
            {
                _isAdult = false;
            }
        }

        public virtual void GetValues()
        {
            Console.WriteLine($"Nome: {Name}");
            Console.WriteLine($"Cognome: {Surname}");
            Console.WriteLine($"Age: {this.Age}");

           
        }
    }
}

