using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class wupeng_0714 : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        Work_01(76.3f);

        Work_02(43.2f, 54.5f, 123.9f);

        Work_03(1, 999);

        Work_04(1000);

        Work_05(7000);

        Work_06(new COLOR(12, 5, 2), new COLOR(123, 42, 14));

        Work_07(new COLOR(12, 5, 2));
        /**/
        Work_08();

        //Work_09,求出((4+9)*8+7-3)/2=？
        float res = Divede(Sub(Add(Mul(Add(4, 9), 8), 7), 3), 2);
        Debug.Log(res);

        Work_10();


    }

    void Work_01(float r)
    {
        float S = Mathf.PI * r * r;
        Debug.Log("圆的面积：" + S);
    }

    void Work_02(float l, float w, float h)
    {
        float volum =  l * w * h;

        Debug.Log("长方体体积：" + volum);
    }

    void Work_03(int start, int end)
    {

        int dist = end - start;

        int res = 0;

        if(dist % 2 == 1)
        {
            res = (start + end) * (dist + 1) / 2;
        }
        else if (dist % 2 == 0)
        {
            res = (start + end - 1) * dist / 2 + end;
        }

        Debug.Log(res);
    }

    float rateJan = 0.063f;
    float rateUS = 0.1454f;

    float Work_04(float money)
    {
        //请写一个日币转换人民币函数，使用此函数算出1000日币可换多少人民币

        float rmb = money * rateJan;

        Debug.Log("兑换人民币：" + rmb);

        return rmb;
    }

    float Work_05(float rmb)
    {
        //请写一个人民币转换美元函数。使用此函数算出7000人民币可换多少美元。
        float usd = rmb * rateUS;

        Debug.Log("兑换人民币：" + usd);

        return usd;
    }


    class COLOR
    {
        public int r;
        public int g;
        public int b;

        public COLOR()
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
        }

        public COLOR(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        } 
    }

    COLOR Work_06(COLOR c1, COLOR c2)
    {
        //已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色加法函数，并求出rgb(12, 5, 2)+rgb(123, 42, 14)=rgb(?,?,?)。

        COLOR res = new COLOR();
        res.r = c1.r + c2.r > 255 ? 255 : c1.r + c2.r;
        res.g = c1.g + c2.g > 255 ? 255 : c1.g + c2.g;
        res.b = c1.b + c2.b > 255 ? 255 : c1.b + c2.b;

        Debug.Log("叠加颜色：(" + res.r + "," + res.g + "," + res.b + ")");

        return res;

    }

    COLOR Work_07(COLOR c)
    {
        //已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色反色函数，并求出rgb(12, 5, 2)的反色为rgb(?,?,?)
        COLOR res = new COLOR();
        res.r = 255 - c.r;
        res.g = 255 - c.g;
        res.b = 255 - c.b;

        Debug.Log("反色为：（" + res.r + "," + res.g + "," + res.b + ")");

        return res;
    }

    void Work_08()
    {
        //白白有10只宠物，请写一个函数为10只宠物命名，第一只宠物的名字为“小白1号”，第二只宠物为“小白2号”，以此类推。请打印出所有宏物的名字。
        string[] names = new string[10];

        for (int i = 0; i < 10; i ++)
        {
            names[i] = "小白" + (i + 1).ToString() + "号"; 
        }

        for (int j = 0; j < names.Length; j ++)
        {
            Debug.Log(names[j]);
        }
    }


    float Add(float a, float b)
    {
        return a + b;
    }

    float Sub(float a, float b)
    {
        return a - b;
    }

    float Mul(float a, float b)
    {
        return a * b;
    }

    float Divede(float a, float b)
    {
        return a / b;
    }


    float Work_10()
    {
        //999.99连续10次除以2得出的数为多少？（不允许使用for）
        int d = 1 << 10;

        float res = 999.99f / d;

        Debug.Log(res);

        return res;
    }
}
