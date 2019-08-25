using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WuwuLesson9 : MonoBehaviour
{
    //1. 声明一个水果类，具有如下成员：颜色，名称，重量。
    public class Fruit
    {
        public string Color;
        public string Name;
        public float Weight;

        //不太明白为什么要写构造函数，再实例化
        public Fruit(string co, string na, float we) 
        {
            Color = co;
            Name = na;
            Weight = we;
        }
        public Fruit(string na)
        {
            Name = na;
        }

    }
    //2. 声明一个苹果类继承自水果类，实例化一个1斤重的红色苹果。
    public class Apple : Fruit
    {
        //萌萌写的不一样，构造函数里的变量是新的变量，还是和父类的构造函数里的变量一模一样？
        public Apple(string co, string na, float we) : base(co, na, we)
        {

        }
    }

    public class Animal
    {
        public string Name;
        public Fruit[] favorFruits;
        public Animal Bestfriend;

        public Animal(string name, Fruit[] favoriteF)
        {
            Name = name;
            favorFruits = favoriteF;
        }
       public Animal()
        {

        }
    }
    public class Human : Animal
    {
        public Human(string name, Fruit[] favoriteF) : base(name, favoriteF)
        {
            Name = name;
            favorFruits = favoriteF;
        }
        public Human()
        {

        }
    }
    
    public class Monkey : Animal
    {
        public Monkey(string name, Fruit[] favoriteF) : base(name, favoriteF)
        {
            Name = name;
            favorFruits = favoriteF;
        }
    }


    float Fruitsweight(Fruit[] Fruits,string colorx,string namex, float weightx, float weighty)
    {
        float totalweight = 0;
        for (int i = 0; i < Fruits.Length;i++)
        {
            Fruits[i] = new Apple(colorx, namex, Random.Range(weightx, weighty));
            float eachweight = Fruits[i].Weight;
            totalweight += eachweight;
        }
        return totalweight;
    }


   float Totalprice(float greenweight,float redweight, int greenprice, int redprice)
    {
         return greenweight*greenprice+redweight * redprice;
    }

    string Fruitname(Fruit[] Fruits)
    {
        string namef = "";
        for (int f = 0; f < Fruits.Length; f++)
        {
            namef += Fruits[f].Name;
        }
        return namef;
    }

    // Start is called before the first frame update
    void Start()
    {
        //实例化一个1斤重的红色苹果
        Apple apple = new Apple("red","苹果", 1.0f);
        Debug.Log("第二题实例化一个" + apple.Weight + "斤重的" + apple.Color + apple.Name);

        //3.随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量
        Apple[] AppleQ3 = new Apple[10];
        float Q3weight = Fruitsweight(AppleQ3,"red","Apple", 0.1f, 1.5f);
        Debug.Log("第三题随机实例化10个红苹果的总重量是" + Q3weight);

        //4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
        Apple[] greenapples = new Apple[5];
        float greenweightQ4 = Fruitsweight(greenapples, "green", "Apple", 0.5f, 1.8f);
        Debug.Log("绿苹果" + greenweightQ4 + "斤");

        Apple[] redapples = new Apple[6];
        float redweightQ4 = Fruitsweight(redapples, "red", "Apple", 0.2f, 1.2f);
        Debug.Log("红苹果" + redweightQ4 + "斤");

        float totalprice=Totalprice(greenweightQ4, redweightQ4, 8, 12);
        Debug.Log("第四题苹果总价是"+ totalprice+"元");

        //5. 白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
        Animal[] animals = new Animal[4];
     
        Fruit[] baibaifavorF = new Fruit[2];
        baibaifavorF[0] = new Fruit("Apple");
        baibaifavorF[1] = new Fruit("Orange");
        animals[0] = new Human("baibai", baibaifavorF);
        //6. 遍历数组，打印出白白喜欢吃的水果的名称和颜色。
        Debug.Log("baibai喜欢吃" + Fruitname(baibaifavorF));

        Fruit[] wuwufavorF = new Fruit[2];
       
        wuwufavorF[0]= new Fruit("Apple");
        wuwufavorF[1]= new Fruit("waterlemon"); 
        animals[1] = new Human("wuwu", wuwufavorF);
        Debug.Log("wuwu喜欢吃" + Fruitname(wuwufavorF));

        Fruit[] ddfavorF = new Fruit[2];
        
        ddfavorF[0]=new Fruit("cherry");
        ddfavorF[1] = new Fruit("lemon");
        animals[2] = new Human("dandan", ddfavorF);
        Debug.Log("dandan喜欢吃" + Fruitname(ddfavorF));

        Fruit[] MonkeyfavorF = new Fruit[1];
        MonkeyfavorF[0] = new Fruit("banana");
        
        animals[3] = new Monkey("小猴子", MonkeyfavorF);
        Debug.Log("小猴子喜欢吃" + Fruitname(MonkeyfavorF));

      
        ////7.遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。
        for (int x = 0; x < animals.Length; x++)
        {
            if (animals[x] is Human == false)
            Debug.Log("数组里非人是"+animals[x].Name + "喜欢吃"+Fruitname(animals[x].favorFruits));
        }

        //8. 已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，
        //打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色
        animals[0].Bestfriend= animals[1];
        animals[1].Bestfriend = animals[2];
        animals[2].Bestfriend = animals[3];
        animals[3].Bestfriend = animals[0];

        Fruit[] fruitx = animals[0].Bestfriend.Bestfriend.Bestfriend.favorFruits;
        Debug.Log("打印出白白的好朋友的好朋友的好朋友喜欢吃的水果"+ Fruitname(fruitx));
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
