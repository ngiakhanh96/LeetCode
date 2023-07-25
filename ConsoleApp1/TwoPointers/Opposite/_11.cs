namespace ConsoleApp1.TwoPointers.Opposite;

[LastVisited(2023, 07, 25)]
public class _11
{
    public int MaxArea(int[] height)
    {
        var maxArea = 0;
        var firstPointer = 0;
        var secondPointer = height.Length - 1;
        while (firstPointer < secondPointer)
        {
            maxArea = Math.Max(maxArea, Math.Min(height[firstPointer], height[secondPointer]) * (secondPointer - firstPointer));
            if (height[firstPointer] == height[secondPointer])
            {
                firstPointer++;
                secondPointer--;
            }
            else if (height[firstPointer] < height[secondPointer])
            {
                firstPointer++;
            }
            else
            {
                secondPointer--;
            }
        }
        return maxArea;
    }
}