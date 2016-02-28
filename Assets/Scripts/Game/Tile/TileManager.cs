using UnityEngine;

public class TileManager : MonoBehaviour
{
    public TileVisualization TlVisualization { get; private set; }
    public TileInteractionBehaviour TlInteraction { get; private set; }

    void Awake()
    {
        TlInteraction = gameObject.AddComponent<TileInteractionBehaviour>();
        TlVisualization = GetComponent<TileVisualization>();
        TlVisualization.RendererGO.gameObject.AddComponent<TileInputHandler>().TileBehaviour = TlInteraction;
    }
     
}

