using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour
{
    public TextMesh textMesh;
    public Tile Tile;
    //After attaching this script to hex tile prefab don't forget to initialize following materials with the ones we created earlier
    public Material OpaqueMaterial;
    public Material defaultMaterial;
    //Slightly transparent orange
    Color orange = new Color(255f / 255f, 127f / 255f, 0, 127f / 255f);

    public void ChangeColor(Color color)
    {
        //If transparency is not set already, set it to default value
        if (color.a == 1)
            color.a = 200f / 255f;
        GetComponent<Renderer>().material = OpaqueMaterial;
        GetComponent<Renderer>().material.color = color;
    }

    //IMPORTANT: for methods like OnMouseEnter, OnMouseExit and so on to work, collider (Component -> Physics -> Mesh Collider) should be attached to the prefab
    void OnMouseEnter()
    {
        GridManager.instance.selectedTile = Tile;
        //when mouse is over some tile, the tile is passable and the current tile is neither destination nor origin tile, change color to orange
        if (Tile.Passable && this != GridManager.instance.destTileTB
            && this != GridManager.instance.originTileTB)
        {
            ChangeColor(Color.red);
        }
    }

    //changes back to fully transparent material when mouse cursor is no longer hovering over the tile
    void OnMouseExit()
    {
        GridManager.instance.selectedTile = null;
        if (Tile.Passable && this != GridManager.instance.destTileTB
            && this != GridManager.instance.originTileTB)
        {
            this.GetComponent<Renderer>().material = defaultMaterial;
            this.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    //called every frame when mouse cursor is on this tile
    void OnMouseOver()
    {
        ////if player right-clicks on the tile, toggle passable variable and change the color accordingly
        //if (Input.GetMouseButtonUp(1))
        //{
        //    if (this == GridManager.instance.destTileTB ||
        //        this == GridManager.instance.originTileTB)
        //        return;
        //    tile.Passable = !tile.Passable;
        //    if (!tile.Passable)
        //        changeColor(Color.gray);
        //    else
        //        changeColor(orange);

        //    GridManager.instance.generateAndShowPath();
        //}
        //if user left-clicks the tile
        if (Input.GetMouseButtonUp(0))
        {
            GridManagerInputHandler.Instance.UserLeftClick(this);
        }
    }
    
    public void SetVisualDefaultState()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }

    public void SetVisualActiveState()
    {
        GetComponent<Renderer>().material.color = orange;
    }
}