namespace ConsoleApp1.BFS;

[LastVisited(2022, 12, 13)]
public class _852
{
    public int PeakIndexInMountainArray(int[] arr)
    {
        var low = 1;
        var high = arr.Length - 2;

        while (low < high)
        {
            var medium = low + (high - low) / 2;
            // Compare to the right since medium can be low
            if (arr[medium] < arr[medium + 1])
            {
                low = medium + 1;
            }
            else
            {
                high = medium;
            }
        }
        return low;
    }

    public int PeakIndexInMountainArray2(int[] arr)
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