using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardMovement
{


    public Vector3 NextTilePos { get; private set; }
    public bool IsMoving { get; set; }
    public List<TileInteraction> CurrentPath { get; private set; }
    public List<GameObject> IndicatorsCollector { get; private set; }
    public TileInteraction CurrentTile { get; private set; }
    public TileInteraction OriginTileTB { get; private set; }
    public TileInteraction DestTileTB { get; private set; }

    public BoardMovement()
    {
        OriginTileTB = null;
        IndicatorsCollector = new List<GameObject>();
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

    public void DestTileChanged(TileInteraction tileBehaviour)
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

    public void OriginTileChanged(TileInteraction tileBehaviour)
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
            //GridBoard.Instance.BdVisualization.ErasePath(IndicatorsCollector);
            return;
        }

        var path = PathFinder.FindPath(OriginTileTB, DestTileTB);
        //GridBoard.Instance.BdVisualization.DrawPath(path.Select(x => x.GridTile).ToList(), IndicatorsCollector);
        StartMoving(path.ToList());
    }



    public void SetNewDestination(TileInteraction tile)
    {
        if (tile.GridTile == OriginTileTB.GridTile) //|| originTileTB == null)
            OriginTileChanged(tile);
        else
            DestTileChanged(tile);

        GenerateAndShowPath();
    }

    //method argument is a list of tiles we got from the path finding algorithm
    public void StartMoving(List<TileInteraction> path)
    {
        if (path.Count == 0)
            return;
        //the first tile we need to reach is actually in the end of the list just before the one the character is currently on
        CurrentTile = path[path.Count - 2];
        NextTilePos = GetWorldTilePos(CurrentTile.GridTile);
        IsMoving = true;
        this.CurrentPath = path;
    }

    public bool CheckPathDestination()
    {
        //if we reached the destination tile
        if (CurrentPath.IndexOf(CurrentTile) == 0)
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
            CurrentTile = CurrentPath[CurrentPath.IndexOf(CurrentTile) - 1];
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
        //GridBoard.Instance.BdVisualization.ErasePath(IndicatorsCollector);
    }



    //gets tile position in world space
    Vector3 GetWorldTilePos(Tile tile)
    {
        Vector3 worldPos = GridBoard.CalcWorldPosFromCoords(tile.X, tile.Y);
        //y coordinate is disregarded
        worldPos.y = 0;
        return worldPos;
    }

    public void StopOnCurrentTile()
    {
        DestTileTB = CurrentTile;

        if (CurrentPath != null)
        {
            CurrentPath[0] = CurrentTile;
        }
    }
}