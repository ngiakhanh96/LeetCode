namespace ConsoleApp1.Array;

public class _167
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var leftPointer = 0;
        var rightPointer = numbers.Length - 1;
        while (numbers[leftPointer] + numbers[rightPointer] != target)
        {
            if (numbers[leftPointer] + numbers[rightPointer] < target)
            {
                leftPointer++;
            }
            else
            {
                rightPointer--;
            }
        }

        return new int[] { leftPointer + 1, rightPointer + 1 };
    }
}