namespace ConsoleApp1
{
    public class _231
    {
        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0)
            {
                return false;
            }

            while (true)
            {
                if (n == 1)
                {
                    return true;
                }
                if (GetBit(n, 0) == 1)
                {
                    return false;
                }

                n >>= 1;
            }
        }


        public bool IsPowerOfTwo2(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

        private int GetBit(int n, int position)
        {
            return (n >> position) & 1;
        }
    }
}
