using UnityEngine;

class TileVisualization : MonoBehaviour
{
    public TextMesh textMesh;
    public Tile Tile;
    //After attaching this script to hex tile prefab don't forget to initialize following materials with the ones we created earlier
    public Material OpaqueMaterial;
    public Material defaultMaterial;
    //Slightly transparent orange
    Color orange = new Color(255f / 255f, 127f / 255f, 0, 127f / 255f);
    public Renderer renderer;

    Animator animatorComponent;

    void Awake()
    {
        animatorComponent = GetComponent<Animator>();
    }

    public void HighlightHover()
    {
        ChangeColor(Color.red);
    }

    public void Reset()
    {
        renderer.material = defaultMaterial;
        renderer.material.color = Color.white;
    }


    void ChangeColor(Color color)
    {
        //If transparency is not set already, set it to default value
        if (color.a == 1)
            color.a = 200f / 255f;
        renderer.material = OpaqueMaterial;
        renderer.material.color = color;
    }


    public void SetText(string text)
    {
        textMesh.text = text;
    }

    public void SetVisualDefaultState()
    {
        //GetComponent<Renderer>().material = defaultMaterial;
        animatorComponent.SetBool("IsActive", false);
    }

    public void SetVisualActiveState()
    {
        //GetComponent<Renderer>().material.color = orange;
        animatorComponent.SetBool("IsActive", true);
    }

    public Vector3 GetBounds()
    {
        return renderer.bounds.size;
    }
}
