using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBB {

    public class Fruit
    {
        public string name;
        public string color;
        public float weight; // unit: 斤

        public Fruit(string n, string c, float w)
        {
            name = n;
            color = c;
            weight = w;
        }

        public Fruit(string n, string c, float min, float max)
        {
            name = n;
            color = c;
            weight = Random.Range(min, max); 
        }

    }

    public class Apple : Fruit
    {

        public Apple(string n, string c, float w) : base(n, c, w)
        {
        }

        public Apple(string n, string c, float min, float max) : base(n, c, min, max)
        {
        }
    }
}




