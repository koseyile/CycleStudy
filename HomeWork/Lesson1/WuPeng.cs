using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework_WuPeng : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //HomeWork_01();
        //HomeWork_02();
        //HomeWork_03();
        //HomeWork_04();
        //HomeWork_05();
        //HomeWork_06();
        //HomeWork_07(100);
        //HomeWork_08();
        //HomeWork_09();
        HomeWork_10();

    }

    //
    public void HomeWork_01()
    {
        Debug.Log("打印1-100中的所有数");
        for (int i = 1; i <= 100; i++)
        {
            Debug.Log(i);

        }
    }

    public void HomeWork_02()
    {
        Debug.Log("打印1-100中的所有偶数");
        for (int i = 1; i <= 100; i ++)
        {
            if ((i % 2) == 0)
                Debug.Log(i);
        }
    }

    public void HomeWork_03()
    {
        Debug.Log("打印1-100中的所有奇数");
        for (int i = 1; i <= 100; i ++)
        {
            if (((i + 1) % 2) == 0)
            {
                Debug.Log(i);
            }
        }
    }

    public void HomeWork_04()
    {
        Debug.Log("打印1-100中的所有素数");
        for (int i = 2; i <= 100; i++)
        {
            for (int j = 2; j <= i; j ++)
            {
                if (j == i)
                    Debug.Log(i);                
                if ((i % j) == 0)
                    break;
            }
        }
    }

    public void HomeWork_05()
    {
        Debug.Log(" 打印这样一些数，这些数处于0到100之间，这些数是偶数并且这些数乘以它自身大于50");
        for (int i = 1; i < 100; i ++)
        {
            if ((i % 2) == 0 && (i * i) > 50)
            {
                Debug.Log(i);
            }
        }
    }

    public void HomeWork_06()
    {
        Debug.Log("打印这样一些数，这些数处于0到100之间，这些数是偶数或者这些数乘以它自身大于50");
        for (int i = 1; i < 100; i++)
        {
            if ((i % 2) == 0 || (i * i) > 50)
            {
                Debug.Log(i);
            }
        }
    }

    public void HomeWork_07(int num)
    {
        Debug.Log("编程求出1+2+3+4+…100=");
        int c = 0;
        
        for (int i = (num / 2); i > 0; i --)
        {
            c += 1 + num;
        }

        if ((num % 2) == 1)
            c += num;

        Debug.Log(c);
    }

    public void HomeWork_08()
    {
        Debug.Log("打印输出平方值小于100的最大整数");

        for (int i = 100; i >= 1; i --)
        {
            if((i * i) < 100)
            {
                Debug.Log(i);
                return;
            }
        }
    }

    public void HomeWork_09()
    {
        Debug.Log("求出半径为8.6的圆面积");
        float s = Mathf.PI * (8.6f * 8.6f);
        Debug.Log(s);
    }


    public void HomeWork_10()
    {
        Debug.Log("打印10-99中所有个位数加十位数为偶数的数");
        for(int i = 10; i <= 99; i++)
        {
            if ((i % 10) != 0 && (((i % 10) + 10) % 2) == 0)
            {
                Debug.Log(i);
            }
        }
    }

}
