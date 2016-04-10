using System.Collections.Generic;

public static class HolyTools
{
    public static ActiveEntity[] GameEntities
    {
        get
        {
            return GameSuperviser.Instance.Characters.ToArray(); // add buildings
        }
    }

    public static List<NeighbourPair> ActiveNeighbours
    {
        get
        {
            return BoardInteraction.Instance.ActiveNeighbours;
        }
    }
}
