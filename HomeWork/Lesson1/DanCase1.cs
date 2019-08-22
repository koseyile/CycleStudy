using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanCase1 : MonoBehaviour
{
    void Start()
    {
        //Lesson 1 第一题 打印1-100所有数
        /* for(int i = 1;i<=100;i++)
         {
             Debug.Log(i);
         }
         */

        //第二题 打印1-100所有偶数
        /* for(int i = 1; i<=100;i++)
        {
            if(i%2==0)
            {
                Debug.Log(i);
            }
        }
        */

        //第三题 打印1-100所有奇数
        /* for(int i = 1;i<=100;i++)
        {
            if(i%2==1)
            {
                Debug.Log(i);
            }
        }
        */

        //第四题 打印1-100所有素数

        /*
         int a = 0;
        for(int i = 2; i<100;i++)
        {
            a = 0;
            for(int s = 2; s<i; s++)
            {
                if(i%s==0)
                {
                    a = 1;
                }
                
            }
            if(a==0)
            {
                Debug.Log(i);
            }

        }
        */

        //第五题 打印处于0到100之间的数，这些数是偶数且这些数乘以它自身大于50
        /* for(int i=0; i<=100;i++)
         {
             if(i%2==0&&i*i>50)
             {
                 Debug.Log(i);
             }
         }
         */

        //第六题 打印处于0到100之间的数，这些数是偶数或者这些数乘以它自身大于50
        /* for(int i = 0;i<=100;i++)
         {
             if(i%2==0||i*i>50)
             {
                 Debug.Log(i);
             }
         }
         */

        //第七题 编程求1+2+3+4+…+100=？
        /*
        int s = 0;
        for(int a = 0; a<=100; a++)
        {
            s = s + a;
        }
        Debug.Log(s);
        */

        //第八题 打印输出平方值小于100的最大整数
        /*
        for(int i = 0; i*i<100;i++)
        {
            if((i+1)*(i+1)>=100)
            {
                Debug.Log(i);
            }
        }
        */

        //第九题 求出半径为8.6的圆面积
        /*
        float r = 8.6f;
        float s = Mathf.PI * r * r;
        Debug.Log(s);
        */

        //第十题 打印10-99中所有个位数加十位数为偶数的数
        /*

        for(int a = 1; a<=9;a++)
        {
            for(int b=1; b<=9;b++)
            {
                int d = 10 * a + b;
                int c = a + b;
                if(c%2 ==0)
                {
                    Debug.Log(d);
                }
            }
            */

        //Lesson 2 第五题
        //虽然第五题没有布置但为了捋第六题的思路还是写了……不明白下面两种方法为什么第2种就始终不行T_T只是把字符串初始定义放在了for循环外面
        /*
         打印
         *
         **
         ***
         ****
         *****
               */

        /*
        for (int i = 0;i<5;i++)

        {
            string str = "";

            for (int j = 0; j<=i;j++)
            {
                str = str + "*";
              
            }
            str = str + '\n';

            Debug.Log(str);

        }
         */


        /*
         string str = "";
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                str = str + "*";
            }
            str = str + '\n';
        }
        Debug.Log(str);
        */



        //第六题
        /*打印
         ####$
         ###$$
         ##$$$
         #$$$$
              */

        /*
        for (int i= 1;i < 5;i++)
        {
        string str1 = "";
        string str2 = "";
        string str = "";

            for(int j=1;j<=5-i;j++)
            {
                str1 = str1 + "#";
            }
            for(int k =1;k<=i;k++)
            {
                str2 = str2 + "$";
            }
            str = str1 + str2 ;
                
        Debug.Log(str);
        }
        */


        //Lesson 3 第九题
        //分别设4个函数，求((4+9)*8+7-3)/2

        /*
        int add(int a1,int b1)
        {
            return a1 + b1;
        }
        int multi(int a2, int b2)
        {
            return a2 * b2;
        }
        int minus(int a3,int b3)
        {
            return a3 - b3;
        }
        int divide(int a4,int b4)
        {
            return a4 / b4;
        }

        int x = 4;
        int y = 9;
        int z = 8;
        int s = 7;
        int q = 3;
        int w = 2;

        int R = divide(minus(add(multi(add(x, y), z), s), q), w);
        Debug.Log(R);
        */



    }

}







