namespace ConsoleApp1.DFS;

public class _207
{
    public HashSet<int> VisitedCourses { get; set; } = new HashSet<int>();

    public Dictionary<int, List<int>> Graph { get; set; } = new Dictionary<int, List<int>>();

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        foreach (var prerequisite in prerequisites)
        {
            if (Graph.ContainsKey(prerequisite[0]))
            {
                Graph[prerequisite[0]].Add(prerequisite[1]);
            }
            else
            {
                Graph[prerequisite[0]] = new List<int> { prerequisite[1] };
            }
        }

        for (int i = 0; i < numCourses; i++)
        {
            var res = Dfs(i);
            if (!res)
            {
                return false;
            }
        }

        return true;
    }

    private bool Dfs(int course)
    {
        if (Graph.ContainsKey(course))
        {
            if (VisitedCourses.Contains(course))
            {
                return false;
            }
            VisitedCourses.Add(course);
            foreach (var afterCourse in Graph[course])
            {
                var res = Dfs(afterCourse);
                if (!res)
                {
                    return false;
                }
            }
            Graph.Remove(course);
        }
        return true;
    }
}