using System.Collections.Generic;
using UnityEngine;

public class GameSuperviser : MonoBehaviour
{
    public static GameSuperviser Instance { get; private set; }
    public List<CharacterEntity> Characters { get; private set; }

    void Awake()
    {
        Instance = this;
        Characters = new List<CharacterEntity>();
        gameObject.AddComponent<EventManager>();
        gameObject.AddComponent<CharacterInvoker>();
    }

    void Start()
    {
        EventManager.TriggerEvent(cEvents.INVOKE_CHARACTER, new CharacterInvokerTag() { Character = cCharacters.Beetle, X = -3, Y = 6 });
        EventManager.TriggerEvent(cEvents.INVOKE_CHARACTER, new CharacterInvokerTag() { Character = cCharacters.RedBeetle, X = -3, Y = 8 });

        // When the user clicks on a tile
        EventManager.StartListening(cEvents.USER_SEND_TILE, OnUSER_SEND_TILE);
    }

    void OnUSER_SEND_TILE(object tag)
    {
        var tile = tag as TileEntity;

        var foundCharacter = tile.CharacterOnTile();
        if (foundCharacter != null)
        {
            PlayerManager.SelectedCharacter = foundCharacter;
            return;
        }

        if (PlayerManager.SelectedCharacter != null)
        {
            PlayerManager.SelectedCharacter.SetNewDestination(tile);
        }
    }

    public void AddCharacter(CharacterEntity character)
    {
        Characters.Add(character);
    }
}