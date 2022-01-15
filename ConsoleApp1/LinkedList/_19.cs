namespace ConsoleApp1.LinkedList
{
    public class _19
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
            {
                return null;
            }

            var fast = head;
            var slow = head;

            for (int i = 0; i < n - 1; i++)
            {
                fast = fast.next;
            }

            ListNode previousSlow = null;
            while (fast.next != null)
            {
                fast = fast.next;
                previousSlow = slow;
                slow = slow.next;
            }

            if (previousSlow == null)
            {
                head = head.next;
            }
            else
            {
                previousSlow.next = previousSlow.next.next;
            }

            return head;
        }
    }
}
