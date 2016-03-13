using UnityEngine;

public class CharacterMonoBehaviour : MonoBehaviour
{
    internal CharacterEntity characterManager;
    internal virtual void TemplateAfterStart() { }

    void Awake()
    {
        characterManager = GetComponent<CharacterEntity>();

        TemplateAfterStart();
    }
}
