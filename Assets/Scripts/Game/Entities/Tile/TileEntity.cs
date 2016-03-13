﻿public class TileEntity : TileMonoBehaviour
{
    public TileVisualization _VisualizationComponent { get; private set; }
    public TileInteraction _InteractionComponent { get; private set; }

    internal override void TemplateAfterAwake()
    {
        base.TemplateAfterAwake();
        _InteractionComponent = gameObject.AddComponent<TileInteraction>();
        _VisualizationComponent = GetComponent<TileVisualization>();

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