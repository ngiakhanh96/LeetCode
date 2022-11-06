namespace ConsoleApp1.DP.EditDistance;

public class _72
{
    // Bottom-up
    public int MinDistance(string word1, string word2)
    {
        if (word1.Length == 0 && word2.Length == 0)
        {
            return 0;
        }

        if (word1.Length > 0 && word2.Length == 0)
        {
            return word1.Length;
        }

        if (word1.Length == 0 && word2.Length > 0)
        {
            return word2.Length;
        }

        var minDistanceUntil = new int[word1.Length, word2.Length];

        for (int i = 0; i < word1.Length; i++)
        {
            for (int j = 0; j < word2.Length; j++)
            {
                if (i == 0 && j == 0)
                {
                    minDistanceUntil[i, j] = word1[i] == word2[j] ? 0 : 1;
                }
                else
                {
                    if (word1[i] == word2[j])
                    {
                        minDistanceUntil[i, j] = new[]
                        {
                            i - 1 >= 0 && j - 1 >= 0 ? minDistanceUntil[i - 1, j - 1] : int.MaxValue,
                            j - 1 >= 0 ? minDistanceUntil[i, j - 1] + 1 : int.MaxValue,
                            i - 1 >= 0 ? minDistanceUntil[i - 1, j] + 1 : int.MaxValue
                        }.Min();
                    }
                    else
                    {
                        minDistanceUntil[i, j] = new[]
                        {
                            i - 1 >= 0 && j - 1 >= 0 ? minDistanceUntil[i - 1, j - 1] + 1 : int.MaxValue,
                            j - 1 >= 0 ? minDistanceUntil[i, j - 1] + 1 : int.MaxValue,
                            i - 1 >= 0 ? minDistanceUntil[i - 1, j] + 1 : int.MaxValue
                        }.Min();
                    }

                    // Tricky part
                    if (i == 0)
                    {
                        minDistanceUntil[i, j] = Math.Min(minDistanceUntil[i, j], j + (word1[i] == word2[j] ? 0 : 1));
                    }

                    if (j == 0)
                    {
                        minDistanceUntil[i, j] = Math.Min(minDistanceUntil[i, j], i + (word1[i] == word2[j] ? 0 : 1));
                    }
                }
            }
        }

        return minDistanceUntil[word1.Length - 1, word2.Length - 1];
    }
}