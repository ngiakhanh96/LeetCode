global using ConsoleApp1.Array;
global using ConsoleApp1.LinkedList;
using ConsoleApp1._2dArray;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var t = new _305().NumIslands2(2, 2, new int[][] { new[] { 0, 0 }, new[] { 1, 1 }, new[] { 0, 1 } });
    }
}