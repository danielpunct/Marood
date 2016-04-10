using UnityEngine;

public class ActiveEntity : MonoBehaviour
{
    public int EntityIndex { get; private set; }

    private static int IndexCount;

    void Awake()
    {
        EntityIndex = ++IndexCount;
    }

    public static void ResetCount()
    {
        IndexCount = 0;
    }
}
