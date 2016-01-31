using UnityEngine;

class GridBehaviour : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening(cEvents.DESTINATION_REACHED, OnDestinationReached);
    }

    void OnDestinationReached(object tag)
    {
        GridManager.instance.DestinationReached();
    }
}
