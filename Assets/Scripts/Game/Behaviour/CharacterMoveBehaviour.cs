using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveBehaviour : MonoBehaviour
{
    public Vector3 NextTilePos { get; private set; }
    public bool IsMoving { get; private set; }

    CharacterVisualization characterVisualization;

    //public TileBehaviour OriginTileTB = null;
    //public TileBehaviour DestTileTB = null;

    Tile currentTile;
    List<Tile> path;

    void Awake()
    {
        IsMoving = false;
    }

    void Start()
    {
        //all the animations by default should loop
        //GetComponent<Animation>().wrapMode = WrapMode.Loop;
        //caching the transform for better performance
        characterVisualization = GetComponent<CharacterVisualization>();
    }

    //gets tile position in world space
    Vector3 GetWorldTilePos(Tile tile)
    {
        Vector3 worldPos = GridBoard.Instance.CalcWorldPosFromCoords(tile.X, tile.Y);
        //y coordinate is disregarded
        worldPos.y = 0;
        return worldPos;
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

   
    public bool CheckDestination()
    {
        //if we reached the destination tile
        if (path.IndexOf(currentTile) == 0)
        {
            IsMoving = false;
            //GetComponent<Animation>().CrossFade("idle");
            EventManager.TriggerEvent(cEvents.DESTINATION_REACHED);
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

}