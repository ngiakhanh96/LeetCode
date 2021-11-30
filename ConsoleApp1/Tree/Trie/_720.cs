using System.Text;

namespace ConsoleApp1.Tree.Trie;

public class _720
{
    public string CurrentLongestWord { get; set; } = "";
    public string LongestWord(string[] words)
    {
        var trieNode = new TrieNode<int>
        {
            IsWord = true
        };

        foreach (var word in words)
        {
            trieNode.Insert(word);
        }

        Dfs(trieNode);
        return CurrentLongestWord;
    }

    private void Dfs(TrieNode<int> trieNode, string word = "")
    {
        var haveChild = false;
        for (int i = 0; i < trieNode.Children.Length; i++)
        {
            var child = trieNode.Children[i];
            if (child != null && child.IsWord)
            {
                Dfs(child, word + char.ConvertFromUtf32(i + 97));
                haveChild = true;
            }
        }

        if (!haveChild && word.Length > CurrentLongestWord.Length)
        {
            CurrentLongestWord = word;
        }
    }

    public string LongestWord2(string[] words)
    {
        var trieNode = new TrieNode2();
        foreach (var word in words)
        {
            trieNode.StackInsert(word);
        }

        var res = new StringBuilder();
        var currentNode = trieNode;

        while (currentNode.LongestChildLength > 0 && currentNode.Children[currentNode.LongestChildIndex].IsWord)
        {
            res.Append(char.ConvertFromUtf32(currentNode.LongestChildIndex + 97));
            currentNode = currentNode.Children[currentNode.LongestChildIndex];
        }

        return res.ToString();
    }

    public class TrieNode2
    {
        public int Val { get; set; }

        public int LongestChildLength { get; set; }

        public int LongestChildIndex { get; set; }

        public bool IsWord { get; set; }

        public TrieNode2[] Children { get; set; } = new TrieNode2[26];

        public TrieNode2() : this(0, true)
        {

        }

        public TrieNode2(int val, bool isWord = false)
        {
            Val = val;
            LongestChildLength = 0;
            LongestChildIndex = 26;
            IsWord = isWord;
        }

        public (bool isWord, int val) StackInsert(string word, int position = 0)
        {
            var chr = word[position];
            Children[chr - 'a'] ??= new TrieNode2(1);

            bool isWord;
            int val;

            var child = Children[chr - 'a'];
            if (position == word.Length - 1)
            {
                child.IsWord = true;
                child.Val = child.LongestChildLength == 0 || child.Children[child.LongestChildIndex].IsWord
                    ? Children[chr - 'a'].LongestChildLength + 1
                    : child.Val;
                isWord = child.IsWord;
                val = child.Val;
            }
            else
            {
                (isWord, val) = child.StackInsert(word, position + 1);
            }

            if (LongestChildLength < val)
            {
                LongestChildLength = val;
                LongestChildIndex = chr - 'a';
            }
            else if (LongestChildLength == val)
            {
                LongestChildIndex = Math.Min(LongestChildIndex, chr - 'a');
            }

            if (IsWord && isWord)
            {
                Val = LongestChildLength + 1;
            }

            return (IsWord, Val);
        }
    }
}