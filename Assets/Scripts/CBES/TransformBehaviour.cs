
using Slash.Unity.Common.ECS;
using Slash.Unity.Common.Math;

public class TransformBehaviour : EntityComponentBehaviour<TransformComponent>
{
    #region Methods

    protected void Update()
    {
        if (this.Component != null)
        {
            // Update transform.
            this.transform.position = this.Component.Position.ToVector3XY();
        }
    }

    #endregion
}