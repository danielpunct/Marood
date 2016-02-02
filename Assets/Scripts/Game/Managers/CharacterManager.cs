using UnityEngine;

class CharacterManager : MonoBehaviour
{
    CharacterMoveBehaviour characterMoveBehaviour;

    void Start()
    {
        EventManager.StartListening(cEvents.TILE_ACTIVATED, OnTileActivated);
        characterMoveBehaviour = GetComponent<CharacterMoveBehaviour>();
    }

    public void Init(Tile originTile)
    {

    }

    void OnTileActivated(object tag)
    {
        Tile tile = tag as Tile;

        GridBoard.Instance.GenerateAndShowPath(characterMoveBehaviour);
    }
}
