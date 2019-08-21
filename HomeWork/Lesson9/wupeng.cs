using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wupeng : MonoBehaviour
{

    Apple apple;
    Apple[] apples;
    Apple[] redApples;
    Apple[] greenApples;



    void Start ()
    {
        int[] a = new int[1] { 1 };

        //02.声明一个苹果类继承自水果类，实例化一个1斤重的红色苹果
        apple = new Apple("red", "", 1.0f);
        
        //03. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
        apples = InstantiateApples(10, 0.1f, 1.5f, "红色");
        float weight = CaculateWeight(apples);
        Debug.Log("03.总重量" + weight + "kg");
        
        //04. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
        greenApples = InstantiateApples(5, 0.5f, 1.8f, "绿色");
        redApples = InstantiateApples(6, 0.2f, 1.2f, "红色");
        float redmoney = CaculateApplePrice(8.0f, greenApples);
        float greenmoney = CaculateApplePrice(12.0f, redApples);
        Debug.Log("04.总价为" + (redmoney + greenmoney) + "元");
        
        //05.白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
        
        Human baibai = InstantiateAnimal("Human" ,"baibai", new Fruit[] { new Fruit("","苹果", 0.0f), new Fruit("", "橘子", 0.0f) }, null) as Human;
        Human wuwu = InstantiateAnimal("Human", "wuwu", new Fruit[] { new Fruit("", "苹果", 0.0f), new Fruit("", "西瓜", 0.0f) }, null) as Human;
        Human dandan = InstantiateAnimal("Human", "dandan", new Fruit[] { new Fruit("", "樱桃", 0.0f), new Fruit("", "哈密瓜", 0.0f) }, null) as Human;
        Monkey monkey = InstantiateAnimal("Monkey", "monmon", new Fruit[] { new Fruit("", "香蕉", 0.0f) }, null) as Monkey;

        Animal[] animals = new Animal[4];

        Debug.Log(animals.Length);
        ////animals = new Animal[4];  这里出错了，一开始我在外部没有new实例化，在内部实例化
        //animals[0] = baibai;
        //animals[1] = wuwu;
        //animals[2] = dandan;
        //animals[3] = monkey;

        //06. 遍历数组，打印出白白喜欢吃的水果的名称和颜色。
        Debug.Log("06:");
        for (int i = 0; i < animals.Length; i ++)
        {
            Debug.Log(1);
            //if (animals[i].name == "baibai")
            //{
            //    animals[i].SayMyFavouriteFruit();
            //}
        }

        //07.遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。
        Debug.Log("07:");
        for (int i = 0; i < animals.Length; i++)
        {

            if (animals[i].type != "Human")
            {
                animals[i].SayMyFavouriteFruit();
            }
        }

        //08.已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色。
        baibai.friend = wuwu;
        wuwu.friend = dandan;
        dandan.friend = monkey;
        monkey.friend = baibai;

        Debug.Log("08:");

        baibai.friend.friend.friend.SayMyFavouriteFruit();
    }


    public Apple[] InstantiateApples(int num, float minWeight, float maxHeight, string color)
    {
        Apple[] apples = new Apple[num];// apples的引用在stack上，它的内容（10个Apple变量）是在heap上吗？10个apple变量都是引用类型，每一个apple的内容是在heap中，他们的引用也在heap中吗？

        for (int i = 0; i < apples.Length; i++)
        {
            apples[i] = new Apple(color, "苹果", Random.Range(minWeight, maxHeight));
        }

        Debug.Log("随机生成" + num + "个苹果");

        return apples;
    }

    float CaculateWeight(Apple[] apples)
    {
        float sum = 0.0f;
        if (apples != null)
        {
            for (int i = 0; i < apples.Length; i++)
            {
                sum += apples[i].weight;
            }
            return sum;
        }

        Debug.LogError("无法计算苹果重量，传入苹果为空");
        return 0.0f;
    }

    float CaculateApplePrice(float price, Apple[] apples)
    {
        float sum = 0.0f;

        if (apples != null)
        {
            for (int i = 0; i < apples.Length; i++)
            {
                sum += apples[i].weight * price;
            }
            return sum;
        }

        Debug.LogError("无法计算苹果价格，传入苹果为空");

        return sum;
    }

    Animal InstantiateAnimal(string type ,string name, Fruit[] favrourite, Animal friend)
    {
        Animal animal = new Animal();
        animal.type = type;
        animal.name = name;
        animal.favouriteFruits = favrourite;
        animal.friend = friend;

        return animal;
    }
    
}


//相关类

public class Fruit
{
    public string color;
    public string name;
    public float weight;

    public Fruit()
    {
    }

    public Fruit(string c, string n, float w)
    {
        color = c;
        name = n;
        weight = w;
    }
}

public class Apple : Fruit
{
    public Apple(string c, string n, float w) : base()
    {
        color = c;
        name = n;
        weight = w;
    }
}

public class Animal
{
    public Fruit[] favouriteFruits;
    public string name;
    public Animal friend;
    public string type;

    public void SayMyFavouriteFruit()
    {
        Debug.Log("我叫" + name);
        foreach (Fruit f in favouriteFruits)
        {
            Debug.Log(", 我喜欢吃" + f.name + "颜色是" + f.color);
        }
    }
}

public class Human : Animal
{

}
public class Monkey : Animal
{

}




