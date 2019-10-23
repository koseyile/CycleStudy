using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;

namespace BBBB {

    public abstract class Item {
        public string type;
        protected float price;
        public bool forSell;
        public Person owner;

        public Item(string t, float p) {
            this.type = t;
            this.price = p;
            this.forSell = true;
            this.owner = null;
        }

        public void setPrice(float p) {
            this.price = p;
        }

        public float getPrice() {
            return this.price;
        }
    }

    public class Food : Item {
        public Food(string t, float p): base(t,p)
        {
            this.type = t;
            this.price = p;
            this.forSell = true;
            this.owner = null;
        }
    }

    public class Fruits : Food
    {
        public Fruits(string t, float p) : base(t, p)
        {
            this.type = t;
            this.price = p;
            this.forSell = true;
            this.owner = null;
        }
    }

    public class WaterMelon : Fruits
    {
        public WaterMelon(string t, float p) : base(t, p)
        {
            this.type = t;
            this.price = p;
            this.forSell = true;
            this.owner = null;
        }
    }


    public class Clothing : Item
    {
        public string bodyPart;

        public Clothing(string t, float p) : base(t, p)
        {
            this.type = t;
            this.price = p;
            this.forSell = true;
            this.owner = null;
        }
    }

    public class Hat : Clothing
    {

        public Hat(string t, float p) : base(t, p)
        {
            this.type = t;
            this.price = p;
            this.forSell = true;
            this.owner = null;
            this.bodyPart = "Head";
        }
    }

}