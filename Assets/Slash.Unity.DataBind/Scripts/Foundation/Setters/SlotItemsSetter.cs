// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SlotItemsSetter.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Slash.Unity.DataBind.Foundation.Setters
{
    using System;
    using System.Linq;

    using UnityEngine;
    
    /// <summary>
    ///   Adds items under specified fixed slots.
    /// </summary>
    [AddComponentMenu("Data Bind/Foundation/Setters/[DB] Slot Items Setter")]
    public class SlotItemsSetter : GameObjectItemsSetter<MonoBehaviour>
    {
        #region Fields

        /// <summary>
        ///   Indicates if slots that don't hold an item should be hidden.
        /// </summary>
        [Tooltip("Indicates if slots that don't hold an item should be hidden.")]
        public bool HideEmptySlots;

        /// <summary>
        ///   Indicates if items are shifted to higher slots when an item in the middle of the collection is removed.
        /// </summary>
        [Tooltip(
            "Indicates if items are shifted to higher slots when an item in the middle of the collection is removed.")]
        public bool ShiftItemsOnRemove;

        /// <summary>
        ///   Slots to add items to.
        /// </summary>
        public Transform[] Slots;

        #endregion

        #region Methods

        protected override void Awake()
        {
            base.Awake();

            if (this.HideEmptySlots)
            {
                // Hide slots.
                foreach (var slot in this.Slots)
                {
                    slot.gameObject.SetActive(false);
                }
            }
        }

        protected override Transform GetParent(object itemContext)
        {
            // Get empty slot.
            var slotTransform = this.GetEmptySlot();
            if (slotTransform == null)
            {
                Debug.LogWarning("No empty slot remaining, won't create object for item", this);
                return null;
            }

            return slotTransform;
        }

        protected override void OnItemCreated(object itemContext, GameObject itemObject)
        {
            var itemSlot = itemObject.transform.parent;
            if (itemSlot == null)
            {
                return;
            }

            this.SetSlotItem(itemSlot, itemObject);
        }

        protected override void OnItemDestroyed(object itemContext, GameObject itemObject)
        {
            var itemSlot = itemObject.transform.parent;
            if (itemSlot == null)
            {
                return;
            }

            if (this.ShiftItemsOnRemove)
            {
                // Reparent items in lower slots.
                var itemSlotIndex = Array.IndexOf(this.Slots, itemSlot);
                if (itemSlotIndex >= 0)
                {
                    var itemGameObjects = this.ItemGameObjects.ToList();
                    for (var slotIndex = itemSlotIndex; slotIndex < this.Slots.Length; slotIndex++)
                    {
                        var slot = this.Slots[slotIndex];
                        var itemGameObject = slotIndex < itemGameObjects.Count ? itemGameObjects[slotIndex] : null;
                        if (itemGameObject != null)
                        {
                            this.SetSlotItem(slot, itemGameObject);
                        }
                        else
                        {
                            this.ClearSlot(slot);
                        }
                    }
                }
            }
            else
            {
                this.ClearSlot(itemSlot);
            }
        }

        private void ClearSlot(Transform slot)
        {
            if (this.HideEmptySlots)
            {
                // Deactivate parent of item.
                slot.gameObject.SetActive(false);
            }
        }

        private Transform GetEmptySlot()
        {
            var itemGameObjects = this.ItemGameObjects.ToList();

            // Get first slot where no item was placed under.
            return
                this.Slots.FirstOrDefault(
                    slot => !itemGameObjects.Any(itemGameObject => itemGameObject.transform.parent == slot));
        }

        private void SetSlotItem(Transform slot, GameObject itemGameObject)
        {
            if (this.HideEmptySlots)
            {
                // Activate parent of item.
                slot.gameObject.SetActive(true);
            }

            itemGameObject.transform.SetParent(slot, false);
        }

        #endregion
    }
}