using UnityEngine;

namespace Assets.Scripts.Player.InventorySystem {
    public class Item {
        public enum ItemType {
            HealthPotion,
            ManaPotion,
            Coin,
            Medkit,
        }

        public ItemType itemType;
        public int amount;
    }
}
