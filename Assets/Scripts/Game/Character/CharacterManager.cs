using System.Linq;
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

    public void Init(Tile originTile)
    {
        ChMove.Init(originTile.Location.X, originTile.Location.Y);
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
    #endregion
}
