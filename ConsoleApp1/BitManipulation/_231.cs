namespace ConsoleApp1.BitManipulation;

// Last visit 4/6/2022
public class _231
{
    public bool IsPowerOfTwo(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }

    public bool IsPowerOfTwo2(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        while (true)
        {
            if (n == 1)
            {
                return true;
            }
            if (GetBit(n, 0) == 1)
            {
                return false;
            }

            n >>= 1;
        }
    }

    private int GetBit(int n, int position)
    {
        return (n >> position) & 1;
    }
}