namespace ConsoleApp1.HashTable;

[LastVisited(2022, 11, 20)]
public class _974
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        var dict = new Dictionary<int, int> { { 0, 1 } };
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] += i - 1 >= 0 ? nums[i - 1] : 0;
            nums[i] %= k;
            var remainder1 = nums[i];
            dict.TryGetValue(remainder1, out var value);
            count += value;

            var remainder2 = nums[i] > 0 ? -(k - remainder1) : remainder1 + k;
            dict.TryGetValue(remainder2, out value);
            count += value;
            if (!dict.TryAdd(nums[i], 1))
            {
                dict[nums[i]]++;
            }
        }
        return count;
    }

    public int SubarraysDivByK2(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] += (i > 0 ? nums[i - 1] : 0);
        }
        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] %= k;
        }

        var count = 0;
        foreach (var num in nums)
        {
            if (num % k == 0)
            {
                count++;
            }

            var lookingLeftNum1 = (-k + num) % k;
            var lookingRightNum2 = (k + num) % k;
            if (dict.ContainsKey(lookingLeftNum1))
            {
                count += dict[lookingLeftNum1];
            }

            if (lookingLeftNum1 != lookingRightNum2)
            {
                if (dict.ContainsKey(lookingRightNum2))
                {
                    count += dict[lookingRightNum2];
                }
            }


            if (!dict.TryAdd(num, 1))
            {
                dict[num]++;
            }
        }
        return count;
    }
}