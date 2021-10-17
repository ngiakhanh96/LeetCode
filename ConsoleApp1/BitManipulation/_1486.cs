namespace ConsoleApp1.BitManipulation
{
    public class _1486
    {
        // Bullshit problem with shortcut described at https://leetcode.com/problems/xor-operation-in-an-array/discuss/699141/Visual-Solution-Python-or-O(1)-Time-or-O(1)-Space
        public int XorOperation(int n, int start)
        {
            var lastNumber = start + 2 * (n - 1);
            if (start % 4 < 2)
            {
                switch (n % 4)
                {
                    case 1:
                        return lastNumber;
                    case 2:
                        return 2;
                    case 3:
                        return lastNumber ^ 2;
                    case 0:
                        return 0;
                }
            }
            else
            {
                var firstNumber = start;
                switch (n % 4)
                {
                    case 1:
                        return firstNumber;
                    case 2:
                        return lastNumber ^ firstNumber;
                    case 3:
                        return firstNumber ^ 2;
                    case 0:
                        return lastNumber ^ firstNumber ^ 2;
                }
            }

            return lastNumber;
        }
    }
}
