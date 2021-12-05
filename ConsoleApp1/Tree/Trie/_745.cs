namespace ConsoleApp1.Tree.Trie;

public class _745
{
    public class WordFilter
    {
        public TrieNode2<string> Trie { get; set; } = new TrieNode2<string>();
        public WordFilter(string[] words)
        {
            for (var index = 0; index < words.Length; index++)
            {
                var word = words[index];
                for (var i = word.Length - 1; i >= 0; i--)
                {
                    var suffix = "";
                    for (var j = i; j < word.Length; j++)
                    {
                        suffix += word[j];
                    }

                    var insertingWord = suffix + "#" + word;
                    Trie.Insert(insertingWord, index);
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            return Trie.LargestIndexStartsWith(suffix + "#" + prefix);
        }
    }

    public class TrieNode2<T>
    {
        public T Val { get; set; }

        public int Index { get; set; }

        public bool IsWord { get; set; }

        public TrieNode2<T>[] Children { get; } = new TrieNode2<T>[27];

        public TrieNode2()
        {

        }

        public TrieNode2(int index)
        {
            Index = index;
        }

        public TrieNode2(T val, bool isWord = false)
        {
            Val = val;
            IsWord = isWord;
        }

        public void Insert(string word, int index)
        {
            var currentNode = this;

            foreach (var chr in word)
            {
                var idx = chr == '#' ? 26 : chr - 'a';
                currentNode.Children[idx] ??= new TrieNode2<T>(index);
                currentNode = currentNode.Children[idx];
                currentNode.Index = index;
            }
            currentNode.IsWord = true;
        }

        public int LargestIndexStartsWith(string prefix)
        {
            var currentNode = this;
            foreach (var chr in prefix)
            {
                var idx = chr == '#' ? 26 : chr - 'a';
                if (currentNode.Children[idx] == null)
                {
                    return -1;
                }
                currentNode = currentNode.Children[idx];
            }

            return currentNode.Index;
        }

    }
}