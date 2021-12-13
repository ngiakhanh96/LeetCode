namespace ConsoleApp1.DP
{
    public class _650
    {
        // Top-down
        public int MinSteps(int n)
        {
            if (n == 1)
            {
                return 0;
            }

            var res = 0;
            for (int i = n / 2; i >= 1; i--)
            {
                if (n % i == 0)
                {
                    res += MinSteps(i) + (n / i);
                    break;
                }
            }
            return res;
        }

        // Bottom-up
        public int MinSteps2(int n)
        {
            if (n == 1)
            {
                return 0;
            }

            var stack = new Stack<int>();
            stack.Push(n);
            var i = n / 2;
            while (i >= 1)
            {

                if (stack.Peek() % i == 0)
                {
                    stack.Push(i);
                    i /= 2;
                }
                else
                {
                    i--;
                }
            }

            var currentMinStepAt = new int[] { stack.Pop(), 0 };
            foreach (var minStepAt in stack)
            {
                currentMinStepAt = new int[] { minStepAt, currentMinStepAt[1] + (minStepAt / currentMinStepAt[0]) };
            }
            return currentMinStepAt[1];
        }
    }
}
