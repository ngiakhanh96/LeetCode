namespace ConsoleApp1.Array
{
    public class _852
    {
        public int PeakIndexInMountainArray(int[] arr)
        {
            var lowIndex = 0;
            var highIndex = arr.Length - 1;

            while (lowIndex < highIndex)
            {
                var midIndex = lowIndex + (highIndex - lowIndex) / 2;
                var midValue = arr[midIndex];
                if (midIndex - 1 >= lowIndex && arr[midIndex - 1] < midValue)
                {
                    lowIndex = midIndex;
                }

                if (midIndex + 1 <= highIndex && arr[midIndex + 1] < midValue)
                {
                    highIndex = midIndex;
                }
            }

            return lowIndex;
        }
    }
}
