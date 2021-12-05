namespace ConsoleApp1.UnionFind;

public class _737
{
    public bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
    {
        if (sentence1.Length != sentence2.Length)
        {
            return false;
        }
        var unionFind = new UnionFind<int>(similarPairs.Count * 2);
        var count = 0;
        var dict = new Dictionary<string, int>();
        foreach (var similarPair in similarPairs)
        {
            if (!dict.ContainsKey(similarPair[0]))
            {
                dict[similarPair[0]] = count++;
            }
            if (!dict.ContainsKey(similarPair[1]))
            {
                dict[similarPair[1]] = count++;
            }

            unionFind.TryUnion(dict[similarPair[0]], dict[similarPair[1]]);
        }

        for (var i = 0; i < sentence1.Length; i++)
        {
            var word1 = sentence1[i];
            var word2 = sentence2[i];

            if (word1 == word2 ||
                (dict.ContainsKey(word1) &&
                 dict.ContainsKey(word2) &&
                 unionFind.Find(dict[word1]) == unionFind.Find(dict[word2])))
            {
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}