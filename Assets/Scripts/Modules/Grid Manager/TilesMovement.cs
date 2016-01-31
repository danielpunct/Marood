using System.Collections.Generic;
using UnityEngine;

public class TilesMovement : MonoBehaviour
{
    //speed in meters per second
    //distance between character and tile position when we assume we reached it and start looking for the next. Explained in detail later on
    public static float MinNextTileDist = 0.07f;

    public static TilesMovement instance = null;
    //position of the tile we are heading to
    Vector3 curTilePos;
    Tile curTile;
    List<Tile> path;
    public bool IsMoving { get; private set; }
    Transform myTransform;

    void Awake()
    {
        instance = this;
        IsMoving = false;
    }

    void Start()
    {
        //all the animations by default should loop
        //GetComponent<Animation>().wrapMode = WrapMode.Loop;
        //caching the transform for better performance
        myTransform = transform;
    }

    //gets tile position in world space
    Vector3 calcTilePos(Tile tile)
    {
        //y / 2 is added to convert coordinates from straight axis coordinate system to squiggly axis system
        Vector2 tileGridPos = new Vector2(tile.X + tile.Y / 2, tile.Y);
        Vector3 tilePos = GridManager.instance.CalcWorldCoord(tileGridPos);
        //y coordinate is disregarded
        tilePos.y = myTransform.position.y;
        return tilePos;
    }

    //method argument is a list of tiles we got from the path finding algorithm
    public void StartMoving(List<Tile> path)
    {
        if (path.Count == 0)
            return;
        //the first tile we need to reach is actually in the end of the list just before the one the character is currently on
        curTile = path[path.Count - 2];
        curTilePos = calcTilePos(curTile);
        IsMoving = true;
        this.path = path;
    }

    void Update()
    {
        if (!IsMoving)
            return;
        //if the distance between the character and the center of the next tile is short enough
        var position_plane = curTilePos; position_plane.y = 0;
        var my_position_plane = myTransform.position; my_position_plane.y = 0;
        if ((position_plane - my_position_plane).sqrMagnitude < MinNextTileDist * MinNextTileDist)
        {
            //if we reached the destination tile
            if (path.IndexOf(curTile) == 0)
            {
                IsMoving = false;
                //GetComponent<Animation>().CrossFade("idle");
                DestinationReached();
                return;
            }
            //curTile becomes the next one
            curTile = path[path.IndexOf(curTile) - 1];
            curTilePos = calcTilePos(curTile);
        }

        MoveTowards(curTilePos);
    }

    void MoveTowards(Vector3 position)
    {
        var rotationSpeed = 2;
        var speed = 2;
        Vector3 dir;
        CharacterController CC = GetComponent<CharacterController>();
        Vector3 myPos = CC.GetComponent<Collider>().bounds.center;
        dir = position - myPos;

        // Rotate towards the target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);

        // Modify speed so we slow down when we are not facing the target
        Vector3 forwardDir = myTransform.forward;
        //Move Forwards - forwardDir is already normalized
        forwardDir = forwardDir * speed;
        float speedModifier = Vector3.Dot(dir.normalized, myTransform.forward);
        forwardDir *= Mathf.Clamp01(speedModifier);
        float speedModMin = 0.97f;

        if (speedModifier > speedModMin)
        {

            CC.SimpleMove(forwardDir);
            //if (!monster && !GetComponent<Animation>()["walk"].enabled)
            //    GetComponent<Animation>().CrossFade("walk");
            //else if (monster && !GetComponent<Animation>()["CreepFem"].enabled)
            //    GetComponent<Animation>().CrossFade("CreepFem");
        }
        //else if (!monster && !GetComponent<Animation>()["idle"].enabled)
        //    GetComponent<Animation>().CrossFade("idle");
        //else if (monster && !GetComponent<Animation>()["IdleFeM"].enabled)
        //    GetComponent<Animation>().CrossFade("IdleFeM");
    }

    void DestinationReached()
    {
        TriggerEvent(cEvents.DESTINATION_REACHED);
    }


    void TriggerEvent(string eventName)
    {
        EventManager.TriggerEvent(eventName);
    }
}