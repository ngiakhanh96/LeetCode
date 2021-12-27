namespace ConsoleApp1.Array;

public class _6
{
    public string Convert(string s, int numRows)
    {
        if (numRows > s.Length)
        {
            numRows = s.Length;
        }
        if (numRows == 1)
        {
            return s;
        }
        var res = "";
        for (var i = 0; i < numRows; i++)
        {
            res += s[i];
            var d1 = numRows - 1 - i;
            var d2 = i - 0;
            if (d1 == 0 && d2 == 0)
            {
                return res;
            }
            var currentPosition = i;
            var shouldGoWithD1 = true;
            while (currentPosition < s.Length)
            {
                var oldCurrentPosition = currentPosition;
                if (shouldGoWithD1)
                {
                    currentPosition += d1 * 2;
                    shouldGoWithD1 = false;
                }
                else
                {
                    currentPosition += d2 * 2;
                    shouldGoWithD1 = true;
                }
                if (currentPosition != oldCurrentPosition && currentPosition < s.Length)
                {
                    res += s[currentPosition];
                }
            }
        }
        return res;
    }
}