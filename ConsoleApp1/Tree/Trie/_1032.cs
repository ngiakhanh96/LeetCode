namespace ConsoleApp1.Tree.Trie;

public class _1032
{
    public class StreamChecker
    {
        public TrieNode2<int> TrieNode { get; set; } = new TrieNode2<int>();

        public string CurrentWord { get; set; } = "";

        public StreamChecker(string[] words)
        {
            foreach (var word in words)
            {
                TrieNode.RevertedInsert(word);
            }
        }

        public bool Query(char letter)
        {
            CurrentWord = letter + CurrentWord;
            return TrieNode.StartsWithPrefixInString(CurrentWord);
        }
    }

    public class TrieNode2<T>
    {
        public T Val { get; set; }

        public List<string> Words { get; set; } = new List<string>();

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

        public void RevertedInsert(string word)
        {
            var currentNode = this;

            for (int i = word.Length - 1; i >= 0; i--)
            {
                var chr = word[i];
                currentNode.Children[chr - 'a'] ??= new TrieNode2<T>();
                currentNode = currentNode.Children[chr - 'a'];
                currentNode.Words.Add(word);
            }
            currentNode.IsWord = true;
        }

        public bool StartsWithPrefixInString(string prefix)
        {
            var currentNode = this;
            foreach (var chr in prefix)
            {
                if (currentNode.Children[chr - 'a'] == null)
                {
                    return false;
                }

                currentNode = currentNode.Children[chr - 'a'];
                if (currentNode.IsWord)
                {
                    return true;
                }
            }

            return false;
        }
    }
}