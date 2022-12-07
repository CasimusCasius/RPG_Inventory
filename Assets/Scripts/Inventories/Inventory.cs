
using RPG.Saving;
using System;
using UnityEngine;

namespace RPG.Inventories
{
    public class Inventory : MonoBehaviour, ISaveable
    {
        public event Action inventoryUpdated;

        [Tooltip("Allowed size")]
        [SerializeField] int invetorySize = 16;

        InventoryItem[] slots;

        public static Inventory GetPlayerInventory()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            return player.GetComponent<Inventory>();
        }

        private void Awake()
        {
            slots = new InventoryItem[invetorySize];
            slots[0] = InventoryItem.GetFromID("71e73607-4bac-4e42-b7d6-5e6f91e92dc4");
            slots[1] = InventoryItem.GetFromID("0aa7c8b8-4796-42aa-89d0-9d100ea67d7b");
        }


        public bool HasSpaceFor(InventoryItem item)
        {
            return FindSlot(item) >= 0;
        }

        public int GetSize() => slots.Length;
        public bool AddToFirstEmptySlot(InventoryItem item)
        {
            int i = FindSlot(item);
            if (i < 0) return false;

            slots[i] = item;
            inventoryUpdated?.Invoke();
            return true;

        }
        public bool HasItem(InventoryItem item)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (object.ReferenceEquals(slots[i], item)) return true;
            }
            return false;
        }

        public InventoryItem GetItemInSlot(int slot) => slots[slot];
        public void RemoveFromSlot(int slot)
        {
            slots[slot] = null;
            inventoryUpdated?.Invoke();
        }
        public bool AddItemToSlot(int slot, InventoryItem item)
        {
            if (slots[slot] != null) return AddToFirstEmptySlot(item);
            slots[slot] = item;
            inventoryUpdated?.Invoke();
            return true;
        }

        private int FindSlot(InventoryItem item)
        {
            return FindEmptySlot();
        }

        private int FindEmptySlot()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == null) return i;
            }
            return -1;
        }

        public object CaptureState()
        {
            var slotString = new String[invetorySize];
            for (int i = 0; i < invetorySize; i++)
            {
                if (slots[i] != null) slotString[i] = slots[i].GetItemID();
            }
            return slotString;
        }

        public void RestoreState(object state)
        {
            var slotString = (string[])state;
            for (int i = 0; i < invetorySize; i++)
            {
                slots[i] = InventoryItem.GetFromID(slotString[i]);
            }
            inventoryUpdated?.Invoke();
        }

    }
}
