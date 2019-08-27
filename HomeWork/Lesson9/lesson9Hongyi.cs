using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit
{
    public string color;
    public string name;
    public float weight;

    public Fruit()
    { 
    }

    public Fruit (string c, string n, float w)
    {
        color = c;
        name = n;
        weight = w;
    }
}

public class Apple : Fruit
{ 
    public Apple() 
    { 
    }

    public Apple(string ac, string an, float aw)
    {
        color = ac;
        name = an;
        weight = aw;
    }
}

public class Animal
{
    public string name;
    public string species;
    public Fruit[] favouritefruit;
    public Animal bestfriend;

    public Animal()
    { 
    }

    public void Favouritefruit()
    { 
        foreach (Fruit fruit in favouritefruit)
        {
            Debug.Log(name+"喜欢吃"+fruit.name+"颜色是"+fruit.color);
        }
    }
}



public class Human : Animal
{ 
    public Human (string hm, string sp, Fruit[]ff, Animal bf)
    {
        name = hm;
        species = sp;
        favouritefruit = ff;
        bestfriend = bf;
    }
}

public class Monkey : Animal 
{
    public Monkey (string mk, string sp, Fruit[] ff, Animal bf)
    {
        name = mk;
        species = sp;
        favouritefruit = ff;
        bestfriend = bf;
    }
}


public class lesson9Hongyi : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        //2
        Apple redapple = new Apple("红色", "苹果", 1.0f);
        Debug.Log(redapple.color + redapple.name + redapple.weight + "斤");

        //3
        float allweight = Allapple(10, "红色", 0.1f, 1.5f);
        Debug.Log("十个苹果总重：" + allweight + "斤");

        //4
        float totalprice = Appleprice(5, "绿色", 0.5f, 1.8f, 8.0f) + Appleprice(6, "红色", 0.2f, 1.2f, 12.0f);
        Debug.Log("红绿苹果总价：" + totalprice + "元");

        //5
        Animal[] animals = new Animal[4];
        animals[0] = new Human("白白", "human",new Fruit[] { new Fruit("红色", "苹果", 0.0f), new Fruit("橙色", "桔子", 0.0f) }, null);
        animals[1] = new Human("巫巫", "human",new Fruit[] { new Fruit("红色", "苹果", 0.0f), new Fruit("红色", "西瓜", 0.0f)}, null);
        animals[2] = new Human("淡淡", "human",new Fruit[] { new Fruit("红色", "樱桃", 0.0f), new Fruit("绿色", "哈密瓜", 0.0f) }, null);
        animals[3] = new Monkey("小猴子", "monkey", new Fruit[] { new Fruit("黄色", "香蕉", 0.0f) }, null);

        //6
        for (int i =0;i<animals.Length;i++)
        { 
        if (animals[i].name =="白白")
            {
                animals[i].Favouritefruit();
            }
        }

        //7
        for (int i = 0; i < animals.Length; i++)
        {
            if (animals[i].species != "human")
            {
                animals[i].Favouritefruit();
            }
        }

        //8
        animals[0].bestfriend = animals[1];
        animals[1].bestfriend = animals[2];
        animals[2].bestfriend = animals[3];

        animals[0].bestfriend.bestfriend.bestfriend.Favouritefruit();
    }

    float Allapple(int amount,string applecolor,float minweight,float maxweight)
    {
        Apple[] apples = new Apple[amount];
        float sum = 0.0f;
        for (int i =0; i<apples.Length;i++)
        {
            float randomweight = Random.Range(minweight, maxweight);
            apples[i] = new Apple(applecolor, "苹果",randomweight);
            sum +=randomweight;
        }
        return sum;
    }

    float Appleprice (int amount2,string applecolor2,float minweight2,float maxweight2,float price)
    {
        return Allapple(amount2, applecolor2, minweight2, maxweight2) * price;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
