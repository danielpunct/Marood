using Slash.ECS.Components;
using Slash.ECS.Inspector.Attributes;

[InspectorComponent]
public class VisualizationComponent : EntityComponent
{
    /// <summary>
    ///   Attribute: Prefab to use for visualization
    /// </summary>
    public const string AttributePrefab = "VisualizationComponent.Prefab";

    /// <summary>
    ///   Attribute default: Prefab to use for visualization
    /// </summary>
    public const string DefaultPrefab = null;

    /// <summary>
    ///   Prefab to use for visualization
    /// </summary>
    [InspectorString(AttributePrefab, Default = DefaultPrefab, Description = "Prefab to use for visualization")]
    public string Prefab { get; set; }

}