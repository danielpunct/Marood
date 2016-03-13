using UnityEngine;

class BeetleBehaviour : CharacterMonoBehaviour
{
    internal override void TemplateAfterAwake()
    {
        base.TemplateAfterAwake();
        gameObject.AddComponent<AttackBehaviour>();
    }
}
