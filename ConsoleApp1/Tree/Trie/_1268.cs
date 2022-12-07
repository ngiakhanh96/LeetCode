namespace ConsoleApp1.Tree.Trie;

public class _1268
{
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var trieNode = new TrieNode2<int>();
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

    public class TrieNode2<T>
    {
        public T Val { get; set; }

        public List<string> Words { get; set; } = new();

        public bool IsWord { get; set; }

        public TrieNode2<T>[] Children { get; } = new TrieNode2<T>[26];

        public TrieNode2()
        {

        }

        public TrieNode2(T val, bool isWord = false)
        {
            Val = val;
            IsWord = isWord;
        }

        public void Insert(string word)
        {
            var currentNode = this;

            foreach (var chr in word)
            {
                currentNode.Children[chr - 'a'] ??= new TrieNode2<T>();
                currentNode = currentNode.Children[chr - 'a'];
                currentNode.Words.Add(word);
            }
            currentNode.IsWord = true;
        }

        public IList<string> StartsWith(string prefix, int quantity)
        {
            var resultList = new List<string>();
            var currentNode = this;
            foreach (var chr in prefix)
            {
                if (currentNode.Children[chr - 'a'] == null)
                {
                    return resultList;
                }
                currentNode = currentNode.Children[chr - 'a'];
            }

            var minHeap = new CustomPriorityQueue<string, string>(
                currentNode.Words.Select(word => (word, word)),
                new MinHeapStringLexicalComparer());
            while (minHeap.Count > 0 && resultList.Count < quantity)
            {
                resultList.Add(minHeap.Dequeue());
            }
            return resultList;
        }

    }

    public IList<IList<string>> SuggestedProducts2(string[] products, string searchWord)
    {
        var trieNode = new TrieNode2<int>();
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