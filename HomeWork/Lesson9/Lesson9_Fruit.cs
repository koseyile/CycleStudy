using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

public class Apple: Fruit {

    public Apple(string n, string c, float w) : base(n, c, w) {
    }
}



