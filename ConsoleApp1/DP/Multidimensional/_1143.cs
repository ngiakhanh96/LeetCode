namespace ConsoleApp1.DP.Multidimensional
{
    public class _1143
    {
        // Bottom-up
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var lenOfLcsUntil = new int[text1.Length, text2.Length];
            for (int i = 0; i < text1.Length; i++)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    if (text1[i] == text2[j])
                    {
                        lenOfLcsUntil[i, j] =
                            (i - 1 >= 0 && j - 1 >= 0
                                ? lenOfLcsUntil[i - 1, j - 1]
                                : 0)
                            + 1;
                    }
                    else
                    {
                        lenOfLcsUntil[i, j] = Math.Max(
                            i - 1 >= 0 ? lenOfLcsUntil[i - 1, j] : 0,
                            j - 1 >= 0 ? lenOfLcsUntil[i, j - 1] : 0);
                    }
                }
            }

            return lenOfLcsUntil[text1.Length - 1, text2.Length - 1];
        }

        // Top-down
        public int[,] LenOfLcsUntil { get; set; }
        public int LongestCommonSubsequence2(string text1, string text2)
        {
            LenOfLcsUntil = new int[text1.Length, text2.Length];
            for (var i = 0; i < LenOfLcsUntil.GetLength(0); i++)
            {
                for (int j = 0; j < LenOfLcsUntil.GetLength(1); j++)
                {
                    LenOfLcsUntil[i, j] = -1;
                }
            }

            return LongestCommonSubsequence2Impl(text1, text2, text1.Length - 1, text2.Length - 1);
        }

        private int LongestCommonSubsequence2Impl(string text1, string text2, int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return 0;
            }

            if (LenOfLcsUntil[i, j] == -1)
            {
                LenOfLcsUntil[i, j] = text1[i] == text2[j]
                    ? LenOfLcsUntil[i, j] = LongestCommonSubsequence2Impl(text1, text2, i - 1, j - 1) + 1
                    : Math.Max(
                        LongestCommonSubsequence2Impl(text1, text2, i - 1, j),
                        LongestCommonSubsequence2Impl(text1, text2, i, j - 1));
            }

            return LenOfLcsUntil[i, j];
        }
    }
}
