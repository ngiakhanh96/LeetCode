namespace ConsoleApp1.DP.Palindrome;

public class _516
{
    // Bottom-up
    public int LongestPalindromeSubseq(string s)
    {
        var longestPalindromeSubseqFromTo = new int[s.Length, s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            // Length 1
            longestPalindromeSubseqFromTo[i, i] = 1;

            // Length 2
            var j = i + 1;
            if (j < s.Length)
            {
                longestPalindromeSubseqFromTo[i, j] = s[i] == s[j] ? 2 : 1;
            }
        }

        // Length 3+
        for (int length = 3; length <= s.Length; length++)
        {
            for (int i = 0; i + length <= s.Length; i++)
            {
                var j = i + length - 1;
                if (s[i] != s[j])
                {
                    longestPalindromeSubseqFromTo[i, j] = Math.Max(longestPalindromeSubseqFromTo[i + 1, j], longestPalindromeSubseqFromTo[i, j - 1]);
                }
                else
                {
                    longestPalindromeSubseqFromTo[i, j] = longestPalindromeSubseqFromTo[i + 1, j - 1] + 2;
                }
            }
        }

        return longestPalindromeSubseqFromTo[0, s.Length - 1];
    }
}