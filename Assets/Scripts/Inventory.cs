using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.InventorySystem {
    public class Inventory {
        private List<Item> itemList;

        /// <summary>
        /// Class constructor.
        /// Initialize the item list.
        /// </summary>
        public Inventory() {
            itemList = new List<Item>();

            AddItem(new Item { itemType = Item.ItemType.Medkit, amount = 1 });
            AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
            AddItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        }

        /// <summary>
        /// Add the specified item to the list.
        /// </summary>
        /// <param name="item">The item to add</param>
        public void AddItem(Item item) {
            itemList.Add(item);
        }

        public List<Item> GetItemList() {
            return itemList;
        }
    }
}