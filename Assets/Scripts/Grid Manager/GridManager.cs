using System;
using System.Collections.Generic;
using System.Linq;
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
    private float groundWidth;
    private float groundHeight;

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



    //The grid should be generated on game start
    void Start()
    {
        gridOrigin = transform.position;
        setSizes();
        createGrid();
    }

    //selectedTile stores the tile mouse cursor is hovering on
    public Tile selectedTile = null;
    //TB of the tile which is the start of the path
    public TileBehaviour originTileTB = null;
    //TB of the tile which is the end of the path
    public TileBehaviour destTileTB = null;

    public static GridManager instance = null;

    void Awake()
    {
        instance = this;
    }
    

    //Line should be initialised to some 3d object that can fit nicely in the center of a hex tile and will be used to indicate the path. For example, it can be just a simple small sphere with some material attached to it. Initialise the variable using inspector pane.
    public GameObject Line;
    //List to hold "Lines" indicating the path
    List<GameObject> path;

    //Finally the method which initialises and positions all the tiles
    //void createGrid()
    //{
    //    //Game object which is the parent of all the hex tiles
    //    GameObject hexGridGO = new GameObject("HexGrid");
    //    Dictionary<Point, Tile> board = new Dictionary<Point, Tile>();

    //    for (float y = 0; y < gridHeightInHexes; y++)
    //    {
    //        for (float x = 0; x < gridWidthInHexes; x++)
    //        {
    //            ////GameObject assigned to Hex public variable is cloned
    //            //GameObject hex = (GameObject)Instantiate(Hex);
    //            ////Current position in grid
    //            //Vector2 gridPos = new Vector2(x, y);
    //            //hex.transform.position = calcWorldCoord(gridPos);
    //            //hex.transform.parent = hexGridGO.transform;

    //            GameObject hex = (GameObject)Instantiate(Hex);
    //            Vector2 gridPos = new Vector2(x, y);
    //            hex.transform.position = calcWorldCoord(gridPos);
    //            hex.transform.parent = hexGridGO.transform;
    //            var tb = (TileBehaviour)hex.GetComponent("TileBehaviour");
    //            //y / 2 is subtracted from x because we are using straight axis coordinate system
    //            tb.tile = new Tile((int)x - (int)(y / 2), (int)y);
    //            board.Add(tb.tile.Location, tb.tile);
    //        }
    //    }

    //    //variable to indicate if all rows have the same number of hexes in them
    //    //this is checked by comparing width of the first hex row plus half of the hexWidth with groundWidth
    //   // bool equalLineLengths = (gridWidthInHexes + 0.5) * hexWidth <= groundWidth;
    //    //Neighboring tile coordinates of all the tiles are calculated
    //    foreach (Tile tile in board.Values)
    //        tile.FindNeighbours(board, new Vector2(gridWidthInHexes,gridHeightInHexes), false);
    //}

    void createGrid()
    {

        //Game object which is the parent of all the hex tiles
        GameObject hexGridGO = new GameObject("HexGrid");
        Dictionary<Point, Tile> board = new Dictionary<Point, Tile>();

        for (float y = 0; y < gridHeightInHexes; y++)
        {
            for (float x = 0; x < gridWidthInHexes; x++)
            {
                GameObject hex = (GameObject)Instantiate(Hex);
                Vector2 gridPos = new Vector2(x, y);
                hex.transform.position = calcWorldCoord(gridPos);
                hex.transform.parent = hexGridGO.transform;
                var tb = (TileBehaviour)hex.GetComponent("TileBehaviour");
                //y / 2 is subtracted from x because we are using straight axis coordinate system
                tb.tile = new Tile((int)x - (int)(y / 2), (int)y);
                board.Add(tb.tile.Location, tb.tile);
                //Mark originTile as the tile with (0,0) coordinates
                if (x == 0 && y == 0)
                {
                    tb.GetComponent<Renderer>().material = tb.OpaqueMaterial;
                    Color red = Color.red;
                    red.a = 158f / 255f;
                    tb.GetComponent<Renderer>().material.color = red;
                    originTileTB = tb;
                }
            }
        }
        //variable to indicate if all rows have the same number of hexes in them
        //this is checked by comparing width of the first hex row plus half of the hexWidth with groundWidth
        foreach (Tile tile in board.Values)
            tile.FindNeighbours(board, new Vector2(gridWidthInHexes, gridHeightInHexes), false);
    }

    public void generateAndShowPath()
    {
        //Don't do anything if origin or destination is not defined yet
        if (originTileTB == null || destTileTB == null)
        {
            DrawPath(new List<Tile>());
            return;
        }
        //We assume that the distance between any two adjacent tiles is 1
        //If you want to have some mountains, rivers, dirt roads or something else which might slow down the player you should replace the function with something that suits better your needs
        Func<Tile, Tile, double> distance = (node1, node2) => 1;
        
        var path = PathFinder.FindPath(originTileTB.tile, destTileTB.tile);
        DrawPath(path);
        CharacterMovement.instance.StartMoving(path.ToList());
    }


    //The method used to calculate the number hexagons in a row and number of rows
    //Vector2.x is gridWidthInHexes and Vector2.y is gridHeightInHexes
    Vector2 calcGridSize()
    {
        //According to the math textbook hexagon's side length is half of the height
        float sideLength = hexHeight / 2;
        //the number of whole hex sides that fit inside inside ground height
        int nrOfSides = (int)(groundHeight / sideLength);
        //I will not try to explain the following calculation because I made some assumptions, which might not be correct in all cases, to come up with the formula. So you'll have to trust me or figure it out yourselves.
        int gridHeightInHexes = (int)(nrOfSides * 2 / 3);
        //When the number of hexes is even the tip of the last hex in the offset column might stick up.
        //The number of hexes in that case is reduced.
        if (gridHeightInHexes % 2 == 0
            && (nrOfSides + 0.5f) * sideLength > groundHeight)
            gridHeightInHexes--;
        //gridWidth in hexes is calculated by simply dividing ground width by hex width
        return new Vector2((int)(groundWidth / hexWidth), gridHeightInHexes);
    }

    //Distance between destination tile and some other tile in the grid
    double calcDistance(Tile tile)
    {
        Tile destTile = destTileTB.tile;
        //Formula used here can be found in Chris Schetter's article
        float deltaX = Mathf.Abs(destTile.X - tile.X);
        float deltaY = Mathf.Abs(destTile.Y - tile.Y);
        int z1 = -(tile.X + tile.Y);
        int z2 = -(destTile.X + destTile.Y);
        float deltaZ = Mathf.Abs(z2 - z1);

        return Mathf.Max(deltaX, deltaY, deltaZ);
    }

    private void DrawPath(IEnumerable<Tile> path)
    {
        if (this.path == null)
            this.path = new List<GameObject>();
        //Destroy game objects which used to indicate the path
        this.path.ForEach(Destroy);
        this.path.Clear();

        //Lines game object is used to hold all the "Line" game objects indicating the path
        GameObject lines = GameObject.Find("Lines");
        if (lines == null)
            lines = new GameObject("Lines");
        foreach (Tile tile in path)
        {
            var line = (GameObject)Instantiate(Line);
            //calcWorldCoord method uses squiggly axis coordinates so we add y / 2 to convert x coordinate from straight axis coordinate system
            Vector2 gridPos = new Vector2(tile.X + tile.Y / 2, tile.Y);
            line.transform.position = calcWorldCoord(gridPos);
            this.path.Add(line);
            line.transform.parent = lines.transform;
        }
    }

    //public void generateAndShowPath()
    //{
    //    //Don't do anything if origin or destination is not defined yet
    //    if (originTileTB == null || destTileTB == null)
    //    {
    //        DrawPath(new List<Tile>());
    //        return;
    //    }
    //    //We assume that the distance between any two adjacent tiles is 1
    //    //If you want to have some mountains, rivers, dirt roads or something else which might slow down the player you should replace the function with something that suits better your needs
    //    Func<Tile, Tile, double> distance = (node1, node2) => 1;

    //    var path = PathFinder.FindPath(originTileTB.tile, destTileTB.tile   );
    //    DrawPath(path);
    //}

}