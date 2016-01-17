using Slash.ECS.Components;
using Slash.ECS.Inspector.Attributes;
using Slash.Math.Algebra.Vectors;
using UnityEngine;

[InspectorComponent]
public class TransformComponent : EntityComponent
{
    #region Constants

    /// <summary>
    ///   Attribute: Destination.
    /// </summary>
    public const string AttributePosition = "TransformComponent.Destination";

    #endregion

    #region Properties

    /// <summary>
    ///   Destination.
    /// </summary>
    [InspectorVector(AttributePosition, Description = "Destination.")]
    public Vector3 Destination { get; set; }

    #endregion
}