using UnityEngine;

class CharacterManager : MonoBehaviour
{
    public CharacterUserState StateUser { get; private set; }

    CharacterMoveBehaviour characterMoveBehaviour;

    void Awake()
    {
        characterMoveBehaviour = gameObject.AddComponent<CharacterMoveBehaviour>();
        gameObject.AddComponent<CharacterVisualization>();
        EventManager.StartListening(cEvents.TILE_ACTIVATED, OnTileActivated);
    }

    public void Init(Tile originTile)
    {
        characterMoveBehaviour.Init(originTile.Location.X, originTile.Location.Y);
    }

    void OnTileActivated(object tag)
    {
        var tile = tag as TileInteractionBehaviour;
        var isCurrentTile = characterMoveBehaviour.IsCurrentTile(tile.GridTile);

        if (StateUser == CharacterUserState.Active)
        {
            if (isCurrentTile)
            {
                StateUser = CharacterUserState.Inactive;
            }
            else
            {
                characterMoveBehaviour.SetNewDestination(tile);
            }
        }
        else
        {
            if (isCurrentTile)
            {
                StateUser = CharacterUserState.Active;
            }
        }
    }
}

enum CharacterUserState { Inactive, Active}
