namespace ConsoleApp1.BinarySearch;

[LastVisited(2022, 12, 20)]
public class _1011
{
    public int ShipWithinDays(int[] weights, int days)
    {
        var minWeight = weights.Max();
        var maxWeight = weights.Sum();

        while (minWeight < maxWeight)
        {
            var midWeight = minWeight + (maxWeight - minWeight) / 2;
            var currentDays = 1;
            var currentSumWeightInDay = 0;
            foreach (var weight in weights)
            {
                if (currentSumWeightInDay + weight <= midWeight)
                {
                    currentSumWeightInDay += weight;
                }
                else
                {
                    currentDays++;
                    currentSumWeightInDay = weight;
                }
            }

            if (currentDays > days)
            {
                minWeight = midWeight + 1;
            }
            else
            {
                maxWeight = midWeight;
            }
        }

        return minWeight;
    }
}