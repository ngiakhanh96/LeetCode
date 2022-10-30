namespace ConsoleApp1.LinkedList;

//Last visit 4/6/2022
public class _142
{
    public ListNode DetectCycle(ListNode head)
    {
        var slowPointer = head;
        var fastPointer = head;

        do
        {
            slowPointer = slowPointer?.next;
            fastPointer = fastPointer?.next?.next;
        } while (fastPointer != slowPointer && fastPointer != null);

        slowPointer = head;
        while (slowPointer != fastPointer)
        {
            slowPointer = slowPointer?.next;
            fastPointer = fastPointer?.next;
        }
        return slowPointer;
    }

    public ListNode DetectCycle2(ListNode head)
    {
        var slowPointer = head;
        var fastPointer = head;

        while (fastPointer?.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next?.next;

            if (slowPointer == fastPointer)
            {
                fastPointer = head;
                while (slowPointer != fastPointer)
                {
                    slowPointer = slowPointer.next;
                    fastPointer = fastPointer.next;
                }

                return slowPointer;
            }
        }

        return null;
    }
}