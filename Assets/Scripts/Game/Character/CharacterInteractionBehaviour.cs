using UnityEngine;

class CharacterInteractionBehaviour : MonoBehaviour
{
    public CharacterState StateCharacter { get; private set; }
    CharacterVisualization characterVisualization;
    CharacterManager characterManager;
    CharacterMoveBehaviour characterMoveBehaviour;

    public void Awake()
    {
        characterVisualization = GetComponent<CharacterVisualization>();
        characterManager = GetComponent<CharacterManager>();
        characterMoveBehaviour = GetComponent<CharacterMoveBehaviour>();

        EventManager.StartListening(cEvents.CHARACTER_USER_CLIK, OnCharacterUserClick);


        EventManager.StartListening(cEvents.CHARACTER_ACTIVATED, OnCharacterActivated);
        EventManager.StartListening(cEvents.CHARACTER_DEACTIVATED, OnCharacterDeactivated);
    }

    public void UserActivate()
    {
        EventManager.TriggerEvent(cEvents.CHARACTER_USER_CLIK, this);
    }

    void OnCharacterUserClick(object tag)
    {
        var chrt = tag as CharacterInteractionBehaviour;

        if (chrt == this)
        {
            switch (StateCharacter)
            {
                case CharacterState.Inactive:
                    characterVisualization.SetActiveState();
                    StateCharacter = CharacterState.Active;
                    EventManager.TriggerEvent(cEvents.CHARACTER_ACTIVATED, this);
                    break;
                case CharacterState.Active:
                    characterVisualization.SetInactiveState();
                    StateCharacter = CharacterState.Inactive;
                    EventManager.TriggerEvent(cEvents.CHARACTER_DEACTIVATED, this);
                    break;
            }
        }
    }


    void OnCharacterActivated(object tag)
    {
        var character = tag as CharacterInteractionBehaviour;

        if (character == this)
        {
            PlayerManager.SelectedCharacter = characterManager;
            characterVisualization.SetActiveState();
            //activate tile
            EventManager.TriggerEvent(cEvents.TILE_HIGHLIGHTED, characterMoveBehaviour.GetActiveTile());
        }
        else
        {
            characterMoveBehaviour.CharacterVisualization.SetInactiveState();
        }
    }

    void OnCharacterDeactivated(object tag)
    {
        var character = tag as CharacterInteractionBehaviour;

        if (character == this)
        {
            PlayerManager.SelectedCharacter = null;
            characterVisualization.SetInactiveState();
            //deactivate tile
            EventManager.TriggerEvent(cEvents.TILE_DEHIGHLIGHTED, characterMoveBehaviour.GetActiveTile());
        }
    }
}

public enum CharacterState { Inactive, Active }

