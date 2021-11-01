namespace ConsoleApp1.Array
{
    public class _69
    {
        public int MySqrt(int x)
        {
            var startNum = 0;
            var endNum = x;
            var res = 0;

            while (startNum <= endNum)
            {
                var midNum = startNum + (endNum - startNum) / 2;
                if ((long)midNum * midNum > x)
                {
                    endNum = midNum - 1;
                }
                else if ((long)midNum * midNum < x)
                {
                    startNum = midNum + 1;
                    res = midNum;
                }
                else
                {
                    res = midNum;
                    return res;
                }
            }
            return res;
        }
    }
}
