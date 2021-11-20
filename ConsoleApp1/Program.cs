global using ConsoleApp1._2dArray;
global using ConsoleApp1.Array;
global using ConsoleApp1.LinkedList;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var t = new _787().FindCheapestPrice(3, new int[][]
        {
            new int[] { 0,1,100 },
            new int[] { 1,2,100 },
            new int[] { 0,2,500 }
        }, 0, 2, 1);
    }
}