using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson_3 : MonoBehaviour
{

    // Use this for initialization
    /*
    1. 请写出求圆面积函数。并使用此函数计算半径为76.3的圆面积。
    2. 请写出求长方体体积函数。并使用此函数计算长43.2,宽54.5, 高为123.9的长方体体积。
    3. 请写出这样的函数，可以求出任意两个整数之间的数字之和，并求出1+2+3+..100=? 及 4+5+6+7+8+..999=?
    4. 请写一个日币转换人民币函数，使用此函数算出1000日币可换多少人民币。
    5. 请写一个人民币转换美元函数。使用此函数算出7000人民币可换多少美元。
    6. 已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色加法函数，并求出rgb(12, 5, 2)+rgb(123, 42, 14)=rgb(?,?,?)。
    7. 已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色反色函数，并求出rgb(12, 5, 2)的反色为rgb(?,?,?)。
    8. 白白有10只宠物，请写一个函数为10只宠物命名，第一只宠物的名字为“小白1号”，第二只宠物为“小白2号”，以此类推。请打印出所有宏物的名字。
    9. 请写4个函数分别实现+-* /，求出((4+9)*8+7-3)/2=？
    10. 999.99连续10次除以2得出的数为多少？（不允许使用for）
    */


    void Start()
    {
        Debug.Log("第1题");
        Debug.Log("半径为" + 76.3 + "的圆面积:" + GetRoundArea(76.3f));

        Debug.Log("第2题");
        Debug.Log("长方体体积:" + GetCuboidVolume(43.2f, 54.5f, 123.9f));

        Debug.Log("第3题");
        Debug.Log(Accumulation(1, 100));
        Debug.Log(Accumulation(4, 999));

        Debug.Log("第4题");
        Debug.Log("1000日币可换" + JPYtoCNY(1000) + "人民币");

        Debug.Log("第5题");
        Debug.Log("7000人民币可换" + CNYtoUSD(7000) + "美元");

        Debug.Log("第6题");
        Debug.Log(MixColor(new Color32(12, 5, 2, 255), new Color32(123, 42, 14, 255)));

        Debug.Log("第7题");
        Debug.Log(InverseColor(new Color32(12, 5, 2, 255)));

        Debug.Log("第8题");
        string[] Names = (GetAllPetsName(10));
        foreach (string Name in Names)
        {
            Debug.Log(Name);
        }
        Debug.Log("第9题");
        Debug.Log(Divide(Minus(Add(Times(Add(4, 9), 8), 7), 3), 2));

        Debug.Log("第10题");
        Debug.Log(DivideTimes(999.99f, 2f, 10));
    }

    float GetRoundArea(float rad)
    {
        return rad * rad * Mathf.PI;
    }

    float GetCuboidVolume(float Length, float Weidth, float Height)
    {
        return Length * Weidth * Height;
    }

    int Accumulation(int StartNum, int EndNum)
    {
        int result = 0;
        for (int i = StartNum; i <= EndNum; i++)
        {
            result += i;
        }
        return result;
    }

    float JPYtoCNY(int Num)
    {
        return Num * 0.063f;
    }

    float CNYtoUSD(int Num)
    {
        return Num * 0.15f;
    }

    Color32 MixColor(Color32 A, Color32 B)
    {
        return new Color32((byte)(A.r + B.r), (byte)(A.g + B.g), (byte)(A.b + B.b), 255);
    }

    Color32 InverseColor(Color32 A)
    {
        return new Color32((byte)(255 - A.r), (byte)(255 - A.g), (byte)(255 - A.b), 255);
    }

    string[] GetAllPetsName(int PetNum)
    {
        string[] Names = new string[PetNum];
        for (int i = 0; i < PetNum; i++)
            Names[i] = "小白" + (i + 1) + "号";
        return Names;
    }

    int Add(int a, int b)
    {
        return a + b;
    }
    int Minus(int a, int b)
    {
        return a - b;
    }
    int Times(int a, int b)
    {
        return a * b;
    }
    int Divide(int a, int b)
    {
        return a / b;
    }

    float DivideTimes(float Divider, float Divdend, int times)
    {
        Divider /= Divdend;
        if (times > 1)
        {
            return DivideTimes(Divider, Divdend, --times);
        }
        return Divider;
    }
}
