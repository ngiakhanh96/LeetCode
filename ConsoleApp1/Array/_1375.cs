namespace ConsoleApp1.Array;

public class _1375
{
    public int NumTimesAllBlue(int[] lights)
    {
        var count = 0;
        var rightmostTurnedOnLight = 0;

        for (var i = 0; i < lights.Length; i++)
        {
            rightmostTurnedOnLight = Math.Max(rightmostTurnedOnLight, lights[i]);
            if (rightmostTurnedOnLight == i + 1)
            {
                count++;
            }
        }
        return count;
    }

    public int NumTimesAllBlue2(int[] lights)
    {
        var count = 0;
        var needToBeTurnedOnLightsToBeAllBlue = new HashSet<int>();
        var rightmostTurnedOnLight = 0;

        foreach (var light in lights)
        {
            if (light > rightmostTurnedOnLight)
            {
                for (var i = rightmostTurnedOnLight + 1; i < light; i++)
                {
                    needToBeTurnedOnLightsToBeAllBlue.Add(i);
                }
                rightmostTurnedOnLight = light;
            }
            else
            {
                needToBeTurnedOnLightsToBeAllBlue.Remove(light);
            }
            if (needToBeTurnedOnLightsToBeAllBlue.Count == 0)
            {
                count++;
            }
        }
        return count;
    }
}