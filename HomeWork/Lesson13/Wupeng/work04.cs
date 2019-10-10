using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bird { }

public abstract class Food { }

public class SeaFood : Food
{

}

public class LandFood : Food
{

}

public class Apple : LandFood
{

}

public class Shrimp : SeaFood
{

}

public class Sardine : SeaFood
{

}

public class SeaGull : Bird
{
    public float m_speed;
    public string m_wingcolor;

    public void Eat(SeaFood _seafood)
    {

    }
}

public class Swallow : Bird
{
    public float m_speed;
    public string m_wingcolor;

    public void Eat(SeaFood _seafood)
    {

    }
}

public class Ostrich : Bird
{
    public float m_speed;
    public string m_wingcolor;

    public void Eat(LandFood _landfood)
    {

    }
}