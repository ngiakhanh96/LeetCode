using ConsoleApp1.Array;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        var medianFinder = new _295.MedianFinder();
        medianFinder.AddNum(1);    // arr = [1]
        medianFinder.AddNum(2);   // return 1.5 (i.e., (1 + 2) / 2)
        var d = medianFinder.FindMedian();
        medianFinder.AddNum(3);
        //medianFinder.AddNum(-4);
        //medianFinder.AddNum(-5); // arr[1, 2, 3]
        var c = medianFinder.FindMedian(); // return 2.0
    }
}