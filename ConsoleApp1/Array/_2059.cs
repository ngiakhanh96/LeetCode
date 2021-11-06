namespace ConsoleApp1.Array;

public class _2059
{
    public Queue<int> BfsQueue { get; set; } = new Queue<int>();

    public HashSet<int> IsVisited { get; set; } = new HashSet<int>();

    public int[] Nums { get; set; }

    public Func<int, int, int>[] TransformList { get; set; } = new Func<int, int, int>[]
    {
        (a, b) => a + b,
        (a, b) => a - b,
        (a, b) => a ^ b
    };

    public int MinimumOperations(int[] nums, int start, int goal)
    {
        Nums = nums;
        return Bfs(start, goal);
    }

    private int Bfs(int start, int target)
    {
        BfsQueue.Enqueue(start);
        IsVisited.Add(start);
        var currentLevel = -1;
        while (BfsQueue.Count > 0)
        {
            var numOfNumsInCurrentLevel = BfsQueue.Count;
            currentLevel++;
            for (var i = 0; i < numOfNumsInCurrentLevel; i++)
            {
                var currentNum = BfsQueue.Dequeue();

                if (currentNum == target)
                {
                    return currentLevel;
                }

                if (currentNum >= 0 && currentNum <= 1000)
                {
                    foreach (var val in Nums)
                    {
                        foreach (var trans in TransformList)
                        {
                            var adjacentNum = trans(currentNum, val);
                            if (!IsVisited.Contains(adjacentNum))
                            {
                                BfsQueue.Enqueue(adjacentNum);
                                IsVisited.Add(adjacentNum);
                            }
                        }
                    }
                }
            }
        }

        return -1;
    }
}