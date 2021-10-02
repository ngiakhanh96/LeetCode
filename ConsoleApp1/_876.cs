namespace ConsoleApp1
{
    public class _876
    {
        public ListNode MiddleNode(ListNode head)
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
                    return slowPointer;
                }

            }
        }
    }
}
