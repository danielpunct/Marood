using Slash.Collections.AttributeTables;
using Slash.ECS.Events;
using Slash.ECS.Systems;
using Slash.Math.Algebra.Vectors;

[GameSystem]
public class Character_InputSystem : GameSystem
{
    #region Fields
    private CompoundEntities<CharacterInputEntity> inputEntities;

    #endregion

    #region Public Methods and Operators

    public override void Init(IAttributeTable configuration)
    {
        base.Init(configuration);

        this.EventManager.RegisterListener(InputAction.MoveTowards, this.OnGridStartMoving);

        this.inputEntities = new CompoundEntities<CharacterInputEntity>(this.EntityManager);
    }

    #endregion

    #region Methods
    

    private void OnGridStartMoving(GameEvent e)
    {
        var data = (MoveData)e.EventData;

        var inputEntity = this.inputEntities.GetEntity(data.EntityId);
        if (inputEntity == null)
        {
            return;
        }

        // Adjust move direction.
        //if (data.Enable)
        //{
        //  inputEntity.Input.MoveDestination = data.Destination;
        // }
        // else
        //{
        //inputEntity.Input.MoveDirections =
        //    (MoveDirection)
        //        inputEntity.Input.MoveDirections.AndComplementOption(data.Direction, typeof(MoveDirection));
        // }

        // Adjust velocity.
        inputEntity.Movement.Destination = data.Destination;
        //GetDirection(inputEntity.Input.MoveDirections)
         //                               * inputEntity.Movement.MaxSpeed;
    }

    #endregion

    private class CharacterInputEntity
    {
        #region Fields

        //[CompoundComponent]
       // public Tile_InputComponent Input;

        [CompoundComponent]
        public MovementComponent Movement;

        #endregion
    }
}