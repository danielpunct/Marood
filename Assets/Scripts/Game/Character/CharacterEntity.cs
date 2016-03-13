using System.Collections;
using System.Linq;
using UnityEngine;

public class CharacterEntity : MonoBehaviour
{
    public CharacterMoveBehaviour ChMove { get; private set; }
    public CharacterVisualization ChVisualizaton { get; private set; }
    public CharacterInteractionBehaviour ChInteraction { get; private set; }

    void Awake()
    {
        GameSuperviser.Instance.AddCharacter(this);
        ChMove = gameObject.AddComponent<CharacterMoveBehaviour>();
        ChVisualizaton = gameObject.AddComponent<CharacterVisualization>();
        ChInteraction = gameObject.AddComponent<CharacterInteractionBehaviour>();
        gameObject.AddComponent<CharacterInputHandler>();
    }

    public void Init(TileInteraction originTile, cCharacters characterType)
    {
        ChMove.Init(originTile.GridTile.Location.X, originTile.GridTile.Location.Y);

        switch (characterType)
        {
            case cCharacters.Beetle:
                gameObject.AddComponent<BeetleBehaviour>();
                break;
            case cCharacters.RedBeetle:
                gameObject.AddComponent<RedBeetleBehaviour>();
                break;
        }
    }



    public CharacterState InteractionState { get { return ChInteraction.StateCharacter; } }

    public bool IsOnTile(Tile tile)
    {
        return ChMove.IsOnTile(tile);
    }

    public TileInteraction[] CurrentPath
    {
        get
        {
            return ChMove.IsMoving ? ChMove.Movement.CurrentPath.ToArray() : (new TileInteraction[] { ChMove.GetActiveTile() });
        }
    }

    public void SetNewDestination(TileEntity tile)
    {
        ChMove.SetNewDestination(tile.TlInteraction);

        EventManager.TriggerEvent(cEvents.CHARACTER_UI_UPDATED, this);
    }


    public void EnterAttack()
    {
        ChMove.StopOnCurrentTile();
        ChVisualizaton.SetTauntState();
    }
}