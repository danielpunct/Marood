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

        this.EventManager.RegisterListener(InputAction.SetDestination, this.OnNewDestination);

        this.inputEntities = new CompoundEntities<CharacterInputEntity>(this.EntityManager);
    }

    #endregion

    #region Methods

    //private static Vector2I GetDirection(MoveDirection moveDirections)
    //{
    //    var direction = new Vector2I();
    //    if (moveDirections.IsOptionSet(MoveDirection.Forward))
    //    {
    //        direction.Y += 1;
    //    }
    //    if (moveDirections.IsOptionSet(MoveDirection.Backward))
    //    {
    //        direction.Y -= 1;
    //    }
    //    if (moveDirections.IsOptionSet(MoveDirection.Right))
    //    {
    //        direction.X += 1;
    //    }
    //    if (moveDirections.IsOptionSet(MoveDirection.Left))
    //    {
    //        direction.X -= 1;
    //    }
    //    return direction;
    //}

    private void OnNewDestination(GameEvent e)
    {
        var data = (DestinationData)e.EventData;

        var inputEntity = this.inputEntities.GetEntity(data.EntityId);
        if (inputEntity == null)
        {
            return;
        }

        // Adjust move direction.
        //if (data.Enable)
        //{
           // inputEntity.Input.MoveDestination = data.Destination;
       // }
       // else
        //{
            //inputEntity.Input.MoveDirections =
            //    (MoveDirection)
            //        inputEntity.Input.MoveDirections.AndComplementOption(data.Direction, typeof(MoveDirection));
       // }

        // Adjust velocity.
        inputEntity.Movement.Velocity = new Vector2F(0.5f, 0.5f);
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