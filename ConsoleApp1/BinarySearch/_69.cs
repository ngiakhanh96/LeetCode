namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]
public class _69
{
    public int MySqrt(int x)
    {
        long startNum = 0;
        var endNum = (long)x;

        while (startNum < endNum)
        {
            var midNum = startNum + (endNum - startNum + 1) / 2;
            if (midNum * midNum > x)
            {
                endNum = midNum - 1;
            }
            else
            {
                startNum = midNum;
            }
        }
        return (int)startNum;
    }
}