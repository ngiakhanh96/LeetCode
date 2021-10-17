namespace ConsoleApp1.Stack;

public class _224
{
    public int Calculate(string s)
    {
        s = "(" + s + ")";
        var lowPriorityOperatorDict = new Dictionary<string, Func<int, int, int>>
        {
            { "+", (i, i1) => i + i1 },
            { "-", (i, i1) => i - i1 }
        };

        var currentNumber = "";
        var deque = new LinkedList<string>();
        var stack = new Stack<string>();
        foreach (var c in s)
        {
            if (string.IsNullOrWhiteSpace(c.ToString()))
            {
                continue;
            }

            if (lowPriorityOperatorDict.ContainsKey(c.ToString()) ||
                c.ToString() == "(" ||
                c.ToString() == ")")
            {
                var previousOperator = deque.Last?.Value;
                if (!string.IsNullOrWhiteSpace(currentNumber))
                {
                    deque.AddLast(currentNumber);
                }

                else if (c.ToString() == "-")
                {
                    if (previousOperator == null || previousOperator == "(")
                    {
                        deque.AddLast("0");
                    }
                }

                if (c.ToString() == ")")
                {
                    string prev;
                    while ((prev = deque.Last.Value) != "(")
                    {
                        stack.Push(prev);
                        deque.RemoveLast();
                    }
                    deque.RemoveLast();

                    while (stack.Count > 1)
                    {
                        var i = stack.Pop();
                        var opr = stack.Pop();
                        var i1 = stack.Pop();
                        var currentRes = lowPriorityOperatorDict[opr](int.Parse(i), int.Parse(i1));
                        stack.Push(currentRes.ToString());
                    }

                    var res = stack.Pop();
                    deque.AddLast(res);
                }

                currentNumber = "";

                if (c.ToString() != ")")
                {
                    deque.AddLast(c.ToString());
                }
            }
            else
            {
                currentNumber += c.ToString();
            }
        }

        return int.Parse(deque.First.Value);
    }
}