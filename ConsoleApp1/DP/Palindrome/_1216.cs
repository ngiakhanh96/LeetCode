namespace ConsoleApp1.DP.Palindrome;

public class _1216
{
    public bool IsValidPalindrome(string s, int k)
    {
        var longestPalindromeSubSeqFromTo = new int[s.Length, s.Length];
        for (int length = 1; length <= s.Length; length++)
        {
            for (int i = 0; i < s.Length; i++)
            {
                var j = i + length - 1;
                if (j < s.Length)
                {
                    // Length 1
                    if (length == 1)
                    {
                        longestPalindromeSubSeqFromTo[i, j] = 1;
                    }

                    // Length 2
                    else if (length == 2)
                    {
                        longestPalindromeSubSeqFromTo[i, j] = s[i] == s[j] ? 2 : 1;
                    }

                    // Length 3+
                    else
                    {
                        if (s[i] == s[j])
                        {
                            longestPalindromeSubSeqFromTo[i, j] = longestPalindromeSubSeqFromTo[i + 1, j - 1] + 2;
                        }
                        else
                        {
                            longestPalindromeSubSeqFromTo[i, j] = Math.Max(
                                longestPalindromeSubSeqFromTo[i + 1, j],
                                longestPalindromeSubSeqFromTo[i, j - 1]
                            );
                        }
                    }
                }
            }
        }

        return s.Length - longestPalindromeSubSeqFromTo[0, s.Length - 1] <= k;
    }
}