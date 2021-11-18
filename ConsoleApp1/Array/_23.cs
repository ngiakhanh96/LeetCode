using ConsoleApp1.LinkedList;

namespace ConsoleApp1.Array;

public class _23
{
    //Mergesort
    public ListNode MergeKLists(ListNode[] lists)
    {
        var interval = 1;
        while (interval < lists.Length)
        {
            for (int i = 0; i < lists.Length - interval; i += interval * 2)
            {
                lists[i] = Merge2Lists(lists[i], lists[i + interval]);
            }

            interval *= 2;
        }

        return lists.Length > 0 ? lists[0] : null;
    }

    private ListNode Merge2Lists(ListNode listNode1, ListNode listNode2)
    {
        var head = new ListNode(0);
        var tail = head;
        var firstPointer = listNode1;
        var secondPointer = listNode2;
        while (firstPointer != null && secondPointer != null)
        {
            if (firstPointer.val < secondPointer.val)
            {
                tail.next = firstPointer;
                tail = tail.next;
                firstPointer = firstPointer.next;
            }
            else
            {
                tail.next = secondPointer;
                tail = tail.next;
                secondPointer = secondPointer.next;
            }
        }

        while (firstPointer != null)
        {
            tail.next = firstPointer;
            tail = tail.next;
            firstPointer = firstPointer.next;
        }

        while (secondPointer != null)
        {
            tail.next = secondPointer;
            tail = tail.next;
            secondPointer = secondPointer.next;
        }

        return head.next;
    }

    //Heapsort
    public class HeapNodeItem : HeapItem
    {
        public ListNode ListNode { get; set; }
    }

    public ListNode MergeKLists2(ListNode[] lists)
    {
        var minHeap = new MinHeap<HeapNodeItem>();

        foreach (var listNode in lists)
        {
            if (listNode != null)
            {
                minHeap.Add(new HeapNodeItem
                {
                    Num = listNode.val,
                    ListNode = listNode
                });
            }
        }

        var head = new ListNode(0);
        var tail = head;
        while (minHeap.Count > 0)
        {
            var newMinNode = minHeap.Pop();
            tail.next = newMinNode.ListNode;
            tail = tail.next;
            if (newMinNode.ListNode.next != null)
            {
                minHeap.Add(new HeapNodeItem
                {
                    Num = newMinNode.ListNode.next.val,
                    ListNode = newMinNode.ListNode.next
                });
            }
        }

        return head.next;
    }

    public ListNode MergeKLists3(ListNode[] lists)
    {
        var minHeap = new PriorityQueue<ListNode, int>();

        foreach (var listNode in lists)
        {
            if (listNode != null)
            {
                minHeap.Enqueue(listNode, listNode.val);
            }
        }

        var head = new ListNode(0);
        var tail = head;
        while (minHeap.Count > 0)
        {
            var newMinNode = minHeap.Dequeue();
            tail.next = newMinNode;
            tail = tail.next;
            if (newMinNode.next != null)
            {
                minHeap.Enqueue(newMinNode.next, newMinNode.next.val);
            }
        }

        return head.next;
    }
}