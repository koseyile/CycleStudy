using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primate 
{
    public string name;
    public Primate bestF;
    public FavoriteFruit[] favorFruit;

    public Primate(string n, FavoriteFruit[] favF)
    {
        name = n;
        favorFruit = favF;
    }

    public Primate(string n)
    {
        name = n;
    }
}

public struct FavoriteFruit {
    public string Name;
    public string Color;
}

public class Human : Primate
{
    public Human(string n, FavoriteFruit[] favF) : base(n, favF)
    {
    }

    public Human(string n) : base(n)
    {
    }
}

public class Monkey : Primate
{
    public Monkey(string n, FavoriteFruit[] favF) : base(n, favF)
    {
    }

    public Monkey(string n) : base(n)
    {
    }
}

