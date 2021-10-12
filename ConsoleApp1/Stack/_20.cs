using System.Collections.Generic;

namespace ConsoleApp1.Stack
{
    public class _20
    {
        public bool IsValid(string s)
        {
            var dict = new Dictionary<char, char>
            {
                {')', '('},
                {'}', '{'},
                {']' ,'['}
            };
            var stack = new Stack<char>();
            foreach (var chr in s)
            {
                if (stack.Count == 0)
                {
                    stack.Push(chr);
                    continue;
                }
                if (dict.ContainsKey(chr) && stack.Peek() == dict[chr])
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(chr);
                }
            }

            return stack.Count == 0;
        }
    }
}
