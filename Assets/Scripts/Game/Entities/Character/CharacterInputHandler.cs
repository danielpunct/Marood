using UnityEngine;

public class CharacterInputHandler : CharacterMonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            cEntity.InteractionComponent.OnUserClick();
        }
    }
}
