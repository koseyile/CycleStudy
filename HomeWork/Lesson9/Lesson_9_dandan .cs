using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace dandan
{
    //1.声明一个水果类, 成员有颜色、名称、重量
    public class Fruit
    {
        public string color;
        public float weight;
        public string name;

    }

    //2.声明苹果继承水果类，实例化一斤重的红苹果
    public class Apple : Fruit
    {

        void Start()
        {
            Apple redapple = new Apple();
            redapple.color = "red";
            redapple.weight = 1;

        }

        public float price;
        public void totalprice(float x, float y)
        {
            float z = x * y;
            Debug.Log(z);
        }
    }


    public class dandan : MonoBehaviour
    {
        void Start()
        {
            // 3. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量
            //没有报错但是就一直跑不出来……！

            Apple[] apples = new Apple[10];

            for (int i = 0; i < 10; i++)
            {
                apples[i].weight = Random.Range(0.1f, 1.5f);

                apples[i].color = "red";

            }

            float totalweight = 0;

            for (int i = 0; i < 10; i++)
            {
                totalweight += apples[i].weight;

            }
            Debug.Log(totalweight);


            //4.绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价

            Apple[] greenapple = new Apple[5];
            Apple[] redapple = new Apple[6];
            for (int i = 0; i < 5; i++)
            {
                greenapple[i].color = "green";
                greenapple[i].weight = Random.Range(0.5f, 1.8f);
                greenapple[i].price = 8 * greenapple[i].weight;

            }
            float greenprice = 0;

            for (int i = 0; i < 5; i++)
            {
                greenprice += greenapple[i].price;
            }

            for (int i = 0; i < 6; i++)
            {
                redapple[i].color = "red";
                redapple[i].weight = Random.Range(0.2f, 1.2f);
                redapple[i].price = 12 * redapple[i].weight;
            }
            float redprice = 0;

            for (int i = 0; i < 6; i++)
            {
                redprice += redapple[i].price;
            }

            Debug.Log(greenprice + redprice);


        }
    }
    //对不起我努力了T_T只写了4题……
}
        

   
