using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TileVisualization))]
public class TileInteraction : MonoBehaviour
{
    public Tile GridTile { get; private set; }
    public TileEntity TileManager { get; private set; }

    void Awake()
    {
        TileManager = GetComponent<TileEntity>();

        EventManager.StartListening(cEvents.CHARACTER_UI_UPDATED, OnCHARACTER_UI_UPDATED);

    }

    public void UserHoverStart()
    {
        //GridBoard.Instance.selectedTile = GridTile;
    }


    public void UserClick()
    {
        //GameManager.Instance.OnUserSendTile(tileManager);
        EventManager.TriggerEvent(cEvents.USER_SEND_TILE, TileManager);
    }

    void OnCHARACTER_UI_UPDATED(object tag)
    {
        if(tag == null)
        {
            TileManager.TlVisualization.ShowAsDefault();
            return;
        }

        var character = tag as CharacterEntity;

        int tileIndex = Array.IndexOf(character.CurrentPath, this);
        if (tileIndex >= 0)
        {
            if (tileIndex == 0)
            {
                TileManager.TlVisualization.ShowAsDestination();
                return;
            }
            TileManager.TlVisualization.ShowAsPath();
            return;
        }
        else
        {
            TileManager.TlVisualization.ShowAsDefault();
        }
    }

    public TileInteraction[] InteractionNeighbours
    {
        get
        {
            return GridTile.Neighbours.ToArray();
        }
    }

   


    public void InitTile(int x, int y, string text)
    {
        GridTile = new Tile(x, y);
        TileManager.TlVisualization.SetText(text);
    }

    public void Reset()
    {
        TileManager.TlVisualization.Reset();
    }

    public void SetAsOrigin()
    {
        TileManager.TlVisualization.HighlightHover();
    }
}