namespace ConsoleApp1.LinkedList;

// Last visit 12/6/2022
public class _148
{
    public ListNode SortList(ListNode head)
    {
        if (head?.next == null)
        {
            return head;
        }
        var middleNode = FindMiddleNode(head);
        var oldMiddleNode = middleNode.next;
        middleNode.next = null;
        var leftPointer = SortList(head);
        var rightPointer = SortList(oldMiddleNode);
        ListNode prevPointer = null;
        ListNode newHead = null;
        while (leftPointer != null && rightPointer != null)
        {
            if (leftPointer.val < rightPointer.val)
            {
                if (prevPointer == null)
                {
                    prevPointer = leftPointer;
                    newHead = leftPointer;
                }
                else
                {
                    prevPointer.next = leftPointer;
                    prevPointer = leftPointer;
                }

                leftPointer = leftPointer.next;

            }
            else
            {
                if (prevPointer == null)
                {
                    prevPointer = rightPointer;
                    newHead = rightPointer;
                }
                else
                {
                    prevPointer.next = rightPointer;
                    prevPointer = rightPointer;
                }
                rightPointer = rightPointer.next;
            }
        }

        while (leftPointer != null)
        {
            prevPointer.next = leftPointer;
            prevPointer = leftPointer;
            leftPointer = leftPointer.next;
        }

        while (rightPointer != null)
        {
            prevPointer.next = rightPointer;
            prevPointer = rightPointer;
            rightPointer = rightPointer.next;
        }
        prevPointer.next = null;
        return newHead;
    }

    private ListNode FindMiddleNode(ListNode head)
    {
        var fastPointer = head;
        var slowPointer = head;

        if (fastPointer.next is { next: null })
        {
            return slowPointer;
        }

        while (fastPointer?.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next?.next;
        }

        return slowPointer;
    }
}