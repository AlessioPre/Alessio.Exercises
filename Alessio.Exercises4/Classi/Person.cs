using System;
using System.Data;
using System.Runtime.InteropServices;

namespace Alessio.Exercises4.Classi
{
    public abstract class Person
    {
        string  _name;
        string  _cf;
        int     _age;

        DateTime _birthDay;
        public Person( string name , string cf , DateTime birthday)
        {
            _name = name;
            _cf = cf;
            _birthDay = birthday;
            _age = DateTime.Now.Year-birthday.Year;
        }

        public string Name { get => _name; }
        public int Age { get => _age; }
        public DateTime BirthDay { get => _birthDay; }
        public string Cf { get => _cf; set => _cf = value; }
    }
}