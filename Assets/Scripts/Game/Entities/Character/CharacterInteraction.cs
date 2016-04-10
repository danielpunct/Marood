
using System.Collections;
using System.Linq;
using UnityEngine;

public class CharacterInteraction : CharacterMonoBehaviour
{
    public CharacterState StateCharacter { get; private set; }

   


    public void OnUserClick()
    {
        switch (StateCharacter)
        {
            case CharacterState.Inactive:
                PlayerManager.SelectedCharacter = cEntity;
                break;
            case CharacterState.Active:
                PlayerManager.SelectedCharacter = null;
                break;
        }
    }
    

    public void SetActiveUI()
    {
        StateCharacter = CharacterState.Active;
        VisualizationComponent.SetActiveState();
    }

    public void SetInactiveUI()
    {
        StateCharacter = CharacterState.Inactive;
        VisualizationComponent.SetInactiveState();
    }

    public void SetTauntState()
    {
        StartCoroutine(TauntAfterStop());
    }

    IEnumerator TauntAfterStop()
    {
        while (MoveComponent.IsMoving)
        {
            yield return new WaitForSeconds(0.5f);
        }
        bool startedAttack = false;
        var neighbourPair = HolyTools.ActiveNeighbours.FirstOrDefault(x => (x.EntityA == cEntity || x.EntityB == cEntity));
        if (neighbourPair != null)
        {
            var theOther = neighbourPair.EntityA == this ? neighbourPair.EntityB : neighbourPair.EntityA;
            if (!theOther.MoveComponent.IsMoving)
            {
                StartAttack(theOther);
                startedAttack = true;
            }
        }
        if(!startedAttack)
        {
            VisualizationComponent.SetTauntState();
        }
    }

    void StartAttack(CharacterEntity OtherCharacter)
    {
        VisualizationComponent.SetAttackState();
        OtherCharacter.VisualizationComponent.SetAttackState();
    }
}

public enum CharacterState { Inactive, Active }

