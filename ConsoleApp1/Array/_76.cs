namespace ConsoleApp1.Array
{
    public class _76
    {
        public string MinWindow(string s, string t)
        {
            var tCharDict = new Dictionary<char, int>();
            foreach (var tChar in t)
            {
                if (!tCharDict.TryAdd(tChar, 1))
                {
                    tCharDict[tChar]++;
                }
            }

            var windowDict = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; i++)
            {
                -4
            }
        }
    }
}
