namespace ConsoleApp1.BitManipulation
{
    public class _1342
    {
        public int NumberOfSteps(int num)
        {
            var step = 0;
            while (num != 0)
            {
                if ((num & 1) == 1)
                {
                    step++;
                }

                if (num == 1)
                {
                    break;
                }
                num >>= 1;
                step++;
            }
            return step;
        }
    }
}
