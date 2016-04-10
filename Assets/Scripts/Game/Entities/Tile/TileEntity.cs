public class TileEntity : TileMonoBehaviour
{
    public TileVisualization _VisualizationComponent { get; private set; }
    public TileInteraction _InteractionComponent { get; private set; }

    internal override void TemplateAfterAwake()
    {
        base.TemplateAfterAwake();
        _InteractionComponent = gameObject.AddComponent<TileInteraction>();
        _VisualizationComponent = GetComponent<TileVisualization>();

        VisualizationComponent.rendererGO.gameObject.AddComponent<TileInputHandler>().SetExternalCustomEntity(this);
    }

    public CharacterEntity CharacterOnTile()
    {
        foreach (CharacterEntity character in HolyTools.GameEntities)
        {
            if (character.MoveComponent.IsOnTile(InteractionComponent.GridTile))
            {
                return character;
            }
        }
        return null;
    }
}