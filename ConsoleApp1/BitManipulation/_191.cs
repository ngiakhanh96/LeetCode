namespace ConsoleApp1.BitManipulation;

public class _191
{
    public int HammingWeight(uint n)
    {
        var count = 0;
        while (n != 0)
        {
            if (GetBit(n, 0) == 1)
            {
                count++;
            }

            n >>= 1;
        }

        return count;
    }

    public int HammingWeight2(uint n)
    {
        int count = 0;

        while (n != 0)
        {
            n &= (n - 1);
            count++;
        }

        return count;
    }

    private uint GetBit(uint n, int position)
    {
        return (n >> position) & 1;
    }
}