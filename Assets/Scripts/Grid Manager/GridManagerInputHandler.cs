using UnityEngine;

class GridManagerInputHandler : MonoBehaviour
{
    public static GridManagerInputHandler Instance = null;

    void Awake()
    {
        Instance = this;
    }

    public void UserLeftClick(TileBehaviour tileBehaviour)
    {
        tileBehaviour.Tile.Passable = true;

        TileBehaviour originTileTB = GridManager.instance.originTileTB;
        //if user clicks on origin tile or origin tile is not assigned yet
        if (tileBehaviour == originTileTB || originTileTB == null)
            GridManager.instance.OriginTileChanged(tileBehaviour);
        else
            GridManager.instance.DestTileChanged(tileBehaviour);

        GridManager.instance.generateAndShowPath();
    }
}
