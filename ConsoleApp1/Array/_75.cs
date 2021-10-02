namespace ConsoleApp1.Array
{
    public class _75
    {
        public void SortColors(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        var temp = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
        }

        public void SortColors2(int[] nums)
        {
            var pivot = 1;
            var boundary = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < pivot)
                {
                    var temp = nums[i];
                    nums[i] = nums[boundary];
                    nums[boundary] = temp;
                    boundary++;
                }
            }

            boundary = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] > pivot)
                {
                    var temp = nums[i];
                    nums[i] = nums[boundary];
                    nums[boundary] = temp;
                    boundary--;
                }
            }
        }
    }
}
