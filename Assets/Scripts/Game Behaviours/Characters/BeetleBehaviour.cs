using UnityEngine;

class BeetleBehaviour : CharacterMonoBehaviour
{
    internal override void TemplateAfterStart()
    {
        base.TemplateAfterStart();
        gameObject.AddComponent<AttackBehaviour>();
    }
}
