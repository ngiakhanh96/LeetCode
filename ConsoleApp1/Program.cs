using ConsoleApp1.Array;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 2, 0, 2, 1, 1, 0 };
            var obj = new _731.MyCalendarTwo();
            var res = obj.Book(10, 20);
            res = obj.Book(50, 60);
            res = obj.Book(10, 40);
            res = obj.Book(5, 15);

            Console.ReadKey();
        }
    }
}
