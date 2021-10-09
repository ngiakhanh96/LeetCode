using ConsoleApp1.Array;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var t2 = new _53().MaxSubArray2(t);
            Console.ReadKey();
        }
    }
}
