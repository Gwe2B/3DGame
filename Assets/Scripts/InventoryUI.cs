using UnityEngine;

namespace Assets.Scripts.Player.InventorySystem {
    public class InventoryUI : MonoBehaviour {
        private const int MAX_X = 3;
        private const float SLOT_SIZE = 55f;
        private const float X_OFFSET = 30f;
        private const float Y_OFFSET = -30f;

        private Inventory inventory;
        private Transform itemSlotContainer;
        private Transform itemSlotTemplate;

        private void Awake() {
            itemSlotContainer = transform.Find("ItemSlotContainer");
            itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        }

        /// <summary>
        /// Inventory mutator.
        /// </summary>
        /// <param name="inventory">The inventory to display</param>
        public void SetInventory(Inventory inventory) {
            this.inventory = inventory;
            RefreshInventoryItems();
        }

        /// <summary>
        /// Update the invetory UI
        /// </summary>
        private void RefreshInventoryItems() {
            int x = 0, y = 0;

            foreach(Item item in inventory.GetItemList()) {
                RectTransform itemSlotRectTransform = 
                    Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(
                    x * SLOT_SIZE + X_OFFSET,
                    y * SLOT_SIZE + Y_OFFSET
                );

                x++;

                if(x > MAX_X) {
                    x = 0;
                    y++;
                }
            }
        }
    }
}
