namespace ConsoleApp1
{
    public class _141
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }
            ListNode slowPointer = head;
            ListNode fastPointer = head;
            while (true)
            {
                slowPointer = slowPointer.next ?? slowPointer;
                fastPointer = fastPointer.next?.next;

                if (fastPointer?.next == null)
                {
                    return false;
                }

                if (slowPointer == fastPointer)
                {
                    return true;
                }

            }
        }
    }
}
