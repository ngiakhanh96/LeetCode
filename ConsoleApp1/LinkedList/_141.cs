namespace ConsoleApp1.LinkedList;

[LastVisited(2023, 08, 17)]
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