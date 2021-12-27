namespace ConsoleApp1.DP.Multidimensional;

public class _583
{
    // Bottom-up
    public int MinDistance(string word1, string word2)
    {
        var lenOfLcsUntil = new int[word1.Length, word2.Length];
        for (int i = 0; i < word1.Length; i++)
        {
            for (int j = 0; j < word2.Length; j++)
            {
                if (word1[i] == word2[j])
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
                        i - 1 >= 0
                            ? lenOfLcsUntil[i - 1, j]
                            : 0,
                        j - 1 >= 0
                            ? lenOfLcsUntil[i, j - 1]
                            : 0
                    );
                }
            }
        }

        var lenOfLcs = lenOfLcsUntil[word1.Length - 1, word2.Length - 1];
        return (word1.Length - lenOfLcs) + (word2.Length - lenOfLcs);
    }

    // Top-down
    public int[,] LenOfLcsUntil { get; set; }
    public int MinDistance2(string word1, string word2)
    {
        LenOfLcsUntil = new int[word1.Length, word2.Length];
        for (var i = 0; i < LenOfLcsUntil.GetLength(0); i++)
        {
            for (int j = 0; j < LenOfLcsUntil.GetLength(1); j++)
            {
                LenOfLcsUntil[i, j] = -1;
            }
        }
        var lenOfLcs = MinDistance2Impl(word1, word2, word1.Length - 1, word2.Length - 1);
        return (word1.Length - lenOfLcs) + (word2.Length - lenOfLcs);
    }

    private int MinDistance2Impl(string word1, string word2, int i, int j)
    {
        if (i < 0 || j < 0)
        {
            return 0;
        }

        if (LenOfLcsUntil[i, j] == -1)
        {
            LenOfLcsUntil[i, j] =
                word1[i] == word2[j]
                    ? MinDistance2Impl(word1, word2, i - 1, j - 1) + 1
                    : Math.Max(
                        MinDistance2Impl(word1, word2, i - 1, j),
                        MinDistance2Impl(word1, word2, i, j - 1));
        }

        return LenOfLcsUntil[i, j];
    }
}