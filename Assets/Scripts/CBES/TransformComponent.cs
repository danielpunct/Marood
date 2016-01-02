using Slash.ECS.Components;
using Slash.ECS.Inspector.Attributes;
using Slash.Math.Algebra.Vectors;

[InspectorComponent]
public class TransformComponent : EntityComponent
{
    #region Constants

    /// <summary>
    ///   Attribute: Position.
    /// </summary>
    public const string AttributePosition = "TransformComponent.Position";

    #endregion

    #region Properties

    /// <summary>
    ///   Position.
    /// </summary>
    [InspectorVector(AttributePosition, Description = "Position.")]
    public Vector2F Position { get; set; }

    #endregion
}