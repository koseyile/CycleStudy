using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1HW_naomi : MonoBehaviour
{
    void Start()
    // 1. 打印1-100中的所有数

    //{
    //    for (int i = 1; i < 100; i++)
    //    {
    //        Debug.Log(i);
    //    }
    //}

    // 2. 打印1-100中的所有偶数

    //{
    //    for (int i = 1; i < 100; i++)
    //    {
    //        if (i % 2 == 0)
    //            Debug.Log(i);
    //    }
    //}

    //3. 打印1-100中的所有奇数

    //{
    //    for (int i = 1; i < 100; i++)
    //    {
    //        if (i % 2 == 1)
    //            Debug.Log(i);
    //    }
    //}

    //4. 打印1-100中的所有素数

    //求整除的个数为2的数；
    //为何定义int sum=0如果写在最外层for循环之前就打印不对？
    //{
    //    for (int i = 2; i < 100; i++)
    //    {
    //        int sum = 0;

    //        for (int a = 1; a <= i; a++)
    //        {
    //            if (i % a == 0)
    //            {
    //                sum += 1;
    //            }
    //        }
    //        if (sum == 2)
    //        {
    //            Debug.Log(i);
    //        }
    //    }

    //}

    //从百度学习break语句
    //{
    //    for (int i = 2; i < 100; i++)
    //    {
    //        for (int a = 2; a <= i; a++)
    //        {
    //            if (i % a == 0 && i != a)
    //            {
    //                break;
    //            }
    //            if (a > i - 1)
    //            {
    //                Debug.Log(i);
    //            }
    //        }
    //    }
    //}

    //5. 打印这样一些数，这些数处于0到100之间，这些数是偶数并且这些数乘以它自身大于50

    //{
    //    for (int i = 0; i< 100; i++)
    //    {
    //        if (i % 2 == 0 && i*i > 50)
    //            Debug.Log(i);
    //    }
    //} 

    //6. 打印这样一些数，这些数处于0到100之间，这些数是偶数或者这些数乘以它自身大于50

    //{
    //    for (int i = 0; i < 100; i++)
    //    {
    //        if ((i % 2 == 0) || (i * i > 50))
    //            Debug.Log(i);
    //    }
    //}

    //7. 编程求出1+2+3+4+…100=？ 

    // 从百度中学习到的新方法 a += 1 就是 a = a+1
    //为什么不能在开始定义时写int i,a=0;
    //第一次走到a = a+1时为什么会再次循环

    //{
    //    int a = 0;

    //    for (int i = 1; i <= 100; i++)
    //    {
    //        a += i;
    //    }
    //    Debug.Log(a);
    //}

    //8. 打印输出平方值小于100的最大整数。(为何从for语句开始的运算就可以不用先定义i？)

    //{
    //    int i, a = 1;
    //    for (i = 1; i * i < 100; i++)
    //    {
    //        if (a < i)
    //        {
    //            a = i;
    //        }
    //    }
    //    Debug.Log(a);
    //}

    //9. 求出半径为8.6的圆面积。

    //{
    //    float i = 3.1415925f;
    //    float j = 8.6f;
    //    float x = i * j * j;
    //    Debug.Log(x);
    //}

    //10. 打印10-99中所有个位数加十位数为偶数的数。

    //{
    //    int i,a=0,b=0;
    //    for(i = 10; i < 99;i++)
    //    {
    //        a = i % 10;
    //        b = i / 10;

    //        if( (a + b) % 2 == 0)
    //        {
    //            Debug.Log(i);
    //        }
    //    }
    //}
}