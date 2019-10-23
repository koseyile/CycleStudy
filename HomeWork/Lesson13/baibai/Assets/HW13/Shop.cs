using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;

namespace BBBB {

    public abstract class Shop
    {
        public List<BBBB.Item> items;
        public float revenue;

        public Shop() {
            items = new List<Item>();
        }
        private void AddItem(Item item) {
            items.Add(item);
        }

        private void RemoveItem(Item item) {
            items.Remove(item);
        }

        public void Sell(Item item, float p) {
            RemoveItem(item);
            revenue += p;
        }
    }

    public class ClothingShop : Shop {
        public new List<Clothing> items;
        
        public ClothingShop(Clothing cloth, int amount)
        {
            items = new List<Clothing>();
            for (int i = 0; i < amount; i++)
            {
                items.Add(cloth);
            }
        }
    }

    public class FruitShop : Shop
    {
        public new List<Fruits> items;
        
        public FruitShop(Fruits fruits, int amount) {
            items = new List<Fruits>();
            for (int i = 0; i < amount; i++) {
                items.Add(fruits);
            }
        }
    }
}

