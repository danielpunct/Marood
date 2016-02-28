using UnityEngine;

public class BoardInteractionBehaviour : MonoBehaviour
{
    void Awake()
    {
        EventManager.StartListening(cEvents.CHARACTER_UI_ACTIVATED, OnCHARACTER_UI_ACTIVATED);
    }

    void OnCHARACTER_UI_ACTIVATED(object tag)
    {
        var character = tag as CharacterManager;

        EventManager.TriggerEvent(cEvents.BOARD_SHOW_MOVEMENT, character != null ? character.CurrentPath : null);
    }
}
