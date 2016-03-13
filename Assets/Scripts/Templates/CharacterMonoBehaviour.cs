using UnityEngine;

public class CharacterMonoBehaviour : MonoBehaviour
{
    public CharacterMoveBehaviour MoveComponent { get; internal set; }
    public CharacterVisualization VisualizationComponent { get; internal set; }
    public CharacterInteractionBehaviour InteractionComponent { get; internal set; }


    internal CharacterEntity cEntity;
    internal virtual void TemplateAfterAwake() { }

    void Awake()
    {
        cEntity = GetComponent<CharacterEntity>();

        TemplateAfterAwake();
    }


    public TileInteraction CurrentInteractionTile { get { return cEntity.MoveComponent.GetCurrentTile(); } }
    public TileInteraction[] CurrentInteractionPath { get { return MoveComponent.IsMoving ? MoveComponent.Movement.CurrentPath.ToArray() : (new TileInteraction[] { MoveComponent.GetActiveTile() }); } }
}
