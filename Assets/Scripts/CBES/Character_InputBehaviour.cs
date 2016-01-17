using UnityEngine;
using Slash.Unity.Common.ECS;
using System.Collections.Generic;

public class Character_InputBehaviour : EntityComponentBehaviour<Character_InputComponent>
{
    public void StartMovingOnGrid(List<Tile> path)
    {
        CharacterMovement.instance.StartMoving(path);
    }

    public void UpdateDestination(Vector3 destination)
    {
        this.Entity.Game.EventManager.QueueEvent(
           InputAction.MoveTowards,
           new MoveData() { EntityId = this.Entity.EntityId, Destination = destination });
    }
}
