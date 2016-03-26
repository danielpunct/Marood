﻿public class CharacterInteraction : CharacterMonoBehaviour
{
    public CharacterState StateCharacter { get; private set; }
    

    public void OnUserClick()
    {
        switch (StateCharacter)
        {
            case CharacterState.Inactive:
                PlayerManager.SelectedCharacter = cEntity;
                break;
            case CharacterState.Active:
                PlayerManager.SelectedCharacter = null;
                break;
        }
    }
    

    public void SetActiveUI()
    {
        StateCharacter = CharacterState.Active;
        VisualizationComponent.SetActiveState();
    }

    public void SetInactiveUI()
    {
        StateCharacter = CharacterState.Inactive;
        VisualizationComponent.SetInactiveState();
    }
}

public enum CharacterState { Inactive, Active }

