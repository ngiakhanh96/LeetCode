namespace ConsoleApp1.BinarySearch
{
    public class _34
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var res = new int[] { -1, -1 };
            var low = 0;
            var high = nums.Length - 1;

            while (low <= high)
            {
                var middle = low + (high - low) / 2;
                if (nums[middle] < target)
                {
                    low = middle + 1;
                }
                else if (nums[middle] > target)
                {
                    high = middle - 1;
                }
                else
                {
                    var left = BinarySearch(true, low, middle - 1, nums, target);
                    res[0] = left == -1 ? middle : left;
                    var right = BinarySearch(false, middle + 1, high, nums, target);
                    res[1] = right == -1 ? middle : right;
                    break;
                }
            }
            return res;
        }

        private int BinarySearch(bool alwaysLookLeft, int low, int high, int[] nums, int target)
        {
            var res = -1;
            while (low <= high)
            {
                var middle = low + (high - low) / 2;
                if (nums[middle] < target)
                {
                    low = middle + 1;
                }
                else if (nums[middle] > target)
                {
                    high = middle - 1;
                }
                else
                {
                    res = middle;
                    if (alwaysLookLeft)
                    {
                        high = middle - 1;
                    }
                    else
                    {
                        low = middle + 1;
                    }
                }
            }

            return res;
        }
    }
}
