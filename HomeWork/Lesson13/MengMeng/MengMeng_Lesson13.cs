using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace MengMeng
{
    public class MengMeng_Lesson13 : ScriptableObject
    {
        [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }
    }

    #region Question 4
    public class AllBrids
    {
        protected double Runspeed;
        protected string WingsColor;
        protected string FavoriteFood;

        public void SetRunspeed(double speed)
        {
            Runspeed = speed;
        }
        public void SetWingsColor(string color)
        {
            WingsColor = color;
        }
        public void SetFavoriteFood(string food)
        {
            FavoriteFood = food;
        }
    }
    public class FlyBrids : AllBrids
    {
        protected double Flyspeed;
        public void SetFlyspeed(double speed)
        {
            Flyspeed = speed;
        }
    }
    public class Ostrich : AllBrids
    {
        public Ostrich()
        {
            SetRunspeed(30);
            SetWingsColor("tan");
            SetFavoriteFood("apple");
        }
    }
    public class SeaMew : FlyBrids
    {
        public SeaMew()
        {
            SetFlyspeed(20);
            SetWingsColor("gray");
            SetFavoriteFood("sardine");
        }
    }
    public class SeaSwallow : FlyBrids
    {
        public SeaSwallow()
        {
            SetFlyspeed(80);
            SetWingsColor("brown");
            SetFavoriteFood("shrimp");
        }
    }
    #endregion

    #region Question 5
    public class People
    {
        readonly string name;
        public Food food;
        public Clothing clothing;

        public void Shopping(Shop shop)
        {
            Object @object = shop.Selling();
            if (@object.GetType() == typeof(Food))
            {
                food = (Food)@object;
            }
            else if (@object.GetType() == typeof(Clothing))
            {
                clothing = (Clothing)@object;
            }
        }
        public void Eating(Food food)
        {
            food = null;
        }
        public void Wearing(Clothing clothing)
        {

        }
        public void Giving(Object @object, People people)
        {
            if (@object.GetType() == typeof(Food))
            {
                people.food = (Food)@object;
                food = null;
            }
            else if (@object.GetType() == typeof(Clothing))
            {
                people.clothing = (Clothing)@object;
                clothing = null;
            }
        }
    }

    interface IShopping
    {
        Object Selling();
    }

    public class Object
    {
        protected string name;

        public Object(string _name)
        {
            name = _name;
        }

    }
    public class Food : Object
    {
        public Food(string _name) : base(_name)
        {
            name = _name;
        }
    }
    public class Clothing : Object
    {
        public Clothing(string _name) : base(_name)
        {
            name = _name;
        }
    }
    public class Shop : IShopping
    {
        readonly string name;
        public Object Selling()
        {
            return new Object("");
        }
    }
    public class FruitShop : Shop
    {
        public Object Selling()
        {
            return new Food("watermelon");
        }
    }
    public class ClothingShop : Shop
    {
        public Object Selling()
        {
            return new Clothing("hat");
        }
    }

    public class Main_5
    {
        void Start()
        {
            People NingNing = new People();
            People WuWu = new People();
            People zz = new People();
            FruitShop fruitShop = new FruitShop();
            ClothingShop clothingShop = new ClothingShop();
            NingNing.Shopping(fruitShop);
            NingNing.Shopping(clothingShop);
            NingNing.Giving(NingNing.food, WuWu);
            NingNing.Giving(NingNing.clothing, zz);
            WuWu.Eating(WuWu.food);
            zz.Wearing(zz.clothing);
        }
    }
    #endregion


    #region Question 5
    public class Director
    {
        readonly string name;

        public void Direct(Developer developer)
        {

        }


    }

    public class Developer
    {
        readonly string name;

        public AnimationMovie GenerateContent()
        {
            return new AnimationMovie();
        }

    }
    public class AnimationMovie
    {
        readonly string name;
        Script script;
        Charactor charactor;
        Scene scene;
        Animator animator;
        Music music;
        VoiceCast voiceCast;
    }
    public class Script { }
    public class Charactor { }
    public class Scene { }
    public class Animator { }
    public class Music { }
    public class VoiceCast { }

    public class Audience
    {
        readonly string name;

        public void WatchingAnimationMovie(AnimationMovie animationMovie)
        {

        }
    }
    #endregion
}

