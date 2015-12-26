﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContextHolderEditor.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Slash.Unity.DataBind.Editor.Editors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Slash.Unity.DataBind.Core.Data;
    using Slash.Unity.DataBind.Core.Presentation;
    using Slash.Unity.DataBind.Core.Utils;
    using Slash.Unity.DataBind.Editor.Utils;

    using UnityEditor;

    using UnityEngine;

    /// <summary>
    ///   Custom editor for <see cref="ContextHolder" />.
    /// </summary>
    [CustomEditor(typeof(ContextHolder))]
    public class ContextHolderEditor : Editor
    {
        #region Fields

        private readonly string[] contextTypeNames;

        private readonly List<Type> contextTypes;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Constructor.
        /// </summary>
        public ContextHolderEditor()
        {
            this.contextTypes = new List<Type> { null };
            var availableContextTypes =
                ReflectionUtils.FindTypesWithBase<Context>().Where(type => !type.IsAbstract).ToList();
            availableContextTypes.Sort(
                (typeA, typeB) => String.Compare(typeA.FullName, typeB.FullName, StringComparison.Ordinal));
            this.contextTypes.AddRange(availableContextTypes);
            this.contextTypeNames = this.contextTypes.Select(type => type != null ? type.FullName : "None").ToArray();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Unity callback.
        /// </summary>
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var contextHolder = this.target as ContextHolder;
            if (contextHolder == null)
            {
                return;
            }

            EditorGUI.BeginChangeCheck();

            if (!Application.isPlaying)
            {
                // Find all available context classes.
                var contextTypeIndex = this.contextTypes.IndexOf(contextHolder.ContextType);
                var newContextTypeIndex = EditorGUILayout.Popup("Context Type", contextTypeIndex, this.contextTypeNames);
                if (newContextTypeIndex != contextTypeIndex)
                {
                    contextHolder.ContextType = this.contextTypes[newContextTypeIndex];
                }

                // Should a context of the specified type be created at startup?
                contextHolder.CreateContext =
                    EditorGUILayout.Toggle(
                        new GUIContent("Create context?", "Create context on startup?"),
                        contextHolder.CreateContext);
            }
            else
            {
                var context = contextHolder.Context;
                var contextType = context != null ? context.GetType().ToString() : "null";
                EditorGUILayout.LabelField("Context", contextType);

                // Reflect data in context.
                this.DrawContextData(context);

                EditorUtility.SetDirty(contextHolder);
            }

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(contextHolder);
            }
        }

        #endregion

        #region Methods

        private const int MaxLevel = 5;

        private void DrawContextData(object contextObject)
        {
            if (contextObject == null)
            {
                return;
            }

            var context = contextObject as Context;
            if (context != null)
            {
                this.DrawContextData(context, 1);
            }
            else
            {
                EditorGUILayout.TextField("Data", contextObject.ToString());
            }
        }

        private void DrawContextData(Context context, int level)
        {
            var prevIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = level;

            var contextMemberInfos = ContextTypeCache.GetMemberInfos(context.GetType());
            foreach (var contextMemberInfo in contextMemberInfos)
            {
                if (contextMemberInfo.Property != null)
                {
                    var memberValue = contextMemberInfo.Property.GetValue(context, null);
                    this.DrawContextData(contextMemberInfo.Name, memberValue, level);
                }
            }

            EditorGUI.indentLevel = prevIndentLevel;
        }

        private void DrawContextData(string memberName, object memberValue, int level)
        {
            if (level < MaxLevel)
            {
                var context = memberValue as Context;
                if (context != null)
                {
                    EditorGUILayout.LabelField(memberName, EditorStyles.boldLabel);
                    this.DrawContextData(context, level + 1);
                    return;
                }

                var collection = memberValue as Collection;
                if (collection != null)
                {
                    EditorGUILayout.LabelField(memberName, EditorStyles.boldLabel);
                    this.DrawContextData(collection, level + 1);
                    return;
                }
            }

            EditorGUILayout.TextField(memberName, memberValue != null ? memberValue.ToString() : "null");
        }

        private void DrawContextData(Collection collection, int level)
        {
            var prevIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = level;

            var index = 0;
            foreach (var item in collection)
            {
                this.DrawContextData("Item " + index, item, level);
                ++index;
            }

            EditorGUI.indentLevel = prevIndentLevel;
        }

        #endregion
    }
}