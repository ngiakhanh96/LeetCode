namespace ConsoleApp1.Array;

public class _952
{
    public int LargestComponentSize(int[] nums)
    {
        var maxNum = nums.Max();
        var unionFind = new UnionFind<int>(maxNum + 1);
        foreach (var num in nums)
        {
            var factors = Factorize(num);
            foreach (var factor in factors)
            {
                unionFind.TryUnion(num, factor);
            }
        }

        var count = new int[maxNum + 1];
        var max = 1;
        foreach (var num in nums)
        {
            count[unionFind.Find(num)]++;
            max = Math.Max(max, count[unionFind.Find(num)]);
        }
        return max;
    }

    private List<int> Factorize(int n)
    {
        var res = new List<int>();
        for (int i = 2; i * i <= n; ++i)
        {
            while (n % i == 0)
            {
                res.Add(i);
                n /= i;
            }
        }
        if (n != 1)
        {
            res.Add(n);
        }
        return res;
    }
}