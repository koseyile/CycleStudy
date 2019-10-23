using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;

namespace BBBB {
    public class Person {
        public string name;
        public List<Item> ownedItems;
        public Body body;
        public Outfit outfit;
        public float balance;

        public Person(string n) {
            name = n;
            ownedItems = new List<Item>();
            body = new Body();
            outfit = new Outfit();
            balance = 500.0f;
        }

        public void BuyItem(Shop shop, float price, Item item) {
            balance -= price;
            shop.Sell(item,price);
            AddItem(item);
            item.owner = this;
            item.forSell = false;
            Debug.Log(name + " has bought the " + item.type + " for " + price + " RMB.");
        }

        public void Gifting(Item item, Person p) {
            RemoveItem(item);
            p.AddItem(item);
        }

        public void EatFood(Food food) {
            Debug.Log(name + " has eaten the " + food + ".");
            RemoveItem(food);
        }

        public void PutOn(Clothing cloth) {
            Debug.Log(name + " has put on the " + cloth + ".");
            outfit.Wear(cloth);
        }

        private void RemoveItem(Item item) {
            ownedItems.Remove(item);
        }

        public void AddItem(Item item) {
            ownedItems.Add(item);
        }
    }

}
