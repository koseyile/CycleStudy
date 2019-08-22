using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9HWbaibai : MonoBehaviour
{
    /*
     * 习题
    1. 声明一个水果类，具有如下成员：颜色，名称，重量。
    2. 声明一个苹果类继承自水果类，实例化一个1斤重的红色苹果。
    3. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
    4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，
    实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
    5. 白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。
    淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
    6. 遍历数组，打印出白白喜欢吃的水果的名称和颜色。
    7. 遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。
    8. 已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，
    打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色。
     */

    // Start is called before the first frame update
    void Start()
    {
        //Q2
        Apple apple = new Apple("Apple", "Red", 1.0f);
        Debug.Log("Q2: " + apple.name + " " + apple.color + " "  + apple.weight + "斤");

        //Q3 
        float sum = SumApples("Red", 10, 0.1f, 1.5f);
        Debug.Log("Q3: 10个0.1到1.5斤重的红色苹果的总重量: " + sum + "斤");

        //Q4 实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
        float greenPrice = 8.0f; //元/斤
        float redPrice = 12.0f;
        float price = CalApplePrice("Green", 5, 0.5f, 1.8f, greenPrice) + CalApplePrice("Red", 6, 0.2f, 1.2f, redPrice);
        Debug.Log("Q4: 5个0.5到1.8斤重的绿苹果+6个0.2到1.2斤重的红色苹果的总价钱: " + price +"元");

        //5.白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。
        //淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
        Primate[] group = new Primate[4];

        FavoriteFruit[] bbFruit = new FavoriteFruit[2];
        bbFruit[0].Name = "Apple";
        bbFruit[1].Name = "Orange";
        group[0] = new Human("白白", bbFruit);

        FavoriteFruit[] wwFruit = new FavoriteFruit[2];
        wwFruit[0].Name = "Apple";
        wwFruit[1].Name = "WaterMelon";
        group[1] = new Human("巫巫", wwFruit);

        FavoriteFruit[] ddFruit = new FavoriteFruit[2];
        ddFruit[0].Name = "Cherry";
        ddFruit[1].Name = "Melon";
        group[2] = new Human("淡淡", ddFruit);

        FavoriteFruit[] xxFruit = new FavoriteFruit[1];
        xxFruit[0].Name = "Banana";
        group[3] = new Monkey("小小", xxFruit);

        //Q6 遍历数组，打印出白白喜欢吃的水果的名称和颜色。
        for (int i = 0; i < group.Length; i++)
        {
            if (group[i].name == "白白") {
                PrintFavoriteF(group[i], "白白");
            }
        }

        //Q7 遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。
        for (int i = 0; i < group.Length; i++)
        {
            if (group[i] is Human == false) 
            {
                PrintFavoriteF(group[i], group[i].name);
            }
        }

        //Q8 已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，
        //打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色。
        group[0].bestF = group[1];
        group[1].bestF = group[2];
        group[2].bestF = group[3];
        group[3].bestF = group[0];

        PrintFavoriteF(group[0].bestF.bestF.bestF, "白白的好朋友的好朋友的好朋友");
       
    }



    //3. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
    float SumApples(string clr, int amount, float min, float max) {

        float sum = 0f;

        Apple[] Apples = new Apple[amount];

        for (int i=0; i<Apples.Length; i++) {
            float x = Random.Range(min,max);
            Apples[i] = new Apple("Apple", clr, x);
            sum = +x;
        }
        
        return sum;
    }

    //4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，
    //实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
    float CalApplePrice(string color, int amount, float min, float max, float price) {

        return SumApples(color, amount, min, max) * price;
    }

    //6&7&8
    void PrintFavoriteF(Primate a, string ini) {

        string p = ini + "喜欢吃的水果: ";

        for (int j = 0; j < a.favorFruit.Length; j++)
        {

            if (a.favorFruit[j].Name != null)
            {
                p += a.favorFruit[j].Name;
            }

            if (a.favorFruit[j].Color != null)
            {
                p += " " + a.favorFruit[j].Color;
            }

            if (j != (a.favorFruit.Length - 1))
            {
                p += ", ";
            }
        }

        Debug.Log(p);

    }


}
