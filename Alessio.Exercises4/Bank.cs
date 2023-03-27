using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alessio.Exercises4
{
    public abstract class Bank
    {
        int _id;
        string _name;

        public int Id { get; set; }
        public string Name { get; set; }
        public Bank() { }

        public Bank(int id)
        {
            Id = id;
        }
    }
}