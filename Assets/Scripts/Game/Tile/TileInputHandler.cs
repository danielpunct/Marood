using UnityEngine;

class TileInputHandler : MonoBehaviour
{
    public TileInteractionBehaviour TileBehaviour { get; set; }

    void OnMouseEnter()
    {
        TileBehaviour.UserHoverStart();
    }

    void OnMouseExit()
    {
        //TileBehaviour.UserHoverLeft();
    }

    void OnMouseOver()
    {
        ////if player right-clicks on the tile, toggle passable variable and change the color accordingly
        //if (Input.GetMouseButtonUp(1))
        //{
        //    if (this == GridManager.instance.destTileTB ||
        //        this == GridManager.instance.originTileTB)
        //        return;
        //    tile.Passable = !tile.Passable;
        //    if (!tile.Passable)
        //        changeColor(Color.gray);
        //    else
        //        changeColor(orange);

        //    GridManager.instance.generateAndShowPath();
        //}
        //if user left-clicks the tile
        if (Input.GetMouseButtonUp(0))
        {
            TileBehaviour.UserClick();
        }
    }
}
