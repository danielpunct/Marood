using UnityEngine;

public class CharacterInteractionBehaviour : MonoBehaviour
{
    public CharacterState StateCharacter { get; private set; }
    CharacterManager characterManager;

    public void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
    }
    

    public void OnUserClick()
    {
        switch (StateCharacter)
        {
            case CharacterState.Inactive:
                PlayerManager.SelectedCharacter = characterManager;
                break;
            case CharacterState.Active:
                PlayerManager.SelectedCharacter = null;
                break;
        }
    }
    

    public void SetActiveUI()
    {
        StateCharacter = CharacterState.Active;
        characterManager.ChVisualizaton.SetActiveState();
    }

    public void SetInactiveUI()
    {
        StateCharacter = CharacterState.Inactive;
        characterManager.ChVisualizaton.SetInactiveState();
    }
}

public enum CharacterState { Inactive, Active }

