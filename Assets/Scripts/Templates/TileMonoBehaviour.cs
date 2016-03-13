using UnityEngine;

public class TileMonoBehaviour : MonoBehaviour
{
    public TileVisualization VisualizationComponent { get; internal set; }
    public TileInteraction InteractionComponent { get; internal set; }

    internal TileEntity tEntity;
    internal virtual void TemplateAfterAwake() { }

    void Awake()
    {
        tEntity = GetComponent<TileEntity>();

        TemplateAfterAwake();
    }


    public TileInteraction[] InteractionNeighbours {  get { return tEntity.InteractionComponent.Neighbours; } }
}
