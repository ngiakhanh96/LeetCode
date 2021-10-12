namespace ConsoleApp1.LinkedList
{
    public class _148
    {
        public ListNode SortList(ListNode head)
        {
            if (head?.next == null)
            {
                return head;
            }
            var fastPointer = head;
            var slowPointer = head;
            while (true)
            {
                fastPointer = fastPointer.next ?? fastPointer;
                fastPointer = fastPointer.next ?? fastPointer;

                if (fastPointer.next == null)
                {
                    break;
                }
                slowPointer = slowPointer.next ?? slowPointer;
            }

            var rightList = SortList(slowPointer.next);
            slowPointer.next = null;
            var leftList = SortList(head);

            var leftPointer = leftList;
            var rightPointer = rightList;
            ListNode returnedListNode = null;
            ListNode prevListNode = null;
            while (leftPointer != null && rightPointer != null)
            {
                var smallerPointer = leftPointer.val < rightPointer.val ? leftPointer : rightPointer;

                if (prevListNode == null)
                {
                    returnedListNode = smallerPointer;
                }
                else
                {
                    prevListNode.next = smallerPointer;
                }

                prevListNode = smallerPointer;
                if (smallerPointer == leftPointer)
                {
                    leftPointer = leftPointer.next;
                }
                else
                {
                    rightPointer = rightPointer.next;
                }
            }

            while (leftPointer != null)
            {
                prevListNode!.next = leftPointer;
                prevListNode = leftPointer;
                leftPointer = leftPointer.next;
            }

            while (rightPointer != null)
            {
                prevListNode!.next = rightPointer;
                prevListNode = rightPointer;
                rightPointer = rightPointer.next;
            }

            return returnedListNode;
        }
    }
}
