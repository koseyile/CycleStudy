using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2HWbaibai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //1. 请输出如下字符串”12345...100”

        /*
        string myString = "";

        for (int i=1; i<=100; i++) {
            myString += i;
        }

        Debug.Log(myString);
        */




        //2. 请输出如下字符串“123换行456换行789….100”

        /*
        string myString = "";

        for (int i=1; i<=100; i++) {

            myString += i;

            if (i%3==0)
            {
                myString += "\n";
            } 
            
        }

        Debug.Log(myString);
        */




        //3. 假设1对应字母a，2对应字母b，3对应字母c，以此类推，请打印以下数字分别对应的字母：13,24,12, 7, 9, 10, 6.

        /*
        string letters = "abcdefghijklmnopqrstuvwxyz";      

        int[] myList = new int[]{13,24,12,7,9,10,6};

        for (int i = 0; i < myList.Length; i++) {

            int idx = myList[i]-1;

            Debug.Log(letters[idx]);
        }
        */




        //4. 请打印满足以下条件的所有数字：大于0小于1000的正整数，个位数加十位数等于9, 十位数乘以百位数为偶数，百位数乘以个位数为奇数。


        /*
        for (int i = 1; i < 1000; i++) {
            int a = i / 100;
            int b = (i - a * 100) / 10;
            int c = i % 10;

            if ((b+c ==9) && ((b*a)%2 == 0) && ((a*c)%2 !=0)) {

                Debug.Log(i);
            }
        }
        */




        //5. 请打印如下图形：
        //*
        //**
        //***
        //****
        //*****

        /*
        string star = "* ";
        string pattern = "";

        for (int i=0; i<5; i++) {

            for (int j = 0; j < 5; j++) {

                if (j <= i)
                {
                    pattern += star[0];
                }
                else {

                    pattern += star[1];
                }


                if (j == 4) {

                    pattern += "\n";
                }
            }
            
        }

        Debug.Log(pattern);
        */




        //6. 请打印以下图形：
        //####$
        //###$$
        //##$$$
        //#$$$$

        /*
        string star = "#$";
        string pattern = "";

        for (int i = 0; i < 4; i++)
        {

            for (int j = 4; j >= 0; j--)
            {

                if (j > i)
                {
                    pattern += star[0];
                }
                else
                {
                    pattern += star[1];
                }

                if (j == 0)
                {
                    pattern += "\n";
                }
            }

        }

        Debug.Log(pattern);
        */




        //7.Zz忘记了4位数字密码的顺序，只记得是以下4位数字: 3，8，9，7。请打印出所有的可能性，帮助zz找回密码。

        /*
        int[] zz = new int[] { 3, 8, 9, 7 };
        int[] pw = new int[4];

        for (int i = 0; i < zz.Length; i++) {
            for (int j = 0; j < zz.Length; j++) {
                if (j != i)
                {
                    for (int k = 0; k < zz.Length; k++)
                    {
                        if (k != j && k != i)
                        {
                            for (int m = 0; m < zz.Length; m++)
                            {
                                if (m != k && m != j && m != i) {
                                    pw[i] = zz[0];
                                    pw[j] = zz[1];
                                    pw[k] = zz[2];
                                    pw[m] = zz[3];

                                    string testpw = "";
                                    testpw += pw[0];
                                    testpw += pw[1];
                                    testpw += pw[2];
                                    testpw += pw[3];
                                    Debug.Log(testpw);
                                }
                            }
                        }
                    }
                }
            }
        }
        
        */




        //8. 请打印数组所有元素：此数组有100个整型元素，每一个数都为前一个数的3倍，第1个数为2。

        /*
        ulong[] elements = new ulong[100];

        elements[0] = 2;
        Debug.Log(elements[0]);

        for (int i = 1; i < elements.Length; i++) {
            elements[i] = elements[i - 1] * 3;
            Debug.Log(elements[i]);

            //Debug.Log("i = " + i + " " + elements[i-1] + " " +elements[i]);
            //整型 int[] 从i=19 开始变成负数了 overflow??
        }
        */




        //9. 已知一个灯有三种颜色，红色，绿色和蓝色。0对应红色，1对应绿色，其它数字对应蓝色，当数字为9时，请打印此时的颜色。（请使用switch关键字）

        /*
        int n = 9;

        switch (n) {
            case 0:
                Debug.Log("the light is red");
                break;
            case 1:
                Debug.Log("the light is green");
                break;
            default:
                Debug.Log("the light is blue");
                break;
        }
        */






        //10. 打印99乘法口诀表
        //1x1 = 1
        //1x2 = 2 2x2 = 4
        //1x3 = 3 2x3 = 6 3x3 = 9
        //1x4 = 4 2x4 = 8 3x4 = 12 4x4 = 16

        /*
        string table = "";

        for (int i = 1; i <= 9; i++) {

            for (int j = 1; j <= i; j++) {

                table += j;
                table += "x";
                table += i;
                table += " = ";
                table += j * i;

                if (j != i)
                {
                    table += " ";
                }
                else
                {
                    table += "\n";
                }
 
            }

        }

        Debug.Log(table);
        */


    }

}
