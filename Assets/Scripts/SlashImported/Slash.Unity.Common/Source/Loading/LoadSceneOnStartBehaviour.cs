﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadSceneOnStartBehaviour.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Slash.Unity.Common.Loading
{
    using UnityEngine;

    /// <summary>
    ///   Loads the specified scene immediately after start.
    /// </summary>
    public class LoadSceneOnStartBehaviour : MonoBehaviour
    {
        #region Fields

        /// <summary>
        ///   Indicates if the scene should be loaded additive to existing one.
        ///   If loaded additive the old scene objects are not removed.
        /// </summary>
        public bool LoadAdditive;

        /// <summary>
        ///   Name of scene to load.
        /// </summary>
        public string SceneName;

        #endregion

        #region Methods

        private void Start()
        {
            if (this.LoadAdditive)
            {
                Application.LoadLevelAdditive(this.SceneName);
            }
            else
            {
                Application.LoadLevel(this.SceneName);
            }
        }

        #endregion
    }
}