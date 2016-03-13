using UnityEngine;

public class CharacterMonoBehaviour : MonoBehaviour
{
    public CharacterMoveBehaviour MoveComponent { get { return cEntity._MoveComponent; } }
    public CharacterVisualization VisualizationComponent { get { return cEntity._VisualizationComponent; } }
    public CharacterInteractionBehaviour InteractionComponent { get { return cEntity._InteractionComponent; } }

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
