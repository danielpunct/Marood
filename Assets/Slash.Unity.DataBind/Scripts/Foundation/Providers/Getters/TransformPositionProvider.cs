namespace Slash.Unity.DataBind.Foundation.Providers.Getters
{
    using Slash.Unity.DataBind.Core.Presentation;

    using UnityEngine;

    /// <summary>
    ///   Provides the position of the target transform.
    /// </summary>
    [AddComponentMenu("Data Bind/Foundation/Getters/[DB] Transform Position Provider")]
    public class TransformPositionProvider : DataProvider
    {
        #region Properties

        public override object Value
        {
            get
            {
                return this.transform.position;
            }
        }

        #endregion

        #region Methods

        protected override void UpdateValue()
        {
            this.OnValueChanged(this.Value);
        }

        #endregion
    }
}