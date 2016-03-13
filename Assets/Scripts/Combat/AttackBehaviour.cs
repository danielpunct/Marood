
using System.Linq;
using UnityEngine;

class AttackBehaviour : CharacterMonoBehaviour
{
    [SerializeField]
    int range = 1;

    internal override void TemplateAfterStart()
    {
        base.TemplateAfterStart();
        InvokeRepeating("CheckNeighbours", 0f, 0.5f);
    }


    public void CheckNeighbours()
    {
        var currentTile = characterManager.ChMove.GetCurrentTile();

        foreach (var neighbour in currentTile.GridTile.Neighbours.Select(x=> x.TileManager))
        {
            var foundCharacter = neighbour.CharacterOnTile();
            if (foundCharacter != null && foundCharacter != characterManager)
            {
                foundCharacter.EnterAttack();
                characterManager.EnterAttack();

                CancelInvoke("CheckNeighbours");
                return;
            }
        }
    }
}
