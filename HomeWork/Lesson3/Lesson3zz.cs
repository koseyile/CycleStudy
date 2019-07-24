using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3zz : MonoBehaviour
{
	// Start is called before the first frame update

	//第1题：写出求圆面积函数。并使用此函数计算半径为76.3的圆面积。
	/*
    float Circle(float r,float p)
	{
		float area = r * r * p;
		return area;
	}

    void Start()
    {
		float a = 76.3f;
		float b = 3.14159f;

		float c = Circle(a, b);
		Debug.Log(c);

    }
    */

	//第2题：求长方体体积函数。并使用此函数计算长43.2；宽54.5；高123.9的长方体体积。
	/*
    float Cube(float l,float w,float h)
	{
		float volu = l * w * h;
		return volu;
	}

    void Start()
	{
		float a = 43.2f;
		float b = 54.5f;
		float c = 123.9f;

		float d = Cube(a, b, c);
		Debug.Log(d);
	}
    */

	//第3题：写出这样的函数，可以求任意两个整数之间的数字之和，并求出1+2+3+...100=？及4+5+6+...999=？
	/*
    int add(int a,int b)
	{
		int num = a + b;
		return num;
	}

	void Start()
	{
		int[] a1 = new int[100];
		for (int i = 0; i < a1.Length; i++)
		{
			a1[i] = i + 1;
		}

		int a2 = 0;
		{
			for (int i = 0; i < a1.Length; i++)
			{
				a2 += a1[i];
			}
		}

		int sum1 = add(a1, a2);
		Debug.Log(sum1);
	}
    */

	//第4题：请写一个日币转换人民币函数，算出1000日币可换多少人民币。
	/*思路一
    float exchange(float j)
	{
		float r = j * 0.063f;
		return r;
	}

    void Start()
	{
        float j1 = 1000.0f;
		float r1 = exchange(j1);
		Debug.Log(r1);
	}

    /*思路二，跑偏，但提出一个问题：浮点型数组参数里声明里，可以出现/如何表达整型条件
	float exchange(params float[] mon)
	{
        if((mon != null)&&(mon.Length != 0))
            for(int i = 0; i < mon.Length; i++)
			{
				mon[i] = mon[i] * 0.063f;
				return mon[i];
			}
		
	}
	void Start()
	{
		float j = 1000.0f;
		float r = exchange(j);
		Debug.Log(r);
	}
    */

	//第5题：请写一个人民币转换美元函数，算出7000人民币可换多少美元。
	/*
	float exchange(float r)
	{
		float usd = r * 0.145f;
		return usd;
	}

	void Start()
	{
		float r1 = 7000.0f;
		float usd1 = exchange(r1);
		Debug.Log(usd1);
	}
    */

	//第6题：已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围是0~255，请写出一个颜色加法函数，求出rgb(12，5，2)+rgb（123，42，14）=rgb（？，？，？）。

    /*
	int Channel(int x,int y)
	{
			{
			int plus = x + y;
				return plus;
			}

	}
	void Start()
	{
		int r1 = 12;
		int r2 = 123;

        int g1 = 5;
        int g2 = 42;

		int b1 = 2;
		int b2 = 14;

		int rplus = Channel(r1, r2);
		int gplus = Channel(g1, g2);
		int bplus = Channel(b1, b2);

		Debug.Log(rplus);
		Debug.Log(gplus);
		Debug.Log(bplus);
	}
    */

	//第7题：已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围是0~255，请写出一个颜色反色函数，求出rgb(12，5，2)的反色为rgb（？，？，？）。
    /*
    int Channel(params int[] color)
	{
        for(int i = 0; i < color.Length; i++)
		{
			color[i] = 255 - color[i];
			return color[i];
		}
	}
	void Start()
	{
		int r = 12;
		int g = 5;
		int b = 2;

		incolor = Channel(r, g, b);
		Debug.Log(incolor);
	}
    */

	//第8题：白白有10只宠物，请写一个函数为10只宠物命名，第一只叫“小白1号”，以此类推打印所有宠物名称。

    string petname()

	//第9题：写4个函数分别实现+-*/，求出（(4+9)*8+7-3）/2=？
	//第10题：999.99连续10次除以2得出的数为多少？（不允许使用for）

	// Update is called once per frame
	void Update()
    {
        
    }
}
