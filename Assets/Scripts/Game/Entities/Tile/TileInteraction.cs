using System;
using System.Linq;

public class TileInteraction : TileMonoBehaviour
{
    public Tile GridTile { get; private set; }

    internal override void TemplateAfterAwake()
    {
        EventManager.StartListening(cEvents.CHARACTER_UI_UPDATED, OnCHARACTER_UI_UPDATED);

    }

    public void UserHoverStart()
    {
        //GridBoard.Instance.selectedTile = GridTile;
    }


    public void UserStartDragOnTile()
    {
        EventManager.TriggerEvent(cEvents.USER_START_DRAG_ON_TILE, InteractionComponent);
    }

    public void UserEndDragOnTile()
    {
        EventManager.TriggerEvent(cEvents.USER_END_DRAG_ON_TILE, tEntity);
    }

    void OnCHARACTER_UI_UPDATED(object tag)
    {
        if (tag == null)
        {
            VisualizationComponent.ShowAsDefault();
            return;
        }

        var character = tag as CharacterEntity;

        int tileIndex = Array.IndexOf(character.CurrentInteractionPath, this);
        if (tileIndex >= 0)
        {
            if (tileIndex == 0)
            {
                VisualizationComponent.ShowAsDestination();
                return;
            }
            VisualizationComponent.ShowAsPath();
            return;
        }
        else
        {
            VisualizationComponent.ShowAsDefault();
        }
    }

    public TileInteraction[] Neighbours
    {
        get
        {
            return GridTile.Neighbours.ToArray();
        }
    }

    public void InitTile(int x, int y, string text)
    {
        GridTile = new Tile(x, y);
        VisualizationComponent.SetText(text);
    }

    public void Reset()
    {
        VisualizationComponent.Reset();
    }

    public void SetAsOrigin()
    {
        VisualizationComponent.HighlightHover();
    }
}