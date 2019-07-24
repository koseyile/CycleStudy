using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2HW_naomi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1.请输出如下字符串”12345...100”

        //{
        //    string n = "1";

        //    for (int i = 2; i <= 100; i++)

        //    {
        //        n += i;
        //    }

        //    Debug.Log(n);
        //}

        //2.请输出如下字符串“123换行456换行789….100”

        //{
        //    string n = "1";

        //    for (int i = 2; i <= 100; i++)

        //    {
        //        if (i % 3 != 0)
        //        {
        //            n += i;
        //        }

        //        else if( i % 3 == 0)
        //        {
        //            n += i + "\n";
        //        }
        //    }

        //    Debug.Log(n);

        //}

        //3.假设1对应字母a，2对应字母b，3对应字母c，以此类推，请打印以下数字分别对应的字母：13,24,12, 7, 9, 10, 6.


        //方法一

        //{
        //    string[] ii = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        //    for (int i = 0; i < ii.Length; i++)
        //    {
        //        if((i + 1 == 13) || (i + 1 == 24) || (i + 1 == 12) || (i + 1 == 7) || (i + 1 == 9) || (i + 1 == 10) || (i + 1 == 6))
        //        {
        //            Debug.Log(ii[i]);
        //        }

        //    }

        //}

        //方法二

        //{
        //    string text = "abcdefghijklmnopqrstuvwxyz";

        //    int[] input = { 13, 24, 12, 7, 9, 10, 6};

        //    for(int ii = 0; ii < input.Length; ii++)

        //    {
        //        int index = input[ii] - 1;
        //        Debug.Log(text[index]);
        //    }
        //}

        //4.请打印满足以下条件的所有数字：大于0小于1000的正整数，个位数加十位数等于9, 十位数乘以百位数为偶数，百位数乘以个位数为奇数。

        //{
        //    for(int i = 0; i < 1000; i++)
        //    {
        //        if (i / 100 < 0)
        //        {
        //            if((i % 10) + (i / 10) == 9)
        //            {
        //                Debug.Log(i);
        //            }

        //        }
        //        else if (i / 100 > 0)
        //        {
        //            if((i % 10) + ((i / 10) % 10) == 9 && (((i / 10) % 10) * (i / 100)) % 2 == 0 && ((i / 100)* (i % 10)) % 2 == 1)
        //            {
        //                Debug.Log(i);
        //            }
        //        }
        //    }
        //}

        //5.请打印如下图形：
        //     *
        //     **
        //     ***
        //     ****
        //     *****

        //{
        //    string n = "";
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        for (int j = 1; j <= i; j++)
        //        {
        //            if (j < i)
        //            {
        //                n += "*";
        //            }
        //            else if (i == j)
        //            {
        //                n += "*" + "\n";
        //            }
        //        }
        //    }
        //    Debug.Log(n);

        //}

        //6.请打印以下图形：
        //     ####$
        //     ###$$
        //     ##$$$
        //     #$$$$

        //{
        //    string n = "";
        //    for (int i = 1; i <= 4; i++)
        //    {
        //        for (int j = 1; j <= 5; j++)
        //        {
        //            if (j <= 5 - i)
        //            {
        //                n += "#";
        //            }
        //            else if (j > 5 - i && j != 5)
        //            {
        //                n += "$";
        //            }
        //            else if (j == 5)
        //            {
        //                n += "$"+"\n";
        //            }

        //        }
        //    }
        //    Debug.Log(n);

        //}

        //7.Zz忘记了4位数字密码的顺序，只记得是以下4位数字: 3，8，9，7。请打印出所有的可能性，帮助zz找回密码。

        //{
        //    string[] values = {"3","8","9","7"};
        //    for (int i = 0; i < values.Length; i++)
        //    {
        //        for (int j = 0; j < values.Length; j++)
        //        {

        //            if (i == j)
        //            {
        //                continue;
        //            }

        //            for (int k = 0; k < values.Length; k++)
        //            {
        //                if (k == j || k == i)
        //                {
        //                    continue;
        //                }

        //                for (int l = 0; l < values.Length; l++)
        //                {
        //                    if ((l == k) || (l == j) || (l == i))
        //                    {
        //                        continue;
        //                    }
        //                    Debug.Log(values[i] + values[j] + values[k] + values[l]);
        //                }

        //            }

        //        }
        //    }
        //}

        //8.请打印数组所有元素：此数组有100个整型元素，每一个数都为前一个数的3倍，第1个数为2。
        // 为什么j如果不用for而直接赋值就算不对？
        // 十几个数之后面出现了很多负数，不知道怎么回事。

        //{
        //    int[] ii = new int[100];
        //    ii[0]= 2;

        //    for (int i = 0;i <= ii.Length;i++)
        //    {
        //        Debug.Log(ii[i]);
        //        for (int j = i+1; j <= i+1; j++)
        //        {
        //            ii[j] = ii[i] * 3;
        //            ii[i] = ii[j];
        //        }
        //    }

        //}

        //9.已知一个灯有三种颜色，红色，绿色和蓝色。0对应红色，1对应绿色，其它数字对应蓝色，当数字为9时，请打印此时的颜色。（请使用switch关键字）

        //case 后面的数字string还是int?可以变成string或是一个条件语句吗？

        //{
        //    int i = 9;
        //    switch(i)
        //    {
        //        case 1:
        //            {
        //                Debug.Log("红色");
        //            }
        //            break;
        //        case 2:
        //            {
        //                Debug.Log("绿色");
        //            }
        //            break;
        //        default:
        //            {
        //                Debug.Log("蓝色");
        //            }
        //            break;
        //    }
        //}

        //10.打印99乘法口诀表

        //{
        //    int i, j;
        //    string a = "";
        //    for (i = 1; i <= 9; i++)
        //    {
        //        for (j = 1; j <= i; j++)
        //        {
        //            int x = i - j;
        //            switch(x)
        //            {
        //                case 0:
        //                    {
        //                        a = a + j + "*" + i + "=" + i * j + "\n";
        //                    }
        //                    break;
        //                default:
        //                    {
        //                        a = a + j + "*" + i + "=" + i * j + "\t";
        //                    }
        //                    break;
        //            }

        //        }

        //    }
        //    Debug.Log(a);
        //}

    }

}
