using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public bool Direction { get; set; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        //Vector3 move = new Vector3(-pos.y * dragSpeed, 0, pos.x * dragSpeed);
        Vector3 move = new Vector3(0, 0, -pos.x * dragSpeed * (Direction ? -1 : 1));

        transform.Translate(move, Space.World);
    }


}