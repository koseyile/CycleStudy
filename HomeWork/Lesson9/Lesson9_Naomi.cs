using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lesson9_Naomi : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //2.声明一个苹果类继承自水果类，实例化一个1斤重的红色苹果。
        Apple apple = new Apple("红色", 1.0f);
        Debug.Log("2|" + apple.Name + " " + apple.Color + " " + apple.Weight + "斤");

        //3. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
        float red_sum = ApplesWeight("红色", 10, 0.1f, 1.5f);
        Debug.Log("3|10个0.1到1.5斤重的红色苹果总共" + red_sum + "斤");

        //4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
        float sumprice = ApplesPrice("Green", 5, 0.5f, 1.8f, 8.0f) + ApplesPrice("Red", 6, 0.2f, 1.2f, 12.0f);
        Debug.Log("4|绿苹果和红苹果总价是" + sumprice + "元");

        //5.白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。

        Animal[] animals = new Animal[4];

        animals[0] = new Human("baibai", new Fruit[] { new Fruit("苹果", "红色", 0.0f), new Fruit("橘子", "绿色", 0.0f) }, null);
        animals[1] = new Human("wuwu", new Fruit[] { new Fruit("苹果", "绿色", 0.0f), new Fruit("西瓜", "黄色", 0.0f) }, null);
        animals[2] = new Human("dandan", new Fruit[] { new Fruit("樱桃", "红色", 0.0f), new Fruit("哈密瓜", "绿色", 0.0f) }, null);
        animals[3] = new Monkey("小猴子", new Fruit[] { new Fruit("香蕉", "黄色", 0.0f) }, null);

        //6.遍历数组，打印出白白喜欢吃的水果的名称和颜色。

        for (int i = 0; i < animals.Length; i++)
        {
            string i_fav = animals[i].Name + "喜欢吃";
            if (animals[i].Name == "baibai")
            {
                i_fav += animals[i].GetFavoriteFruits();
                Debug.Log("6|" + i_fav);
            }
        }

        //7.遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。

        for (int i = 0; i < animals.Length; i++)
        {
            string un_fav = animals[i].Name + "喜欢吃";
            if (animals[i].Species != "Human")
            {
                un_fav += animals[i].GetFavoriteFruits();
                Debug.Log("7|" + un_fav);
            }
            
        }

        //8.已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色。
        animals[0].BFF = animals[1];
        animals[1].BFF = animals[2];
        animals[2].BFF = animals[3];
        animals[3].BFF = animals[0];

        string BFF_fav = animals[0].BFF.BFF.BFF.GetFavoriteFruits();

        Debug.Log("8|"+ "白白的好朋友的好朋友的好朋友喜欢吃的水果是" + BFF_fav);
        
    }

    //-----------------------------------函数------------------------------------

    //问：
    //a.为什么这些函数写在这个class外面，就会报错？函数无法在外面独立存在吗？
    //b.之前写的struct都是在这个class里面，是否意味着struct的级别要低于class？（结构是属于类的一种变量？在类外面也无法被独立声明？）


    //3. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
    //问：传参加上ref会报错

    float ApplesWeight(string apple_color, int apple_amount, float amount_min, float weight_max)
    {

        Apple[] apples = new Apple[apple_amount];

        float apples_sum = 0.0f;

        for (int i = 0; i < apples.Length; i++)
        {
            float x = Random.Range(amount_min, weight_max);
            apples[i] = new Apple(apple_color, x);
            apples_sum = +x;
        }

        return apples_sum;
    }

    //4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。

    float ApplesPrice(string cap_color, int cap_amount, float cap_min, float cap_max, float cap_price)
    {
        return ApplesWeight(cap_color, cap_amount, cap_min, cap_max) * cap_price;

    }
}

//----------------------------------------类------------------------------------

//1. 声明一个水果类，具有如下成员：颜色，名称，重量。
public class Fruit
{
    public string Name;
    public string Color;
    public float Weight;

    public Fruit()
    {
    }

    public Fruit(string n, string c, float w)
    {
        Name = n;
        Color = c;
        Weight = w;
    }
}

public class Apple : Fruit
{
    public Apple()
    {

    }

    public Apple(string A_c, float A_w)
    {
        Name = "Apple";
        Color = A_c;
        Weight = A_w;
    }

}

//5. 白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
public class Animal
{
    public string Name;
    public string Species;
    public Fruit[] FavoriteFruits;
    public Animal BFF;

    public Animal()
    {

    }

    public virtual  string GetFavoriteFruits()
    {
        string FavoriteFruitsText = "";
        foreach (Fruit fruit in FavoriteFruits)
        {
            FavoriteFruitsText += (fruit.Color + "的" + fruit.Name + "和");
        }
        FavoriteFruitsText = FavoriteFruitsText.Remove(FavoriteFruitsText.Length - 1);
        return FavoriteFruitsText;
    }
}

public class Human : Animal
{
    public Human(string H_n, Fruit[] H_favorite, Animal H_BFF)
    {
        Species = "Human";
        Name = H_n;
        FavoriteFruits = H_favorite;
        BFF = H_BFF;
    }

    public override string GetFavoriteFruits()
    {
        string FavoriteFruitsText = "";
        foreach (Fruit fruit in FavoriteFruits)
        {
            FavoriteFruitsText += (fruit.Color + "的" + fruit.Name + "和");
        }
        FavoriteFruitsText = FavoriteFruitsText.Remove(FavoriteFruitsText.Length - 1);
        return FavoriteFruitsText;
    }
}

public class Monkey : Animal
{
    public Monkey(string M_n, Fruit[] M_Favorite, Animal M_BFF)
    {
        Species = "Monkey";
        Name = M_n;
        FavoriteFruits = M_Favorite;
        BFF = M_BFF;
    }

    public override string GetFavoriteFruits()
    {
        string FavoriteFruitsText = "";
        foreach (Fruit fruit in FavoriteFruits)
        {
            FavoriteFruitsText += (fruit.Color + "的" + fruit.Name + "和");
        }
        FavoriteFruitsText = FavoriteFruitsText.Remove(FavoriteFruitsText.Length - 1);
        return FavoriteFruitsText;
    }
}



