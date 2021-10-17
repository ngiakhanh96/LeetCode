namespace ConsoleApp1.LinkedList;

public class _142
{
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null)
        {
            return null;
        }
        ListNode slowPointer = head;
        ListNode fastPointer = head;
        while (true)
        {
            slowPointer = slowPointer.next ?? slowPointer;
            fastPointer = fastPointer.next?.next;

            if (fastPointer?.next == null)
            {
                return null;
            }

            if (slowPointer == fastPointer)
            {
                slowPointer = head;
                if (slowPointer == fastPointer)
                {
                    return slowPointer;
                }
                while (true)
                {
                    slowPointer = slowPointer.next;
                    fastPointer = fastPointer.next;
                    if (slowPointer == fastPointer)
                    {
                        return slowPointer;
                    }
                }
            }

        }
    }
}