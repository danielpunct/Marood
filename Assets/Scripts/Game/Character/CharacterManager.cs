using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterPlayerState StateUser { get; set; }

    public CharacterMoveBehaviour CharacterMoveBehaviour { get; private set; }

    void Awake()
    {
        GameManager.Instance.AddCharacter(this);
        CharacterMoveBehaviour = gameObject.AddComponent<CharacterMoveBehaviour>();
        gameObject.AddComponent<CharacterVisualization>();
        EventManager.StartListening(cEvents.TILE_ACTIVATED, OnTileActivated);
        EventManager.StartListening(cEvents.TILE_DEACTIVATED, OnTileDeactivated);


        EventManager.StartListening(cEvents.CHARACTER_ACTIVATED, OnCharacterActivated);
        EventManager.StartListening(cEvents.CHARACTER_DEACTIVATED, OnCharacterDeactivated);
    }

    public void Init(Tile originTile)
    {
        CharacterMoveBehaviour.Init(originTile.Location.X, originTile.Location.Y);
    }

    void OnTileActivated(object tag)
    {
        var tile = tag as TileInteractionBehaviour;
        var isOnCurrentTile = CharacterMoveBehaviour.IsCurrentTile(tile.GridTile);

        if (isOnCurrentTile)
        {
            EventManager.TriggerEvent(cEvents.CHARACTER_ACTIVATED, this);
        }
        else
        {

        }
    }

    void OnTileDeactivated(object tag)
    {
        var tile = tag as TileInteractionBehaviour;
        var isOnCurrentTile = CharacterMoveBehaviour.IsCurrentTile(tile.GridTile);

        if (isOnCurrentTile)
        {
            EventManager.TriggerEvent(cEvents.CHARACTER_DEACTIVATED, this);
        }
        else
        {

        }
    }


    void OnCharacterActivated(object tag)
    {
        var character = tag as CharacterManager;

        if (character == this)
        {
            CharacterMoveBehaviour.CharacterVisualization.SetActiveState();
        }
        else
        {
            CharacterMoveBehaviour.CharacterVisualization.SetInactiveState();
        }
    }

    void OnCharacterDeactivated(object tag)
    {
        var character = tag as CharacterManager;

        if (character == this)
        {
            CharacterMoveBehaviour.CharacterVisualization.SetInactiveState();
        }
    }
}

public enum CharacterPlayerState { Inactive, Active}
