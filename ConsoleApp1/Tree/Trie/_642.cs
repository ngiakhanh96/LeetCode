namespace ConsoleApp1.Tree.Trie;

public class _642
{
    public class AutocompleteSystem
    {
        public TrieNode2<int> RootNode { get; set; }

        public TrieNode2<int> CurrentNode { get; set; }

        public string CurrentWord { get; set; } = "";

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            RootNode = new TrieNode2<int>();
            for (var i = 0; i < sentences.Length; i++)
            {
                RootNode.Insert(sentences[i], times[i]);
            }

            CurrentNode = RootNode;
        }

        public IList<string> Input(char c)
        {
            var res = new List<string>();
            if (c == '#')
            {
                CurrentNode = RootNode;
                RootNode.Insert(CurrentWord);
                CurrentWord = "";
                return res;
            }

            CurrentWord += c;
            if (CurrentNode == null)
            {
                return res;
            }
            (res, CurrentNode) = RootNode.StartsWith(c.ToString(), 3, CurrentNode);
            return res;
        }
    }

    public class TrieNode2<T>
    {
        public T Val { get; set; }

        public Dictionary<string, int> Words { get; set; } = new();

        public bool IsWord { get; set; }

        public TrieNode2<T>[] Children { get; } = new TrieNode2<T>[27];

        public TrieNode2()
        {
        }

        public TrieNode2(T val, bool isWord = false)
        {
            Val = val;
            IsWord = isWord;
        }

        public void Insert(string word, int hotDegree)
        {
            var currentNode = this;

            foreach (var chr in word)
            {
                var index = chr == ' ' ? 26 : chr - 'a';
                currentNode.Children[index] ??= new TrieNode2<T>();
                currentNode = currentNode.Children[index];
                currentNode.Words[word] = hotDegree;

            }
            currentNode.IsWord = true;
        }

        public void Insert(string word)
        {
            var currentNode = this;

            foreach (var chr in word)
            {
                var index = chr == ' ' ? 26 : chr - 'a';
                currentNode.Children[index] ??= new TrieNode2<T>();
                currentNode = currentNode.Children[index];
                if (!currentNode.Words.TryAdd(word, 1))
                {
                    currentNode.Words[word]++;
                }
            }
            currentNode.IsWord = true;
        }


        public (List<string>, TrieNode2<T>) StartsWith(string prefix, int quantity, TrieNode2<T> currentNode = null)
        {
            var resultList = new List<string>();
            currentNode ??= this;
            foreach (var chr in prefix)
            {
                var index = chr == ' ' ? 26 : chr - 'a';
                if (currentNode.Children[index] == null)
                {
                    return (resultList, null);
                }
                currentNode = currentNode.Children[index];
            }

            var maxHeap = new MaxPriorityQueue<string, int>(currentNode.Words.Select(item => (item.Key, item.Value)));
            var lastPriority = 0;
            var tempList = new List<string>();
            PriorityQueue<string, string> tempMinHeap;
            while (maxHeap.Count > 0 && resultList.Count < quantity)
            {
                var dequeuedWord = maxHeap.Dequeue();
                var hotDegree = currentNode.Words[dequeuedWord];
                if (hotDegree < lastPriority)
                {
                    tempMinHeap = new PriorityQueue<string, string>(tempList.Select(a => (a, a)), new MinPriorityQueueStringLexicalComparer());
                    while (tempMinHeap.Count > 0 && resultList.Count < quantity)
                    {
                        resultList.Add(tempMinHeap.Dequeue());
                    }

                    tempList = new List<string>();
                }
                tempList.Add(dequeuedWord);
                lastPriority = hotDegree;
            }

            if (resultList.Count < quantity)
            {
                tempMinHeap = new PriorityQueue<string, string>(tempList.Select(a => (a, a)), new MinPriorityQueueStringLexicalComparer());
                while (tempMinHeap.Count > 0 && resultList.Count < quantity)
                {
                    resultList.Add(tempMinHeap.Dequeue());
                }
            }

            return (resultList, currentNode);
        }

    }
}