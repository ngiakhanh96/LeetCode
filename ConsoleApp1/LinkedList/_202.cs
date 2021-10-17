namespace ConsoleApp1.LinkedList;

public class _202
{
    public bool IsHappy(int n)
    {
        var slowPointer = n;
        var fastPointer = n;
        while (true)
        {
            slowPointer = CalculateNextNumber(slowPointer);
            fastPointer = CalculateNextNumber(CalculateNextNumber(fastPointer));

            if (fastPointer == 1)
            {
                return true;
            }

            if (slowPointer == fastPointer)
            {
                return false;
            }

        }
    }

    private int CalculateNextNumber(int n)
    {
        var sum = 0;
        while (n != 0)
        {
            sum += (int)Math.Pow(n % 10, 2);
            n /= 10;
        }

        return sum;
    }
}