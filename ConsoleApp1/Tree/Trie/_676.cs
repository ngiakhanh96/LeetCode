namespace ConsoleApp1.Tree.Trie;

public class _676
{
    public class MagicDictionary
    {
        public string[] Words { get; set; }

        public TrieNode<int> TrieNode { get; set; } = new TrieNode<int>();

        public MagicDictionary()
        {

        }

        public void BuildDict(string[] dictionary)
        {
            Words = dictionary;
            foreach (var word in dictionary)
            {
                TrieNode.Insert(word);
            }
        }

        public bool Search(string searchWord)
        {
            return TrieNode.Search(searchWord, 1);
        }
    }

    public class TrieNode<T>
    {
        public T Val { get; set; }

        public bool IsWord { get; set; }

        public TrieNode<T>[] Children { get; } = new TrieNode<T>[26];

        public TrieNode()
        {

        }

        public TrieNode(T val, bool isWord = false)
        {
            Val = val;
            IsWord = isWord;
        }

        public void Insert(string word)
        {
            var currentNode = this;

            foreach (var chr in word)
            {
                currentNode.Children[chr - 'a'] ??= new TrieNode<T>();
                currentNode = currentNode.Children[chr - 'a'];
            }
            currentNode.IsWord = true;
        }

        public bool Search(string word, int lives = 0, int idx = 0, TrieNode<T> currentNode = null)
        {
            currentNode ??= this;
            for (var index = idx; index < word.Length; index++)
            {
                var chr = word[index];
                if (currentNode.Children[chr - 'a'] == null)
                {
                    if (lives == 0)
                    {
                        return false;
                    }

                    lives--;
                    foreach (var child in currentNode.Children)
                    {
                        if (child != null && Search(word, lives, index + 1, child))
                        {
                            return true;
                        }
                    }
                    return false;
                }

                currentNode = currentNode.Children[chr - 'a'];
            }

            return lives <= 0;
        }
    }
}