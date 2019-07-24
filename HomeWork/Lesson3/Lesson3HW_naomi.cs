using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3HW_naomi : MonoBehaviour
{
    //1. 请写出求圆面积函数。并使用此函数计算半径为76.3的圆面积。
    //问：必须给out的输入赋值到底是什么意思？什情况下会报错？

    //void circle(float r,out float s)
    //{
            //s = 
    //    s = r * r * 3.14f;
    //}

    //void Start()
    //{
    //    float r1 = 76.3f;
    //    float s1 = 0;
    //    circle(r1,out s1);
    //    Debug.Log(s1);
    //}

    //float函数

    //float circle(float r)
    //{
    //    return r * r * 3.14f;
    //}

    //void Start()
    //{
    //    float r1 = 76.3f;
    //    float s = circle(r1);
    //    Debug.Log(s);
    //}


    //2. 请写出求长方体体积函数。并使用此函数计算长43.2,宽54.5, 高为123.9的长方体体积。

    //float cuboid(float x,float y,float z)
    //{
    //    return x * y * z;
    //}

    //void Start()
    //{
    //    float a = 43.2f;
    //    float b = 54.5f;
    //    float c = 123.9f;
    //    float s = cuboid(a,b,c);
    //    Debug.Log(s);
    //}

    //3. 请写出这样的函数，可以求出任意两个整数之间的数字之和，并求出1+2+3+..100=? 及 4+5+6+7+8+..999=?

    //int add(int a,int b)
    //{
    //    return a+b;
    //}

    //void Start()
    //{
    //    int j = 0;
    //    for(int i = 1;i<=100;i++)
    //    {
    //        add(i,j);
    //        j = i + j;
    //    }

    //    Debug.Log(j);

    //    int k = 4;
    //    for (int i = 5; i <= 999; i++)
    //    {
    //        add(i, k);
    //        k = i + k;
    //    }

    //    Debug.Log(k);
    //}

    //4. 请写一个日币转换人民币函数，使用此函数算出1000日币可换多少人民币。

    //float exchangeJPYtoCNY(float a)
    //{
    //    return a * 0.06345f;
    //}

    //void Start()
    //{
    //    float j1 = 1000f;
    //    float c1 = exchangeJPYtoCNY(j1);
    //    Debug.Log(c1); 
    //}

    //5. 请写一个人民币转换美元函数。使用此函数算出7000人民币可换多少美元。

    //float exchangeCNYtoUSD(float a)
    //{
    //    return a * 0.1455f;
    //}

    //void Start()
    //{
    //    float j1 = 7000f;
    //    float c1 = exchangeCNYtoUSD(j1);
    //    Debug.Log(c1); 
    //}

    //6. 已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色加法函数，并求出rgb(12, 5, 2)+rgb(123, 42, 14)=rgb(?,?,?)。

    //string add(int[] i,int[]j)
    //{
    //    int r = i[0] + j[0];
    //    int g = i[1] + j[1];
    //    int b = i[2] + j[2];
    //    string rgb = "rgb(" + r +"," + g + "," + b +")";
    //    string wrong = "wrong";
    //    if (r<255 && g<255 && b<255)
    //        {
    //            return rgb;
    //        }else
    //        {
    //            return wrong;
    //        }
    //}

    //void Start()
    //{
    //    int[] ii = { 12, 5, 2 };
    //    int[] jj = { 123, 42, 14 };
    //    string c1 = add(ii, jj);
    //    Debug.Log(c1);
    //}

    //7. 已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色反色函数，并求出rgb(12, 5, 2)的反色为rgb(?,?,?)。

    //string invert(int[] i)
    //{
    //    int r = 255 - i[0];
    //    int g = 255 - i[1];
    //    int b = 255 - i[2];
    //    string rgb = "rgb(" + r +"," + g + "," + b +")";
    //    return rgb;
    //}

    //void Start()
    //{
    //    int[] ii = { 12, 5, 2 };
    //    int[] jj = { 123, 42, 14 };
    //    string c1 = add(ii, jj);
    //    Debug.Log(c1);
    //}

    //8. 白白有10只宠物，请写一个函数为10只宠物命名，第一只宠物的名字为“小白1号”，第二只宠物为“小白2号”，以此类推。请打印出所有宏物的名字。

    //string name(int a)
    //{
    //    string pet = "小白" + a +"号" ;
    //    return pet;
    //}

    //void Start()
    //{
    //    for (int i = 1; i <= 10; i++)
    //    {
    //        string ii = name(i);
    //        Debug.Log(ii);
    //    }
    //}


    //9. 请写4个函数分别实现+-*/，求出((4+9)*8+7-3)/2=？

    //int add(int a, int b)
    //{
    //    return a + b;
    //}

    //int minus(int a, int b)
    //{
    //    return a - b;
    //}

    //int times(int a, int b)
    //{
    //    return a * b;
    //}

//int float bool 
    void fun()
    {
        int i = fun2();
        int b;

    }


    //int divide(int a, int b)
    //{
    //    return a / b;
    //}
    //void Start()
    //{
    //    int i = 4;
    //    int j = 9;
    //    int k = 8;
    //    int l = 7;
    //    int m = 3;
    //    int n = 2;
    //    int x = add(i, j);
    //    int y = times(x, k);
    //    int z = add(y, l);
    //    int o = minus(z, m);
    //    int p = divide(o, n);
    //    Debug.Log(p);
    //}

    //10. 999.99连续10次除以2得出的数为多少？（不允许使用for）

    //float divide(float a,int b)
    //{
    //    return a/b;
    //}

    //void Start()
    //{
    //    float j = 999.99f;
    //    int k = 2;
    //    for (int i = 1; i <= 10; i++)
    //    {
    //        j = divide(j, k);
    //    }
    //    Debug.Log(j);
    //}

    //递归：

    //float divide(float a,int b)
    //{
    //    float x;
    //    if (b == 0)
    //    {
    //        return a;
    //    }
    //    else
    //    {
    //        x = divide(a,b-1)/ 2; 
    //    }
    //    return x;
    //}

    //void Start()
    //{
    //    float i = 999.99f;
    //    int k = 10;
    //    float j = divide(i, k);

    //    Debug.Log(j);
    //}
}
