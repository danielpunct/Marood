using UnityEngine;

public class TileMonoBehaviour : MonoBehaviour
{
    public TileVisualization VisualizationComponent { get { return tEntity._VisualizationComponent; } }
    public TileInteraction InteractionComponent { get { return tEntity._InteractionComponent; } }

    internal TileEntity tEntity;
    internal virtual void TemplateAfterAwake() { }

    public void SetExternalCustomEntity(TileEntity ent)
    {
        tEntity = ent;
    }

    void Awake()
    {
        tEntity = GetComponent<TileEntity>();

        TemplateAfterAwake();
    }


    public TileInteraction[] InteractionNeighbours {  get { return InteractionComponent.Neighbours; } }
}
