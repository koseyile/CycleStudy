using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hongyi2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //1. 请输出如下字符串”12345...100”

        /* string a = "";
         {
             for (int i = 1; i <= 100; i++)
             {
             a+= i;
             }

            Debug.Log(a);

         } */


        //2. 请输出如下字符串“123换行456换行789….100” (貌似不太对)

        /*string a = "";
         {
            for (int i = 1; i <= 100; i++)
            {
                a += i;
                if (i % 3 == 0)

                { Debug.Log("\n"); }
                
            }

         }*/

        //3. 假设1对应字母a，2对应字母b，3对应字母c，以此类推，请打印以下数字分别对应的字母：13,24,12, 7, 9, 10, 6.

        /* string a = "abcdefghijklmnopqrstuvwxyz";
        {
            int[] b = { 13, 24, 12, 7, 9, 10, 6 };
            for (int i = 0; i < b.Length; ++i)
            {
                int c = b[i] - 1;
                Debug.Log(a[c]);
            }
        }*/

        //4. 请打印满足以下条件的所有数字：大于0小于1000的正整数，个位数加十位数等于9, 十位数乘以百位数为偶数，百位数乘以个位数为奇数。

        /* for (int i = 100; i <= 1000; i++)
        {
                int a = i % 10;
                int b = (i-a)%100/10;
                int c = (i-a-10*b)/100;
                if (a + b == 9 && (b * c) % 2 == 0 && (c * a) % 2 != 0)
            { Debug.Log(i); }
        } */







        //5. 请打印如下图形： */**/***/****/***** （不会写）


        /* for (int i = 1; i <= 5; i++)
        {
                for (int j = 1; j <= i; j++)
                    Debug.Log("*");
                Debug.Log("\n");
        } */




        //6. 请打印以下图形：####$/###$$/##$$$/#$$$$









        // 7. Zz忘记了4位数字密码的顺序，只记得是以下4位数字:3，8，9，7。请打印出所有的可能性，帮助zz找回密码。


        /* int[] a = { 3, 8, 9, 7 };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (j == i)
                    continue;
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (k == j || k == i)
                            continue;
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                if (l == i || l == j || l == k)
                                    continue;
                                Debug.Log(a[i] + " " + a[j] + " " + a[k] + " " + a[l]);
                            }
                        }
                    }
                }
            }
        }*/








        // 8.请打印数组所有元素：此数组有100个整型元素，每一个数都为前一个数的3倍，第1个数为2。？？？

        /* int[] ii = new int[100];

        for (int i = 2; i < ii.Length; i++)
        {
            ii[i] = 3 * i;
            { Debug.Log(ii[i]); }
        }*/










        //9. 已知一个灯有三种颜色，红色，绿色和蓝色。0对应红色，1对应绿色，其它数字对应蓝色，当数字为9时，请打印此时的颜色。

        /* int i = 9;
        switch (i)
        {
            case 0:
            { Debug.Log("red"); }
            break;

            case 1:
            { Debug.Log("green"); }
            break;

            default:
            { Debug.Log("blue"); }
            break;
        }*/










        //10.打印九九乘法口诀 (!不知道怎么分行!知道i==j时换行但不知道怎么写)

        /*for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= i; j++)
            {

                { Debug.LogFormat("{0}*{1}={2}\t", j, i, j * i); }

                if (i == j)
                    continue;
            }

            Debug.Log( "\n" );
        }*/


    }

}
