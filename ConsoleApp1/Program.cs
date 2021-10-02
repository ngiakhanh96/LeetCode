using ConsoleApp1.Array;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 2, 0, 2, 1, 1, 0 };
            new _75().SortColors2(arr);
            Console.ReadKey();
        }
    }
}
