using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zzlesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		/*
        //第一题：输出如下字符串“12345...100”
       
        //先搞错了，结果练习了下数组的表达...
        int[] ii = new int[100];

        for (int i = 0; i< ii.Length; i++) {
            ii[i] = i+1;           
        
            Debug.Log(ii[i]);
        }
       */
		//正确的来了
		/*
		 string a = string.Empty;
		 for (int i = 1; i <= 100; i++)
			 a = a + i;
		 Debug.Log(a);
		 */

		//第二题：输出如下字符串“123换行456换行...100”
		/*
        string a = string.Empty;
		{ 
        for (int i = 1; i <= 100; i++)
			{
				a = a + i;
				if (i % 3 == 0)
				{
					Debug.Log(a + "\n");
				}
			}
		Debug.Log(a);
		}
		
		*/

		//第三题： 假设1对应字母a，2对应字母b，3对应字母c，以此类推，
		//请打印以下数字分别对应的字母：13,24,12, 7, 9, 10, 6.
        /*
        string myString = "abcdefghijklmnopqrstuvwxyz";
		{
			int[] num = { 13, 24, 12, 7, 9, 10, 6 };
			for (int n = 0; n < num.Length; ++n)
			{
				int x = num[n] - 1;
				Debug.Log(myString[x]);
			}
		}

        */
		

		//第四题： 请打印满足以下条件的所有数字：大于0小于1000的正整数，个位数加十位数等于9,
		//十位数乘以百位数为偶数，百位数乘以个位数为奇数。
        /*
		for(int i = 100; i < 1000; i++)
		{
            int b=i%100;
            int s=i/100;

		}
            
			Debug.Log(ii[i]);
           */


		//第五题：请打印如下图形：这两道题的解法。。哈哈哈哈哈。。大神不要打我
		//*
	    //**
	    //***
	    //****
	    //*****

        /*
        string s="*\n**\n***\n****\n*****";

            Debug.Log(s);
        */

		//第六题：请打印如下图形：
        //####$
		//###$$
        //##$$$
        //#$$$$

        /*
		string c = "####$\n###$$\n##$$$\n#$$$$";

		Debug.Log(c);
        */

		//第七题：Zz忘记了4位数字密码的顺序，只记得是以下4位数字
		//:3，8，9，7。请打印出所有的可能性，帮助zz找回密码。

        //这道题有四处找资料学习，并和学渣们一起学习了一下（毕竟自己的密码一定要想起来）
		/*
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

		//第八题：请打印数组所有元素，此数组有100个整形元素，每一个数都为前一个数的3倍，第1个数为2.
		/*
        int[] ii = new int[100];

		for (int i = 0; i < ii.Length; i++)
		{
			困到想不出
		}
        */


		//第九题；已知一个灯有三种颜色，红色，绿色和蓝色。0对应红色，1对应绿色，
		//其它数字对应蓝色，当数字为9时，请打印此时的颜色。（请使用switch关键字）
		/*
        int i=9;
		switch(i)
		{
            case 0:
			{
               Debug.Log("red");
			}
            break;

            case 1:
			{
               Debug.Log("green");
			}
			break;
           
            default:
			{
               Debug.Log("blue");
			}
            break;
          
		}
        
    */

		//第十题：九九乘法表。baibai提示了一些思路，奈何我没有时间研究这题了，我估计也研究不出来。。。

        
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
