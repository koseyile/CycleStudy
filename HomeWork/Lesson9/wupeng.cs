using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WuPengSpace
{
    public class wupeng : MonoBehaviour
    {
        /*问题1：我没有创建哈密瓜等类，因为Animal中只需要一个Fruit的对象。如果创建了哈密瓜等类，
                就需要在Animal类的对象中实例化一个特定的哈密瓜对象。题目中么只是说喜欢吃什么类
                型，没有说喜欢哪一个哈密瓜，不知道我这样理解对不对

          问题2: 87行

          问题3： 有没有办法将父类型转换为子类型？ */


        Apple apple;
        Apple[] apples;
        Apple[] redApples;
        Apple[] greenApples;

        void Start()
        {

            //02.声明一个苹果类继承自水果类，实例化一个1斤重的红色苹果
            apple = new Apple("red", "", 1.0f);

            //03. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
            apples = InstantiateApples(10, 0.1f, 1.5f, "红色");
            float weight = CaculateWeight(apples);
            Debug.Log("03.总重量" + weight + "kg");

            //04. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
            greenApples = InstantiateApples(5, 0.5f, 1.8f, "绿色");
            redApples = InstantiateApples(6, 0.2f, 1.2f, "红色");
            float redmoney = CaculateApplePrice(8.0f, greenApples);
            float greenmoney = CaculateApplePrice(12.0f, redApples);
            Debug.Log("04.总价为" + (redmoney + greenmoney) + "元");

            //05.白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。

            Human baibai = new Human("baibai", new Fruit[] { new Fruit("红色", "苹果", 0.0f), new Fruit("", "橘子", 0.0f) }, null);
            Human wuwu = new Human("wuwu", new Fruit[] { new Fruit("红色", "苹果", 0.0f), new Fruit("", "西瓜", 0.0f) }, null);
            Human dandan = new Human("dandan", new Fruit[] { new Fruit("紫红", "樱桃", 0.0f), new Fruit("", "哈密瓜", 0.0f) }, null);
            Monkey monkey = new Monkey("monmon", new Fruit[] { new Fruit("黄色", "香蕉", 0.0f) }, null);

            Animal[] animals = new Animal[4];

            animals[0] = baibai;
            animals[1] = wuwu;
            animals[2] = dandan;
            animals[3] = monkey;

            //06. 遍历数组，打印出白白喜欢吃的水果的名称和颜色。
            Debug.Log("06:");
            for (int i = 0; i < animals.Length; i++)
            {

                if (animals[i].name == "baibai")
                {
                    animals[i].SayMyFavouriteFruit();
                }
            }

            //07.遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。
            Debug.Log("07:");
            for (int i = 0; i < animals.Length; i++)
            {

                if (animals[i].type != "Human")
                {
                    animals[i].SayMyFavouriteFruit();
                }
            }

            //08.已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色。
            baibai.friend = wuwu;
            wuwu.friend = dandan;
            dandan.friend = monkey;
            monkey.friend = baibai;

            Debug.Log("08:");

            baibai.friend.friend.friend.SayMyFavouriteFruit();
        }


        public Apple[] InstantiateApples(int num, float minWeight, float maxHeight, string color)
        {
            Apple[] apples = new Apple[num];// apples的引用在stack上，它的内容（10个Apple变量）是在heap上吗？10个apple变量都是引用类型，每一个apple的内容是在heap中，他们的引用也在heap中吗？

            for (int i = 0; i < apples.Length; i++)
            {
                apples[i] = new Apple(color, "苹果", Random.Range(minWeight, maxHeight));
            }

            Debug.Log("随机生成" + num + "个苹果");

            return apples;
        }

        float CaculateWeight(Apple[] apples)
        {
            float sum = 0.0f;
            if (apples != null)
            {
                for (int i = 0; i < apples.Length; i++)
                {
                    sum += apples[i].weight;
                }
                return sum;
            }

            Debug.LogError("无法计算苹果重量，传入苹果为空");
            return 0.0f;
        }

        float CaculateApplePrice(float price, Apple[] apples)
        {
            float sum = 0.0f;

            if (apples != null)
            {
                for (int i = 0; i < apples.Length; i++)
                {
                    sum += apples[i].weight * price;
                }
                return sum;
            }

            Debug.LogError("无法计算苹果价格，传入苹果为空");

            return sum;
        }

    }


    //相关类

    public class Fruit
    {
        public string color;
        public string name;
        public float weight;

        public Fruit()
        {
        }

        public Fruit(string c, string n, float w)
        {
            color = c;
            name = n;
            weight = w;
        }
    }

    public class Apple : Fruit
    {
        public Apple(string c, string n, float w) : base()
        {
            color = c;
            name = n;
            weight = w;
        }
    }

    public class Animal
    {
        public Fruit[] favouriteFruits;
        public string name;
        public Animal friend;
        public string type;

        public void SayMyFavouriteFruit()
        {
            Debug.Log("我叫" + name);
            foreach (Fruit f in favouriteFruits)
            {
                Debug.Log(", 我喜欢吃" + f.name + "颜色是" + f.color);
            }
        }
    }

    public class Human : Animal
    {
        public Human(string n, Fruit[] favrourite, Animal f)
        {
            type = "Human";
            name = n;
            favouriteFruits = favrourite;
            friend = f;
        }
    }
    public class Monkey : Animal
    {
        public Monkey(string n, Fruit[] favrourite, Animal f)
        {
            type = "Monkey";
            name = n;
            favouriteFruits = favrourite;
            friend = f;
        }
    }
}
