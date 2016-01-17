
using Slash.ECS.Components;
using Slash.ECS.Inspector.Attributes;
using Slash.Math.Algebra.Vectors;
using UnityEngine;

[InspectorComponent]
public class MovementComponent : EntityComponent
{
    //#region Constants

    ///// <summary>
    /////   Attribute: Maximum speed (in m/s).
    ///// </summary>
    //public const string AttributeMaxSpeed = "MovementComponent.MaxSpeed";

    ///// <summary>
    /////   Attribute default: Maximum speed (in m/s).
    ///// </summary>
    //public const float DefaultSpeed = 5.0f;

    //#endregion

    #region Properties

    ///// <summary>
    /////   Maximum speed (in m/s).
    ///// </summary>
    //[InspectorFloat(AttributeMaxSpeed, Default = DefaultSpeed, Description = "Maximum speed (in m/s).")]
    //public float Speed { get; set; }

    /// <summary>
    ///   Current velocity (in m/s).
    /// </summary>
    public Vector3 Destination { get; set; }

    #endregion
}