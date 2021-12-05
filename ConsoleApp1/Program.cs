global using ConsoleApp1.Heap;
global using ConsoleApp1.LinkedList;
global using ConsoleApp1.UnionFind;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var heap = new Heap<int>(new List<int> { 3, 2, 1 });

        var t = heap.Pop();
    }
}