﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class BoardMovement
{
    public Vector3 NextTilePos { get; private set; }
    public bool IsMoving { get; set; }

    Tile currentTile;
    List<Tile> path;
    List<GameObject> indicators;
    TileBehaviour originTileTB = null;
    TileBehaviour destTileTB = null;

    public BoardMovement()
    {
        EventManager.StartListening(cEvents.TILE_ACTIVATED, OnTileActivated);
        indicators = new List<GameObject>();
    }

    //!! to use
    public void Reset()
    {
        destTileTB = null;
        originTileTB = null;
    }

    public void SetOrigin(int x, int y)
    {
        var tb = GridBoard.Instance.GetTile(x, y);
        tb.SetAsOrigin();
        originTileTB = tb;
    }

    public void DestTileChanged(TileBehaviour tileBehaviour)
    {
        //deselect destination tile if user clicks on current destination tile
        if (tileBehaviour == destTileTB)
        {
            destTileTB = null;
            tileBehaviour.Reset();
            return;
        }
        //if there was other tile marked as destination, change its material to default (fully transparent) one
        if (destTileTB != null)
            destTileTB.Reset();
        destTileTB = tileBehaviour;
        //tileBehaviour.ChangeColor(Color.blue);
    }

    public void OriginTileChanged(TileBehaviour tileBehaviour)
    {
        //deselect origin tile if user clicks on current origin tile
        if (tileBehaviour == originTileTB)
        {
            originTileTB = null;
            tileBehaviour.Reset();
            return;
        }
        //if origin tile is not specified already mark this tile as origin
        originTileTB = tileBehaviour;
        tileBehaviour.SetAsOrigin();
    }

    public void GenerateAndShowPath()
    {
        if (originTileTB == null || destTileTB == null)
        {
            GridBoard.Instance.ErasePath(indicators);
            return;
        }

        var path = PathFinder.FindPath(originTileTB.GridTile, destTileTB.GridTile);
        GridBoard.Instance.DrawPath(path, indicators);
        StartMoving(path.ToList());
    }

    void OnTileActivated(object tag)
    {
        var tile = tag as TileBehaviour;
        if (tile.GridTile == originTileTB.GridTile) //|| originTileTB == null)
            OriginTileChanged(tile);
        else
            DestTileChanged(tile);

        GenerateAndShowPath();
    }

    //method argument is a list of tiles we got from the path finding algorithm
    public void StartMoving(List<Tile> path)
    {
        if (path.Count == 0)
            return;
        //the first tile we need to reach is actually in the end of the list just before the one the character is currently on
        currentTile = path[path.Count - 2];
        NextTilePos = GetWorldTilePos(currentTile);
        IsMoving = true;
        this.path = path;
    }

    public bool CheckPathDestination()
    {
        //if we reached the destination tile
        if (path.IndexOf(currentTile) == 0)
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
            currentTile = path[path.IndexOf(currentTile) - 1];
            NextTilePos = GetWorldTilePos(currentTile);
            return false;
        }
    }

    public void DestinationReached()
    {
        originTileTB.Reset();
        originTileTB = destTileTB;

        originTileTB.SetAsOrigin();
        destTileTB = null;
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