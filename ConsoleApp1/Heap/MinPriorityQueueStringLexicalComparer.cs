namespace ConsoleApp1.Heap;

public class MinPriorityQueueStringLexicalComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return string.CompareOrdinal(x, y);
    }
}