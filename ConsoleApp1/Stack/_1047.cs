using System.Text;

namespace ConsoleApp1.Stack;

[LastVisited(2022, 11, 9)]
public class _1047
{
    public string RemoveDuplicates(string s)
    {
        var deque = new LinkedList<char>();
        var result = new StringBuilder();
        foreach (var chr in s)
        {
            if (deque.Last == null)
            {
                deque.AddLast(chr);
            }
            else
            {
                if (deque.Last.Value == chr)
                {
                    deque.RemoveLast();
                }
                else
                {
                    deque.AddLast(chr);
                }
            }
        }
        while (deque.Count > 0)
        {
            result.Append(deque.First.Value);
            deque.RemoveFirst();
        }
        return result.ToString();
    }

    public string RemoveDuplicates2(string s)
    {
        var stack = new Stack<char>();
        foreach (var chr in s)
        {
            if (stack.Count == 0)
            {
                stack.Push(chr);
                continue;
            }
            if (stack.Peek() == chr)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(chr);
            }
        }

        var resString = "";
        while (stack.Count > 0)
        {
            resString = stack.Peek() + resString;
            stack.Pop();
        }

        return resString;
    }
}