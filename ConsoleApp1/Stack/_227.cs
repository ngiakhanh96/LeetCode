using System;
using System.Collections.Generic;

namespace ConsoleApp1.Stack
{
    public class _227
    {
        public int Calculate(string s)
        {
            s += ".";
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
            foreach (var c in s)
            {
                if (string.IsNullOrWhiteSpace(c.ToString()))
                {
                    continue;
                }

                if (!int.TryParse(c.ToString(), out var intResult))
                {
                    var previousOperator = deque.Last?.Value;
                    if (previousOperator is not null && highPriorityOperatorDict.ContainsKey(previousOperator))
                    {
                        deque.RemoveLast();
                        var i = deque.Last.Value;
                        deque.RemoveLast();
                        var currentRes = highPriorityOperatorDict[previousOperator](int.Parse(i), int.Parse(currentNumber));
                        deque.AddLast(currentRes.ToString());
                    }
                    else
                    {
                        deque.AddLast(currentNumber);
                    }
                    currentNumber = "";
                    if (c.ToString() != ".")
                    {
                        deque.AddLast(c.ToString());
                    }
                }
                else
                {
                    currentNumber += c.ToString();
                }
            }

            while (deque.Count > 1)
            {
                var i = deque.First.Value;
                deque.RemoveFirst();
                var opr = deque.First.Value;
                deque.RemoveFirst();
                var i1 = deque.First.Value;
                deque.RemoveFirst();
                var currentRes = lowPriorityOperatorDict[opr](int.Parse(i), int.Parse(i1));
                deque.AddFirst(currentRes.ToString());
            }

            return int.Parse(deque.First.Value);
        }
    }
}
