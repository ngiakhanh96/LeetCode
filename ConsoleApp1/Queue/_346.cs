namespace ConsoleApp1.Queue;

[LastVisited(2022, 11, 7)]
public class _346
{
    public class MovingAverage
    {
        private Queue<int> _queue;
        private int _size;
        private int _culmulativeRes;
        public MovingAverage(int size)
        {
            _size = size;
            _queue = new Queue<int>();
            _culmulativeRes = 0;
        }

        public double Next(int val)
        {
            if (_queue.Count == _size)
            {
                _culmulativeRes -= _queue.Dequeue();
            }
            _culmulativeRes += val;
            _queue.Enqueue(val);
            return (double)_culmulativeRes / _queue.Count;
        }
    }
}