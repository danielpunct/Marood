using UnityEngine;

public class TileEntity : MonoBehaviour
{
    public TileVisualization TlVisualization { get; private set; }
    public TileInteraction TlInteraction { get; private set; }

    void Awake()
    {
        TlInteraction = gameObject.AddComponent<TileInteraction>();
        TlVisualization = GetComponent<TileVisualization>();
        TlVisualization.RendererGO.gameObject.AddComponent<TileInputHandler>().TileBehaviour = TlInteraction;
    }

    public CharacterEntity CharacterOnTile()
    {
        foreach (var character in HolyTools.Characters)
        {
            if (character.ChMove.IsOnTile(TlInteraction.GridTile))
            {
                return character;
            }
        }
        return null;
    }
}