﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Collection.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Slash.Unity.DataBind.Core.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///   Collection with events to monitor if an item was added/removed.
    /// </summary>
    public abstract class Collection : IEnumerable
    {
        #region Delegates

        /// <summary>
        ///   Delegate for Cleared event.
        /// </summary>
        public delegate void ClearedDelegate();

        /// <summary>
        ///   Delegate for ItemAdded event.
        /// </summary>
        /// <param name="item">Item which was added.</param>
        public delegate void ItemAddedDelegate(object item);

        /// <summary>
        ///   Delegate for ItemRemoved event.
        /// </summary>
        /// <param name="item">Item which was removed.</param>
        public delegate void ItemRemovedDelegate(object item);

        #endregion

        #region Events

        /// <summary>
        ///   Called when an item was added.
        /// </summary>
        public event ItemAddedDelegate ItemAdded;

        /// <summary>
        ///   Called when an item was removed.
        /// </summary>
        public event ItemRemovedDelegate ItemRemoved;

        /// <summary>
        ///   Called when the collection was cleared.
        /// </summary>
        public event ClearedDelegate Cleared;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Returns the enumerator of the collection.
        /// </summary>
        /// <returns>Enumerator of the collection.</returns>
        public abstract IEnumerator GetEnumerator();

        #endregion

        #region Methods

        /// <summary>
        ///   Called when the collection was cleared.
        /// </summary>
        protected void OnCleared()
        {
            var handler = this.Cleared;
            if (handler != null)
            {
                handler();
            }
        }

        /// <summary>
        ///   Called when an item was added.
        /// </summary>
        /// <param name="item">Item which was added.</param>
        protected void OnItemAdded(object item)
        {
            var handler = this.ItemAdded;
            if (handler != null)
            {
                handler(item);
            }
        }

        /// <summary>
        ///   Called when an item was removed.
        /// </summary>
        /// <param name="item">Item which was removed.</param>
        protected void OnItemRemoved(object item)
        {
            var handler = this.ItemRemoved;
            if (handler != null)
            {
                handler(item);
            }
        }

        #endregion
    }

    /// <summary>
    ///   Generic collection with events to monitor when an item was added/removed.
    /// </summary>
    /// <typeparam name="T">Type of items in the collection.</typeparam>
    public sealed class Collection<T> : Collection, ICollection<T>
    {
        #region Fields

        private readonly List<object> items = new List<object>();

        #endregion

        #region Constructors and Destructors

        public Collection(IEnumerable<T> items)
        {
            this.items = new List<object>(items.Cast<object>());
        }

        public Collection()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Number of items in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        /// <summary>
        ///   Indicates if the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                return (T)this.items[index];
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Adds the specified item to the collection.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void Add(T item)
        {
            this.items.Add(item);
            this.OnItemAdded(item);
        }

        /// <summary>
        ///   Clears the collection.
        /// </summary>
        public void Clear()
        {
            if (this.items.Count == 0)
            {
                return;
            }
            this.items.Clear();
            this.OnCleared();
        }

        /// <summary>
        ///   Indicates if the collection contains the specified item.
        /// </summary>
        /// <param name="item">Item to check.</param>
        /// <returns>True if the specified item exists in the collection; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        /// <summary>
        ///   Copies the collection to the specified index in the specified array.
        /// </summary>
        /// <param name="array">Array to copy this collection to.</param>
        /// <param name="arrayIndex">Array index to start to put copies in the array.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this.items)
            {
                array[arrayIndex++] = (T)item;
            }
        }

        public override IEnumerator GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return this.items.IndexOf(item);
        }

        /// <summary>
        ///   Removes the specified item from the collection.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <returns>True if the item was removed; false, if it didn't exist in the collection.</returns>
        public bool Remove(T item)
        {
            if (!this.items.Remove(item))
            {
                return false;
            }

            this.OnItemRemoved(item);

            return true;
        }

        public void RemoveAt(int index)
        {
            var item = this.items[index];
            this.items.RemoveAt(index);

            this.OnItemRemoved(item);
        }

        #endregion

        #region Methods

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.items.Select(item => (T)item).GetEnumerator();
        }

        #endregion
    }
}