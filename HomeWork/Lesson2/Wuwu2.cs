using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wuwu2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*(可跑通)
        //1.请输出如下字符串”12345...100”

         string str = string.Empty;
         {
         for (int i = 1; i <= 100; i++) 
         {
         str+=i;
         }
             Debug.Log(str);
         }
       */

        /* 会抛出很多行，这个跑的逻辑不懂
        //2.请输出如下字符串“123换行456换行789….100”
        string str = string.Empty;
        {
            for (int i = 1; i <= 100; i++)
            {
                str += i;
                //str.Length和str[]都不能被赋值啊，为什么
                {
                    if (i % 3 == 0)
                    {
                        Debug.Log(str+"\n");
                    }

                }
            }
            Debug.Log(str);

        }
        */

        /*(可跑通)
        //3.假设1对应字母a，2对应字母b，3对应字母c，以此类推，请打印以下数字分别对应的字母：13,24,12, 7, 9, 10, 6.
         string myString = "abcdefghijklmnopqrstuvwxyz";//定义好字符串
         {
         int[] num= {13, 24, 12, 7, 9, 10, 6};//声明一个数组
           for (int i = 0; i < num.Length; ++i)//num的长度复制给i
           {
               int x = num[i]-1;
               Debug.Log(myString[x]);
           }
         }
        */



        /*(可跑通)
      //4.请打印满足以下条件的所有数字：大于0小于1000的正整数，个位数加十位数等于9, 十位数乘以百位数为偶数，百位数乘以个位数为奇数。

      for (int i = 0; i <=1000; i++)
       { if (i >= 10 && i< 100)
          { int a = i/ 10;//双位数的十位数
              int b = i-a*10;//双位数的十位数
              if (a+b==9)
                  Debug.Log(i);
          }
        if (i >= 100 && i < 1000)
          {
              int c = i/100;//百位数
              int d = (i-c*100)/10;//十位数
                  int e =(i-c*100-d*10);//个位数
              if(e+d==9 ||(d*c)%2==0 ||(c*e)%2!=0 )
              Debug.Log(i);
          }

       }
        * /

        /*
      //5.请打印如下图形：
      //    1. *
      //    2. * *
      //    3. * **
      //    4. * ***
      //    5. * ****
      
        string str = "* ****";//我理解是每次多打印一个下标的字符串，每次空一行；
        string new ={ };
        for (int i=0;i<str.Length;i++)
        {
            int index = i;
            string new = str{index}
            Debug.Log(new {index} +"\n");
         }
       */

        /*这个方法应该不对
       //6.请打印以下图形：
       //    1. ####$
       //    2. ###$$
       //    3. ##$$$
       //    4. #$$$$
       string str1 = "####$\n###$$\n##$$$\n#$$$$";
       { Debug.Log(str1); }
       */


        /*(可跑通)
         //7.Zz忘记了4位数字密码的顺序，只记得是以下4位数字: 3，8，9，7。请打印出所有的可能性，帮助zz找回密码。
         int[] code = { 3, 8, 9, 7 };
         for (int i = 0; i <4; i++)
         {
             for (int j = 0; j < 4; j++)
             { if (j == i)
                     continue;
                 {
                     for (int k = 0; k < 4; k++)
                     {
                         if (k == j || k == i)
                             continue;
                         {
                             for (int g = 0; g < 4; g++)
                             {
                                 if (g == i || g == j || g == k)
                                     continue;
                                 Debug.Log(code[i] + " " + code[j] + " " + code[k] + " " + code[g]);
                             }

                         }
                     }
                 }
             }

         }
          */

        /* 不行
        //8.请打印数组所有元素：此数组有100个整型元素，每一个数都为前一个数的3倍，第1个数为2。
        int[] num = new int[100];
         num[0] = 2;
         {
           for (int i= 0;i<100; i++)
             { if(i==0)
                    Debug.Log(2);
                if (i == 1)
                    Debug.Log(6);
                if (i >1 )
                num[i+1] = num[i] * 3;
                Debug.Log(num);
             }

        }
        */




        /*(可跑通)
        //9.已知一个灯有三种颜色，红色，绿色和蓝色。0对应红色，1对应绿色，其它数字对应蓝色，当数字为9时，请打印此时的颜色。（请使用switch关键字）
          for (int i=0;i<=9; i++)
        {
            switch(i)
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
        */


        //10.打印99乘法口诀表（多维数组？选择放弃）
        //1. 1x1 = 1
        //2. 1x2 = 2 2x2 = 4
        //3. 1x3 = 3 2x3 = 6 3x3 = 9
        //4. 1x4 = 4 2x4 = 8 3x4 = 12 4x4 = 16


    }

    // Update is called once per frame
    void Update()
    {

    }
}
