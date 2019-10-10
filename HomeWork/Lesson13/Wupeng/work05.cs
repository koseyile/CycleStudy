using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Human { }

public abstract class Goods { }

public class Cloth : Goods { }

public class Fruit : Goods { }

public class Hat : Cloth { }

public class WaterMelon: Fruit { }

public class ClothShop
{
    public Cloth[] cloths;
}
public class FruitShop
{
    public Fruit[] fruits;
}

public class NinNin : Human
{
    void Shopping(Goods _goods) { }
    
    void Give(Human _friend, Goods _good) { }
}

public class ZZ : Human
{
    public Goods m_gift;
    void UseGood() { /*m_gift is used*/}
}

public class WuWu : Human
{
    public Goods m_gift;
    void UseGood() { /*m_gift is used*/}
}

public class BaiBai : Human
{
    public Goods m_gift;
    void UseGood() { /*m_gift is used*/}
}