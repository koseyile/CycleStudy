using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wupeng_0707 : MonoBehaviour
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
        //HomeWork_07();
        //HomeWork_08();//用long也存不下呀
        //HomeWork_09(9);
        //HomeWork_10();
    }

    void HomeWork_01()
    {
        //请输出如下字符串”12345...100”
        string res = "";
        for (int i = 1; i <= 100; i ++)
        {
            res += i;
        }

        Debug.Log(res);
    }

    void HomeWork_02()
    {
        //请输出如下字符串“123换行456换行789….100”
        string res = "";
        for (int i = 1; i <= 100; i++)
        {
            res += i;
            if ((i % 3) == 0)
                res += "\n";
        }

        Debug.Log(res);
    }

    void HomeWork_03()
    {
        //假设1对应字母a，2对应字母b，3对应字母c，以此类推，请打印以下数字分别对应的字母：13,24,12, 7, 9, 10, 6.
        Debug.Log((char)('a' + (13-1)));
        Debug.Log((char)('a' + (24-1)));
        Debug.Log((char)('a' + (12-1)));
        Debug.Log((char)('a' + (7-1)));
        Debug.Log((char)('a' + (9-1)));
        Debug.Log((char)('a' + (10-1)));
        Debug.Log((char)('a' + (6-1)));
    }

    void HomeWork_04()
    {
        //请打印满足以下条件的所有数字：大于0小于1000的正整数，个位数加十位数等于9, 十位数乘以百位数为偶数，百位数乘以个位数为奇数。
        
        for (int i = 1; i < 1000; i ++)
        {
            int ge = i % 10;
            int shi = (i / 10) % 10;
            int bai = (i / 100) % 10;
            if ((ge + shi) == 9 && (shi * bai) % 2 == 0 &&  (bai * ge) % 2 == 1 )
            {
                Debug.Log(i);
            }
        
        }
    }

    void HomeWork_05()
    {
        // 请打印如下图形：
        // 1. *
        // 2. * *
        // 3. * **
        // 4. * ***
        // 5. * ****

        for(int i = 1; i <= 5; i ++)
        {
            string c = "*";

            for (int j = 1; j <= i; j ++)
            {
                c += "*";
            }
            c += '\n';

            Debug.Log(c);
        }
    }

    void HomeWork_06()
    {
        // 请打印以下图形：
        //1. ####$
        //2. ###$$
        //3. ##$$$
        //4. #$$$$

        for(int i = 0, j = 4; i < 4 && j > 0; i++, j --)
        {
            string a = "";
            string b = "";

            for (int k = 0; k < j; k ++)
            {
                a += "#";
            }

            for (int w = 0; w <= i; w ++)
            {
                b += "$";
            }

            a = a + b + "\n";

            Debug.Log(a);
        }

    }

    void HomeWork_07()//应该用递归，但是我不会。。。。
    {
        //Zz忘记了4位数字密码的顺序，只记得是以下4位数字:3，8，9，7。请打印出所有的可能性，帮助zz找回密码。

        string[] array = { "3", "8", "9", "7" };

        for (int i = 0; i < array.Length; i ++)
        {

        }

    }


    //用long也存不下呀！！！
    void HomeWork_08()
    {
        // 请打印数组所有元素：此数组有100个整型元素，每一个数都为前一个数的3倍，第1个数为2。

        long[] array = new long[100];

        array[0] = 2;

        for (int i = 1; i < 100; i ++)
        {
            int scale = 3;
            for (int j = 1; j < i; j ++)
            {
                scale *= 3;
            }

            array[i] = array[0] * scale;
        }

        for (int i = 0; i < array.Length; i ++)
        {
            Debug.Log(array[i]);
        }
    }


    void HomeWork_09(int color)
    {
        //已知一个灯有三种颜色，红色，绿色和蓝色。0对应红色，1对应绿色，其它数字对应蓝色，当数字为9时，请打印此时的颜色。（请使用switch关键字）

        switch (color)
        {
            case 0:
                Debug.Log("红色");
                break;
            case 1:
                Debug.Log("绿色");
                break;
            default:
                Debug.Log("蓝色");
                break;
        }

    }

    void HomeWork_10()
    {
        // 打印99乘法口诀表
        // 1x1 = 1
        // 1x2 = 2 2x2 = 4
        // 1x3 = 3 2x3 = 6 3x3 = 9
        // 1x4 = 4 2x4 = 8 3x4 = 12 4x4 = 16

        for (int i = 1; i <= 9; i ++)
        {
            string str = " ";
            for (int j = 1; j <= i; j ++)
            {
                str += j.ToString() + "x" + i.ToString() + " = " + (i * j).ToString() + " ";
            }

            str += "\n";

            Debug.Log(str);
        }
    }
}
