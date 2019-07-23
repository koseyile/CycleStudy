using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wuwutest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       //1. 打印1-100中的所有数

        for (int i = 0; i <= 100; i++)
        {
            Debug.Log(i);
        }
        //2. 打印1-100中的所有偶数

        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 0)
            { Debug.Log(i); }
        }

        //3. 打印1-100中的所有奇数

        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 1)
            {
                Debug.Log(i);
            }
        }

        //4. 打印1-100中的所有素数

        for (int i = 1; i <= 100; i++)
        {
            for (int j = 2; j <= i; j++)//找第二个比i小的变量
            {
                if (i % j == 0 && i != j)
                { break; }//第二个变量从2直到i的数中都求余跑一次，有任何能被整除的并且不等于i的话就跳出循环，说明不是质数
                //提问：break是不是把这个条件成立的数字，从这个循环中剔除的意思？
                if (j == i)//接下来再把剩下的数字开始判断，这个数是不是等于i，等于的话就说明是质数，开始打印
                {
                    {
                        Debug.Log(i);
                    }
                }

            }
        }


        //5. 打印这样一些数，这些数处于0到100之间，这些数是偶数并且这些数乘以它自身大于50
        for (int i = 0; i <= 100; i++)
        {
            if (i % 2 == 0 && i * i > 50)
            {
                Debug.Log(i);
            }
        }

        //6. 打印这样一些数，这些数处于0到100之间，这些数是偶数或者这些数乘以它自身大于50
        for (int i = 0; i <= 100; i++)
        {
            if (i % 2 == 0 || i * i > 50)
            {
                Debug.Log(i);
            }
        }
        //7. 编程求出1+2+3+4+…100=？
        int sum = 0;
        for (int i = 1; i <= 100; i++)
        { sum = sum + i;
        }//把所有的跑到100为止；
        {
            Debug.Log(sum);//输出sum这个结果
        }


        //8. 打印输出平方值小于100的最大整数。

        for (int i = 1; i < 100; i++)
        { if( (i * i < 100) && ((i + 1) * (i + 1) >= 100))
         Debug.Log(i);
         }
        //如果这个整数平方小于100，再加1就大于100了就说明结束可以打印这个数了


        //9.求出半径为8.6的圆面积。
       

            float p = 3.1416f;
            float r = 8.6f;
        
            {
            float area = p * r * r;
                { 
                Debug.Log(area); 
                }
            }




    
        //10. 打印10-99中所有个位数加十位数为偶数的数。
       
          for(int i=10;i<=99;i++)
          { 
            int s = i % 10;
            int g = i / 10; // 增加两个整数变量，j是除以10的余数是个位数，一个除以10的余数就是十位数
             {
              if ((s + g) % 2 == 0)//两个变量增加看是不是偶数，是偶数就打印i
                 {Debug.Log(i);}
             }
          }
            


    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
