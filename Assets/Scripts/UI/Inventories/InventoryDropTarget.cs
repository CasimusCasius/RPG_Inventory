using RPG.Inventories;
using RPG.UI.Dragging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.UI.Inventories
{
    public class InventoryDropTarget : MonoBehaviour, IDragDestination<InventoryItem>
    {
        public void AddItems(InventoryItem item, int number)
        {
            var player = GameObject.FindWithTag("Player");
            player.GetComponent<ItemDropper>().DropItem(item);
        }

        public int MaxAcceptable(InventoryItem items)
        {
            return int.MaxValue;
        }
    }
}