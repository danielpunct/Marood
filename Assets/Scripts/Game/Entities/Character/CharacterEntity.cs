public class CharacterEntity : CharacterMonoBehaviour
{
    public CharacterMove _MoveComponent { get; private set; }
    public CharacterVisualization _VisualizationComponent { get; private set; }
    public CharacterInteraction _InteractionComponent { get; private set; }


    internal override void TemplateAfterAwake()
    {
        base.TemplateAfterAwake();
        GameSuperviser.Instance.AddCharacter(this);
        _MoveComponent = gameObject.AddComponent<CharacterMove>();
        _VisualizationComponent = gameObject.AddComponent<CharacterVisualization>();
        _InteractionComponent = gameObject.AddComponent<CharacterInteraction>();
        gameObject.AddComponent<CharacterInputHandler>();
    }

    public void Init(TileInteraction originTile, cCharacters characterType)
    {
        MoveComponent.Init(originTile.GridTile.Location.X, originTile.GridTile.Location.Y);

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

    public CharacterState InteractionState { get { return InteractionComponent.StateCharacter; } }

    public bool IsOnTile(Tile tile)
    {
        return MoveComponent.IsOnTile(tile);
    }

    public void SetNewDestination(TileEntity tile)
    {
        MoveComponent.SetNewDestination(tile.InteractionComponent);

        EventManager.TriggerEvent(cEvents.CHARACTER_UI_UPDATED, this);
    }

    public void EnterAttack()
    {
        MoveComponent.StopOnCurrentTile();
        VisualizationComponent.SetTauntState();
    }
}