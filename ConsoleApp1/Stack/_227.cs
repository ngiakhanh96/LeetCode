using System.Text;

namespace ConsoleApp1.Stack;

[LastVisited(2022, 11, 14)]
public class _227
{
    // Time: O(n)
    // Space: O(n)
    // Look at below to see optimized version
    public int Calculate(string s)
    {
        s += "+";
        var operatorDict = new Dictionary<string, Func<int, int, int>>
        {
            {"*", (i, i1) => i * i1 },
            {"/", (i, i1) => i / i1 },
            {"+", (i, i1) => i + i1 },
            {"-", (i, i1) => i - i1 }
        };

        var currentNumber = new StringBuilder();
        var stack = new Stack<string>();
        foreach (var c in s)
        {
            if (c == ' ')
            {
                continue;
            }

            if (operatorDict.ContainsKey(c.ToString()))
            {
                if (stack.TryPeek(out var previousOperator) && (previousOperator == "*" || previousOperator == "/"))
                {
                    stack.Pop();
                    var firstNum = stack.Pop();
                    var currentRes = operatorDict[previousOperator](int.Parse(firstNum), int.Parse(currentNumber.ToString()));
                    stack.Push(currentRes.ToString());
                }
                else
                {
                    stack.Push(currentNumber.ToString());
                }

                if (c == '+' || c == '-')
                {
                    if (stack.Count > 1)
                    {
                        var secondNum = stack.Pop();
                        var opr = stack.Pop();
                        var firstNum = stack.Pop();
                        var result = operatorDict[opr](int.Parse(firstNum), int.Parse(secondNum));
                        stack.Push(result.ToString());
                    }
                }
                currentNumber.Clear();
                stack.Push(c.ToString());
            }
            else
            {
                currentNumber.Append(c);
            }
        }

        // Remove the last '+'
        stack.Pop();
        return int.Parse(stack.Pop());
    }

    // Optimized version
    // Time: O(n)
    // Space: O(1)
    public int Calculate2(string s)
    {
        s += "+";
        var dict = new Dictionary<char, Func<int, int, int>>{
            {'+', (a, b) => a+b},
            {'-', (a, b) => a-b},
            {'*', (a, b) => a*b},
            {'/', (a, b) => a/b}
        };
        var numStack = new Stack<int>();
        var oprStack = new Stack<char>();
        var currentNumber = 0;

        foreach (var chr in s)
        {
            if (chr == ' ')
            {
                continue;
            }
            if (dict.ContainsKey(chr))
            {
                if (oprStack.TryPeek(out var previousOpr) && (previousOpr == '*' || previousOpr == '/'))
                {
                    previousOpr = oprStack.Pop();
                    var firstNum = numStack.Pop();
                    var result = dict[previousOpr](firstNum, currentNumber);
                    numStack.Push(result);
                }
                else
                {
                    numStack.Push(currentNumber);
                }
                if (chr == '+' || chr == '-')
                {
                    if (numStack.Count > 1)
                    {
                        var secondNum = numStack.Pop();
                        var opr = oprStack.Pop();
                        var firstNum = numStack.Pop();
                        var result = dict[opr](firstNum, secondNum);
                        numStack.Push(result);
                    }
                }
                oprStack.Push(chr);
                currentNumber = 0;
            }
            else
            {
                currentNumber = (currentNumber * 10) + int.Parse(chr.ToString());
            }
        }

        return numStack.Pop();
    }
}