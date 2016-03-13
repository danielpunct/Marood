using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    CharacterEntity charactermanager;

    void Awake()
    {
        charactermanager = GetComponent<CharacterEntity>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            charactermanager.ChInteraction.OnUserClick();
        }
    }
}
