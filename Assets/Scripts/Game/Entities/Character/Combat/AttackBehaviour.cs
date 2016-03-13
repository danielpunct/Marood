
using System.Linq;
using UnityEngine;

class AttackBehaviour : CharacterMonoBehaviour
{
    [SerializeField]
    int range = 1;

    internal override void TemplateAfterAwake()
    {
        base.TemplateAfterAwake();
        InvokeRepeating("CheckNeighbours", 0f, 0.5f);
    }


    public void CheckNeighbours()
    {
        foreach (var neighbour in CurrentInteractionTile.InteractionNeighbours.Select(x=> x.tEntity))
        {
            var foundCharacter = neighbour.CharacterOnTile();
            if (foundCharacter != null && foundCharacter != cEntity)
            {
                foundCharacter.EnterAttack();
                cEntity.EnterAttack();

                CancelInvoke("CheckNeighbours");
                return;
            }
        }
    }
}
