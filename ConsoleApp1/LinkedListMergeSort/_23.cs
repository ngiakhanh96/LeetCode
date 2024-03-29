﻿namespace ConsoleApp1.LinkedListMergeSort;

[LastVisited(2023, 08, 16)]
public class _23
{
    //Mergesort
    public ListNode MergeKLists(ListNode[] lists)
    {
        var interval = 1;
        while (interval < lists.Length)
        {
            for (var i = 0; i < lists.Length - interval; i += interval * 2)
            {
                lists[i] = Merge2Lists(lists[i], lists[i + interval]);
            }

            interval *= 2;
        }

        return lists.Length > 0 ? lists[0] : null;
    }

    private ListNode Merge2Lists(ListNode listNode1, ListNode listNode2)
    {
        var head = new ListNode();
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

    public ListNode MergeKLists2(ListNode[] lists)
    {
        var minHeap = new PriorityQueue<ListNode, int>(lists.Where(node => node != null).Select(node => (node, node.val)));

        var head = new ListNode();
        var tail = head;
        while (minHeap.Count > 0)
        {
            var newMinNode = minHeap.Dequeue();
            tail.next = newMinNode;
            tail = tail.next;
            if (newMinNode.next != null)
            {
                minHeap.Enqueue(
                newMinNode.next,
                newMinNode.next.val);
            }
        }

        return head.next;
    }
}