using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;


namespace Alessio.Exersises7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Dato un certo elemento ordinare la lista in ordine crescente decrescente
            ///

            Person alessio = new Person { Name = "Alessio", Surname = "Presciuttini", CF = "PRSLSS92L10F499Q" };
            Person matteo = new Person { Name = "Matteo", Surname = "Luccisano", CF = "LCSMTT98T15G111T" };
            Person cristina = new Person { Name = "Alex", Surname = "sircu", CF = "CRCALX97G21G111K" };
            Person fausto = new Person { Name = "Fausto", Surname = "Boshoff", CF = "BSFFST92G11H501W" };
            Person Mario = new Person { Name = "Mario", Surname = "Di Stefano", CF = "DSTMNC97" };
            List<Person> people = new List<Person>
            {
                alessio, matteo, cristina, fausto
            };
            
            people = Ordered.OrderListAscended(people,"Name");


            people = Ordered.OrderListDiscendent(people,"Name");

            foreach (Person person in people)
                Console.WriteLine(person.Name);

            people = Ordered.OrdinaPerProprieta(people, p => p.Surname);

            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"il nome " + people[i].Name + " " + people[i].Surname);

            }
            List<int> listint = new List<int>() { 1, 2, 3 };
            listint = Ordered.OrdinaPerProprieta(listint, l => l, false);
            for (int i = 0; i < listint.Count; i++)
            {
                Console.WriteLine(listint[i]);

            }
        }
    }

    public class Ordered
    {
    public  static List<T> OrderListAscended<T>(List<T> data ,string typeobj)
        {
            var asclist = data.OrderBy(x => x.GetType().GetProperty(typeobj).GetValue(x)).ToList();
            return asclist;
        }
        public static List<T> OrderListAscended2<T>(List<T> data ,string typeobj)
        {
          
            for (int i = 0; i < data.Count; i++)
            {

            }
            return null;
        }
      
        public static List<T> OrderListDiscendent<T>(List<T> data,string name)
        {
         var deslist=   data.OrderByDescending(x => x.GetType().GetProperty(name).GetValue(x)).ToList();
            return deslist;
        }

        public void OrderListByElement<T>(T data)
    {

    }
        public static List<T> OrdinaPerProprieta<T, TKey>(List<T> lista, Func<T, TKey> selezioneProprieta, bool ordineCrescente = true)
        {
            if (ordineCrescente)
            {
                return lista.OrderBy(selezioneProprieta).ToList();
            }
            else
            {
                return lista.OrderByDescending(selezioneProprieta).ToList();
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CF { get; set; }
    }
}
