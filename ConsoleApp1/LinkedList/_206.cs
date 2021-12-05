namespace ConsoleApp1.LinkedList;

public class _206
{
    public ListNode ReverseList(ListNode head, ListNode previousNode = null)
    {
        if (head == null)
            return null;
        var initialNext = head.next;
        head.next = previousNode;

        var returnNode = initialNext == null ? head : ReverseList(initialNext, head);

        return returnNode;

    }

    public ListNode ReverseList2(ListNode head)
    {
        if (head == null)
            return null;
        ListNode previousNode = null;
        var currNode = head;
        do
        {
            var initialNext = currNode.next;
            currNode.next = previousNode;
            previousNode = currNode;
            currNode = initialNext;
        } while (currNode != null);

        return previousNode;

    }
}