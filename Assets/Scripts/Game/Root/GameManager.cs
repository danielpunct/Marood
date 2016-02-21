using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    List<CharacterManager> characters;

    void Awake()
    {
        Instance = this;
        characters = new List<CharacterManager>();
        gameObject.AddComponent<EventManager>();
        gameObject.AddComponent<CharacterInvoker>();

        EventManager.StartListening(cEvents.TILE_USER_ACTIVATED, OnTileActivated);
        EventManager.StartListening(cEvents.TILE_USER_DEACTIVATED, OnTileDeactivated);
    }

    void Start()
    {
        EventManager.TriggerEvent(cEvents.INVOKE_CHARACTER, new CharacterInvokerTag() { Character = "Character", X = -3, Y = 6 });
        EventManager.TriggerEvent(cEvents.INVOKE_CHARACTER, new CharacterInvokerTag() { Character = "Character", X = -3, Y = 8 });
    }

    public void AddCharacter(CharacterManager character)
    {
        characters.Add(character);
    }


    void OnTileActivated(object tag)
    {
        var tileBehaviour = tag as TileInteractionBehaviour;

        var tileSelectedCharacter = characters.FirstOrDefault(x => x.IsOnTile(tileBehaviour.GridTile));

        if (tileSelectedCharacter == null)
        {
            if (PlayerManager.SelectedCharacter != null)
            {
                PlayerManager.SelectedCharacter.SetNewDestination(tileBehaviour);
            }
        }

    }

    void OnTileDeactivated(object tag)
    {
        //var tile = tag as TileInteractionBehaviour;

        //var tileSelectedCharacter = characters.FirstOrDefault(x => x.IsOnTile(tile.GridTile));

        //if (tileSelectedCharacter == null)
        //{

        //}
        //else
        //{
        //    PlayerManager.SelectedCharacter = null;
        //}
    }
}