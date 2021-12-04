namespace ConsoleApp1.Heap;

/// <summary>
/// Imitate PriorityQueue on .NET 6 for Leetcode
/// </summary>
/// <typeparam name="TElement">Element</typeparam>
/// <typeparam name="TPriority">Priority</typeparam>
public class CustomPriorityQueue<TElement, TPriority>
{
    private readonly List<(TElement Element, TPriority Priority)> _elements;
    public int Count => _elements.Count;

    private IComparer<TPriority> Comparer { get; }

    public CustomPriorityQueue() : this(null, null)
    {
    }

    public CustomPriorityQueue(IComparer<TPriority> comparer) : this(new List<(TElement Element, TPriority Priority)>(), comparer)
    {
    }

    public CustomPriorityQueue(
        IEnumerable<(TElement Element, TPriority Priority)> elementList = null,
        IComparer<TPriority> comparer = null)
    {
        _elements = elementList?.ToList() ?? new List<(TElement Element, TPriority Priority)>();
        Comparer = comparer ?? Comparer<TPriority>.Default;

        for (var i = Count - 1; i >= 0; i--)
        {
            SiftDown(i);
        }
    }

    public TElement Peek()
    {
        if (IsEmpty())
            throw new IndexOutOfRangeException();

        return _elements[0].Element;
    }

    public bool TryPeek(out TElement element)
    {
        if (IsEmpty())
        {
            element = default;
            return false;
        }

        element = Peek();
        return true;
    }

    public TElement Dequeue()
    {
        if (IsEmpty())
            throw new IndexOutOfRangeException();

        var result = _elements[0];
        _elements[0] = _elements.Last();
        _elements.RemoveAt(Count - 1);

        SiftDown();

        return result.Element;
    }

    public bool TryDequeue(out TElement element)
    {
        if (IsEmpty())
        {
            element = default;
            return false;
        }

        element = Dequeue();
        return true;
    }

    public void Enqueue(TElement element, TPriority priority)
    {
        _elements.Add((element, priority));
        SiftUp();
    }

    public TElement DequeueEnqueue(TElement element, TPriority priority)
    {
        var dequeuedElement = Dequeue();
        Enqueue(element, priority);
        return dequeuedElement;
    }

    public TElement EnqueueDequeue(TElement element, TPriority priority)
    {
        Enqueue(element, priority);
        return Dequeue();
    }

    private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
    private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
    private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

    private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < Count;
    private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < Count;
    private bool IsRoot(int elementIndex) => elementIndex == 0;

    private (TElement Element, TPriority Priority) GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
    private (TElement Element, TPriority Priority) GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
    private (TElement Element, TPriority Priority) GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

    private void Swap(int firstIndex, int secondIndex)
    {
        var temp = _elements[firstIndex];
        _elements[firstIndex] = _elements[secondIndex];
        _elements[secondIndex] = temp;
    }

    private bool IsEmpty()
    {
        return Count == 0;
    }

    private void SiftDown(int index = 0)
    {
        while (HasLeftChild(index))
        {
            var smallerIndex = GetLeftChildIndex(index);


            if (HasRightChild(index) && Comparer.Compare(GetRightChild(index).Priority, GetLeftChild(index).Priority) < 0)
            {
                smallerIndex = GetRightChildIndex(index);
            }


            if (Comparer.Compare(_elements[index].Priority, _elements[smallerIndex].Priority) < 1)
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


        while (!IsRoot(index) && Comparer.Compare(_elements[index].Priority, GetParent(index).Priority) < 0)
        {
            var parentIndex = GetParentIndex(index);
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }
}