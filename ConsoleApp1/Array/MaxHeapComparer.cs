namespace ConsoleApp1.Array;

public class MaxHeapComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y.CompareTo(x);
    }
}

public class MaxHeapFloatComparer : IComparer<float>
{
    public int Compare(float x, float y)
    {
        return y.CompareTo(x);
    }
}