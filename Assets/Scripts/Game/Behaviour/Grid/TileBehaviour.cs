using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileVisualization))]
public class TileBehaviour : MonoBehaviour
{
    public Tile GridTile { get; private set; }
    TileVisualization tileVisualization;

    void Awake()
    {
        tileVisualization = GetComponent<TileVisualization>();
    }
    public void UserHoverStart()
    {
        GridBoard.Instance.selectedTile = GridTile;
        //when mouse is over some tile, the tile is passable and the current tile is neither destination nor origin tile, change color to orange
        if (GridTile.Passable && this != GridBoard.Instance.destTileTB
            && this != GridBoard.Instance.originTileTB)
        {
            tileVisualization.HighlightHover();
        }
    }

    public void UserHoverLeft()
    {
        GridBoard.Instance.selectedTile = null;
        if (GridTile.Passable && this != GridBoard.Instance.destTileTB
            && this != GridBoard.Instance.originTileTB)
        {
            tileVisualization.Reset();
        }
    }

    public void UserActivate()
    {
        GridTile.Passable = true;

        TileBehaviour originTileTB = GridBoard.Instance.originTileTB;
        //if user clicks on origin tile or origin tile is not assigned yet
        if (this == originTileTB || originTileTB == null)
            GridBoard.Instance.OriginTileChanged(this);
        else
            GridBoard.Instance.DestTileChanged(this);
        
        EventManager.TriggerEvent(cEvents.TILE_ACTIVATED, GridTile);
    }

    public void InitTile(int x, int y, string text)
    {
        GridTile = new Tile(x, y);
        tileVisualization.SetText(text);
    }

    public void Reset()
    {
        tileVisualization.Reset();
    }

    public void SetAsOrigin()
    {
        tileVisualization.HighlightHover();
    }
}