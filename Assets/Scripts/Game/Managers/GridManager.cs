using UnityEngine;

class GridManager : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening(cEvents.DESTINATION_REACHED, OnDestinationReached);
    }

    void OnDestinationReached(object tag)
    {
        GridBoard.Instance.DestinationReached();
    }
}
