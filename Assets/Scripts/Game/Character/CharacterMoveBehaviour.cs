using UnityEngine;

public class CharacterMoveBehaviour : MonoBehaviour
{

    public CharacterVisualization CharacterVisualization { get; private set; } 

    BoardMovement boardMovement;

    public bool IsMoving { get { return boardMovement.IsMoving; } }
    public Vector3 NextDestination { get { return boardMovement.NextTilePos; } }

    public void MoveDestinationReached()
    {
        boardMovement.CheckPathDestination();
    }

    void Awake()
    {
        boardMovement = new BoardMovement();
        boardMovement.IsMoving = false;
    }

    void Start()
    {
        //all the animations by default should loop
        //GetComponent<Animation>().wrapMode = WrapMode.Loop;
        //caching the transform for better performance
        CharacterVisualization = GetComponent<CharacterVisualization>();
    }

    public void Init(int x, int y)
    {
        var t = gameObject.transform;
        t.localPosition = GridBoard.Instance.CalcWorldPosFromCoords(x, y);
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        t.SetParent(GridBoard.Instance.transform);
        gameObject.layer = GridBoard.Instance.gameObject.layer;

        boardMovement.SetOrigin(x, y);
    }

    public void SetNewDestination(TileInteractionBehaviour tile)
    {
        boardMovement.SetNewDestination(tile);
    }

    public bool IsCurrentTile(Tile tile)
    {
        return tile.Location.Equals(boardMovement.CurrentTile.GridTile.Location);
    }

    public TileInteractionBehaviour GetActiveTile()
    {
        return IsMoving ? boardMovement.DestTileTB : boardMovement.CurrentTile;
    }
}