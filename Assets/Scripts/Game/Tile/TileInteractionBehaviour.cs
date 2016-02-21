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

        EventManager.StartListening(cEvents.TILE_USER_ACTIVATED, OnTileActivated);
        EventManager.StartListening(cEvents.TILE_USER_DEACTIVATED, OnTileDeactivated);

        EventManager.StartListening(cEvents.TILE_HIGHLIGHTED, OnTileHighlighted);
        EventManager.StartListening(cEvents.TILE_DEHIGHLIGHTED, OnTileDehighlighted);
    }

    public void UserHoverStart()
    {
        GridBoard.Instance.selectedTile = GridTile;
        //when mouse is over some tile, the tile is passable and the current tile is neither destination nor origin tile, change color to orange
       // if (GridTile.Passable && this != GridBoard.Instance.destTileTB
        //    && this != GridBoard.Instance.originTileTB)
        //{
           // tileVisualization.HighlightHover();
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


    void OnTileActivated(object tag)
    {
        var tile = tag as TileInteractionBehaviour;

        if (this == tile)
        {
            tileVisualization.SetVisualActiveState(); 
            StateTile = TileState.Active;
        }
        else
        {
            tileVisualization.SetVisualDefaultState();
            StateTile = TileState.Inactive;
        }
    }

    void OnTileDeactivated(object tag)
    {
        var tile = tag as TileInteractionBehaviour;

        if (this == tile)
        {
            tileVisualization.SetVisualDefaultState();
            StateTile = TileState.Inactive;
        }
    }

    void OnTileHighlighted(object tag)
    {
        var tile = tag as TileInteractionBehaviour;

        if (this == tile)
        {
            tileVisualization.SetVisualActiveState();
        }
        else
        {
            tileVisualization.SetVisualDefaultState();
        }
    }

    void OnTileDehighlighted(object tag)
    {
        var tile = tag as TileInteractionBehaviour;

        if (this == tile)
        {
            tileVisualization.SetVisualDefaultState();
        }
    }


    void OnTileUserClick(object tag)
    {
        if(PlayerManager.SelectedCharacter == null || PlayerManager.SelectedCharacter.InteractionState == CharacterState.Inactive)
        {
            return;
        }

        var tile = tag as TileInteractionBehaviour;

        if (tile == this)
        {
            switch (StateTile)
            {
                case TileState.Inactive:
                    EventManager.TriggerEvent(cEvents.TILE_USER_ACTIVATED, this);

                    break;
                case TileState.Active:
                    EventManager.TriggerEvent(cEvents.TILE_USER_DEACTIVATED, this);
                    break;
            }
        }
        else
        {
            if (StateTile == TileState.Active)
            {
                EventManager.TriggerEvent(cEvents.TILE_USER_DEACTIVATED, this);
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
