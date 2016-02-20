using UnityEngine;

[RequireComponent(typeof(TileVisualization))]
public class TileInteractionBehaviour : MonoBehaviour
{
    public Tile GridTile { get; private set; }
    TileVisualization tileVisualization;
    public TileState StateTile { get; private set; }

    void Awake()
    {
        StateTile = TileState.Inactive;
        tileVisualization = GetComponent<TileVisualization>();
        EventManager.StartListening(cEvents.TILE_USER_CLIK, OnTileUserClick);
    }

    public void UserHoverStart()
    {
        GridBoard.Instance.selectedTile = GridTile;
        //when mouse is over some tile, the tile is passable and the current tile is neither destination nor origin tile, change color to orange
       // if (GridTile.Passable && this != GridBoard.Instance.destTileTB
        //    && this != GridBoard.Instance.originTileTB)
        //{
            tileVisualization.HighlightHover();
      //  }
    }

    public void UserHoverLeft()
    {
      //  GridBoard.Instance.selectedTile = null;
      // // if (GridTile.Passable && this != GridBoard.Instance.destTileTB
      // //     && this != GridBoard.Instance.originTileTB)
      ////  {
      //      tileVisualization.Reset();
      //  // }
      //  tileVisualization.SetVisualDefaultState();

    }

    public void UserActivate()
    {
        //GridTile.Passable = true;

        //TileBehaviour originTileTB = GridBoard.Instance.originTileTB;
        ////if user clicks on origin tile or origin tile is not assigned yet
        //if (this == originTileTB || originTileTB == null)
        //    GridBoard.Instance.OriginTileChanged(this);
        //else
        //    GridBoard.Instance.DestTileChanged(this);

        EventManager.TriggerEvent(cEvents.TILE_USER_CLIK, this);
    }

    void OnTileUserClick(object tag)
    {
        var tile = tag as TileInteractionBehaviour;

        if (tile == this)
        {
            switch (StateTile)
            {
                case TileState.Inactive:
                    tileVisualization.SetVisualActiveState();
                    StateTile = TileState.Active;
                    EventManager.TriggerEvent(cEvents.TILE_ACTIVATED, this);

                    break;
                case TileState.Active:
                    tileVisualization.SetVisualDefaultState();
                    StateTile = TileState.Inactive;
                    EventManager.TriggerEvent(cEvents.TILE_DEACTIVATED, this);

                    break;
            }
        }
        else
        {
            if (StateTile == TileState.Active)
            {
                tileVisualization.SetVisualDefaultState();
                StateTile = TileState.Inactive;
            }
        }
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

public enum TileState { Inactive, Active }
