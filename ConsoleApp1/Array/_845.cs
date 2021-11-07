namespace ConsoleApp1.Array;

public class _845
{
    public int LongestMountain(int[] arr)
    {
        var firstPointer = 0;
        var secondPointer = 0;
        var longestMountain = 0;
        while (secondPointer < arr.Length)
        {
            while (secondPointer < arr.Length - 1 && arr[secondPointer] < arr[secondPointer + 1])
            {
                secondPointer++;
            }

            var peak = secondPointer;
            while (secondPointer < arr.Length - 1 && arr[secondPointer] > arr[secondPointer + 1])
            {
                secondPointer++;
            }

            if (firstPointer != peak && firstPointer != secondPointer && peak != secondPointer)
            {
                longestMountain = Math.Max(longestMountain, secondPointer - firstPointer + 1);
            }
            else if (firstPointer == peak && firstPointer == secondPointer && peak == secondPointer)
            {
                secondPointer++;
            }
            firstPointer = secondPointer;
        }

        return longestMountain;
    }
}