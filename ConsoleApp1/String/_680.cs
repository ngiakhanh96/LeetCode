namespace ConsoleApp1.String;

[LastVisited(2023, 08, 09)]
public class _680
{
    public bool ValidPalindrome(string s, int low = 0, int high = 0, int maxCharToDelete = 1)
    {
        high = high == 0 ? s.Length - 1 : high;
        while (low < high && low < s.Length && high >= 0)
        {
            if (s[low] != s[high])
            {
                if (maxCharToDelete == 0)
                {
                    return false;
                }
                maxCharToDelete--;
                return ValidPalindrome(s, low, high - 1, maxCharToDelete) || ValidPalindrome(s, low + 1, high, maxCharToDelete);
            }

            low++;
            high--;
        }
        return true;
    }
}