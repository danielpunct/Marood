using UnityEngine;

public class TileVisualization : MonoBehaviour
{
    public TextMesh textMesh;
    public Tile Tile;
    //After attaching this script to hex tile prefab don't forget to initialize following materials with the ones we created earlier
    public Material OpaqueMaterial;
    public Material defaultMaterial;
    //Slightly transparent orange
    Color orange = new Color(255f / 255f, 127f / 255f, 0, 127f / 255f);
    public Renderer RendererGO;

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
        RendererGO.material = defaultMaterial;
        RendererGO.material.color = Color.white;
    }


    void ChangeColor(Color color)
    {
        //If transparency is not set already, set it to default value
        if (color.a == 1)
            color.a = 200f / 255f;
        RendererGO.material = OpaqueMaterial;
        RendererGO.material.color = color;
    }


    public void SetText(string text)
    {
        textMesh.text = text;
    }

    public void ShowAsDefault()
    {
        //GetComponent<Renderer>().material = defaultMaterial;
        animatorComponent.SetTrigger("Default");
    }

    public void ShowAsDestination()
    {
        //GetComponent<Renderer>().material.color = orange;
        animatorComponent.SetTrigger("IsDestination");
    }

    public void ShowAsPath()
    {
        //GetComponent<Renderer>().material.color = orange;
        animatorComponent.SetTrigger("IsPath");
    }

    public Vector3 GetBounds()
    {
        return RendererGO.bounds.size;
    }
}
