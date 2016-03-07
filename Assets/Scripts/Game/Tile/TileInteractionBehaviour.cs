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

        EventManager.StartListening(cEvents.CHARACTER_UI_UPDATED, OnCHARACTER_UI_UPDATED);

    }

    public void UserHoverStart()
    {
        //GridBoard.Instance.selectedTile = GridTile;
    }


    public void UserClick()
    {
        GameManager.Instance.OnUserSendTile(tileManager);
    }

    void OnCHARACTER_UI_UPDATED(object tag)
    {
        if(tag == null)
        {
            tileManager.TlVisualization.ShowAsDefault();
            return;
        }

        var character = tag as CharacterManager;

        int tileIndex = Array.IndexOf(character.CurrentPath, this);
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