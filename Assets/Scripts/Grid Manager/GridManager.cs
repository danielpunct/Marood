using UnityEngine;

public class GridManager : MonoBehaviour
{
    //following public variable is used to store the hex model prefab;
    //instantiate it by dragging the prefab on this variable using unity editor
    public GameObject Hex;
    //next two variables can also be instantiated using unity editor
    public int gridWidthInHexes = 10;
    public int gridHeightInHexes = 10;

    //Hexagon tile width and height in game world
    private float hexWidth;
    private float hexHeight;

    Vector3 gridOrigin;

    //Method to initialise Hexagon width and height
    void setSizes()
    {
        //renderer component attached to the Hex prefab is used to get the current width and height
        hexWidth = Hex.GetComponent<Renderer>().bounds.size.x;
        hexHeight = Hex.GetComponent<Renderer>().bounds.size.z;
    }

    //Method to calculate the position of the first hexagon tile
    //The center of the hex grid is (0,0,0)
    Vector3 calcInitPos()
    {
        Vector3 initPos;
        //the initial position will be in the left upper corner
        initPos = new Vector3(-hexWidth * gridWidthInHexes / 2f + hexWidth / 2, 0,
            gridHeightInHexes / 2f * hexHeight - hexHeight / 2);

        return gridOrigin;// initPos;
    }

    //method used to convert hex grid coordinates to game world coordinates
    public Vector3 calcWorldCoord(Vector2 gridPos)
    {
        //Position of the first hex tile
        Vector3 initPos = calcInitPos();
        //Every second row is offset by half of the tile width
        float offset = 0;
        if (gridPos.x % 2 != 0)
            offset = hexHeight * 0.675f / 2;

        float x = initPos.x + gridPos.x * hexWidth * 0.65f;
        //Every new line is offset in z direction by 3/4 of the hexagon height
        float z = initPos.z + offset - gridPos.y * hexHeight * 0.675f;
        return new Vector3(x, gridOrigin.y, z);
    }

    //Finally the method which initialises and positions all the tiles
    void createGrid()
    {
        //Game object which is the parent of all the hex tiles
        GameObject hexGridGO = new GameObject("HexGrid");

        for (float y = 0; y < gridHeightInHexes; y++)
        {
            for (float x = 0; x < gridWidthInHexes; x++)
            {
                //GameObject assigned to Hex public variable is cloned
                GameObject hex = (GameObject)Instantiate(Hex);
                //Current position in grid
                Vector2 gridPos = new Vector2(x, y);
                hex.transform.position = calcWorldCoord(gridPos);
                hex.transform.parent = hexGridGO.transform;
            }
        }
    }

    //The grid should be generated on game start
    void Start()
    {
        gridOrigin = transform.position;
        setSizes();
        createGrid();
    }
}