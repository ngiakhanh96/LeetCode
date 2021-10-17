namespace ConsoleApp1.Array;

public class _760
{
    public int[] AnagramMappings(int[] nums1, int[] nums2)
    {
        var dict = new Dictionary<int, Stack<int>>();
        var res = new int[nums1.Length];
        for (var i = 0; i < nums2.Length; i++)
        {
            if (!dict.TryAdd(nums2[i], new Stack<int>(new[] { i })))
            {
                dict[nums2[i]].Push(i);
            }
        }

        for (var i = 0; i < nums1.Length; i++)
        {
            res[i] = dict[nums1[i]].Pop();
        }

        return res;
    }
}