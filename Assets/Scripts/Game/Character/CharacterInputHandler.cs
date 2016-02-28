using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    CharacterManager charactermanager;

    void Awake()
    {
        charactermanager = GetComponent<CharacterManager>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            charactermanager.ChInteraction.OnUserClick();
        }
    }
}
