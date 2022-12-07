namespace ConsoleApp1.HashTable;

public class _676
{
    public class MagicDictionary
    {
        public Dictionary<string, List<string>> Dictionary { get; } = new();

        public void BuildDict(string[] dictionary)
        {
            foreach (var word in dictionary)
            {
                for (var i = 0; i < word.Length; i++)
                {
                    var insertingWordArray = word.ToCharArray();
                    insertingWordArray[i] = '*';
                    var insertingWord = new string(insertingWordArray);

                    if (!Dictionary.TryAdd(insertingWord, new List<string> { word }))
                    {
                        Dictionary[insertingWord].Add(word);
                    }
                }
            }
        }

        public bool Search(string searchWord)
        {
            for (var i = 0; i < searchWord.Length; i++)
            {
                var searchingWordArray = searchWord.ToCharArray();
                searchingWordArray[i] = '*';
                var searchingWord = new string(searchingWordArray);

                if (Dictionary.ContainsKey(searchingWord))
                {
                    if (Dictionary[searchingWord].Count > 1 || Dictionary[searchingWord].First() != searchWord)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}