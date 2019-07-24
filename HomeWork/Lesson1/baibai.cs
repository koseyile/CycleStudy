using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1HWbaibai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1. 打印1-100中的所有数

        /*
        for (int i = 0; i <= 100; i++)
        {
            Debug.Log(i);
        }
        */



        //2. 打印1-100中所有偶数

        /*
        for (int i = 0; i <= 100; i++)
        {
            if (i % 2 == 0)
            {
                Debug.Log(i);
            }
        }
        */



        //3. 打印1-100中所有奇数

        /*
        for (int i = 0; i <= 100; i++)
        {
            if (i % 2 == 1)
            {
                Debug.Log(i);
            }
        }
        */




        //4. 打印1-100中所有素数

        /*
        for (int i = 2; i <= 100; i++)
        {
            int count = 0;

            for (int j = 2; j <= i - 1; j++)
            {
                if (i % j == 0)
                {
                    count += 1;
                }
            }

            if (count == 0) {
                Debug.Log(i);
            }
        }
        */



        //5. 打印这样一些数，这些数处于0到100之间，这些数是偶数并且这些数乘以它自身大于50

        /*
        for (int i = 1; i < 100; i++) {
            if (i % 2 == 0 && (i*i > 50))
            {
                Debug.Log(i);
            }
        }
        */




        //6. 打印这样一些数，这些数处于0到100之间，这些数是偶数或者这些数乘以它自身大于50

        /*
        for (int i = 1; i < 100; i++)
        {
            if (i % 2 == 0 || (i * i > 50))
            {
                Debug.Log(i);
            }
        }
        */





        //7. 编程求出1+2+3.。。100=？

        /*
        int sum = 0;

        for (int i = 1; i <= 100; i++)
        {
            sum += i;
        }

        Debug.Log(sum);
        */




        //8. 打印输出平方值小于100的最大整数

        /*
        int result = 1;

        for (int i = 2; i <= 100; i++)
        {
            if (i * i < 100 && i > result) {
                result = i;
            }
            else if (i * i >=100)
            {
                break;
            }
        }

        Debug.Log(result);
        */



        //9. 求出半径为8.6的圆面积

        /*
        float r = 8.6f;

        Debug.Log(3.14 * r * r);
        */



        //10. 打印10-99中所有个位数加十位数为偶数的数

        /*
        for (int i = 10; i < 100; i++)
        {
            int s = i % 10;
            int d = (i - s) / 10;

            if ((s + d) % 2 == 0) {
                Debug.Log(i);
            }
        }
        */













    }


}
