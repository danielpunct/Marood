using Slash.Collections.AttributeTables;
using Slash.ECS.Blueprints;
using Slash.ECS.Events;
using Slash.ECS.Systems;
using System;
using System.Collections.Generic;

[GameSystem]
public class LevelSystem : GameSystem
{
    public override void Init(IAttributeTable configuration)
    {
        base.Init(configuration);

        this.EventManager.RegisterListener(FrameworkEvent.GameStarted, this.OnGameStarted);
    }

    private void OnGameStarted(GameEvent e)
    {
        this.CreatePlayerCharacter();
    }

    private void CreatePlayerCharacter()
    {
        var playerBlueprint = new Blueprint
        {
            ComponentTypes =
                new List<Type>() {
                    typeof(TransformComponent),
                    typeof(MovementComponent),
                    typeof(Character_InputComponent),
                    typeof(VisualizationComponent)},
            AttributeTable = new AttributeTable() { { VisualizationComponent.AttributePrefab, "Character" } }

        };

        // Create player entity.
        this.EntityManager.CreateEntity(playerBlueprint);
    }
}