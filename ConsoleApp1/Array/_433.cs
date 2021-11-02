namespace ConsoleApp1.Array;

public class _433
{
    public Queue<string> BfsQueue { get; set; } = new Queue<string>();

    public HashSet<string> VisitedHashSet { get; set; } = new HashSet<string>();

    public string EndGene { get; set; }

    public int NumberOfMutationsInShortestTransformationSequence { get; set; } = -1;

    public Dictionary<string, List<string>> AdjacentGenesDict { get; set; } =
        new Dictionary<string, List<string>>();

    public int MinMutation(string start, string end, string[] bank)
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
            var wildCardAdjacentGene = "";
            for (var chr = 0; chr < gene.Length; chr++)
            {
                wildCardAdjacentGene += chr != starPosition ? gene[chr] : "*";
            }

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