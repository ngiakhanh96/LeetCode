namespace ConsoleApp1.LinkedListMergeSort;

[LastVisited(2023, 07, 31)]
public class _21
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var pointer1 = list1;
        var pointer2 = list2;
        ListNode head = null;
        ListNode prev = null;
        while (pointer1 != null && pointer2 != null)
        {
            if (pointer1.val > pointer2.val)
            {
                head ??= pointer2;

                if (prev != null)
                {
                    prev.next = pointer2;
                }

                prev = pointer2;
                pointer2 = pointer2.next;
            }
            else
            {
                head ??= pointer1;

                if (prev != null)
                {
                    prev.next = pointer1;
                }

                prev = pointer1;
                pointer1 = pointer1.next;
            }

        }

        while (pointer1 != null)
        {
            head ??= pointer1;
            if (prev != null)
            {
                prev.next = pointer1;
            }

            prev = pointer1;
            pointer1 = pointer1.next;
        }

        while (pointer2 != null)
        {
            head ??= pointer2;
            if (prev != null)
            {
                prev.next = pointer2;
            }

            prev = pointer2;
            pointer2 = pointer2.next;
        }
        return head;
    }
}