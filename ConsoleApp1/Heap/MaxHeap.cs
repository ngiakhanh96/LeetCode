namespace ConsoleApp1.Heap;

// Only used for Leetcode
public class MaxHeap
{
    private readonly List<int> _elements;
    public int Count => _elements.Count;

    public MaxHeap()
    {
        _elements = new List<int>();
    }

    public MaxHeap(int initialSize)
    {
        _elements = new List<int>(initialSize);
    }

    private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
    private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
    private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

    private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < Count;
    private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < Count;
    private bool IsRoot(int elementIndex) => elementIndex == 0;

    private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
    private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
    private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

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

    public int Peek()
    {
        if (IsEmpty())
            throw new IndexOutOfRangeException();

        return _elements[0];
    }

    public int Pop()
    {
        if (IsEmpty())
            throw new IndexOutOfRangeException();

        var result = _elements[0];
        _elements[0] = _elements.Last();
        _elements.RemoveAt(Count - 1);

        ReCalculateDown();

        return result;
    }

    public void Add(int element)
    {
        _elements.Add(element);

        ReCalculateUp();
    }

    private void ReCalculateDown()
    {
        int index = 0;
        while (HasLeftChild(index))
        {
            var biggerIndex = GetLeftChildIndex(index);
            if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
            {
                biggerIndex = GetRightChildIndex(index);
            }

            if (_elements[biggerIndex] < _elements[index])
            {
                break;
            }

            Swap(biggerIndex, index);
            index = biggerIndex;
        }
    }

    private void ReCalculateUp()
    {
        var index = Count - 1;
        while (!IsRoot(index) && _elements[index] > GetParent(index))
        {
            var parentIndex = GetParentIndex(index);
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }
}

public class MaxHeap<T> where T : HeapItem
{
    private readonly List<T> _elements;
    public int Count => _elements.Count;

    public MaxHeap()
    {
        _elements = new List<T>();
    }

    public MaxHeap(int initialSize)
    {
        _elements = new List<T>(initialSize);
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

    public T Pop()
    {
        if (IsEmpty())
            throw new IndexOutOfRangeException();

        var result = _elements[0];
        _elements[0] = _elements.Last();
        _elements.RemoveAt(Count - 1);

        ReCalculateDown();

        return result;
    }

    public void Add(T element)
    {
        _elements.Add(element);

        ReCalculateUp();
    }

    private void ReCalculateDown()
    {
        int index = 0;
        while (HasLeftChild(index))
        {
            var biggerIndex = GetLeftChildIndex(index);
            if (HasRightChild(index) && GetRightChild(index).Num > GetLeftChild(index).Num)
            {
                biggerIndex = GetRightChildIndex(index);
            }

            if (_elements[biggerIndex].Num < _elements[index].Num)
            {
                break;
            }

            Swap(biggerIndex, index);
            index = biggerIndex;
        }
    }

    private void ReCalculateUp()
    {
        var index = Count - 1;
        while (!IsRoot(index) && _elements[index].Num > GetParent(index).Num)
        {
            var parentIndex = GetParentIndex(index);
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }
}