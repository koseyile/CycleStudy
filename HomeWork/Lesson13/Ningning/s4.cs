//    4.请使用UML图画出以下事物之间的关系：
//    * 海鸥的飞行速度是20，翅膀为灰色，最喜欢吃的食物是沙丁鱼。
//    * 海燕的飞行速度是80，翅膀为棕色，最喜欢吃的食物是小虾。
//    * 鸵鸟的奔跑速度是30，翅膀为褐色，最喜欢吃的食物是苹果。


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s4 : MonoBehaviour
{
    /// <summary>
    /// 简单工厂模式
    /// 定义一个共同接口，创建不同的对象，简化创建过程，创建与表示分离
    /// </summary>
    // Use this for initialization
    void Start()
    {
        //根据不同的条件选择不同的动物
        SimpleFactory.CreateAnimal("HaiOu").Print();
        SimpleFactory.CreateAnimal("HaiYan").Print();
        SimpleFactory.CreateAnimal("TuoNiao").Print();

    }

    // Update is called once per frame
    void Update()
    {

    }



    public class Animals
    {
        public float FlySpeed;
        public string Wing;
        public string FavouritFood;
        public string Name;


        public void Print()
        {
            Debug.Log(Name + "的飞行速度是" + FlySpeed + "翅膀为" + Wing + "最喜欢吃的食物是" + FavouritFood);
        }

    }

    public class HaiOu : Animals
    {

        public HaiOu(string _name, float _FlySpeed, string _Wing, string _FavouriteFood)
        {
            Name = _name;
            FlySpeed = _FlySpeed;
            Wing = _Wing;
            FavouritFood = _FavouriteFood;

        }
    }

    public class HaiYan : Animals
    {

        public HaiYan(string _name, float _FlySpeed, string _Wing, string _FavouriteFood)
        {
            Name = _name;
            FlySpeed = _FlySpeed;
            Wing = _Wing;
            FavouritFood = _FavouriteFood;

        }
    }

    public class TuoNiao : Animals
    {

        public TuoNiao(string _name, float _FlySpeed, string _Wing, string _FavouriteFood)
        {
            Name = _name;
            FlySpeed = _FlySpeed;
            Wing = _Wing;
            FavouritFood = _FavouriteFood;

        }
    }

    public class food
    {
        public string FoodName;
        

    }




    ///简单工厂管理
    public class SimpleFactory
    {
        public static Animals CreateAnimal(string idx)
        {
            switch (idx)
            {
                case "HaiOu":
                    return new HaiOu("haiou", 20, "grey", "sardine");
                case "HaiYan":
                    return new HaiYan("tuoniao", 80, "brown", "xiaoxia");
                case "TuoNiao":
                    return new TuoNiao("haiou", 40, "brown", "apple");

                default:
                    return null;
            }
        }
    }
}

