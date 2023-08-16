namespace ConsoleApp1.Stack;

[LastVisited(2023, 08, 16)]
public class _20
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var dict = new Dictionary<char, char>{
            {')', '('},
            {'}', '{'},
            {']', '['}
        };
        foreach (var chr in s)
        {
            if (dict.TryGetValue(chr, out var openChr))
            {
                if (stack.Count > 0 && stack.Peek() == openChr)
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                stack.Push(chr);
            }
        }

        return stack.Count == 0;
    }
}