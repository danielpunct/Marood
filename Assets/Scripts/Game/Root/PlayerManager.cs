public static class PlayerManager
{
    public static TileEntity SelectedTile { get; set; }

    public static CharacterEntity SelectedCharacter
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

    static CharacterEntity selectedCharacter;
}
