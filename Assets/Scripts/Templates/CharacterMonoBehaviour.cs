using UnityEngine;

public class CharacterMonoBehaviour : MonoBehaviour
{
    internal CharacterManager characterManager;
    internal virtual void TemplateAfterStart() { }

    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();

        TemplateAfterStart();
    }
}
