namespace ConsoleApp1.Array;

public class _303
{
    public class NumArray
    {
        private readonly int[] _nums;

        public NumArray(int[] nums)
        {
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                nums[i] = sum;
            }
            _nums = nums;
        }

        public int SumRange(int left, int right)
        {
            return _nums[right] - (left > 0 ? _nums[left - 1] : 0);
        }
    }
}