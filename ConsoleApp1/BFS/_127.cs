namespace ConsoleApp1.BFS;

public class _127
{

    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var adjacentWordsDict = new Dictionary<string, List<string>>();
        var adjacentWildCardWordsDict = new Dictionary<string, List<string>>();
        var wordHashSet = wordList.ToHashSet();
        wordHashSet.Add(beginWord);
        foreach (var word in wordHashSet)
        {
            var wordArray = word.ToCharArray();
            for (var i = 0; i < wordArray.Length; i++)
            {
                var temp = wordArray[i];
                wordArray[i] = '*';
                var key = new string(wordArray);
                if (!adjacentWordsDict.TryAdd(key, new List<string> { word }))
                {
                    adjacentWordsDict[key].Add(word);
                }
                if (!adjacentWildCardWordsDict.TryAdd(word, new List<string> { key }))
                {
                    adjacentWildCardWordsDict[word].Add(key);
                }

                wordArray[i] = temp;
            }
        }
        return Bfs(beginWord, endWord, adjacentWordsDict, adjacentWildCardWordsDict);
    }

    private int Bfs(string start, string end, Dictionary<string, List<string>> adjWordsDict, Dictionary<string, List<string>> adjWildCardWordsDict)
    {
        var bfsQueue = new Queue<string>();
        bfsQueue.Enqueue(start);
        var visitedWords = new HashSet<string> { start };
        var distance = 0;
        while (bfsQueue.Any())
        {
            var count = bfsQueue.Count;
            distance++;
            for (var i = 0; i < count; i++)
            {
                var currentWord = bfsQueue.Dequeue();
                if (currentWord == end)
                {
                    return distance;
                }

                foreach (var wildCardWord in adjWildCardWordsDict[currentWord])
                {
                    foreach (var word in adjWordsDict[wildCardWord])
                    {
                        if (!visitedWords.Contains(word))
                        {
                            bfsQueue.Enqueue(word);
                            visitedWords.Add(word);
                        }
                    }
                }

            }
        }

        return 0;
    }
    public Queue<string> BfsQueue { get; set; } = new Queue<string>();

    public HashSet<string> VisitedHashSet { get; set; } = new HashSet<string>();

    public string EndWord { get; set; }

    public int NumberOfWordsInShortestTransformationSequence { get; set; }

    public Dictionary<string, List<string>> AdjacentWordsDict { get; set; } =
        new Dictionary<string, List<string>>();

    public int LadderLength2(string beginWord, string endWord, IList<string> wordList)
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
            var wildCardAdjacentArray = word.ToCharArray();
            wildCardAdjacentArray[starPosition] = '*';
            var wildCardAdjacentWord = new string(wildCardAdjacentArray);

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
        VisitedHashSet.Add(beginWord);
        var currentLevel = 0;
        while (BfsQueue.Count > 0)
        {
            var numOfWordsInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numOfWordsInCurrentLevel; i++)
            {
                var word = BfsQueue.Dequeue();

                if (word == EndWord)
                {
                    NumberOfWordsInShortestTransformationSequence = currentLevel;
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
            }
        }
    }
}