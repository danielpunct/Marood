using Slash.Unity.Common.ECS;
using Slash.Unity.Common.Utils;
using UnityEngine;

public class VisualizationBehaviour : EntityComponentBehaviour<VisualizationComponent>
{
    #region Methods

    protected override void Start()
    {
        base.Start();

        this.CreateVisualization();
    }

    public void CreateVisualization()
    {
        if (this.Component == null || string.IsNullOrEmpty(this.Component.Prefab))
        {
            return;
        }

        // Create prefab.
        var visualization = this.gameObject.AddChild(Resources.Load<GameObject>(this.Component.Prefab));
        visualization.name = "Visualization";
    }

    #endregion

    void Update()
    {
        int gg = 0;
    }
}