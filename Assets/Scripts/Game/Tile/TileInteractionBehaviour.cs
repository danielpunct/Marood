using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileVisualization))]
public class TileInteractionBehaviour : MonoBehaviour
{
    public Tile GridTile { get; private set; }
    TileManager tileManager;

    void Awake()
    {
        tileManager = GetComponent<TileManager>();

        EventManager.StartListening(cEvents.BOARD_SHOW_MOVEMENT, OnBOARD_SHOW_MOVEMENT);

    }

    public void UserHoverStart()
    {
        //GridBoard.Instance.selectedTile = GridTile;
    }


    public void UserClick()
    {
        GameManager.Instance.OnUserSendTile(tileManager);
    }

    void OnBOARD_SHOW_MOVEMENT(object tag)
    {
        if(tag == null)
        {
            tileManager.TlVisualization.ShowAsDefault();
            return;
        }

        var tiles = tag as TileInteractionBehaviour[];
        int tileIndex = Array.IndexOf(tiles, this);
        if (tileIndex >= 0)
        {
            if (tileIndex == 0)
            {
                tileManager.TlVisualization.ShowAsDestination();
                return;
            }
            tileManager.TlVisualization.ShowAsPath();
            return;
        }
        else
        {
            tileManager.TlVisualization.ShowAsDefault();
        }
    }



    public void InitTile(int x, int y, string text)
    {
        GridTile = new Tile(x, y);
        tileManager.TlVisualization.SetText(text);
    }

    public void Reset()
    {
        tileManager.TlVisualization.Reset();
    }

    public void SetAsOrigin()
    {
        tileManager.TlVisualization.HighlightHover();
    }
}