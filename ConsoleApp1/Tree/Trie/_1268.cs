namespace ConsoleApp1.Tree.Trie;

public class _1268
{
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var trieNode = new TrieNode<int>();
        foreach (var product in products)
        {
            trieNode.Insert(product);
        }

        var currentSearchWord = "";
        var res = new List<IList<string>>();
        foreach (var character in searchWord)
        {
            currentSearchWord += character;
            res.Add(trieNode.StartsWith(currentSearchWord, 3));
        }

        return res;
    }
}