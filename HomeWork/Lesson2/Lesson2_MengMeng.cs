using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson2_MengMeng : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //1. 输出字符串""12345...100"
        Debug.Log("第1题");

        Debug.Log("12345...100");

        //2.输出指定字符串
        Debug.Log("第2题");

        Debug.Log("123\n456\n789....100");

        //3. 1对应字母a，2对应b以此类推，打印以下数字对应的字母：13，24，12，7，9，10，6
        Debug.Log("第3题");

        //我的思路是使用强制类型转换，把字符转成ASCII码，可以少写一些代码
        int ascii_A = (int)'a';
        Debug.Log((char)(ascii_A + 13));
        Debug.Log((char)(ascii_A + 24));
        Debug.Log((char)(ascii_A + 12));
        Debug.Log((char)(ascii_A + 7));
        Debug.Log((char)(ascii_A + 9));
        Debug.Log((char)(ascii_A + 10));
        Debug.Log((char)(ascii_A + 6));

        //4. 打印大于0小于1000，并且个位数加十位数等于9，十位数乘百位数为偶数，百位数乘个位数为奇数的数
        Debug.Log("第4题");
        for (int i = 100; i < 1000; i++)
        {
            int units = (i % 100) % 10;
            int tens = (i / 10) % 10;
            int hundreds = i / 100;
            if (units + tens == 9 && (tens * hundreds) % 2 == 0 && (units * hundreds) % 2 == 1)
                Debug.Log(i);
        }

        //5. 打印特定图形
        Debug.Log("第5题");
        string Answer_5 = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Answer_5 += "*";
            }
            Answer_5 += "\n";
        }
        Debug.Log(Answer_5);

        //6. 打印特定图形
        Debug.Log("第6题");
        string Answer_6 = string.Empty;
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                if (j + i <= 5)
                    Answer_6 += "#";
                else
                    Answer_6 += "$";
            }
            Answer_6 += "\n";
        }
        Debug.Log(Answer_6);

        //7.打印3、8、9、7组成的所有可能的四位数
        //这题用递归会好做一些，但是还没教的话就写4遍for循环了。
        Debug.Log("第7题");
        int[] list = new int[] { 3, 8, 9, 7 };
        for (int i = 0; i < list.Length; i++)
        {
            string Answer_7 = string.Empty;
            Answer_7 += list[i];
            for (int j = 0; j < list.Length; j++)
            {
                if (Answer_7.Contains(list[j].ToString()))
                    continue;
                Answer_7 += list[j];
                for (int x = 0; x < list.Length; x++)
                {
                    if (Answer_7.Contains(list[x].ToString()))
                        continue;
                    Answer_7 += list[x];
                    for (int y = 0; y < list.Length; y++)
                    {
                        if (Answer_7.Contains(list[y].ToString()))
                            continue;
                        Answer_7 += list[y];
                        Debug.Log(Answer_7);
                        Answer_7 = Answer_7.Remove(3);

                    }
                    Answer_7 = Answer_7.Remove(2);
                }
                Answer_7 = Answer_7.Remove(1);
            }
            Answer_7 = Answer_7.Remove(0);
        }

        //8.打印一个100个元素的数组，每一个元素的值是上一个的3倍，第一个数是2
        //以立方速度增长，int很快就放不下了，于是会有负数
        Debug.Log("第8题");
        int[] array_8 = new int[100];
        array_8[0] = 2;
        for (int i = 1; i < array_8.Length; i++)
        {
            array_8[i] = array_8[i - 1] * 3;
        }
        for (int j = 0; j < array_8.Length; j++)
        {
            Debug.Log(array_8[j]);
        }
        //9.用switch关键字，0对红色，1对绿色，其他对蓝色，数字为9时，打印此时颜色
        Debug.Log("第9题");
        int Num = 9;
        switch (Num)
        {
            case 0:
                Debug.Log("Red");
                break;
            case 1:
                Debug.Log("Green");
                break;
            default:
                Debug.Log("Blue");
                break;
        }
        //10.打印乘法口诀表
        Debug.Log("第10题");
        string Answer_10 = string.Empty;
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Answer_10 += j.ToString() + "×" + i.ToString() + "=" + (i * j).ToString() + " ";
                if (i == j)
                    Answer_10 += "\n";
            }
        }
        Debug.Log(Answer_10);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
