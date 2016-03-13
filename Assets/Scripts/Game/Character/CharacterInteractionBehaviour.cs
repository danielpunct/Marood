using UnityEngine;

public class CharacterInteractionBehaviour : MonoBehaviour
{
    public CharacterState StateCharacter { get; private set; }
    CharacterEntity characterManager;

    public void Awake()
    {
        characterManager = GetComponent<CharacterEntity>();
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
        characterManager.VisualizationComponent.SetActiveState();
    }

    public void SetInactiveUI()
    {
        StateCharacter = CharacterState.Inactive;
        characterManager.VisualizationComponent.SetInactiveState();
    }
}

public enum CharacterState { Inactive, Active }

