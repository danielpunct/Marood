using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileVisualization))]
public class TileBehaviour : MonoBehaviour
{
    public Tile Tile { get; private set; }
    TileVisualization tileVisualization;

    void Awake()
    {
        tileVisualization = GetComponent<TileVisualization>();
    }
    public void UserHoverStart()
    {
        GridManager.instance.selectedTile = Tile;
        //when mouse is over some tile, the tile is passable and the current tile is neither destination nor origin tile, change color to orange
        if (Tile.Passable && this != GridManager.instance.destTileTB
            && this != GridManager.instance.originTileTB)
        {
            tileVisualization.HighlightHover();
        }
    }

    public void UserHoverLeft()
    {
        GridManager.instance.selectedTile = null;
        if (Tile.Passable && this != GridManager.instance.destTileTB
            && this != GridManager.instance.originTileTB)
        {
            tileVisualization.Reset();
        }
    }

    public void UserActivate()
    {
        Tile.Passable = true;

        TileBehaviour originTileTB = GridManager.instance.originTileTB;
        //if user clicks on origin tile or origin tile is not assigned yet
        if (this == originTileTB || originTileTB == null)
            GridManager.instance.OriginTileChanged(this);
        else
            GridManager.instance.DestTileChanged(this);

        GridManager.instance.generateAndShowPath();
    }

    public void InitTile(int x, int y, string text)
    {
        Tile = new Tile(x, y);
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