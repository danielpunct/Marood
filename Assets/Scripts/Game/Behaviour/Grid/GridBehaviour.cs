using UnityEngine;

class GridBehaviour : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening("DestinationReached", OnDestinationReached);
    }

    void OnDestinationReached()
    {
        GridManager GM = GridManager.instance;

        GM.originTileTB.Reset();
        GM.originTileTB = GM.destTileTB;

        GM.originTileTB.SetAsOrigin();
        GM.destTileTB = null;
        GM.generateAndShowPath();
    }
}
