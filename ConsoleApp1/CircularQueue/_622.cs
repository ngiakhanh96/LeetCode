namespace ConsoleApp1.CircularQueue;

public class _622
{
    public class MyCircularQueue
    {
        private readonly int[] _queue;
        private int _head;
        private int _tail;
        public MyCircularQueue(int k)
        {
            _queue = new int[k];
            _head = -1;
            _tail = -1;
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
            {
                return false;
            }

            _tail = (_tail + 1) % _queue.Length;
            _queue[_tail] = value;
            if (_head < 0)
            {
                _head++;
            }
            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
            {
                return false;
            }
            _head = (_head + 1) % _queue.Length;
            if ((_tail + 1) % _queue.Length == _head)
            {
                _head = -1;
                _tail = -1;
            }
            return true;
        }

        public int Front()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return _queue[_head];
        }

        public int Rear()
        {
            if (IsEmpty())
            {
                return -1;
            }

            return _queue[_tail];
        }

        public bool IsEmpty()
        {
            return _head == -1 && _tail == -1;
        }

        public bool IsFull()
        {
            return (_tail + 1) % _queue.Length == _head;
        }
    }
}