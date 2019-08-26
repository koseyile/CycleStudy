using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson9zz : MonoBehaviour
{
    //   习题
    //1. 声明一个水果类，具有如下成员：颜色，名称，重量。
    //2. 声明一个苹果类继承自水果类，实例化一个1斤重的红色苹果。
    //3. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
    //4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
    //5. 白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
    //6. 遍历数组，打印出白白喜欢吃的水果的名称和颜色。
    //7. 遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。
    //8. 已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色。
    // Start is called before the first frame update

    float Sumapple(string C,float Wmax,float Wmin,int Num)
    {
        float sum = 0.0f;
        Apple[] apples = new Apple[Num]; 
        for(int i = 0; i < apples.Length; i++)
        {
            float x = Random.Range(Wmin, Wmax);
            sum += x;
        }
        return sum;
    }

    float SumapplePrice(string C,float Wmax,float Wmin,int Num,float Price)
    {
        return Sumapple(C, Wmax,  Wmin, Num) * Price;
    }

    string Fruitname(Fruit[] fruits)
    {
        string nf = "";
        for(int f = 0; f < fruits.Length; f++)
        {
            nf += fruits[f].Name;
        }
        return nf;
    }

    void Start()
    {

        //2. 声明一个苹果类继承自水果类，实例化一个1斤重的红色苹果。
        Apple apple = new Apple("red", "apple", 1.0f);


        //3. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
        float sum = Sumapple("red", 1.5f, 0.1f, 10);
        Debug.Log("十个随机苹果的总重量是：" + sum + "斤");


        //4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
        float Greenprice = 8.0f;
        float Redprice = 12.0f;
        float Totalprice = Sumapple("green", 1.8f, 0.5f, 5) * 8.0f + Sumapple("red", 1.2f, 0.2f, 6) * 12.0f;
        Debug.Log("随机的红苹果和绿苹果们总价:" + Totalprice + "元");


        //5. 白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
        Life[] life = new Life[4];

        Fruit[] baibaifF = new Fruit[2];
        baibaifF[0] =new Fruit("apple");
        baibaifF[1] = new Fruit("orange");
        life[0] = new Human("baibai", baibaifF);

        Fruit[] wuwufF = new Fruit[2];
        wuwufF[0] = new Fruit("apple");
        wuwufF[1] = new Fruit("waterlemon");
        life[1] = new Human("wuwu", wuwufF);

        Fruit[] dandanfF = new Fruit[2];
        dandanfF[0] = new Fruit("cherry");
        dandanfF[1] = new Fruit("hami");
        life[2] = new Human("dandan", dandanfF);

        Fruit[] monkeyfF = new Fruit[1];
        monkeyfF[0] = new Fruit("banana");
        life[3] = new Monkey("小猴子", monkeyfF);


        //6. 遍历数组，打印出白白喜欢吃的水果的名称和颜色。
        for (int i = 0; i < life.Length; i++)
        {
            if (life[i].Name == "baibai")
            {
                Debug.Log("baibai喜欢吃的水果是:"+Fruitname(life[i].favoriteFruits));
            }
        }

        //7. 遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。
        for (int i = 0; i < life.Length; i++)
        {
            if (life[i] is Human == false)
            {
                Debug.Log("非人类喜欢的水果是:" + Fruitname(life[i].favoriteFruits));
            }
        }

        //8. 已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色。
        life[0].bestfriends = life[1];
        life[1].bestfriends = life[2];
        life[2].bestfriends = life[3];
        life[3].bestfriends = life[0];

        Fruit[] fruitlastfriend = life[0].bestfriends.bestfriends.bestfriends.favoriteFruits;
        Debug.Log("白白的最后的那位好朋友喜欢的水果是:" + Fruitname(fruitlastfriend));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
