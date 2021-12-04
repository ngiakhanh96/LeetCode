namespace ConsoleApp1.Heap;

public class MaxHeapIntComparer : IComparer<int>
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


public class MinHeapStringLexicalComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return string.CompareOrdinal(x, y);
    }
}