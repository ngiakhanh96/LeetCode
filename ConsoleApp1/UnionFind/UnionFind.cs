namespace ConsoleApp1.UnionFind;

public class UnionFind<T>
{
    public int[] Parents { get; }

    public int Count { get; private set; }

    public int[] Ranks { get; }

    public int[] GridDimension { get; set; } = new int[] { 0, 0 };

    public UnionFind(int capacity, Func<T, bool> condition = null) : this(new T[capacity], condition)
    {
    }

    public UnionFind(T[] array, Func<T, bool> condition = null)
    {
        Parents = new int[array.Length];
        for (var i = 0; i < Parents.Length; i++)
        {
            if (condition == null || condition(array[i]))
            {
                Parents[i] = i;
                Count++;
            }
        }

        Ranks = new int[array.Length];
    }

    public UnionFind(T[,] grid, Func<T, bool> condition = null)
    {
        Parents = new int[grid.GetLength(0) * grid.GetLength(1)];
        GridDimension[0] = grid.GetLength(0);
        GridDimension[1] = grid.GetLength(1);
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                if (condition == null || condition(grid[i, j]))
                {
                    var index = i * grid.GetLength(1) + j;
                    Parents[index] = index;
                    Count++;
                }
            }
        }
        Ranks = new int[grid.Length * grid.GetLength(1)];
    }

    public UnionFind(T[][] grid, Func<T, bool> condition = null)
    {
        Parents = new int[grid.Length * grid[0].Length];
        GridDimension[0] = grid.Length;
        GridDimension[1] = grid[0].Length;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (condition == null || condition(grid[i][j]))
                {
                    var index = i * grid[0].Length + j;
                    Parents[index] = index;
                    Count++;
                }
            }
        }
        Ranks = new int[grid.Length * grid[0].Length];
    }

    public bool TryUnion(int index1, int index2)
    {
        var root1 = Find(index1);
        var root2 = Find(index2);

        if (root1 == root2) return false;
        Count--;
        if (Ranks[root1] > Ranks[root2])
        {
            Parents[root2] = root1;
        }
        else
        {
            Parents[root1] = root2;
        }

        if (Ranks[root1] == Ranks[root2])
        {
            Ranks[root2]++;
        }
        return true;

    }

    public bool TryUnion(int index1Row, int index1Col, int index2Row, int index2Col)
    {
        var index1 = index1Row * GridDimension[1] + index1Col;
        var index2 = index2Row * GridDimension[1] + index2Col;

        return TryUnion(index1, index2);
    }

    public int Find(int index)
    {
        if (index == Parents[index])
        {
            return index;
        }

        Parents[index] = Find(Parents[index]);
        return Parents[index];
    }
}