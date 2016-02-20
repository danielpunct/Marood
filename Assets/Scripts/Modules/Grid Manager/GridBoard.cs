using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GridBoard : MonoBehaviour
{
    public GameObject Ground;
    public GameObject Hex;
    public GameObject Line;

    public Tile selectedTile = null;
    public Dictionary<Point, TileInteractionBehaviour> Board;

    float hexSizeX, hexSizeY, hexSizeZ, groundSizeX, groundSizeY, groundSizeZ;
    public static GridBoard Instance = null;

    void Awake()
    {
        Instance = this;
        SetSizes();
        CreateGrid();
    }

    void CreateGrid()
    {
        Vector2 gridSize = CalcGridSize();
        GameObject hexGridGO = new GameObject("HexGrid");
        hexGridGO.transform.SetParent(transform);
        Board = new Dictionary<Point, TileInteractionBehaviour>();

        for (float y = 0; y < gridSize.y; y++)
        {
            float sizeX = gridSize.x;
            if (y % 2 != 0 && (gridSize.x + 0.5) * hexSizeX > groundSizeX)
                sizeX--;
            for (float x = 0; x < sizeX; x++)
            {
                GameObject hex = Instantiate(Hex);
                Vector2 gridPos = new Vector2(x, y);
                hex.transform.position = CalcWorldCoord(gridPos);
                hex.transform.parent = hexGridGO.transform;
                var tb = hex.GetComponent<TileInteractionBehaviour>();

                tb.InitTile((int)x - (int)(y / 2), (int)y, (int)x - (int)(y / 2) + ":" + (int)y);
              
                Board.Add(tb.GridTile.Location, tb);
            }
        }
        bool equalLineLengths = (gridSize.x + 0.5) * hexSizeX <= groundSizeX;
        foreach (TileInteractionBehaviour tb in Board.Values)
            tb.GridTile.FindNeighbours(Board, gridSize, equalLineLengths);
    }

    public void ErasePath( List<GameObject> indicators)
    {
        indicators.ForEach(Destroy);
        indicators.Clear();
    }

    public void DrawPath(IEnumerable<Tile> path, List<GameObject> indicators)
    {
        indicators.Clear();

        GameObject lines = GameObject.Find("Lines");
        if (lines == null)
            lines = new GameObject("Lines");
        foreach (Tile tile in path)
        {
            var line = (GameObject)Instantiate(Line);
            line.transform.position = CalcWorldPosFromCoords(tile.X, tile.Y);
            indicators.Add(line);
            line.transform.parent = lines.transform;
        }
    }

    
    public Vector3 CalcWorldPosFromCoords(int X, int Y)
    {
        //y / 2 is added to convert coordinates from straight axis coordinate system to squiggly axis system
        Vector2 gridPos = new Vector2(X + Y / 2, Y);
        return CalcWorldCoord(gridPos);
    }

    public TileInteractionBehaviour GetTile(int x, int y)
    {
        return Board[new Point(x, y)];
    }


    void SetSizes()
    {
        var tilebounds = Hex.GetComponent<TileVisualization>().GetBounds();

        hexSizeX = tilebounds.x;
        hexSizeY = tilebounds.y;
        hexSizeZ = tilebounds.z;
        groundSizeX = Ground.GetComponent<Renderer>().bounds.size.x;
        groundSizeY = Ground.GetComponent<Renderer>().bounds.size.y;
        groundSizeZ = Ground.GetComponent<Renderer>().bounds.size.z;
    }

    Vector2 CalcGridSize()
    {
        float sideLength = hexSizeZ / 2;
        int nrOfSides = (int)(groundSizeZ / sideLength + 0.00005f);
        int nrOfZHexes = (int)(nrOfSides * 2 / 3);
        if (nrOfZHexes % 2 == 0
            && (nrOfSides + 0.5f) * sideLength > groundSizeZ)
            nrOfZHexes--;

        return new Vector2((int)(groundSizeX / hexSizeX), nrOfZHexes);
    }

    Vector3 CalcInitPos()
    {
        Vector3 initPos;
        initPos = new Vector3(hexSizeX / 2 - groundSizeX / 2,
            groundSizeY / 2 + hexSizeY / 2, groundSizeZ / 2 - hexSizeZ / 2);

        return initPos;
    }

    Vector3 CalcWorldCoord(Vector2 gridPos)
    {
        Vector3 initPos = CalcInitPos();
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexSizeX / 2;
        float x = gridPos.x * hexSizeX + initPos.x + offset;
        float z = initPos.z - gridPos.y * hexSizeZ * 0.75f;
        float y = groundSizeY / 2 + 0.137f;
        return new Vector3(x, y, z);
    }

    #region not used
    private static float CalcDistance(Tile tile, Tile destTile)
    {
        float dx = Mathf.Abs(destTile.X - tile.X);
        float dy = Mathf.Abs(destTile.Y - tile.Y);
        int z1 = -(tile.X + tile.Y);
        int z2 = -(destTile.X + destTile.Y);
        float dz = Mathf.Abs(z2 - z1);

        return Mathf.Max(dx, dy, dz);
    }

    private void setGroundSize(float width, float height)
    {
        Destroy(GameObject.Find("Lines"));
        Destroy(GameObject.Find("HexGrid"));
        Vector3 groundScale = Ground.transform.localScale;
        Vector3 groundSize = new Vector3(width, groundScale.y, height);
        Ground.transform.localScale = groundSize;
        Vector2 textureTiling = new Vector2(width * 2, height * 2);
        Ground.GetComponent<Renderer>().material.mainTextureScale = textureTiling;
        SetSizes();
        CreateGrid();
    }

    private Vector2 calcGridPos(Vector3 coord)
    {
        Vector3 initPos = CalcInitPos();
        Vector2 gridPos = new Vector2();
        float offset = 0;
        gridPos.y = Mathf.RoundToInt((initPos.z - coord.z) / (hexSizeZ * 0.75f));
        if (gridPos.y % 2 != 0)
            offset = hexSizeX / 2;
        gridPos.x = Mathf.RoundToInt((coord.x - initPos.x - offset) / hexSizeX);
        return gridPos;
    }
    #endregion
}