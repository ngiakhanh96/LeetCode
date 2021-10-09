namespace ConsoleApp1.Array
{
    public class _75
    {
        public void SortColors(int[] nums)
        {
            var pivot = 1;
            var from = 0;
            var to = nums.Length - 1;
            while (from < to)
            {
                if (nums[from] < pivot)
                {
                    from++;
                }
                else if (nums[to] >= pivot)
                {
                    to--;
                }
                else
                {
                    var temp = nums[from];
                    nums[from] = nums[to];
                    nums[to] = temp;
                    from++;
                    to--;
                }
            }

            from = nums.Length - 1;
            to = 0;
            while (from > to)
            {
                if (nums[from] > pivot)
                {
                    from--;
                }
                else if (nums[to] <= pivot)
                {
                    to++;
                }
                else
                {
                    var temp = nums[from];
                    nums[from] = nums[to];
                    nums[to] = temp;
                    from--;
                    to++;
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
