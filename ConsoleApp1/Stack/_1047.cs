using System.Collections.Generic;

namespace ConsoleApp1.Stack
{
    public class _1047
    {
        public string RemoveDuplicates(string s)
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
}
