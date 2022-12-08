using RPG.Saving;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Inventories
{
    public class ItemDropper : MonoBehaviour, ISaveable
    {
        private List<Pickup> droppedItems = new List<Pickup>();

        public void DropItem(InventoryItem item)
        {
            SpawnPickup(item, GetDropLocation());
        }
        protected virtual Vector3 GetDropLocation()
        {
            return gameObject.transform.position;
        }
        private void SpawnPickup(InventoryItem item, Vector3 spawnLocation)
        {
            if (item == null) return;
            var pickup = item.SpawnPickup(spawnLocation);
            droppedItems.Add(pickup);
        }
        [System.Serializable]
        private struct DropRecord
        {
            public string itemID;
            public SerializableVector3 position;
        }
        // Save/Load
        public object CaptureState()
        {
            RemoveDestroyedDrops();
            DropRecord[] state = new DropRecord[droppedItems.Count];
            for (int i = 0; i < droppedItems.Count; i++)
            {
                state[i].itemID = droppedItems[i].GetItem().GetItemID();
                state[i].position = new SerializableVector3(droppedItems[i].transform.position);

            }
            return state;
        }
        public void RestoreState(object state)
        {

            foreach (var item in (DropRecord[])state)
            {
                var pickupItem = InventoryItem.GetFromID(item.itemID);
                SpawnPickup(pickupItem, item.position.ToVector());
            }
        }
        private void RemoveDestroyedDrops()
        {
            var newList = new List<Pickup>();
            foreach (var item in droppedItems)
            {
                if (item != null) newList.Add(item);
            }
            droppedItems = newList;
        }
    }
}
