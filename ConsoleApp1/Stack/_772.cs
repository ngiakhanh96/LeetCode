using System;
using System.Collections.Generic;

namespace ConsoleApp1.Stack
{
    public class _772
    {
        public int Calculate(string s)
        {
            s = "(" + s + ")";
            var highPriorityOperatorDict = new Dictionary<string, Func<int, int, int>>
            {
                {"*", (i, i1) => i * i1 },
                {"/", (i, i1) => i / i1 }
            };
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

                if (highPriorityOperatorDict.ContainsKey(c.ToString()) ||
                    lowPriorityOperatorDict.ContainsKey(c.ToString()) ||
                    c.ToString() == "(" ||
                    c.ToString() == ")")
                {
                    var previousOperator = deque.Last?.Value;
                    if (!TryDoHighPriorityOperation(deque, currentNumber, highPriorityOperatorDict, c.ToString()))
                    {
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
                        if (!TryDoHighPriorityOperation(deque, res, highPriorityOperatorDict))
                        {
                            deque.AddLast(res);
                        }
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

        private bool TryDoHighPriorityOperation(
            LinkedList<string> deque,
            string currentNumber,
            Dictionary<string, Func<int, int, int>> highPriorityOperatorDict,
            string currentChar = "")
        {
            var previousOperator = deque.Last?.Value;
            if (currentChar != "(" && previousOperator is not null && highPriorityOperatorDict.ContainsKey(previousOperator))
            {
                deque.RemoveLast();
                var i = deque.Last.Value;
                deque.RemoveLast();
                var currentRes = highPriorityOperatorDict[previousOperator](int.Parse(i), int.Parse(currentNumber));
                deque.AddLast(currentRes.ToString());
                return true;
            }

            return false;
        }
    }
}
