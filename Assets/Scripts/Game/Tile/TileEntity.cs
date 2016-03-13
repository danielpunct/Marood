public class TileEntity : TileMonoBehaviour
{

    internal override void TemplateAfterAwake()
    {
        base.TemplateAfterAwake();
        InteractionComponent = gameObject.AddComponent<TileInteraction>();
        VisualizationComponent = GetComponent<TileVisualization>();
        VisualizationComponent.RendererGO.gameObject.AddComponent<TileInputHandler>().TileBehaviour = InteractionComponent;
    }

    public CharacterEntity CharacterOnTile()
    {
        foreach (var character in HolyTools.Characters)
        {
            if (character.MoveComponent.IsOnTile(InteractionComponent.GridTile))
            {
                return character;
            }
        }
        return null;
    }
}