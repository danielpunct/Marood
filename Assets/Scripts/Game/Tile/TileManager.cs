using UnityEngine;

public class TileManager : MonoBehaviour
{
    TileInteractionBehaviour tileBehaviour;

    void Awake()
    {
        tileBehaviour = gameObject.AddComponent<TileInteractionBehaviour>();
        var tileViz = GetComponent<TileVisualization>();
        tileViz.renderer.gameObject.AddComponent<TileInputHandler>().TileBehaviour = tileBehaviour;

    }
     
}

