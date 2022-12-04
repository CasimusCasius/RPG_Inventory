using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory.UI
{
    public class ShowHideUI : MonoBehaviour
    {
        [SerializeField] KeyCode showHideKey = KeyCode.I;
        [SerializeField] GameObject objectToHide = null;

        private void Start()
        {
            objectToHide.SetActive(false);
        }
        void Update()
        {
           if(Input.GetKeyDown(showHideKey))
            {
                ShowHide();
            }

        }

        private void ShowHide()
        {
            objectToHide.SetActive(!objectToHide.activeSelf);
        }
    }
}
