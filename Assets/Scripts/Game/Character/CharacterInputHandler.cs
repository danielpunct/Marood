using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    CharacterInteractionBehaviour characterInteractionBehaviour;

    void Awake()
    {
        characterInteractionBehaviour = GetComponent<CharacterInteractionBehaviour>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            characterInteractionBehaviour.UserActivate();
        }
    }
}
