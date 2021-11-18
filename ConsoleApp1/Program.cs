using ConsoleApp1.Array;
using ConsoleApp1.LinkedList;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var medianFinder = new _23().MergeKLists(new ListNode[]
            { new(-10), new(-5), new(4), new(-8), null, new(-9) });
    }
}