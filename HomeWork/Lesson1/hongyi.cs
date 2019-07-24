using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //1

        /* for (int i=1; i<=100; i++)
        {

            Debug.Log(i);
                      
        } */



        //2

        /* for (int i = 1; i <= 100; i++)
        {
        
        if (i%2 == 0)
            Debug.Log(i);

        } */



        //3

        /* for (int i = 1; i <= 100; i++)
        {
        
        if (i%2 == 1)
            Debug.Log(i);

        } */




        //4 (结合百度搜索，答案应该是对的但是有些部分不是很理解)

        /* bool s = false;
        for (int i = 2; i <= 100; i++)
        {
            s = true;
            for (int m = 2; m < i; m++)
            {
                if (i % m == 0)
                {
                    s = false; break;
                }
            }
            if (s)
                Debug.Log(i);
            }
            */



        //5

        /* for (int i = 0; i <= 100; i++)
        {
        
        if ((i % 2 == 0) && (i * i > 50))
            Debug.Log(i);

        } */



        //6

        /* for (int i = 0; i <= 100; i++)
        {

            if ((i % 2 == 0) || (i * i > 50))
                Debug.Log(i);

        } */



        //7

        /* int sum = 0;
        for (int i = 1; i <= 100; i++)
        

            sum = sum + i;

        {
            Debug.Log(sum);
        } */




        //8



        /* for (int i = 0; i < 100; i++)

         if ((i * i < 100) && (i + 1) * (i + 1) >= 100)

                { Debug.Log(i);

        }
        */       



        //9

        /* const float pi = 3.1415927f;
        const float r = 8.6f;
        Debug.Log(pi * r * r); 
        */



        //10 ？？？

        /*for (int i = 10; i <= 99; i++)
         */



















    }


}
