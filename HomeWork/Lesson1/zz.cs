using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       /* 复习
        * for (int i = 0; i < 10; i++)
        {
            if (i < 5)
            {
                Debug.Log(i);
            }
        }
        */
        //习题1 1~100整数

        for(int i=1;i<=100;i++)
        {
            Debug.Log(i);
        }

        //习题2 1~100中所有偶数

        for(int i=0;i<=100;i++)
        {
            if (i % 2 == 0)
            {
                Debug.Log(i);
            }

        }

        //习题3 1~100中所有奇数

        for(int i=0;i<=100;i++)
        {
            if(i%2==1)
            {
                Debug.Log(i);
            }
        }

        //习题4 1~100中所有素数.这道题，懵逼！
        /*
        int a = 0;

        for（int i = 2; i < a; i++)
        {
            if (a % i == 0) 
            {
                Debug.Log(a);
            }
        }
       */

        //习题5 0~100中的偶数，并且乘以自身大于50

        for (int i = 0; i <= 100; i++)
        {
            if (i%2==0 && i*i>50)
            {
                Debug.Log(i);
            }
        }

        //习题6 0~100中的偶数，或者乘以自身大于50

        for(int i=0;i<=100;i++)
        {
            if ((i % 2 == 0) || (i * i > 50))
            {
                Debug.Log(i);
            }
        }

        //习题7 编程求出1+2+3+4+...100=?这个我好像得出了一堆。。怎么值得出最后答案呢

        int a = 0;

        for (int i = 1; i <= 100; i++)
        {
            a += i;
            {
                Debug.Log(a);
            }
        }

        //习题8 平方值小于100的最大整数。这个题与上面同理，然后为什么就打印不出来了呢？
        /*
        int f = q + 1;
        for (int q = 0; q < 100; q++)
        {
            if (q * q < 100 && f * f >= 100) ;
            {
                Debug.Log(q);
            }
        }
        */

        //习题9 求出半径为8.6的圆面积

        float p = 3.14f;
        float r = 8.6f;
        float s = p * r * r;
        Debug.Log(s);

        //习题10 打印10到99中所有个位数加十位数为偶数的数.好像做的完全不对。。。
        /*
        int g = 0;
        int s = 0;
        int h = g + s;
        for (int g<= 9; g++;int s<= 9;s++);
        {
            if ((h < 10 && h % 2 == 0);
            {
                Debug.Log(h);
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}

  