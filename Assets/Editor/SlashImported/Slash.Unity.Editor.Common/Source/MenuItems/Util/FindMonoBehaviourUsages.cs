﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindMonoBehaviourUsages.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Slash.Unity.Editor.Common.MenuItems.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using UnityEditor;

    using UnityEngine;

    using Object = UnityEngine.Object;

    /// <summary>
    ///   Finds prefabs who have the specified MonoBehaviour attached.
    /// </summary>
    public class FindMonoBehaviourUsages : EditorWindow
    {
        #region Static Fields

        /// <summary>
        ///   C# type of the script to find usages of.
        /// </summary>
        private static Type monoBehaviourType;

        /// <summary>
        ///   Script asset to find the usages of.
        /// </summary>
        private static MonoScript monoScript;

        /// <summary>
        ///   Prefabs who have the searched script attached.
        /// </summary>
        private static GameObject[] usages;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Shows the Find Mono Behaviour Usages window.
        /// </summary>
        [MenuItem("Slash Games/Util/Find Mono Behaviour Usages")]
        public static void ShowFindMonoBehaviourUsages()
        {
            GetWindow(typeof(FindMonoBehaviourUsages)).Show();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Finds all prefabs who have the searched script attached.
        /// </summary>
        private static void FindUsages()
        {
            IEnumerable<string> assetFolderPaths =
                AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".prefab", StringComparison.Ordinal));

            usages =
                assetFolderPaths.Select(item => AssetDatabase.LoadAssetAtPath(item, typeof(GameObject)))
                                .Cast<GameObject>()
                                .Where(obj => obj != null)
                                .Where(obj => obj.GetComponentsInChildren(monoBehaviourType, true).Length > 0)
                                .ToArray();
        }

        /// <summary>
        ///   Selects the specified prefab in the project window.
        /// </summary>
        /// <param name="prefab">Prefab to select.</param>
        private static void NavigateTo(Object prefab)
        {
            Selection.activeObject = prefab;
            EditorUtility.FocusProjectWindow();
        }

        private void OnGUI()
        {
            const int X = 3;
            const int Height = 20;
            const int Offset = 2;

            int y = 3;
            float width = this.position.width - 2 * X;

            // Show selection field for the user.
            monoScript =
                (MonoScript)
                EditorGUI.ObjectField(
                    new Rect(X, y, width, Height), "Mono Behaviour", monoScript, typeof(MonoScript), false);

            // Show error message if no mono behaviour selected.
            y += Height + Offset;

            if (monoScript == null)
            {
                EditorGUI.LabelField(new Rect(X, y, width, Height), "Missing:", "Select a behaviour first!");
                return;
            }

            if (monoScript.GetClass() == null || !typeof(MonoBehaviour).IsAssignableFrom(monoScript.GetClass()))
            {
                EditorGUI.LabelField(
                    new Rect(X, y, width, Height),
                    "Missing:",
                    string.Format("{0} is no MonoBehaviour.", monoScript.name));
                return;
            }

            // Clear found usages if selection changed.
            if (monoBehaviourType != monoScript.GetClass())
            {
                monoBehaviourType = monoScript.GetClass();
                usages = null;
            }

            // Show Find Usages button.
            if (GUI.Button(new Rect(X, y, width, Height), "Find Prefabs"))
            {
                FindUsages();
            }

            if (usages == null)
            {
                return;
            }

            // Show found usages.
            foreach (GameObject prefab in usages)
            {
                y += Height + Offset;

                EditorGUILayout.BeginHorizontal();

                EditorGUI.LabelField(new Rect(X, y, width / 2, Height), prefab.name);

                if (GUI.Button(new Rect(X + width / 2, y, width / 2, Height), "Navigate To"))
                {
                    NavigateTo(prefab);
                    return;
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        #endregion
    }
}