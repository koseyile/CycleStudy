using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_Naomi : MonoBehaviour
{
    //1.定义一个学校结构体，包含上述所有数据

    struct SchoolInfo
    {
        public string name;
        public int boy;
        public int girl;
        public int total;
    }

    //2.输入参数为学校结构体，打印小班男女人数各为多少
    //问：什么时候写在函数里，什么时候写在start里？ 函数的输入中，结构体后面的的名称到底是指谁？

    void printboygirl(SchoolInfo[] kindergarten)
    {
        int i = 2;
        string result = kindergarten[i].boy + "\n" + kindergarten[i].girl;
        Debug.Log(result);
    }

    //3.定义一个旅行社结构体，包含所有旅行社信息
    struct travelCost
    {
        public string name;
        public int white;
        public int black;
    }

    //4.编写一个函数，传参为学校结构体和旅行社结构体，求出园长妈妈吃了多少回扣

    void printMoney(travelCost[] japan, SchoolInfo[] kindergarten)
    {
        int a = 0;
        int b = 0;
        for (int i = 0; i < japan.Length; i++)
        {
            a += japan[i].white * kindergarten[i].total;
            b += japan[i].black * kindergarten[i].total;
        }
        Debug.Log(a - b);
    }

    //5.定义武器结构体，包含上述所有武器信息，实例化红光剑和蓝光盾。

    struct Weapon
    {
        public string name;
        public float length;
        public float width;
        public int attack;
        public int defence;
    }

    //6.编写一个函数，传参为红光剑和蓝光盾，求出两个武器的面积之和。
    void addarea(Weapon a,Weapon b)
    {
        float add = a.length * a.width + b.length * b.width;
        Debug.Log(add);
    }

    //7.假设有个坏人血量为1000 ，求出Hank大喊：“红光之力攻击！”后，编写一个函数打印如下数据：坏人剩余血量，蓝光盾的护值。
    void attackred(Weapon a, Weapon b,int c)
    {
        int blood = (c - (a.attack * 2)) / 2;
        int defence = (c - (a.attack * 2)) / 2 + b.defence;
        string result = blood + "\n" + defence;
        Debug.Log(result);
    }

    //8.定义喜翠瓶在每一代的价格结构体
    struct price
    {
        public string generation;
        public int jpy;
    }

    //9.假设喜翠瓶在第四代之后，每年价值翻倍，编写一个函数，传入参数为喜翠瓶价格结构体，填充结构体数据，打印喜翠瓶在每一代人手中的价格。
    void printprice(price[] xc)
    {
        string n = "";
        for (int j = 0; j < xc.Length; j++)
        {
            if (j<=3)
            {
                n += xc[j].jpy + "\n";
            }else
            {
                xc[j].jpy = xc[j - 1].jpy * 2;
                n += xc[j].jpy + "\n";
            }
        }
        Debug.Log(n);
    }

    //10.编写一个函数，传入学校结构体，旅行社结构体及喜翠瓶价格结构体，求出园长妈妈最终的盈亏。
    void PI(SchoolInfo[] kindergarten,travelCost[] japan,price []c)
    {
        int a = 0;
        int b = 0;
        for (int i = 0; i < japan.Length; i++)
        {
            a += japan[i].white * kindergarten[i].total;
            b += japan[i].black * kindergarten[i].total;
        }
        float loss = c[c.Length - 1].jpy * 0.06389f * 0.8f;
        int result = a - b - (int)loss;
        Debug.Log(result);
    }

    void Start()
    {
        //1.定义一个学校结构体，包含上述所有数据
        //问：为什么不能写kindergarten[0].boy + kindergarten[0].girl = 30;
        SchoolInfo[] kindergarten = new SchoolInfo[3];
        kindergarten[0].name = "大班";
        kindergarten[0].total = 30;
        kindergarten[0].boy = kindergarten[0].girl = 15;

        kindergarten[1].name = "中班";
        kindergarten[1].total = 36;
        kindergarten[1].boy = kindergarten[1].girl + 4;
        kindergarten[1].boy = 36 - kindergarten[1].girl;

        kindergarten[2].name = "小班";
        kindergarten[2].total = 42;
        kindergarten[2].boy = kindergarten[0].total - kindergarten[2].girl;

        kindergarten[2].boy = 60 - kindergarten[1].boy - kindergarten[0].boy;
        kindergarten[2].girl = 48 - kindergarten[1].girl - kindergarten[0].girl;

        //2.输入参数为学校结构体，打印小班男女人数各为多少
        printboygirl(kindergarten);

        //3.定义一个旅行社结构体，包含所有旅行社信息
        travelCost[] japan = new travelCost[3];
        japan[0].name = "大班";
        japan[0].white = 2000;
        japan[0].black = 1900;

        japan[1].name = "中班";
        japan[1].white = 2200;
        japan[1].black = 1900;

        japan[2].name = "小班";
        japan[2].white = 2500;
        japan[2].black = 1900;


        //4.编写一个函数，传参为学校结构体和旅行社结构体，求出园长妈妈吃了多少回扣
        printMoney(japan, kindergarten);

        //5.定义武器结构体，包含上述所有武器信息，实例化红光剑和蓝光盾。
        Weapon red;
        Weapon blue;

        red.name = "红光剑";
        red.length = 2.0f;
        red.width = 0.4f;
        red.attack = 80;
        red.defence = 20;

        blue.name = "蓝光盾";
        blue.length = 1.5f;
        blue.width = 1.5f;
        blue.attack = 30;
        blue.defence = 90;

        //6.编写一个函数，传参为红光剑和蓝光盾，求出两个武器的面积之和。
        addarea(red,blue);

        //7.假设有个坏人血量为1000 ，求出Hank大喊：“红光之力攻击！”后，编写一个函数打印如下数据：坏人剩余血量，蓝光盾的护值。
        attackred(red,blue,1000);

        //8.定义喜翠瓶在每一代的价格结构体
        price[] xicui = new price[14];
        xicui[0].generation = "四十万一代";
        xicui[0].jpy = 4000;

        xicui[1].jpy = xicui[0].jpy / 2;
        xicui[2].jpy = xicui[1].jpy * 10;
        xicui[3].jpy = xicui[2].jpy;

        //9.假设喜翠瓶在第四代之后，每年价值翻倍，编写一个函数，传入参数为喜翠瓶价格结构体，填充结构体数据，打印喜翠瓶在每一代人手中的价格.
        printprice(xicui);

        //10.编写一个函数，传入学校结构体，旅行社结构体及喜翠瓶价格结构体，求出园长妈妈最终的盈亏。
        PI(kindergarten, japan, xicui);

    }

}
