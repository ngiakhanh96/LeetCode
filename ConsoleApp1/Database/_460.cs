namespace ConsoleApp1.Database;

public class _460
{
    public class LFUCache
    {
        private Dictionary<int, (int value, LinkedListNode<int> lruNode, LinkedListNode<(int frequency, LinkedList<int> lruLinkedList)> lfuNode)> Cache
        { get; set; }

        private LinkedList<(int frequency, LinkedList<int> lruLinkedList)> LfuLinkedList { get; set; }

        private int Capacity { get; set; }

        public LFUCache(int capacity)
        {
            Cache =
                new Dictionary<int, (int value, LinkedListNode<int> lruNode, LinkedListNode<(int frequency, LinkedList<int> lruLinkedList)> lfuNode)>();
            LfuLinkedList = new LinkedList<(int frequency, LinkedList<int> lruLinkedList)>();
            Capacity = capacity;
        }

        public int Get(int key)
        {
            if (!Cache.ContainsKey(key))
            {
                return -1;
            }

            var cachedValue = Cache[key];
            var oldLfuNode = cachedValue.lfuNode;
            var oldLruNode = cachedValue.lruNode;

            oldLfuNode.Value.lruLinkedList.Remove(oldLruNode);
            var frequency = oldLfuNode.Value.frequency;
            var nextLfuNode = oldLfuNode.Next;
            if (nextLfuNode == null || nextLfuNode.Value.frequency != frequency + 1)
            {
                nextLfuNode = new LinkedListNode<(int frequency, LinkedList<int> lruLinkedList)>((
                    frequency + 1,
                    new LinkedList<int>()));
                LfuLinkedList.AddAfter(
                    oldLfuNode,
                    nextLfuNode);
            }

            var newLruNode = new LinkedListNode<int>(key);
            nextLfuNode.Value.lruLinkedList.AddLast(newLruNode);

            Cache[key] = (cachedValue.value, newLruNode, nextLfuNode);

            if (oldLfuNode.Value.lruLinkedList.Count == 0)
            {
                LfuLinkedList.Remove(oldLfuNode);
            }
            return cachedValue.value;
        }

        public void Put(int key, int value)
        {
            if (Capacity == 0)
            {
                return;
            }

            if (Cache.ContainsKey(key))
            {
                var cachedValue = Cache[key];
                var oldLfuNode = cachedValue.lfuNode;
                var oldLruNode = cachedValue.lruNode;

                oldLfuNode.Value.lruLinkedList.Remove(oldLruNode);
                var frequency = oldLfuNode.Value.frequency;
                var nextLfuNode = oldLfuNode.Next;
                if (nextLfuNode == null || nextLfuNode.Value.frequency != frequency + 1)
                {
                    nextLfuNode = new LinkedListNode<(int frequency, LinkedList<int> lruLinkedList)>((
                        frequency + 1,
                        new LinkedList<int>()));
                    LfuLinkedList.AddAfter(
                        oldLfuNode,
                        nextLfuNode);
                }

                var newLruNode = new LinkedListNode<int>(key);
                nextLfuNode.Value.lruLinkedList.AddLast(newLruNode);

                Cache[key] = (value, newLruNode, nextLfuNode);

                if (oldLfuNode.Value.lruLinkedList.Count == 0)
                {
                    LfuLinkedList.Remove(oldLfuNode);
                }
                return;
            }

            if (Cache.Count == Capacity)
            {
                var removingLfuNode = LfuLinkedList.First;
                var removingLruNode = removingLfuNode.Value.lruLinkedList.First;
                removingLfuNode.Value.lruLinkedList.Remove(removingLruNode);
                if (removingLfuNode.Value.lruLinkedList.Count == 0)
                {
                    LfuLinkedList.Remove(removingLfuNode);
                }

                Cache.Remove(removingLruNode.Value);
            }

            var firstLfuNode = LfuLinkedList.First;
            if (firstLfuNode == null || firstLfuNode.Value.frequency != 1)
            {
                firstLfuNode =
                    new LinkedListNode<(int frequency, LinkedList<int> lruLinkedList)>((1, new LinkedList<int>()));
                LfuLinkedList.AddFirst(firstLfuNode);
            }

            var insertingLruNode = new LinkedListNode<int>(key);
            firstLfuNode.Value.lruLinkedList.AddLast(insertingLruNode);

            Cache[key] = (value, insertingLruNode, firstLfuNode);
        }
    }
}