using Slash.ECS.Components;
using Slash.ECS.Inspector.Attributes;
using UnityEngine;

[InspectorComponent]
public class Character_InputComponent : EntityComponent
{
    #region Properties

    /// <summary>
    ///   Current move directions.
    /// </summary>
    public Vector3 MoveDestination { get; set; }

    #endregion
}