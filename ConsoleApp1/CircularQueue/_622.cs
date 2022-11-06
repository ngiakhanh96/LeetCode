namespace ConsoleApp1.CircularQueue;

[LastVisited(2022, 11, 7)]
public class _622
{
    public class MyCircularQueue
    {
        private int[] _queue;
        private int _head;
        private int _tail;
        private int _count;
        public MyCircularQueue(int k)
        {
            _queue = new int[k];
            _head = 0;
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
            _count++;
            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
            {
                return false;
            }
            _head = (_head + 1) % _queue.Length;
            _count--;
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
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _queue.Length;
        }
    }


    public class MyCircularQueue2
    {
        private readonly int[] _queue;
        private int _head;
        private int _tail;
        public MyCircularQueue2(int k)
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