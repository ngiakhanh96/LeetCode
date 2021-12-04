namespace ConsoleApp1.Tree.Trie;

public class _1233
{
    public IList<string> RemoveSubfolders(string[] folder)
    {
        System.Array.Sort(folder, (f1, f2) => f1.Length.CompareTo(f2.Length));
        var trie = new TrieNode2<int>();
        var res = new List<string>();
        var hashSet = new HashSet<string>();
        foreach (var path in folder)
        {
            var parent = trie.Insert(path.Split('/'));
            if (hashSet.Add(parent))
            {
                res.Add(parent);
            }
        }
        return res;
    }

    public class TrieNode2<T>
    {
        public T Val { get; set; }

        public bool IsWord { get; set; }

        public Dictionary<string, TrieNode2<T>> Children { get; } = new Dictionary<string, TrieNode2<T>>();

        public TrieNode2()
        {
        }

        public TrieNode2(T val, bool isWord = false)
        {
            Val = val;
            IsWord = isWord;
        }

        public string Insert(string[] words)
        {
            var currentNode = this;
            var res = new List<string>();

            foreach (var word in words)
            {
                currentNode.Children.TryAdd(word, new TrieNode2<T>());
                currentNode = currentNode.Children[word];
                res.Add(word);
                if (currentNode.IsWord)
                {
                    return string.Join("/", res.ToArray());
                }
            }
            currentNode.IsWord = true;
            return string.Join("/", words);
        }
    }
}