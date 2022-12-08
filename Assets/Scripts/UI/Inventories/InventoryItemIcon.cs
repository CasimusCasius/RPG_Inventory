using RPG.Inventories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.Inventories
{
    [RequireComponent(typeof(Image))]
    public class InventoryItemIcon : MonoBehaviour
    {
        [SerializeField] GameObject container;
        [SerializeField] TextMeshProUGUI itemNumber;

        public void SetItem(InventoryItem item, int number)
        {
            var iconImage = GetComponent<Image>();
            if (item == null)
            {
                iconImage.enabled = false;
            }
            else
            {

                iconImage.enabled = true;
                iconImage.sprite = item.GetIcon();

                if (number > 1)
                {
                    container.SetActive(true);
                    itemNumber.text = number.ToString();
                }
                else
                {
                    container.SetActive(false);
                }

            }
        }
    }
}
