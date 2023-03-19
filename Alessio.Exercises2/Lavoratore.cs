using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alessio.Exercises2
{
    internal class Lavoratore : Persona
    {
        private string _contrattoLavorativo;


        public Lavoratore(string name, string surname, int age, int maturita, bool militare, decimal pilcomune, int figli, int università, int maturità,bool fedinaPenale, bool debiti) : base(name, surname, age,maturita,università,fedinaPenale ,figli,militare,debiti,pilcomune)
        {
            Name = name;
            Surname = surname;
            Age = age;  
        }
    }
}
