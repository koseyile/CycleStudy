using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBB;

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
        BBB.Apple apple = new BBB.Apple("Apple", "Red", 1.0f);
        Debug.Log("Q2: " + apple.name + " " + apple.color + " "  + apple.weight + "斤");

        //Q3 
        BBB.Apple[] applesRed = new BBB.Apple[10];
        CreateApples(ref applesRed, "Red", 0.1f, 1.5f);
        float sum = SumAppleWeight(applesRed);
        Debug.Log("Q3: 10个0.1到1.5斤重的红色苹果的总重量: " + sum + "斤");

        //Q4 实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
        BBB.Apple[] applesG = new BBB.Apple[5];
        CreateApples(ref applesG, "Green", 0.5f, 1.8f);
        BBB.Apple[] applesR = new BBB.Apple[6];
        CreateApples(ref applesR, "Red", 0.2f, 1.2f);
        float greenPrice = 8.0f; //元/斤
        float redPrice = 12.0f;
        float price = CalApplePrice(applesG, greenPrice) + CalApplePrice(applesR, redPrice);
        Debug.Log("Q4: 5个0.5到1.8斤重的绿苹果+6个0.2到1.2斤重的红色苹果的总价钱: " + price +"元");

        //5.白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。
        //淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
        BBB.Primate[] group = new BBB.Primate[4];

        BBB.FavoriteFruit[] bbFruit = new BBB.FavoriteFruit[2];
        bbFruit[0].Name = "Apple";
        bbFruit[1].Name = "Orange";
        group[0] = new BBB.Human("白白", bbFruit);

        BBB.FavoriteFruit[] wwFruit = new BBB.FavoriteFruit[2];
        wwFruit[0].Name = "Apple";
        wwFruit[1].Name = "WaterMelon";
        group[1] = new BBB.Human("巫巫", wwFruit);

        BBB.FavoriteFruit[] ddFruit = new BBB.FavoriteFruit[2];
        ddFruit[0].Name = "Cherry";
        ddFruit[1].Name = "Melon";
        group[2] = new BBB.Human("淡淡", ddFruit);

        BBB.FavoriteFruit[] xxFruit = new BBB.FavoriteFruit[1];
        xxFruit[0].Name = "Banana";
        group[3] = new BBB.Monkey("小小", xxFruit);

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
            if (group[i] is BBB.Human == false) 
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

    void CreateApples(ref BBB.Apple[] aaa, string clr, float min, float max) {
        for (int i = 0; i < aaa.Length; i++)
        {
            aaa[i] = new BBB.Apple("Apple", clr, min, max);
        }
    }

    float SumAppleWeight(BBB.Apple[] apples) {

        float sum = 0f;

        for (int i=0; i<apples.Length; i++) {
            sum += apples[i].weight;
        }
        
        return sum;
    }

    //4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，
    //实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
    float CalApplePrice(BBB.Apple[] apples, float price) {

        return SumAppleWeight(apples) * price;
    }

    //6&7&8
    void PrintFavoriteF(BBB.Primate a, string ini) {

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
