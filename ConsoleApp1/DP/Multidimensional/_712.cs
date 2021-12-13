namespace ConsoleApp1.DP.Multidimensional
{
    public class _712
    {
        // Bottom-up
        public int MinimumDeleteSum(string s1, string s2)
        {
            var lenOfAsciiLcsUntil = new int[s1.Length, s2.Length];
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        lenOfAsciiLcsUntil[i, j] =
                            (i - 1 >= 0 && j - 1 >= 0
                                ? lenOfAsciiLcsUntil[i - 1, j - 1]
                                : 0)
                            + s1[i];
                    }
                    else
                    {
                        lenOfAsciiLcsUntil[i, j] = Math.Max(
                            i - 1 >= 0
                                ? lenOfAsciiLcsUntil[i - 1, j]
                                : 0,
                            j - 1 >= 0
                                ? lenOfAsciiLcsUntil[i, j - 1]
                                : 0
                        );
                    }
                }
            }

            var lenOfLcs = lenOfAsciiLcsUntil[s1.Length - 1, s2.Length - 1];
            var asciiSumOfS1 = 0;
            foreach (var chr in s1)
            {
                asciiSumOfS1 += chr;
            }

            var asciiSumOfS2 = 0;
            foreach (var chr in s2)
            {
                asciiSumOfS2 += chr;
            }

            return (asciiSumOfS1 - lenOfLcs) + (asciiSumOfS2 - lenOfLcs);
        }

        // Top-down
        public int[,] LenOfAsciiLcsUntil { get; set; }
        public int MinimumDeleteSum2(string s1, string s2)
        {
            LenOfAsciiLcsUntil = new int[s1.Length, s2.Length];
            for (var i = 0; i < LenOfAsciiLcsUntil.GetLength(0); i++)
            {
                for (int j = 0; j < LenOfAsciiLcsUntil.GetLength(1); j++)
                {
                    LenOfAsciiLcsUntil[i, j] = -1;
                }
            }

            var lenOfLcs = MinimumDeleteSum2Impl(s1, s2, s1.Length - 1, s2.Length - 1);
            var asciiSumOfS1 = 0;
            foreach (var chr in s1)
            {
                asciiSumOfS1 += chr;
            }

            var asciiSumOfS2 = 0;
            foreach (var chr in s2)
            {
                asciiSumOfS2 += chr;
            }

            return (asciiSumOfS1 - lenOfLcs) + (asciiSumOfS2 - lenOfLcs);
        }

        private int MinimumDeleteSum2Impl(string s1, string s2, int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return 0;
            }

            if (LenOfAsciiLcsUntil[i, j] == -1)
            {
                LenOfAsciiLcsUntil[i, j] = s1[i] == s2[j]
                    ? LenOfAsciiLcsUntil[i, j] = MinimumDeleteSum2Impl(s1, s2, i - 1, j - 1) + s1[i]
                    : Math.Max(
                        MinimumDeleteSum2Impl(s1, s2, i - 1, j),
                        MinimumDeleteSum2Impl(s1, s2, i, j - 1));
            }

            return LenOfAsciiLcsUntil[i, j];
        }
    }
}
