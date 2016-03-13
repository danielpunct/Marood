using UnityEngine;

public class CharacterMove : CharacterMonoBehaviour
{
    public BoardMovement Movement { get; private set; }

    public bool IsMoving { get { return Movement.IsMoving; } }
    public Vector3 NextDestination { get { return Movement.NextTilePos; } }

    public void MoveDestinationReached()
    {
        Movement.CheckPathDestination();
    }
    internal override void TemplateAfterAwake()
    {
        base.TemplateAfterAwake();
        Movement = new BoardMovement();
        Movement.IsMoving = false;
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

    public void SetNewDestination(TileInteraction tile)
    {
        Movement.SetNewDestination(tile);
    }

    public bool IsOnTile(Tile tile)
    {
        return tile.Location.Equals(Movement.CurrentTile.GridTile.Location);

    }

    public TileInteraction GetActiveTile()
    {
        return IsMoving ? Movement.DestTileTB : Movement.CurrentTile;
    }

    public TileInteraction GetCurrentTile()
    {
        return Movement.CurrentTile;
    }

    public void StopOnCurrentTile()
    {
        Movement.StopOnCurrentTile();
    }

     
}