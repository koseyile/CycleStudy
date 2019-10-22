using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson13_Naomi
{

    //4. 请使用UML图画出以下事物之间的关系：
    //* 海鸥的飞行速度是20，翅膀为灰色，最喜欢吃的食物是沙丁鱼。
    //* 海燕的飞行速度是80，翅膀为棕色，最喜欢吃的食物是小虾。
    //* 鸵鸟的奔跑速度是30，翅膀为褐色，最喜欢吃的食物是苹果。

    public class Wing
    {
        public Color color;
    }

    public class Animal
    {
        protected int Speed;
        protected Wing wing;
        protected Food FavoriteFood;

        public Animal(string _specie, int _speed, Wing _wing, Food _food)
        {
            Speed = _speed;
            wing = _wing;
            FavoriteFood = _food;
        }

        public int GetSpeed()
        {
            return Speed;
        }

        public Color GetWingColor()
        {
            return wing.color;
        }

        public Food GetFavoriteFood()
        {
            return FavoriteFood;
        }
    }

    public class Seagull : Animal
    {

        public Seagull(string _seagull, int _speed, Wing _wing, Food _food):base(_seagull,_speed,_wing,_food)
        {
            Speed = _speed;
            wing = _wing;
            FavoriteFood = _food;
        }
    }

    public class Petrel : Animal
    {

        public Petrel(string _petrel, int _speed, Wing _wing, Food _food):base(_petrel, _speed, _wing, _food)
        {
            Speed = _speed;
            wing = _wing;
            FavoriteFood = _food;
        }
    }

    public class Ostrich : Animal
    {

        public Ostrich(string _ostrich, int _speed, Wing _wing, Food _food):base(_ostrich, _speed, _wing, _food)
        {
            Speed = _speed;
            wing = _wing;
            FavoriteFood = _food;
        }
    }



    public class Food
    {

    }

    public class Sardine : Food
    {

    }

    public class Shrimp : Food
    {

    }


    public class Apple : Food
    {

    }


    //5. 宁宁最喜欢的行为是购物，一天，宁宁路过一家水果店时，买了一个西瓜。路过一家服装店时，买了一个帽子。宁宁把西瓜送给了巫巫，巫巫吃掉了。宁宁把帽子送给zz，zz把帽子戴在了头上。请使用UML图画出宁宁，水果店，西瓜，服装店，帽子，巫巫，zz之间的关系。

    public class Shop
    {
        private Goods goods;

        public Goods Selling()
        {
            return goods;
        }
    }

    public class FruitShop : Shop
    { }

    public class ClothingShop : Shop
    { }

    public class Goods
    { }

    public class Fruit : Goods
    { }

    public class Watermelon : Fruit
    { }

    public class Clothing : Goods
    { }

    public class Hat : Clothing
    { }

    public class Human
    {
        private string HumanName;
        public Goods goods;

        public Human(string _name)
        {
            HumanName = _name;
            goods = null;
        }

        public void Shopping(Goods _g)
        {
            goods = _g;
        }

        public void Giving(Goods _g, Human _name)
        {
            goods = null;
            _name.goods = _g;
        }

        public void Eat(Goods goods)
        {
            if (goods.GetType() == typeof(Fruit))
            {
                goods = null;
            }
        }

        public void Wear()
        {

        }
    }


    //6. 白白是一位勤劳的建造者，这一次，白白打算制作一部短片给某位大佬看，一部动画片由以下几部分组成，故事剧本，人物设计，场景设计，动画制作，音乐，配音等。白白请来了朋友们一起帮忙，最终成功完成了这部动画，大佬给出了很高的评价。
    //请将大佬抽象为观众类，白白抽象为导演类，朋友们抽象为开发者类，请使用UML图画出他们的关系。


    public class Director
    {
        private string Name;
        private AnimatedShortFilm FilmName;

        public Director(string _name)
        {
            Name = _name;
            FilmName = null;
        }

        public void CallingFriends(List<Developer> friends)
        {

        }

        public AnimatedShortFilm DirectFilm()
        {
            return FilmName;
        }

        public void ShowToAudience(Audience _a)
        {

        }
    }

    public class Developer
    {
        private string Name;

        public Developer(string _name)
        {
            Name = _name;
        }

        public FilmPart DevelopFilmPart()
        {
            return new FilmPart();
        }

    }

    public class AnimatedShortFilm
    {
        //private string Name;
        //private Script script;
        //private CharactorDesign charactordesign;
        //private SetDesign setdesign;
        //private Animation animation;
        //private Soundtrack soundtrack;
        //private SoundDesign sounddesign;
    }

    //问题：组合关系体现在代码中是继承关系吗？
    public class FilmPart
    { }

    public class Script : FilmPart
    { }
    public class CharactorDesign : FilmPart
    { }
    public class SetDesign : FilmPart
    { }
    public class Animation : FilmPart
    { }
    public class Soundtrack : FilmPart
    { }
    public class SoundDesign : FilmPart
    { }

    public class Audience
    {
        private string name;

        public void CommentFilm(AnimatedShortFilm _film)
        {
            Debug.Log("我给出很高的评价");
        }
    }


    public class lesson13_naomi : MonoBehaviour
    {
        void Start()
        {
            //7. 请将第4题转化为c#代码。
            //======================================================实例化==================================================================

            Food sd = new Sardine();
            Wing greywing = new Wing();
            Seagull sg = new Seagull("seagull", 20, greywing, sd);

            Food shrimp = new Shrimp();
            Wing brownwing = new Wing();
            Petrel pt = new Petrel("petrel", 20, brownwing, shrimp);

            Food apple = new Apple();
            Wing hazelwing = new Wing();
            Ostrich os = new Ostrich("ostrich", 20, hazelwing, apple);


            //8. 请将第5题转化为c#代码。
            //======================================================实例化==================================================================
            Human Ningning = new Human("Ningning");
            Human Wuwu = new Human("wuwu");
            Human Zz = new Human("zz");

            FruitShop fruitShop = new FruitShop();
            ClothingShop clothingShop = new ClothingShop();

            Ningning.Shopping(fruitShop.Selling());
            Ningning.Giving(Ningning.goods, Wuwu);
            Wuwu.Eat(Wuwu.goods);

            Ningning.Shopping(clothingShop.Selling());
            Ningning.Giving(Ningning.goods, Zz);
            Zz.Wear();


            //9. 请将第6题转化为c#代码。
            //======================================================实例化==================================================================
            Director Baibai = new Director("baibai");
            List<Developer> friends = new List<Developer>
            {
                new Developer("writer"),
                new Developer("charactordesigner"),
                new Developer("setdesigner"),
                new Developer("animator"),
                new Developer("composer"),
                new Developer("sounddesigner"),
            };
            Audience dalao = new Audience();

            Baibai.CallingFriends(friends);
            Baibai.ShowToAudience(dalao);
            dalao.CommentFilm(Baibai.DirectFilm());
        }
    }
}
