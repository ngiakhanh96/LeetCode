namespace ConsoleApp1.DP.Palindrome
{
    public class _5
    {
        public bool[,] IsPalindromeFromTo { get; set; }

        public int LongestPalindromeFrom { get; set; }

        public int LongestPalindromeTo { get; set; }

        // Bottom-up
        public string LongestPalindrome(string s)
        {
            IsPalindromeFromTo = new bool[s.Length, s.Length];
            LongestPalindromeFrom = 0;
            LongestPalindromeTo = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // Length 1
                IsPalindromeFromTo[i, i] = true;

                // Length 2
                var j = i + 1;
                if (j < s.Length)
                {
                    IsPalindromeFromTo[i, j] = s[i] == s[j];
                    if (IsPalindromeFromTo[i, j])
                    {
                        LongestPalindromeFrom = i;
                        LongestPalindromeTo = j;
                    }
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
                        IsPalindromeFromTo[i, j] = false;
                    }
                    else
                    {
                        IsPalindromeFromTo[i, j] = IsPalindromeFromTo[i + 1, j - 1];
                        if (IsPalindromeFromTo[i, j] && length > LongestPalindromeTo - LongestPalindromeFrom + 1)
                        {
                            LongestPalindromeFrom = i;
                            LongestPalindromeTo = j;
                        }
                    }
                }
            }

            var res = "";
            for (int i = LongestPalindromeFrom; i <= LongestPalindromeTo; i++)
            {
                res += s[i];
            }

            return res;
        }
    }
}
