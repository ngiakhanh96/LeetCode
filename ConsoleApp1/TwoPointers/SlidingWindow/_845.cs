namespace ConsoleApp1.TwoPointers.SlidingWindow;

[LastVisited(2022, 12, 28)]
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

            if (firstPointer != peak && peak != secondPointer)
            {
                longestMountain = Math.Max(longestMountain, secondPointer - firstPointer + 1);
            }
            else if (firstPointer == secondPointer)
            {
                secondPointer++;
            }
            firstPointer = secondPointer;
        }

        return longestMountain;
    }

    public int LongestMountain2(int[] arr)
    {
        var slowPointerIndex = 0;
        var previousNum = arr[slowPointerIndex];
        var currentLongestMountain = 0;
        var shouldIncrease = true;
        var usedToIncrease = false;
        for (var i = 1; i < arr.Length; i++)
        {
            var currentNum = arr[i];
            if (shouldIncrease)
            {
                if (currentNum < previousNum)
                {
                    if (usedToIncrease)
                    {
                        shouldIncrease = false;
                    }
                    else
                    {
                        slowPointerIndex = i;
                    }
                }
                else if (currentNum == previousNum)
                {
                    slowPointerIndex = i;
                    usedToIncrease = false;
                }
                else
                {
                    usedToIncrease = true;
                }
            }
            else
            {
                if (currentNum > previousNum)
                {
                    currentLongestMountain = Math.Max(currentLongestMountain, i - slowPointerIndex);
                    slowPointerIndex = i - 1;
                    shouldIncrease = true;
                }
                else if (currentNum == previousNum)
                {
                    currentLongestMountain = Math.Max(currentLongestMountain, i - slowPointerIndex);
                    slowPointerIndex = i;
                    shouldIncrease = true;
                    usedToIncrease = false;
                }
            }

            if (!shouldIncrease && i == arr.Length - 1)
            {
                currentLongestMountain = Math.Max(currentLongestMountain, i + 1 - slowPointerIndex);
            }
            previousNum = currentNum;
        }
        return currentLongestMountain;
    }
}