namespace ConsoleApp1.String;

[LastVisited(2023, 07, 31)]
public class _9
{
    public bool IsPalindrome(int x)
    {
        var s = x.ToString();
        var low = 0;
        var high = s.Length - 1;
        while (low < high && low < s.Length && high >= 0)
        {
            if (s[low] == s[high])
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