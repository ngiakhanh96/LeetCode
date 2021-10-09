using ConsoleApp1.Array;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new[] { 3, 3, 3, 3, 4, 3, 3, 3, 3 };
            var t2 = new _215().FindKthLargest2(t, 1);
            Console.ReadKey();
        }
    }
}
