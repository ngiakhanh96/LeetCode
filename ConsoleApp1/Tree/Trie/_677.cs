namespace ConsoleApp1.Tree.Trie;

public class _677
{
    public class MapSum : TrieNode<int>
    {
        public Dictionary<string, int> StringToScore { get; set; }

        public MapSum()
        {
            StringToScore = new Dictionary<string, int>();
        }

        public void Insert(string key, int val)
        {
            TrieNode<int> currentNode = this;
            var delta = val - StringToScore.GetValueOrDefault(key);

            foreach (var chr in key)
            {
                currentNode.Children[chr - 'a'] ??= new MapSum();
                currentNode = currentNode.Children[chr - 'a'];
                currentNode.Val += delta;
            }
            currentNode.IsWord = true;
            if (!StringToScore.TryAdd(key, val))
            {
                StringToScore[key] = val;
            }
        }

        public int Sum(string prefix)
        {
            TrieNode<int> currentNode = this;

            foreach (var chr in prefix)
            {
                if (currentNode.Children[chr - 'a'] == null)
                {
                    return 0;
                }

                currentNode = currentNode.Children[chr - 'a'];
            }

            return currentNode.Val;
        }
    }
}