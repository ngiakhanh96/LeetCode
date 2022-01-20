namespace ConsoleApp1.HashTable;

public class _974
{
    public int SubarraysDivByK(int[] nums, int k)
    {
        var sum = 0;
        var sumDict = new Dictionary<int, int> { { 0, 1 } };
        var res = 0;
        foreach (var num in nums)
        {
            sum += num;

            var remainder = sum % k;
            if (sumDict.ContainsKey(remainder))
            {
                res += sumDict[remainder];
            }

            var remainder2 = Math.Abs(-k + sum % k) < k ? -k + sum % k : k + sum % k;
            if (sumDict.ContainsKey(remainder2))
            {
                res += sumDict[remainder2];
            }

            if (!sumDict.TryAdd(remainder, 1))
            {
                sumDict[remainder]++;
            }
        }
        return res;
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