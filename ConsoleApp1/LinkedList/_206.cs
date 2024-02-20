namespace ConsoleApp1.LinkedList;

[LastVisited(2024, 02, 21)]
public class _206
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode previousNode = null;

        while (head != null)
        {
            (head.next, previousNode, head) = (previousNode, head, head.next);
        }

        return previousNode;
    }

    public ListNode ReverseList2(ListNode head, ListNode previousNode = null)
    {
        if (head == null)
            return null;
        var initialNext = head.next;
        head.next = previousNode;

        var returnNode = initialNext == null ? head : ReverseList2(initialNext, head);

        return returnNode;
    }
}