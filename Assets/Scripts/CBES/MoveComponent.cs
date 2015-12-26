
using Slash.ECS.Components;
using Slash.ECS.Inspector.Attributes;
using UnityEngine;

[InspectorComponent]
public class MovementComponent : EntityComponent
{
    #region Constants

    /// <summary>
    ///   Attribute: Maximum speed (in m/s).
    /// </summary>
    public const string AttributeMaxSpeed = "MovementComponent.MaxSpeed";

    /// <summary>
    ///   Attribute default: Maximum speed (in m/s).
    /// </summary>
    public const float DefaultMaxSpeed = 5.0f;

    #endregion

    #region Properties

    /// <summary>
    ///   Maximum speed (in m/s).
    /// </summary>
    [InspectorFloat(AttributeMaxSpeed, Default = DefaultMaxSpeed, Description = "Maximum speed (in m/s).")]
    public float MaxSpeed { get; set; }

    /// <summary>
    ///   Current velocity (in m/s).
    /// </summary>
    public Vector2 Velocity { get; set; }

    #endregion
}