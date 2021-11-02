namespace ConsoleApp1.Array;

public class _69
{
    public int MySqrt(int x)
    {
        var startNum = 0;
        var endNum = x;
        var res = int.MinValue;

        while (startNum <= endNum)
        {
            var midNum = startNum + (endNum - startNum) / 2;
            if ((long)midNum * midNum > x)
            {
                endNum = midNum - 1;
            }
            else
            {
                res = midNum;
                startNum = midNum + 1;
            }
        }
        return res;
    }
}