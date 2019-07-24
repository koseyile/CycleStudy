using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3HWbaibai : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //RunAnswer1();

        //RunAnswer2();

        //RunAnswer3();

        //RunAnswer4();

        //RunAnswer5();

        //RunAnswer6();

        //RunAnswer7();

        //RunAnswer8();

        //RunAnswer9();

        //RunAnswer10();
    }



    //1.请写出求圆面积函数。并使用此函数计算半径为76.3的圆面积。
    void RunAnswer1() {

        float radius = 76.3f;
        float area = CircleArea(radius);
        Debug.Log(area);
    }

    float CircleArea(float r) {

        return Mathf.PI * r * r;
    }



    //2.请写出求长方体体积函数。并使用此函数计算长43.2,宽54.5, 高为123.9的长方体体积。
    void RunAnswer2()
    {
        float length = 43.2f;
        float width = 54.5f;
        float height = 123.9f;
        float Volume = CubeVolume(length, width, height);
        Debug.Log(Volume);
    }

    float CubeVolume(float l, float w, float h) {

        return l * w * h;
    }



    //3.请写出这样的函数，可以求出任意两个整数之间的数字之和，并求出1 + 2 + 3 +..100 =? 及 4 + 5 + 6 + 7 + 8 +..999 =?
    //函数求和，包含这两个数本身 [a,b]
    void RunAnswer3() {
        int x1 = 1;
        int x2 = 100;
        int sumX = SumBetween(x1, x2);
        Debug.Log(sumX);

        int y1 = 4;
        int y2 = 999;
        int sumY = SumBetween(y1, y2);
        Debug.Log(sumY);
    }

    int SumBetween(int a, int b) {

        int sum = 0;
        for (int i = a; i <= b; i++) {
            sum += i;
        }

        return sum;
    }



    //4.请写一个日币转换人民币函数，使用此函数算出1000日币可换多少人民币。
    void RunAnswer4() {
        float amountJP = 1000.0f;
        float rate = 0.0632f;
        float amountCN = MoneyConvert(amountJP, rate);
        Debug.Log(amountCN);
    }

    // #4 & 5 function
    float MoneyConvert(float sum, float rate) {

        return sum * rate;
    }



    //5.请写一个人民币转换美元函数。使用此函数算出7000人民币可换多少美元。
    void RunAnswer5() {
        float amountRMB = 7000.0f;
        float rate = 0.1453f;
        float amountUSD = MoneyConvert(amountRMB, rate);
        Debug.Log(amountUSD);
    }



    //6.已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0 - 255，请写一个颜色加法函数，并求出rgb(12, 5, 2) + rgb(123, 42, 14) = rgb(?,?,?)。

    void RunAnswer6() {
        int[] color1 = { 12, 5, 2 };
        int[] color2 = { 123, 42, 14 };
        int[] color3 = new int[3];
        int[] color4;

        AddRGB(color1, color2, ref color3);
        Debug.Log("ref keyword: " + color3[0] + ", " + color3[1] + ", " + color3[2]);

        AddColor(color1, color2, out color4);
        Debug.Log("out keyword: " + color4[0] + ", " + color4[1] + ", " + color4[2]);
    }

    // #6 function 用ref
    void AddRGB(int[] a, int[] b, ref int[] c) {

        for (int i = 0; i < 3; i++) {
            c[i] = a[i] + b[i];
        }

    }
    // #6 function 用out
    void AddColor(int[] a, int[] b, out int[] c)
    {
        c = new int[3]; // 重新定义 改为重新分配内存比较好

        for (int i = 0; i < 3; i++)
        {
            c[i] = a[i] + b[i];
        }

    }


    //7.已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0 - 255，请写一个颜色反色函数，并求出rgb(12, 5, 2)的反色为rgb(?,?,?)。
    void RunAnswer7() {
        int[] rgb1 = { 12, 5, 2 };
        int[] rgb2;

        OppositeColor(rgb1, out rgb2);
        Debug.Log(rgb2[0] + ", " + rgb2[1] + ", " + rgb2[2]);
    }

     void OppositeColor(int[] a, out int[] b)
    {
        int[] full = { 255, 255, 255 };

        b = new int[3]; // 重新定义 改为重新分配内存比较好

        for (int i = 0; i < 3; i++)
        {
            b[i] = full[i] - a[i];
        }

    }



    //8.白白有10只宠物，请写一个函数为10只宠物命名，第一只宠物的名字为“小白1号”，第二只宠物为“小白2号”，以此类推。请打印出所有宏物的名字。

    void RunAnswer8() {
        string[] petNames = new string[10];
        NamePets(ref petNames);
    }

    void NamePets(ref string[] pets) {
        for (int i = 0; i < pets.Length; i++) {
            int num = i + 1;
            pets[i] = "小白" + num + "号";
            Debug.Log(pets[i]);
        }
    }



    //9.请写4个函数分别实现 + -*/，求出((4 + 9) * 8 + 7 - 3) / 2 =？
    void RunAnswer9() {
        int u = 4;
        int v = 9;
        int w = 8;
        int x = 7;
        int y = 3;
        int z = 2;
        
        int k = Divide(Minus(Plus(Multiply(Plus(u, v), w), x), y), z);
        Debug.Log(k);
    }

    int Plus(int a, int b) {
        return a + b;
    }

    int Minus(int a, int b) {
        return a - b;
    }

    int Multiply(int a, int b) {
        return a * b;
    }

    int Divide(int a, int b) {
        return a / b;
    }



    //10. 999.99连续10次除以2得出的数为多少？（不允许使用for）
    void RunAnswer10() {
        float p = 999.99f;
        float q = 2f;
        int times = 10;

        float k = SDivide(p, q, times);
        Debug.Log(k);
    }

    float SDivide(float a, float b, int c) {

        if (c == 1)
        {
            return a / b ;
        }
        else {

            return SDivide(a, b, (c - 1)) / b;
        }

    }

}
