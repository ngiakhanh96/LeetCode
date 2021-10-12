using System;
using System.Collections.Generic;

namespace ConsoleApp1.Stack
{
    public class _150
    {
        public int EvalRPN(string[] tokens)
        {
            var dict = new Dictionary<string, Func<int, int, int>>
            {
                { "+", (i, i1) => i + i1 },
                { "-", (i, i1) => i - i1 },
                { "*", (i, i1) => i * i1 },
                { "/", (i, i1) => i / i1 }
            };
            var stack = new Stack<string>();
            foreach (var token in tokens)
            {
                if (stack.Count == 0)
                {
                    stack.Push(token);
                    continue;
                }

                if (dict.ContainsKey(token))
                {
                    var i1 = int.Parse(stack.Pop());
                    var i = int.Parse(stack.Pop());
                    var res = dict[token](i, i1);
                    stack.Push(res.ToString());
                }
                else
                {
                    stack.Push(token);
                }
            }

            return int.Parse(stack.Pop());
        }
    }
}
