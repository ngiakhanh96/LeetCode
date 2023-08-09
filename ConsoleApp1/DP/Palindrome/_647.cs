namespace ConsoleApp1.DP.Palindrome;

public class _647
{
    public int CountSubstrings(string s)
    {
        var isPalindromeFromTo = new bool[s.Length, s.Length];
        var count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // Length 1
            isPalindromeFromTo[i, i] = true;
            count++;

            // Length 2
            var j = i + 1;
            if (j < s.Length && s[i] == s[j])
            {
                isPalindromeFromTo[i, j] = true;
                count++;
            }
        }

        // Length 3+
        for (int length = 3; length <= s.Length; length++)
        {
            for (int i = 0; i < s.Length; i++)
            {
                var j = i + length - 1;
                if (j < s.Length)
                {
                    if (s[i] == s[j] && isPalindromeFromTo[i + 1, j - 1])
                    {
                        isPalindromeFromTo[i, j] = true;
                        count++;
                    }
                }
            }
        }
        return count;
    }
}