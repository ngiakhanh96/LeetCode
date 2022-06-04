namespace ConsoleApp1.LinkedList;

// Last visit 4/6/2022
public class _287
{
    public int FindDuplicate(int[] nums)
    {
        var slowPointer = nums[0];
        var fastPointer = nums[0];

        while (true)
        {
            slowPointer = nums[slowPointer];
            fastPointer = nums[nums[fastPointer]];
            if (slowPointer == fastPointer)
            {
                fastPointer = nums[0];
                break;
            }
        }

        while (slowPointer != fastPointer)
        {
            slowPointer = nums[slowPointer];
            fastPointer = nums[fastPointer];
        }

        return slowPointer;
    }
}