namespace ConsoleApp1.Database
{
    public class _380
    {
        public class RandomizedSet
        {
            private HashSet<int> Set { get; set; }

            private Random Rand { get; set; }

            public RandomizedSet()
            {
                Set = new HashSet<int>();
                Rand = new Random();
            }

            public bool Insert(int val)
            {
                if (Set.Contains(val))
                {
                    return false;
                }

                Set.Add(val);
                return true;
            }

            public bool Remove(int val)
            {
                if (!Set.Contains(val))
                {
                    return false;
                }

                Set.Remove(val);
                return true;
            }

            public int GetRandom()
            {
                return Set.ElementAt(Rand.Next(Set.Count));
            }
        }
    }
}
