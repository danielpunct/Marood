using UnityEngine;

public class CharacterMoveBehaviour : MonoBehaviour
{

    public CharacterVisualization CharacterVisualization { get; private set; } 

    public BoardMovement Movement { get; private set; }

    public bool IsMoving { get { return Movement.IsMoving; } }
    public Vector3 NextDestination { get { return Movement.NextTilePos; } }

    public void MoveDestinationReached()
    {
        Movement.CheckPathDestination();
    }

    void Awake()
    {
        Movement = new BoardMovement();
        Movement.IsMoving = false;
    }

    void Start()
    {
        CharacterVisualization = GetComponent<CharacterVisualization>();
    }

    public void Init(int x, int y)
    {
        var t = gameObject.transform;
        t.localPosition = GridBoard.CalcWorldPosFromCoords(x, y);
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        t.SetParent(GridBoard.Instance.transform);
        gameObject.layer = GridBoard.Instance.gameObject.layer;

        Movement.SetOrigin(x, y);
    }

    public void SetNewDestination(TileInteractionBehaviour tile)
    {
        Movement.SetNewDestination(tile);
    }

    public bool IsCurrentTile(Tile tile)
    {
        return tile.Location.Equals(Movement.CurrentTile.GridTile.Location);
    }

    public TileInteractionBehaviour GetActiveTile()
    {
        return IsMoving ? Movement.DestTileTB : Movement.CurrentTile;
    }


}