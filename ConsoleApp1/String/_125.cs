namespace ConsoleApp1.String;

[LastVisited(2023, 07, 31)]
public class _125
{
    public bool IsPalindrome(string s)
    {
        var low = 0;
        var high = s.Length - 1;
        while (low < high && low < s.Length && high >= 0)
        {
            while (low < s.Length && !char.IsLetterOrDigit(s[low]))
            {
                low++;
            }
            if (low >= s.Length)
            {
                return true;
            }
            while (high >= 0 && !char.IsLetterOrDigit(s[high]))
            {
                high--;
            }
            if (high < 0)
            {
                return true;
            }

            if (char.ToLower(s[low]) == char.ToLower(s[high]))
            {
                low++;
                high--;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}