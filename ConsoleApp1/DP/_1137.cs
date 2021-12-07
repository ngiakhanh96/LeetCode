namespace ConsoleApp1.DP
{
    public class _1137
    {
        // Bottom-up
        public int Tribonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 1;
            }

            var t0 = 0;
            var t1 = 1;
            var t2 = 1;
            var t3 = 0;
            for (int i = 3; i <= n; i++)
            {
                t3 = t0 + t1 + t2;
                t0 = t1;
                t1 = t2;
                t2 = t3;
            }
            return t3;
        }

        // Top-down
        public int[] Cache { get; set; }
        public int Tribonacci2(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 1;
            }
            Cache = Enumerable.Repeat(-1, n + 1).ToArray();
            Cache[0] = 0;
            Cache[1] = 1;
            Cache[2] = 1;
            return Tribonacci2Impl(n);

        }

        private int Tribonacci2Impl(int index)
        {
            if (Cache[index] == -1)
            {
                Cache[index] = Tribonacci2Impl(index - 3) + Tribonacci2Impl(index - 2) + Tribonacci2Impl(index - 1);
            }

            return Cache[index];
        }
    }
}
