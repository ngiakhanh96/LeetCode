namespace ConsoleApp1.DP.Palindrome;

public class _1312
{
    // Also used for minDeletions
    public int MinInsertions(string s)
    {
        return s.Length - LongestPalindromeSubsequence(s);
    }

    private int LongestPalindromeSubsequence(string s)
    {
        var longestPalindromeSubsequenceFromTo = new int[s.Length, s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            // Length 1
            longestPalindromeSubsequenceFromTo[i, i] = 1;

            // Length 2
            var j = i + 1;
            if (j < s.Length)
            {
                longestPalindromeSubsequenceFromTo[i, j] = s[i] == s[j] ? 2 : 1;
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
                    if (s[i] == s[j])
                    {
                        longestPalindromeSubsequenceFromTo[i, j] = longestPalindromeSubsequenceFromTo[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        longestPalindromeSubsequenceFromTo[i, j] = Math.Max(
                            longestPalindromeSubsequenceFromTo[i, j - 1],
                            longestPalindromeSubsequenceFromTo[i + 1, j]);
                    }
                }
            }
        }

        return longestPalindromeSubsequenceFromTo[0, s.Length - 1];
    }
}