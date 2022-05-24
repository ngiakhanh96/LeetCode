namespace ConsoleApp1.LinkedList;

//Last visit 24/5/2022
public class _876
{
    public ListNode MiddleNode(ListNode head)
    {
        var fastPointer = head;
        var slowPointer = head;
        while (fastPointer?.next != null)
        {
            slowPointer = slowPointer.next;
            fastPointer = fastPointer?.next?.next;
        }
        return slowPointer;
    }
}