using System;
using System.Linq;

namespace Alessio.Exercises5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Fiat",1);
            car.addOwner("mario");
            car.addOwner("alex");
            car.addOwner("fausto");
            // car.RemoveOwner("Elena");
            //car.ExpandCar(15);
        }

        //public void ExpandCounter(string[] arraySourse,int length)
        //{
        //    Array.Copy()
        //}

        public static void DichiarazioneStatica()
        {
            string[] strings = new string[5];
            string a = "a";
            string b = "b";
            string c = "c";
            string d = "d";
            string e = "e";
            string f = "e";

            strings[0] = a;
            strings[1] = b;
            strings[2] = c;
            strings[3] = d;
            strings[4] = e;
            strings[5] = f;
        }
        public static void DichiarazioneDinamica()
        {
            string[] strings = new string[] { "a", "b", "c", "d", "e", "f", "g" };

            strings[3] = "z";
            Console.WriteLine(strings[3]);
        }

        public static void ArrayIteration()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            // iterare tutti gli elenmenti dell'array a patto che rispetti la dimensione max dell'array! 



            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                Console.WriteLine(numbers[i]);
            }

        }
        public static void LinqFunction()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Sum());

        }
        public static void FindItem()
        {
            string[] items = new string[] { "Bruno", "Marco", "Elena", "Fabio" };
            var result = Array.Find(items, i => i.Equals("Bruno"));
            Console.WriteLine(result);
        }
        public static void StartWithM()
        {
            string[] items = new string[] { "Bruno", "Marco", "Elena", "Mario" };
            var result = Array.FindAll(items, i => i.Length == 5); //LAMBDA FUCNTION 
        }
        public static void FindPosition()
        {
            string[] items = new string[] { "Bruno", "Marco", "Elena", "Mario" };
            var index = Array.IndexOf(items, "Bruno");
            Console.WriteLine(items[index]);
        }
        public static void LAMBDAFucntions()
        {
            string[] items = new string[] { "Bruno", "Marco", "Elena", "Mario" };
            var result = items.Where(i => i == "Bruno");
            var sorted = items.OrderByDescending(i => i == "Bruno");
            var GroupBy = items.GroupBy(i => i == "Bruno");
            Car car = new Car("FIAT", 5);
            car.addOwner("Bruno");

        }
    }

    class Car
    {
        //const int TotOwners = 4; // di istanza 
        string _name;
        string[] _owners;
        int counter;
        public Car(string Name, int totOwners)
        {
            _name = Name;
            _owners = new string[totOwners];
        }

        public void addOwner(string Name)
        {
            //  
            if (counter < _owners.Length)
            {
                _owners[counter] = Name;
                counter++;
            }
            else if   (counter >= _owners.Length) 
            {
                string[] items = new string[counter+1];
                Array.Copy(_owners, items, _owners.Length);
                _owners = items;
                _owners[counter] = Name;
                counter++;
            }
        }
        public void RemoveOwner(string Name)
        {
            Person[] items = new Person[] {
                new Person() { Name = "Bruno" } ,
                new Person() { Name = "Marco" },
                new Person() { Name = "Elena" },
                new Person() { Name = "Mario" },
                new Person() { Name = "Fabio" },
               };

            var index = Array.IndexOf(items, Name);
            items[index] = null;

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
            
        }
        public void ExpandCar(int length)
        {
            string[] items = new string[length];

            if (_owners.Length < length)
            {
                Array.Copy(_owners,items,_owners.Length);
                _owners = items;
            }
        }
    }
    
    
    class Person
    {   
        public string Name { get; set; }
    }
}

