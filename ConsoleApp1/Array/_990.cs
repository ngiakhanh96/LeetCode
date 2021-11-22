namespace ConsoleApp1.Array;

public class _990
{
    public bool EquationsPossible(string[] equations)
    {
        var unionFind = new UnionFind<int>(26);
        foreach (var equation in equations)
        {
            if (!equation.Contains("!"))
            {
                unionFind.TryUnion(equation[0] - 97, equation[3] - 97);
            }
        }

        foreach (var equation in equations)
        {
            if (equation.Contains("!") && unionFind.Find(equation[0] - 97) == unionFind.Find(equation[3] - 97))
            {
                return false;
            }
        }
        return true;
    }
}