public static class PlayerManager
{
    public static TileManager SelectedTile { get; set; }

    public static CharacterManager SelectedCharacter
    {
        get { return selectedCharacter; }
        set
        {
            if (selectedCharacter != null)
            {
                selectedCharacter.ChInteraction.SetInactiveUI();
            }

            selectedCharacter = value;

            if (selectedCharacter != null)
            {
                selectedCharacter.ChInteraction.SetActiveUI();
            }

            EventManager.TriggerEvent(cEvents.CHARACTER_UI_UPDATED, selectedCharacter);
        }
    }

    static CharacterManager selectedCharacter;
}
