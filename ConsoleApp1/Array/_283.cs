namespace ConsoleApp1.Array
{
    public class _283
    {
        public void MoveZeroes(int[] nums)
        {
            var boundary = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    var temp = nums[i];
                    nums[i] = nums[boundary];
                    nums[boundary] = temp;
                    boundary++;
                }
            }
        }
    }
}
