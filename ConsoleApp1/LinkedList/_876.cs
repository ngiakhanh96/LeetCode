namespace ConsoleApp1.LinkedList;

public class _876
{
    public ListNode MiddleNode(ListNode head)
    {
        if (head == null)
        {
            return null;
        }
        var slowPointer = head;
        var fastPointer = head;
        while (true)
        {
            slowPointer = slowPointer.next ?? slowPointer;
            fastPointer = fastPointer.next?.next;

            if (fastPointer?.next == null)
            {
                return slowPointer;
            }

        }
    }
}