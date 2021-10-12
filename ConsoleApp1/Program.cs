using ConsoleApp1.CircularQueue;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCircularQueue = new _622.MyCircularQueue(3);
            var a = myCircularQueue.EnQueue(1);
            a = myCircularQueue.DeQueue();  // return True
            a = myCircularQueue.EnQueue(4); // return True
            var b = myCircularQueue.Rear();
            Console.ReadKey();
        }
    }
}
