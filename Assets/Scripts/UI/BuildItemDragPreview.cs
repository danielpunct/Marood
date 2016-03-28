
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
        t.SetParent(null);
        t.localPosition = GridBoard.CalcWorldPosFromCoords(x, y);
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        t.SetParent(GridBoard.Instance.transform);
        gameObject.layer = GridBoard.Instance.gameObject.layer;
        
    }

    public void UpdateXY(int x, int y)
    {
        Init(x, y);
        
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if(hit.transform.name == "Hex")
            {
                var hex = hit.transform.GetComponent<TileInputHandler>();

                UpdateXY(hex.InteractionComponent.GridTile.X, hex.InteractionComponent.GridTile.Y);
            }
        }
    }
}
