using System.Text;

namespace ConsoleApp1.BFS;

[LastVisited(2022, 12, 08)]
public class _433
{
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        var queue = new Queue<string>();
        queue.Enqueue(startGene);
        var numOfNodesInCurrentLevel = 1;
        var currentLevel = 0;
        var visited = new HashSet<string> { startGene };
        var bankHashSet = new HashSet<string>(bank) { startGene };
        var validCharacters = new List<string> { "A", "C", "G", "T" };
        while (queue.Any())
        {
            var currentGene = queue.Dequeue();
            if (currentGene == endGene)
            {
                return currentLevel;
            }

            var prefix = new StringBuilder(); ;
            var postfix = currentGene;
            for (var i = 0; i < currentGene.Length; i++)
            {
                postfix = postfix.Substring(1);
                foreach (var validChar in validCharacters)
                {
                    var nextGene = prefix + validChar + postfix;
                    if (bankHashSet.Contains(nextGene) && visited.Add(nextGene))
                    {
                        queue.Enqueue(nextGene);
                    }
                }
                prefix.Append(currentGene[i]);
            }

            if (--numOfNodesInCurrentLevel == 0)
            {
                numOfNodesInCurrentLevel = queue.Count;
                currentLevel++;
            }
        }

        return -1;
    }

    public int MinMutation2(string start, string end, string[] bank)
    {
        var adjacentGenesDict = new Dictionary<string, List<string>>();
        var adjacentWildCardGenesDict = new Dictionary<string, List<string>>();
        var bankList = bank.ToList();
        bankList.Add(start);
        foreach (var gene in bankList)
        {
            var geneArray = gene.ToCharArray();
            for (var i = 0; i < geneArray.Length; i++)
            {
                var temp = geneArray[i];
                geneArray[i] = '*';
                var key = new string(geneArray);
                if (!adjacentGenesDict.TryAdd(key, new List<string> { gene }))
                {
                    adjacentGenesDict[key].Add(gene);
                }
                if (!adjacentWildCardGenesDict.TryAdd(gene, new List<string> { key }))
                {
                    adjacentWildCardGenesDict[gene].Add(key);
                }

                geneArray[i] = temp;
            }
        }
        return Bfs(start, end, adjacentGenesDict, adjacentWildCardGenesDict);
    }

    private int Bfs(string start, string end, Dictionary<string, List<string>> adjGenesDict, Dictionary<string, List<string>> adjWildCardGenesDict)
    {
        var bfsQueue = new Queue<string>();
        bfsQueue.Enqueue(start);
        var visitedGenes = new HashSet<string> { start };
        var distance = -1;
        while (bfsQueue.Any())
        {
            var count = bfsQueue.Count;
            distance++;
            for (var i = 0; i < count; i++)
            {
                var currentGene = bfsQueue.Dequeue();
                if (currentGene == end)
                {
                    return distance;
                }

                foreach (var wildCardGene in adjWildCardGenesDict[currentGene])
                {
                    foreach (var gene in adjGenesDict[wildCardGene])
                    {
                        if (!visitedGenes.Contains(gene))
                        {
                            bfsQueue.Enqueue(gene);
                            visitedGenes.Add(gene);
                        }
                    }
                }

            }
        }

        return -1;
    }

    public Queue<string> BfsQueue { get; set; } = new();

    public HashSet<string> VisitedHashSet { get; set; } = new();

    public string EndGene { get; set; }

    public int NumberOfMutationsInShortestTransformationSequence { get; set; } = -1;

    public Dictionary<string, List<string>> AdjacentGenesDict { get; set; } = new();

    public int MinMutation3(string start, string end, string[] bank)
    {
        EndGene = end;
        var bankList = bank.ToList();
        bankList.Add(start);
        BuildAdjacentGenesDict(bankList);
        Bfs(start);
        return NumberOfMutationsInShortestTransformationSequence;
    }

    private List<string> BuildWildCardAdjacentGenes(string gene)
    {
        var wildCardAdjacentGeneList = new List<string>();
        for (var starPosition = 0; starPosition < gene.Length; starPosition++)
        {
            var wildCardAdjacentGeneArray = gene.ToCharArray();
            wildCardAdjacentGeneArray[starPosition] = '*';
            var wildCardAdjacentGene = new string(wildCardAdjacentGeneArray);

            wildCardAdjacentGeneList.Add(wildCardAdjacentGene);
        }

        return wildCardAdjacentGeneList;
    }

    private void BuildAdjacentGenesDict(IList<string> wordList)
    {
        foreach (var word in wordList)
        {
            var wildCardAdjacentWords = BuildWildCardAdjacentGenes(word);
            foreach (var wildCardAdjacentWord in wildCardAdjacentWords)
            {
                if (!AdjacentGenesDict.TryAdd(wildCardAdjacentWord, new List<string> { word }))
                {
                    AdjacentGenesDict[wildCardAdjacentWord].Add(word);
                }
            }
        }
    }

    private void Bfs(string beginGene)
    {
        BfsQueue.Enqueue(beginGene);
        var currentLevel = -1;
        VisitedHashSet.Add(beginGene);

        while (BfsQueue.Count > 0)
        {
            var numOfGenesInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numOfGenesInCurrentLevel; i++)
            {
                var gene = BfsQueue.Dequeue();

                if (gene == EndGene)
                {
                    NumberOfMutationsInShortestTransformationSequence = currentLevel;
                    return;
                }

                var wildCardAdjacentGenes = BuildWildCardAdjacentGenes(gene);
                foreach (var wildCardAdjacentGene in wildCardAdjacentGenes)
                {
                    foreach (var adjacentWord in AdjacentGenesDict[wildCardAdjacentGene])
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