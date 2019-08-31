using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit
{
    public string Color;
    public string Name;
    public float Weight;

    public Fruit(string C,string N,float W)
    {
        Color = C;
        Name = N;
        Weight = W;
    }

    public Fruit(string n)
    {
        Name = n;
    }
}

public class Apple : Fruit
{
    public Apple(string C,string N,float W):base(C, N, W)
    {

    }
}



public class Life
{
    public string Name;
    public Life bestfriends;
    public Fruit[] favoriteFruits;

    public Life(string N, Fruit[] fF)
    {
        Name = N;
        favoriteFruits = fF;
    }
    public Life(string n)
    {
        Name = n;
    }
}

public class Human : Life
{
    public Human(string N, Fruit[] fF) : base(N, fF)
    {

    }
    public Human(string n):base(n)
    {

    }
}

public class Monkey : Life
{
    public Monkey(string N, Fruit[] fF) : base(N, fF)
    {

    }
    public Monkey(string n):base(n)
    {

    }
}

public class Lesson9zz_fruits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
