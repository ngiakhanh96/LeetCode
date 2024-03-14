using System.Text;

namespace ConsoleApp1.Stack;

[LastVisited(2024, 03, 14)]
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
                if (stack.TryPeek(out var previousOperator) && previousOperator is "*" or "/")
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

                if (c is '+' or '-')
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
        s += ".";
        var stack = new Stack<string>();
        var operatorDict = new Dictionary<char, Func<int, int, int>>{
            {'*', (a, b) => a * b},
            {'/', (a, b) => a / b},
            {'+', (a, b) => a + b},
            {'-', (a, b) => a - b},
        };

        var highOperatorSet = new HashSet<char> { '*', '/' };
        var lowOperatorSet = new HashSet<char> { '+', '-' };
        int currentNumber = 0;
        foreach (var token in s)
        {
            if (token == ' ')
            {
                continue;
            }
            if (char.IsDigit(token))
            {
                currentNumber = currentNumber * 10 + token - '0';
            }
            else
            {
                if (stack.Count > 0 && (token == '.' || lowOperatorSet.Contains(token) || highOperatorSet.Contains(stack.Peek()[0])) && operatorDict.TryGetValue(stack.Pop()[0], out var function))
                {
                    var number1 = stack.Pop();
                    var result = function(int.Parse(number1), currentNumber);
                    if (stack.Count > 0 && (lowOperatorSet.Contains(token) || token == '.'))
                    {
                        var opr = stack.Pop()[0];
                        number1 = stack.Pop();
                        result = operatorDict[opr](int.Parse(number1), result);
                    }
                    stack.Push(result.ToString());
                }
                else
                {
                    stack.Push(currentNumber.ToString());
                }
                if (token != '.')
                {
                    stack.Push(token.ToString());
                }
                currentNumber = 0;
            }
        }

        return int.Parse(stack.Pop());
    }
}