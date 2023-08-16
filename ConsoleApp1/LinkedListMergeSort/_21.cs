namespace ConsoleApp1.LinkedListMergeSort;

[LastVisited(2023, 08, 15)]
public class _21
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var pointer1 = list1;
        var pointer2 = list2;
        ListNode head = new ListNode();
        ListNode prev = head;
        while (pointer1 != null && pointer2 != null)
        {
            if (pointer1.val > pointer2.val)
            {
                prev.next = pointer2;
                prev = pointer2;
                pointer2 = pointer2.next;
            }
            else
            {
                prev.next = pointer1;
                prev = pointer1;
                pointer1 = pointer1.next;
            }

        }

        while (pointer1 != null)
        {
            prev.next = pointer1;
            prev = pointer1;
            pointer1 = pointer1.next;
        }

        while (pointer2 != null)
        {
            prev.next = pointer2;
            prev = pointer2;
            pointer2 = pointer2.next;
        }
        return head.next;
    }
}