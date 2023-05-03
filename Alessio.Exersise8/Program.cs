using System;
using System.Net.Http.Headers;

namespace Alessio.Exersises8
{
    internal class Program
    {
        public delegate void DelegateSumMethod(int a, int b);
        public delegate void DelegateofDelsSumMethod(DelegateSumMethod a,int ac ,int b);
        
        static void Main(string[] args)
        {
            //Ex.1
            DelegateSumMethod del = SumNumber;
            DelegateofDelsSumMethod hendler = DelSumNumber;
            hendler.Invoke(del,1, 3);

            //Ex.2
            Func<int, int,int> FuncMultiplication = (int x, int y) =>
            {
                return x * y;
            };
            Func<int, int, bool> CheckComparison = (int x, int result) =>
            {
               return result > x ? true : false;
            };
            Action<bool> Progression = (bool result) =>
            {
                if (result)
                {
                    Console.WriteLine("is more higther");
                }
                else { Console.WriteLine("is minor "); }
            };
            Predicate<bool> predicate = (bool result) =>
            {
                if (result) Console.WriteLine("Check loading... "); return true;
            };

            Progression(predicate(CheckComparison(10, FuncMultiplication(2, 6))));
        }
        //Ex.1
        static void DelSumNumber(DelegateSumMethod del ,int a, int b)
        {
            del.Invoke(a, b);
        }

        static void SumNumber(int a, int b)
        {
            int sum = a+ b;
            Console.WriteLine(sum);
        }
        

      
    }
}
