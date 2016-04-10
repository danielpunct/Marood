using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardInteraction : MonoBehaviour
{
    public static BoardInteraction Instance { get; private set; }

    public List<NeighbourPair> ActiveNeighbours;
    public int range = 1;

    void Awake()
    {
        InvokeRepeating("CheckNeighbours", 0f, 0.5f);
        Instance = this;
        ActiveNeighbours = new List<NeighbourPair>();
    }

    public void CheckNeighbours()
    {
        ActiveNeighbours.ForEach(x => x.TemporaryFlag = false);
        foreach (var ent in HolyTools.GameEntities)
        {
            if (!(ent is CharacterEntity)) return;

            var character = ent as CharacterEntity;

            foreach (var neighbour in character.CurrentInteractionTile.InteractionNeighbours.Select(x => x.tEntity))
            {
                var foundCharacter = neighbour.CharacterOnTile();
                if (foundCharacter != null && foundCharacter != character)
                {
                    SignalInteraction(character, foundCharacter);
                }
            }
        }

        ActiveNeighbours.ForEach(x =>
        {
            if (!x.TemporaryFlag)
            {
                InteractionFinished(x.EntityA, x.EntityB);
            }
        });
        ActiveNeighbours.RemoveAll(x => x.TemporaryFlag == false);
    }

    void SignalInteraction(CharacterEntity chA, CharacterEntity chB)
    {
        var neighbourPair = ActiveNeighbours.FirstOrDefault(x => (x.EntityA == chA && x.EntityB == chB) || (x.EntityA == chB && x.EntityB == chA));
        if (neighbourPair == null)
        {
            neighbourPair = new NeighbourPair()
            {
                EntityA = chA,
                EntityB = chB,
                TemporaryFlag = true
            };
            chA.EnterAttack();
            chB.EnterAttack();

            ActiveNeighbours.Add(neighbourPair);
        }
        else
        {
            neighbourPair.TemporaryFlag = true;
        }
    }

    void InteractionFinished(CharacterEntity chA, CharacterEntity chB)
    {
        chA.VisualizationComponent.SetIdleState();
        chB.VisualizationComponent.SetIdleState();
    }
}

public class NeighbourPair
{
    public CharacterEntity EntityA;
    public CharacterEntity EntityB;
    public bool TemporaryFlag;
}