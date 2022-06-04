namespace ConsoleApp1.LinkedList;

// Last visit 4/6/2022
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

    public bool IsHappy2(int n)
    {
        var slowPointer = n;
        var fastPointer = n;

        while (CalculateNextNumber(fastPointer) != 1)
        {
            slowPointer = CalculateNextNumber(slowPointer);
            fastPointer = CalculateNextNumber(CalculateNextNumber(fastPointer));

            if (slowPointer == fastPointer && slowPointer != 1)
            {
                return false;
            }
        }

        return true;
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