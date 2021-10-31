namespace ConsoleApp1.Array
{
    public class _127
    {
        public Queue<string> BfsQueue { get; set; } = new Queue<string>();

        public HashSet<string> VisitedHashSet { get; set; } = new HashSet<string>();

        public int CurrentLevel { get; set; }

        public int NumOfWordsInCurrentLevel { get; set; }

        public string EndWord { get; set; }

        public int NumberOfWordsInShortestTransformationSequence { get; set; }

        public Dictionary<string, List<string>> AdjacentWordsDict { get; set; } =
            new Dictionary<string, List<string>>();

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            EndWord = endWord;
            wordList.Add(beginWord);
            BuildAdjacentWordsDict(wordList);
            Bfs(beginWord);
            return NumberOfWordsInShortestTransformationSequence;
        }

        private List<string> BuildWildCardAdjacentWords(string word)
        {
            var wildCardAdjacentWords = new List<string>();
            for (var starPosition = 0; starPosition < word.Length; starPosition++)
            {
                var wildCardAdjacentWord = "";
                for (var chr = 0; chr < word.Length; chr++)
                {
                    wildCardAdjacentWord += chr != starPosition ? word[chr] : "*";
                }

                wildCardAdjacentWords.Add(wildCardAdjacentWord);
            }

            return wildCardAdjacentWords;
        }

        private void BuildAdjacentWordsDict(IList<string> wordList)
        {
            foreach (var word in wordList)
            {
                var wildCardAdjacentWords = BuildWildCardAdjacentWords(word);
                foreach (var wildCardAdjacentWord in wildCardAdjacentWords)
                {
                    if (!AdjacentWordsDict.TryAdd(wildCardAdjacentWord, new List<string> { word }))
                    {
                        AdjacentWordsDict[wildCardAdjacentWord].Add(word);
                    }
                }
            }
        }

        private void Bfs(string beginWord)
        {
            BfsQueue.Enqueue(beginWord);
            CurrentLevel = 1;
            NumOfWordsInCurrentLevel = BfsQueue.Count;
            VisitedHashSet.Add(beginWord);
            Bfs();
        }

        private void Bfs()
        {
            if (BfsQueue.Count == 0)
            {
                return;
            }

            var word = BfsQueue.Dequeue();
            NumOfWordsInCurrentLevel--;

            if (word == EndWord)
            {
                NumberOfWordsInShortestTransformationSequence = CurrentLevel;
                return;
            }

            var wildCardAdjacentWords = BuildWildCardAdjacentWords(word);
            foreach (var wildCardAdjacentWord in wildCardAdjacentWords)
            {
                foreach (var adjacentWord in AdjacentWordsDict[wildCardAdjacentWord])
                {
                    if (!VisitedHashSet.Contains(adjacentWord))
                    {
                        VisitedHashSet.Add(adjacentWord);
                        BfsQueue.Enqueue(adjacentWord);
                    }
                }
            }

            if (NumOfWordsInCurrentLevel == 0)
            {
                NumOfWordsInCurrentLevel = BfsQueue.Count;
                CurrentLevel++;
            }
            Bfs();
        }
    }
}
