﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugInputEditor.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Slash.Unity.Editor.Common.Inspectors.Diagnostics
{
    using Slash.Unity.Common.Diagnostics;
    using Slash.Unity.Common.Input;

    using UnityEditor;

    using UnityEngine;

    /// <summary>
    ///   Custom editor/inspector of the mono behaviour DebugInput.
    /// </summary>
    [CustomEditor(typeof(DebugInput))]
    public class DebugInputEditor : Editor
    {
        #region Fields

        /// <summary>
        ///   Current inspected behaviour.
        /// </summary>
        private DebugInput instance;

        /// <summary>
        ///   Property fields of the current inspected behaviour.
        /// </summary>
        private PropertyField[] propertyFields;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Called when the inspector gets active.
        /// </summary>
        public void OnEnable()
        {
            this.instance = this.target as DebugInput;
            this.propertyFields = this.instance != null ? ExposeProperties.GetProperties(this.instance) : null;
        }

        /// <summary>
        ///   Called when the inspector GUI should be drawn.
        /// </summary>
        public override void OnInspectorGUI()
        {
            if (this.instance == null)
            {
                return;
            }

            // Draw default inspector.
            this.DrawDefaultInspector();

            // Draw properties.
            ExposeProperties.Expose(this.propertyFields);

            // Draw input information.
            EditorGUILayout.Vector2Field("Screen Dimensions", new Vector2(Screen.width, Screen.height));
            EditorGUILayout.Vector3Field("Mouse Position", Input.mousePosition);
            EditorGUILayout.Vector3Field("GUI Mouse Position", InputUtils.GUIMousePosition);

            // Always update.
            EditorUtility.SetDirty(this.instance);
        }

        #endregion

        #region Methods

        private void OnDisable()
        {
            this.instance = null;
        }

        #endregion
    }
}