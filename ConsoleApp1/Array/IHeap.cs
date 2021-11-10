namespace ConsoleApp1.Array;

public interface IHeap
{
    public void Add(int element);

    public int Pop();

    public int Peek();

    public bool IsEmpty();

    public bool IsFull();

    public int Count { get; }
}