namespace ConsoleApp1.Array;

public class _732
{
    public class MyCalendarThree
    {

        private readonly Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        private int[] _sortedArr;

        public MyCalendarThree()
        {

        }

        public int Book(int start, int end)
        {
            Set(_dictionary, start, 1);
            Set(_dictionary, end, -1);

            return CalculatePrefixSum(_dictionary);

        }

        private int CalculatePrefixSum(Dictionary<int, int> dict)
        {
            var sum = 0;
            var max = 0;
            foreach (var index in _sortedArr)
            {
                sum += dict[index];
                if (sum > max)
                {
                    max = sum;
                }
            }

            return max;
        }

        private void Set(Dictionary<int, int> dict, int pos, int val)
        {
            if (!dict.TryAdd(pos, val))
            {
                dict[pos] += val;
            }
            else
            {
                if (_sortedArr == null)
                {
                    _sortedArr = new[] { pos };
                }
                else
                {
                    var newArr = new int[_sortedArr.Length + 1];
                    var added = false;
                    for (int i = 0; i < _sortedArr.Length; i++)
                    {
                        if (_sortedArr[i] < pos)
                        {
                            newArr[i] = _sortedArr[i];
                        }
                        else
                        {
                            if (!added)
                            {
                                newArr[i] = pos;
                                added = true;
                            }
                            newArr[i + 1] = _sortedArr[i];
                        }
                    }
                    if (!added)
                    {
                        newArr[_sortedArr.Length] = pos;
                    }
                    _sortedArr = newArr;
                }
            }
        }
    }
}