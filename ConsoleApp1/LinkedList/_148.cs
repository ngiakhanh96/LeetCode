namespace ConsoleApp1.LinkedList;

[LastVisited(2024, 3, 5)]
public class _148
{
    public ListNode SortList(ListNode head)
    {
        if (head is null)
        {
            return null;
        }
        var middle = DetermineMiddleNode(head);
        if (middle == head)
        {
            return head;
        }

        var left = SortList(head);
        var right = SortList(middle);
        return Merge(left, right);
    }

    private ListNode DetermineMiddleNode(ListNode head)
    {
        var fastPointer = head?.next;
        var slowPointer = head;
        ListNode prevSlowPointer = null;
        while (fastPointer is not null)
        {
            prevSlowPointer = slowPointer;
            fastPointer = fastPointer?.next?.next;
            slowPointer = slowPointer?.next;
        }
        if (prevSlowPointer is not null)
        {
            prevSlowPointer.next = null;
        }
        return slowPointer;
    }

    private ListNode Merge(ListNode left, ListNode right)
    {
        var leftPointer = left;
        var rightPointer = right;
        ListNode newHead = null;
        ListNode pointer = null;
        while (leftPointer is not null && rightPointer is not null)
        {
            if (leftPointer.val < rightPointer.val)
            {
                newHead ??= leftPointer;
                if (pointer is not null)
                {
                    pointer.next = leftPointer;
                }
                pointer = leftPointer;
                leftPointer = leftPointer.next;
            }
            else
            {
                newHead ??= rightPointer;
                if (pointer is not null)
                {
                    pointer.next = rightPointer;
                }
                pointer = rightPointer;
                rightPointer = rightPointer.next;
            }
        }

        while (leftPointer is not null)
        {
            pointer.next = leftPointer;
            pointer = leftPointer;
            leftPointer = leftPointer.next;
        }

        while (rightPointer is not null)
        {
            pointer.next = rightPointer;
            pointer = rightPointer;
            rightPointer = rightPointer.next;
        }

        return newHead;
    }
}