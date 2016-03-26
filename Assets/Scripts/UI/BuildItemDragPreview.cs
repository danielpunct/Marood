
using UnityEngine;

public class BuildItemDragPreview : MonoBehaviour
{
    public int X;
    public int Y;

    public void Init(int x, int y)
    {
        X = x;
        Y = y;
        var t = gameObject.transform;
        t.localPosition = GridBoard.CalcWorldPosFromCoords(x, y);
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        t.SetParent(GridBoard.Instance.transform);
        gameObject.layer = GridBoard.Instance.gameObject.layer;
    }

    public void UpdateXY(int x, int y)
    {
        X = x;
        Y = y;
    }
}
