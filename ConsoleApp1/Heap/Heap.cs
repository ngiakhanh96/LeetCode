namespace ConsoleApp1.Heap;

/// <summary>
/// Default is MinHeap
/// </summary>
/// <typeparam name="T"></typeparam>
public class Heap<T> where T : IComparable<T>
{
    private readonly List<T> _elements;
    public int Count => _elements.Count;

    private Func<T, T, int> Comparer { get; }

    public Heap(IComparer<T> comparer = null) : this(null, comparer)
    {
    }

    public Heap(IEnumerable<T> elementList = null, IComparer<T> comparer = null)
    {
        _elements = elementList?.ToList() ?? new List<T>();
        if (comparer != null)
        {
            Comparer = comparer.Compare;
        }
        else
        {
            Comparer = (ele1, ele2) => ele1.CompareTo(ele2);
        }

        for (int i = Count - 1; i >= 0; i--)
        {
            SiftDown(i);
        }
    }

    private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
    private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
    private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

    private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < Count;
    private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < Count;
    private bool IsRoot(int elementIndex) => elementIndex == 0;

    private T GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
    private T GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
    private T GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

    private void Swap(int firstIndex, int secondIndex)
    {
        var temp = _elements[firstIndex];
        _elements[firstIndex] = _elements[secondIndex];
        _elements[secondIndex] = temp;
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new IndexOutOfRangeException();

        return _elements[0];
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new IndexOutOfRangeException();

        var result = _elements[0];
        _elements[0] = _elements.Last();
        _elements.RemoveAt(Count - 1);

        SiftDown();

        return result;
    }

    public void Enqueue(T element)
    {
        _elements.Add(element);

        SiftUp();
    }

    private void SiftDown(int index = 0)
    {
        while (HasLeftChild(index))
        {
            var smallerIndex = GetLeftChildIndex(index);


            if (HasRightChild(index) && Comparer(GetRightChild(index), GetLeftChild(index)) < 0)
            {
                smallerIndex = GetRightChildIndex(index);
            }


            if (Comparer(_elements[index], _elements[smallerIndex]) < 1)
            {
                break;
            }

            Swap(smallerIndex, index);
            index = smallerIndex;
        }
    }

    private void SiftUp()
    {
        var index = Count - 1;


        while (!IsRoot(index) && Comparer(_elements[index], GetParent(index)) < 0)
        {
            var parentIndex = GetParentIndex(index);
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }
}