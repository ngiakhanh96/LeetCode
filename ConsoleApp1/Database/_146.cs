namespace ConsoleApp1.Database
{
    public class _146
    {
        public class LRUCache
        {
            private Dictionary<int, (int value, LinkedListNode<int> node)> Cache { get; set; }

            private LinkedList<int> LeastRecentUsedLinkedList { get; set; }

            private int Capacity { get; set; }

            public LRUCache(int capacity)
            {
                Cache = new Dictionary<int, (int value, LinkedListNode<int> node)>();
                LeastRecentUsedLinkedList = new LinkedList<int>();
                Capacity = capacity;
            }

            public int Get(int key)
            {
                if (!Cache.ContainsKey(key))
                {
                    return -1;
                }


                LeastRecentUsedLinkedList.Remove(Cache[key].node);
                var node = new LinkedListNode<int>(key);
                LeastRecentUsedLinkedList.AddLast(node);
                Cache[key] = (Cache[key].value, node);
                return Cache[key].value;
            }

            public void Put(int key, int value)
            {
                if (Cache.ContainsKey(key))
                {
                    LeastRecentUsedLinkedList.Remove(Cache[key].node);
                    var newNode = new LinkedListNode<int>(key);
                    LeastRecentUsedLinkedList.AddLast(newNode);
                    Cache[key] = (value, newNode);
                    return;
                }

                if (Cache.Count == Capacity)
                {
                    Cache.Remove(LeastRecentUsedLinkedList.First.Value);
                    LeastRecentUsedLinkedList.RemoveFirst();
                }
                var node = new LinkedListNode<int>(key);
                LeastRecentUsedLinkedList.AddLast(node);
                Cache[key] = (value, node);
            }
        }
    }
}
