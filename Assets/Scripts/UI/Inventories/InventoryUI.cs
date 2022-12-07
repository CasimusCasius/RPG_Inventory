using RPG.Inventories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.UI.Inventories
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] InventorySlotUI inventorySlotPrefab = null;

        Inventory playerInventory;

        private void Awake()
        {
            playerInventory = Inventory.GetPlayerInventory();
        }
        private void OnEnable()
        {
            playerInventory.inventoryUpdated += Redraw;
        }

        private void Start()
        {
            Redraw();
        }

        private void Redraw()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < playerInventory.GetSize(); i++)
            {
                var itemUI = Instantiate(inventorySlotPrefab, transform);
                itemUI.Setup(playerInventory, i);
            }
        }


    }
}
