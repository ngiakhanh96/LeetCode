namespace ConsoleApp1.LinkedList;

//Last visit 24/5/2022
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
        ListNode previousNode = null;
        while (head != null)
        {
            var temp = head.next;
            head.next = previousNode;
            previousNode = head;
            head = temp;
        }

        return previousNode;

    }
}