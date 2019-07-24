using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wuwu3 : MonoBehaviour
{
	//1. 请写出求圆面积函数。并使用此函数计算半径为76.3的圆面积。
	float Area(float p, float r)
	{
		return p * r * r;
	}
	//2. 请写出求长方体体积函数。并使用此函数计算长43.2,宽54.5, 高为123.9的长方体体积。
	float Cube(float l, float w, float h)
	{
		return l * w * h;
	}
	//3. 请写出这样的函数，可以求出任意两个整数之间的数字之和，并求出1+2+3+..100=? 及 4+5+6+7+8+..999=?
	int Adding(int i, int j)
	{
		return i + j;
	}
	//4. 请写一个日币转换人民币函数，使用此函数算出1000日币可换多少人民币。
	float Rmb(float Y, float R)
	{
		return Y * R;
	}
	//5. 请写一个人民币转换美元函数。使用此函数算出7000人民币可换多少美元。
	float Dollar(float Rmb, float Drate)
	{
		return Rmb * Drate;
	}
	//9. 请写4个函数分别实现+-*/，求出((4+9)*8+7-3)/2=？
	int Add(int a, int b)
	{
		return a + b;
	}
	int Minus(int c, int d)
	{
		return c - d;
	}
	int Multiply(int e, int f)
	{
		return e * f;
	}
	int Divide(int g, int h)
	{
		return g / h;
	}
	//10. 999.99连续10次除以2得出的数为多少？（不允许使用for）
	float test(float n, int ns)
	{
		return n / ns;
	}
}
// Start is called before the first frame update
void Start()
{
	//1.请写出求圆面积函数。并使用此函数计算半径为76.3的圆面积。
	float r1 = 76.3f;
	float p = 3.1415f;
	float c = Area(p, r1);

	Debug.Log(c);
	//2.请写出求长方体体积函数。并使用此函数计算长43.2,宽54.5, 高为123.9的长方体体积。
	float l1 = 43.2f;
	float w1 = 54.5f;
	float h1 = 123.9f;
	float c1 = Cube(l1, w1, h1);
	Debug.Log(c1);
	//3. 请写出这样的函数，可以求出任意两个整数之间的数字之和，并求出1+2+3+..100=? 及 4+5+6+7+8+..999=?
	for (int i = 1; i <= 999; i++)
		int c =

	//4. 请写一个日币转换人民币函数，使用此函数算出1000日币可换多少人民币。
	float Y = 1000.0f;
	float R＝0.0635f;
	float Rmb1 = Rmb(Y＊R)；

		Debug.Log(Rmb1);
	//5. 请写一个人民币转换美元函数。使用此函数算出7000人民币可换多少美元。
	float rmb2 = 7000.0f;
	float Drate2 = 6.88f;
	float Dollar1 = Dollar(rmb2, Drate);
	Debug.Log(Dollar1);

	//6. 已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色加法函数，并求出rgb(12, 5, 2)+rgb(123, 42, 14)=rgb(?,?,?)。

	//7. 已知颜色有红绿蓝(rgb)三个通道，每个通道的取值范围为0-255，请写一个颜色反色函数，并求出rgb(12, 5, 2)的反色为rgb(?,?,?)。
	//8. 白白有10只宠物，请写一个函数为10只宠物命名，第一只宠物的名字为“小白1号”，第二只宠物为“小白2号”，以此类推。请打印出所有宏物的名字。

	//9. 请写4个函数分别实现+-*/，求出((4+9)*8+7-3)/2=？
	int result = Divide(Minus(Add(Multiply(8, Add(4, 9)), 7), 3), 2);
	Debug.Log(result);
	//10. 999.99连续10次除以2得出的数为多少？（不允许使用for）
	float n = 999.99;
	int ns = 2
    float test1 = test(test(n / ns), test(n / ns));
	Debug.Log(test1);
}
	// Update is called once per frame
	void Update()
    {
        
    }
}
