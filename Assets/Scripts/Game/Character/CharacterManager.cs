using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    CharacterMoveBehaviour characterMoveBehaviour;
    CharacterInteractionBehaviour characterInteractionBehaviour;

    void Awake()
    {
        GameManager.Instance.AddCharacter(this);
        characterMoveBehaviour = gameObject.AddComponent<CharacterMoveBehaviour>();
        gameObject.AddComponent<CharacterVisualization>();
        characterInteractionBehaviour = gameObject.AddComponent<CharacterInteractionBehaviour>();
        gameObject.AddComponent<CharacterInputHandler>();
    }

    public void Init(Tile originTile)
    {
        characterMoveBehaviour.Init(originTile.Location.X, originTile.Location.Y);
    }


    #region Getters&Setters

    public CharacterState InteractionState { get { return characterInteractionBehaviour.StateCharacter; } }
    
    public bool IsOnTile(Tile tile)
    {
        return characterMoveBehaviour.IsCurrentTile(tile);
    }

    public void SetNewDestination(TileInteractionBehaviour tile)
    {
        characterMoveBehaviour.SetNewDestination(tile);
    }
    #endregion
}
