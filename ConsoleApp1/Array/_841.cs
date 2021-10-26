﻿namespace ConsoleApp1.Array;

public class _841
{
    public bool[] IsVisitedRooms { get; set; }

    public IList<IList<int>> Rooms { get; set; }

    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        IsVisitedRooms = new bool[rooms.Count];
        Rooms = rooms;
        Dfs(0);
        foreach (var isVisitedRoom in IsVisitedRooms)
        {
            if (!isVisitedRoom)
            {
                return false;
            }
        }
        return true;
    }

    private void Dfs(int index)
    {
        IsVisitedRooms[index] = true;
        foreach (var key in Rooms[index])
        {
            if (!IsVisitedRooms[key])
            {
                Dfs(key);
            }
        }
    }
}