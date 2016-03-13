public static class HolyTools
{
    public static CharacterEntity[] Characters
    {
        get
        {
            return GameSuperviser.Instance.Characters.ToArray();
        }
    }
}
