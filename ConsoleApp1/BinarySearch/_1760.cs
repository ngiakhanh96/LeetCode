namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]
public class _1760
{
    public int MinimumSize(int[] nums, int maxOperations)
    {
        var minMaxNumOfBallsInBag = 1;
        var maxMaxNumOfBallsInBag = nums.Max();

        while (minMaxNumOfBallsInBag < maxMaxNumOfBallsInBag)
        {
            var midMaxNumOfBallsInBag = minMaxNumOfBallsInBag + (maxMaxNumOfBallsInBag - minMaxNumOfBallsInBag) / 2;
            var needsOperation = nums.Aggregate(
                0,
                (res, next) => res + (next % midMaxNumOfBallsInBag == 0
                    ? next / midMaxNumOfBallsInBag - 1
                    : next / midMaxNumOfBallsInBag));
            if (needsOperation <= maxOperations)
            {
                maxMaxNumOfBallsInBag = midMaxNumOfBallsInBag;
            }
            else
            {
                minMaxNumOfBallsInBag = midMaxNumOfBallsInBag + 1;
            }
        }

        return minMaxNumOfBallsInBag;
    }
}