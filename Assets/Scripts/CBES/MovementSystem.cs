using Slash.Collections.AttributeTables;
using Slash.ECS.Systems;

[GameSystem]
public class MovementSystem : GameSystem
{
    #region Fields

    private CompoundEntities<MovementEntity> movementEntities;

    #endregion

    #region Public Methods and Operators

    public override void Init(IAttributeTable configuration)
    {
        base.Init(configuration);

        this.movementEntities = new CompoundEntities<MovementEntity>(this.EntityManager);
    }

    public override void Update(float dt)
    {
        foreach (var movementEntity in this.movementEntities)
        {
            // Update position.
            movementEntity.Transform.Position += movementEntity.Movement.Velocity * dt;
        }
    }

    #endregion

    private class MovementEntity
    {
        #region Fields

        [CompoundComponent]
        public MovementComponent Movement;

        [CompoundComponent]
        public TransformComponent Transform;

        #endregion
    }
}