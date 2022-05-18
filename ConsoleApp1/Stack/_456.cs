namespace ConsoleApp1.Stack;

public class _456
{
    public bool Find132pattern(int[] nums)
    {
        var stack = new Stack<(int num, int index)>();
        var smallestLeftValueSoFarArr = new int[nums.Length];

        var smallestLeftValueSoFar = int.MaxValue;
        for (var i = 0; i < nums.Length; i++)
        {
            smallestLeftValueSoFarArr[i] = smallestLeftValueSoFar;
            smallestLeftValueSoFar = Math.Min(smallestLeftValueSoFar, nums[i]);
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (!stack.Any())
            {
                stack.Push((nums[i], i));
            }
            else
            {
                while (stack.Any() && stack.Peek().num <= nums[i])
                {
                    stack.Pop();
                }

                if (stack.Any() && nums[i] > smallestLeftValueSoFarArr[stack.Peek().index])
                {
                    return true;
                }
                stack.Push((nums[i], i));
            }
        }

        return false;
    }
}