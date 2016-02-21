using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class BoardMovement
{
    public Vector3 NextTilePos { get; private set; }
    public bool IsMoving { get; set; }

    List<TileInteractionBehaviour> path;
    List<GameObject> indicators;
    public TileInteractionBehaviour CurrentTile { get; private set; }
    public TileInteractionBehaviour OriginTileTB { get; private set; }
    public TileInteractionBehaviour DestTileTB { get; private set; }

    public BoardMovement()
    {
        OriginTileTB = null;
        indicators = new List<GameObject>();
    }

    //!! to use
    public void Reset()
    {
        DestTileTB = null;
        OriginTileTB = null;
    }

    public void SetOrigin(int x, int y)
    {
        var tb = GridBoard.Instance.GetTile(x, y);
        tb.SetAsOrigin();
        OriginTileTB = tb;
        CurrentTile = tb;
    }

    public void DestTileChanged(TileInteractionBehaviour tileBehaviour)
    {
        //deselect destination tile if user clicks on current destination tile
        if (tileBehaviour == DestTileTB)
        {
            DestTileTB = null;
            tileBehaviour.Reset();
            return;
        }
        //if there was other tile marked as destination, change its material to default (fully transparent) one
        if (DestTileTB != null)
            DestTileTB.Reset();
        DestTileTB = tileBehaviour;
        //tileBehaviour.ChangeColor(Color.blue);
    }

    public void OriginTileChanged(TileInteractionBehaviour tileBehaviour)
    {
        //deselect origin tile if user clicks on current origin tile
        if (tileBehaviour == OriginTileTB)
        {
            OriginTileTB = null;
            tileBehaviour.Reset();
            return;
        }
        //if origin tile is not specified already mark this tile as origin
        OriginTileTB = tileBehaviour;
        tileBehaviour.SetAsOrigin();
    }

    public void GenerateAndShowPath()
    {
        if (OriginTileTB == null || DestTileTB == null)
        {
            GridBoard.Instance.ErasePath(indicators);
            return;
        }

        var path = PathFinder.FindPath(OriginTileTB, DestTileTB);
        GridBoard.Instance.DrawPath(path.Select(x => x.GridTile).ToList(), indicators);
        StartMoving(path.ToList());
    }

    public void SetNewDestination(TileInteractionBehaviour tile)
    {
        if (tile.GridTile == OriginTileTB.GridTile) //|| originTileTB == null)
            OriginTileChanged(tile);
        else
            DestTileChanged(tile);

        GenerateAndShowPath();
    }

    //method argument is a list of tiles we got from the path finding algorithm
    public void StartMoving(List<TileInteractionBehaviour> path)
    {
        if (path.Count == 0)
            return;
        //the first tile we need to reach is actually in the end of the list just before the one the character is currently on
        CurrentTile = path[path.Count - 2];
        NextTilePos = GetWorldTilePos(CurrentTile.GridTile);
        IsMoving = true;
        this.path = path;
    }

    public bool CheckPathDestination()
    {
        //if we reached the destination tile
        if (path.IndexOf(CurrentTile) == 0)
        {
            IsMoving = false;
            //GetComponent<Animation>().CrossFade("idle");
            //EventManager.TriggerEvent(cEvents.DESTINATION_REACHED);
            DestinationReached();
            return true;
        }
        else
        {
            //curTile becomes the next one
            CurrentTile = path[path.IndexOf(CurrentTile) - 1];
            NextTilePos = GetWorldTilePos(CurrentTile.GridTile);
            return false;
        }
    }

    public void DestinationReached()
    {
        OriginTileTB.Reset();
        OriginTileTB = DestTileTB;

        OriginTileTB.SetAsOrigin();
        DestTileTB = null;
        GridBoard.Instance.ErasePath(indicators);
    }



    //gets tile position in world space
    Vector3 GetWorldTilePos(Tile tile)
    {
        Vector3 worldPos = GridBoard.Instance.CalcWorldPosFromCoords(tile.X, tile.Y);
        //y coordinate is disregarded
        worldPos.y = 0;
        return worldPos;
    }
}