namespace ConsoleApp1.LinkedList;

//Last visit 4/6/2022
public class _141
{
    public bool HasCycle(ListNode head)
    {
        var slowPointer = head;
        var fastPointer = head;

        while (fastPointer?.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer.next?.next;
            if (slowPointer == fastPointer)
            {
                return true;
            }
        }

        return false;
    }
}