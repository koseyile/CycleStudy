using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hongyi3 : MonoBehaviour
{



    //1. 请写出求圆面积函数。并使用此函数计算半径为76.3的圆面积。

    /*
    float circle(float r, float p)

    {
        return p * r * r;
    }
       
             
    void Start()
    {
        float r = 76.3f;
        float p = 3.14f;

        float c = circle(r, p);

        Debug.Log(c);
    }
    */



    //2. 请写出求长方体体积函数。并使用此函数计算长43.2,宽54.5, 高为123.9的长方体体积。

    /*
    float cube (float a, float b, float c)
    {
        return a * b * c;
    }


    void Start()
    {
        float a = 43.2f;
        float b = 54.5f;
        float c = 123.9f;


        float d = cube (a, b, c);

        Debug.Log(d);
    }
    */



    //3. 请写出这样的函数，可以求出任意两个整数之间的数字之和，并求出1+2+3+..100=? 及 4+5+6+7+8+..999=?

    /*
    int add (int x, int y)
    {
        return (x+y)*(y-x+1)/2;
    }

    void Start()
    {
        int x1 = 1;
        int y1 = 100;
        int x2 = 4;
        int y2 = 999;

        int a1 = add(x1, y1);
        int a2 = add(x2, y2);

        Debug.Log(a1);
        Debug.Log(a2); 
    }
    */


    //4. 请写一个日币转换人民币函数，使用此函数算出1000日币可换多少人民币。

    /* 
    float cny(float x)
    {
        return x * 0.06376f;
    }

    void Start()
    {
        float x = 1000.0f;
        float c = cny(x);

        Debug.Log(c);
    }
    */



    //5. 请写一个人民币转换美元函数。使用此函数算出7000人民币可换多少美元。

    /*
    float usd(float x)
    {
        return x * 0.1454f;
    }

    void Start()
    {
        float x = 7000.0f;
        float c = usd(x);

        Debug.Log(c);
    }
    */



    //6. 已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色加法函数，并求出rgb(12, 5, 2)+rgb(123, 42, 14)=rgb(?,?,?)。


    /*Color add (Color a, Color b)
    {
        return a+b;
    }

    void Start()
    {

        Color x = new Color(12, 5, 2);
        Color y = new Color(123, 42, 14);

        Color c = add (x, y);

        Debug.Log(c);  //有四个数字，白白说最后一个是alpha层，但是我不知道怎么去除
    }
    */



    //7. 已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色反色函数，并求出rgb(12, 5, 2)的反色为rgb(?,?,?)。

    /*
    Color n(Color a, Color b)
    {
        return b - a;
    }

    void Start()
    {
        Color a = new Color(12, 5, 2);
        Color b = new Color(255, 255, 255);

        Color c = n(a, b);

        Debug.Log(c);  
    }
    */



    //8. 白白有10只宠物，请写一个函数为10只宠物命名，第一只宠物的名字为“小白1号”，第二只宠物为“小白2号”，以此类推。请打印出所有宠物的名字。


    /* 方法1
    void Start()
    {

        string n = "白白";
        string end = "号";
        string pattern = "";

        for (int i=1; i <=10; i++)
        {

            pattern = n + i + end;
            Debug.Log(pattern);
        }


    }
    */


    /* 方法2
    string p (string a, int b, string c)
    {

        return a + b + c;
    }

    void Start()
    {
        string s = "白白";
        string e = "号";

        for (int i = 1; i <= 10; i++)
        {

            string d = p(s, i, e);
            Debug.Log(d);
        }
    }
    */




    //9. 请写4个函数分别实现+-*/，求出((4+9)*8+7-3)/2=？







    //10. 999.99连续10次除以2得出的数为多少？（不允许使用for）


    /*
    float n(float a, int b)
    {

        return a / b;

    }

    void Start()
    {
        int b = (int)System.Math.Pow(2, 10);

        float a = 999.99f;

        float k = n(a, b);
        Debug.Log(k);
    }
    */












}

num3 = 8;
        int num4 = 7;
        int num5 = 3;
        int num6 = 2; 

        int i = plus(num1, num2);

        int j = minus(num4, num5);

        int k = multiply(i, num3);

        int l = plus(k, j);

        int m = divide(l, num6);
        Debug.Log(m); 
    }



    //10. 999.99连续10次除以2得出的数为多少？（不允许使用for）


    /*
    float n(float a, int b)
    {

        return a / b;

    }

    void Start()
    {
        int b = (int)System.Math.Pow(2, 10);

        float a = 999.99f;

        float k = n(a, b);
        Debug.Log(k);
    }
    */












}

