using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterMoveBehaviour ChMove { get; private set; }
    public CharacterVisualization ChVisualizaton { get; private set; }
    public CharacterInteractionBehaviour ChInteraction { get; private set; }

    void Awake()
    {
        GameManager.Instance.AddCharacter(this);
        ChMove = gameObject.AddComponent<CharacterMoveBehaviour>();
        ChVisualizaton = gameObject.AddComponent<CharacterVisualization>();
        ChInteraction = gameObject.AddComponent<CharacterInteractionBehaviour>();
        gameObject.AddComponent<CharacterInputHandler>();
    }

    public void Init(Tile originTile, cCharacters characterType)
    {
        ChMove.Init(originTile.Location.X, originTile.Location.Y);

        switch(characterType)
        {
            case cCharacters.Beetle:
                gameObject.AddComponent<BeetleBehaviour>();
                break;
            case cCharacters.RedBeetle:
                gameObject.AddComponent<RedBeetleBehaviour>();
                break;
        }
    }


    #region Out Methods

    public CharacterState InteractionState { get { return ChInteraction.StateCharacter; } }

    public bool IsOnTile(Tile tile)
    {
        return ChMove.IsCurrentTile(tile);
    }

    public TileInteractionBehaviour[] CurrentPath
    {
        get
        {
            return ChMove.IsMoving ? ChMove.Movement.CurrentPath.ToArray() : (new TileInteractionBehaviour[] { ChMove.GetActiveTile() });
        }
    }

    public void SetNewDestination(TileManager tile)
    {
        ChMove.SetNewDestination(tile.TlInteraction);

        EventManager.TriggerEvent(cEvents.CHARACTER_UI_UPDATED, this);
    }


    public void EnterAttack()
    {
        ChMove.StopOnCurrentTile();
    }
    #endregion
}
