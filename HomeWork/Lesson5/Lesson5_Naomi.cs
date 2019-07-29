using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_Naomi : MonoBehaviour
{
    // 1.建立候选人结构体；
    struct candidate
    {
        public string name;
        public int math;
        public int chi;
        public int eng;
        public int wechatFriends;
    }

    //2.写出以成绩总分最高的来选出学习委员的函数并打印学委的名字。
    int totalScore(ref candidate a)
    {
        int totalA = a.math + a.chi + a.eng;

        return totalA; 
    }

    string SelectStudyCommissary(candidate[] candidates)
    {
        int index = 0;
        int maxScore = 0;

        for (int i = 0; i < candidates.Length; i++)
        {
            int score = totalScore(ref candidates[i]);
            if (score > maxScore)
            {
                maxScore = score;
                index = i;
            }
        }
        return candidates[index].name;
    }

    //3.写出以人缘和成绩总分来选出班长的函数并打印班长的名字。

    int totalConditions(ref candidate a)
    {
        int totalConditionsA = a.math + a.chi + a.eng + a.wechatFriends;

        return totalConditionsA;
    }

    string SelectCaptain(candidate[] candidates)
    {
        int index = 0;
        int maxConditions = 0;

        for (int i = 0; i < candidates.Length; i++)
        {
            int score = totalConditions (ref candidates[i]);
            if (score > maxConditions)
            {
                maxConditions = score;
                index = i;
            }
        }
        return candidates[index].name;
    }

    //4.定义一个奥特曼结构体，包含上述所有数据
    struct Ultraman
    {
        public string Name;
        public int Height;
        public int Weight;
        public int Speed;
        public string Mother;
        public string Partner;
        public string BirthPlace;
        public string CurrentLocation;
    }

    //5.编写一个函数，输入参数为奥特曼结构体，打印泰罗和爱迪(塞文？)的速度各为多少米每秒。
    int CalculateSpeed(ref Ultraman altman)
    {
        return altman.Speed * 340;
    }
   
    //6.M78星云，距离地球300万光年。仙女座星云距离地球254万光年。现发现怪兽贝劳克恩第9代出现在地球。编写一个函数，输入为奥特曼结构体、星云与地球的距离，求出哪个奥特曼会先到达地球。
    string FirstUltraman(ref Ultraman altman1, ref int distance1, ref Ultraman altman2, ref int distance2)
    {
        if (distance1 < distance2)
        {
            return altman1.Name;
        }
        else if (distance1 < distance2)
        {
            return altman2.Name;
        }
        else
        {
            return altman1.Name + "和" + altman2.Name;
        }
    }

    //7.如今林克得到了这把剑，他拿着这把剑来到了被恶魔缠绕的城堡门口，面对恶魔它大喊一声：“卡尔斯鲁厄”！如果林克的属性为:生命100, 攻击60, 防御40.请问他此时的属性是多少。请设计相应的数据结构并计算输出。
    struct Hero
    {
        public string Name;
        public int Health;
        public int Attack;
        public int Defend;
    }

    struct HeroSkill
    {
        public string Name;
        public int Damage;
        public int CutSpeed;
        public int TimesDefend;
        public int AddAttack;
        public int SelfDamage;
    }

    void CallHeroSkill(ref Hero player, ref HeroSkill calledHero)
    {
        player.Health -= calledHero.SelfDamage;
        player.Attack += calledHero.AddAttack;
    }

    string PrintProperty(ref Hero hero)
    {
        string result = hero.Name + "的生命值为：" + hero.Health + "，攻击力为：" + hero.Attack + "， 防御力为：" + hero.Defend;
        return result;
    }

    //* 8.如果这时林克大喊一身“克里斯提娜附身！”，请问这时林克的属性为多少？ 请设计或修改数据结构，并设计附身技能函数，打印并输出结果。 
    void HeroPossess(ref Hero player, ref Hero calledHero)
    {
        player.Health += calledHero.Health;
        player.Attack += calledHero.Attack;
        player.Defend += calledHero.Defend;
    }

    //9.请问10年后，当呀哈哈喊出“林克附身”这句话时，请打印呀哈哈的属性。假设呀哈哈的当前属性为生命30，攻击1， 防御5.

    int PropertyDecay(int property, int year)
    {

        if (year == 0)
        {
            return property;
        }
        else
        {
            return PropertyDecay(property, year - 1) - (PropertyDecay(property, year - 1) / 10);
        }
    }

    void HeroDecay (ref Hero hero,int year)
    {
        hero.Attack = PropertyDecay(hero.Attack, year);
        hero.Health = PropertyDecay(hero.Health, year);
        hero.Defend = PropertyDecay(hero.Defend, year);
    }

    //问：直接用hero struct递归失败的原理？
    //Hero PowerDecay(Hero hero, int year)
    //{
    //    Hero hero1 = new Hero();
    //    if (year == 0)
    //    {
    //        return hero;
    //    }
    //    else
    //    {
    //        hero1.Health -= PowerDecay(hero, year - 1).Health / 10;
    //        hero1.Attack -= PowerDecay(hero, year - 1).Attack / 10;
    //        hero1.Defend -= PowerDecay(hero, year - 1).Defend / 10;
    //        return hero1;
    //    }
    //}

    //From mengmeing:
    //1. wuwu、baibai、zz三人斗地主，请用一个结构体表示所有的牌的数据。
    //2. 实例化一套牌。
    //3. 请写一个函数（传入的参数是刚刚实例化的那套牌）为他们三个人发牌，并打印出每个人的手牌

    struct Card
    {
        public int Type; 
        public int Num; 
    }


    struct Deck
    {
        public Card[] Spade;
        public Card[] Heart;
        public Card[] Club;
        public Card[] Diamond;
        public Card[] Joker;
    }

    string PrintCard(ref Card card)
    {
        string cardFace= "";
        switch (card.Type)
        {
            case 0:
                {
                    cardFace = "王";
                }
                break;
            case 1:
                {
                    cardFace = "♠";
                }
                break;
            case 2:
                {
                    cardFace = "♥";
                }
                break;
            case 3:
                {
                    cardFace = "♣";
                }
                break;
            case 4:
                {
                    cardFace = "♦";
                }
                break;
        }

        if (card.Type == 0)
        {
            if (card.Num == 1)
            {
                cardFace = "大" + cardFace;
            }
            else
            {
                cardFace = "小" + cardFace;
            }
        }
        else
        {
            if (card.Num == 1)
            {
                cardFace += "A"; 
            }
            else if (card.Num == 12)
            {
                cardFace += "Q";
            }
            else if (card.Num == 13)
            {
                cardFace += "K";
            }
            else if (card.Num == 11)
            {
                cardFace += "J";
            }
            else
            {
                cardFace += card.Num;
            }
        }
        return cardFace;

    }

    void ShuffleCards(ref Deck deck)
    {
        int total = deck.Spade.Length + deck.Heart.Length + deck.Club.Length + deck.Diamond.Length + deck.Joker.Length;
        for (int i = 0; i < 5; i++)
        {
            int cardType = Random.Range(0, i);
            
        }

    }

    void Start()
    {
        //From Naomi----------------------------------------------------

        candidate[] threeCan = new candidate[3];

        threeCan[0].name = "zz";
        threeCan[0].math = 85;
        threeCan[0].chi = 95;
        threeCan[0].eng = 80;
        threeCan[0].wechatFriends = 20;

        threeCan[1].name = "wuwu";
        threeCan[1].math = 88;
        threeCan[1].chi = 94;
        threeCan[1].eng = 82;
        threeCan[1].wechatFriends = 13;

        threeCan[2].name = "baibai";
        threeCan[2].math = 98;
        threeCan[2].chi = 87;
        threeCan[2].eng = 90;
        threeCan[2].wechatFriends = 5;

        string studyCom = SelectStudyCommissary(threeCan);
        Debug.Log("2." + "学习委员: " + studyCom);

        string captain = SelectCaptain(threeCan);
        Debug.Log("3." + "班长: " + captain);

        //From baibai----------------------------------------------------

        Ultraman Taro = new Ultraman();
        Taro.Name = "泰罗";
        Taro.Height = 53;
        Taro.Weight = 55000;
        Taro.Speed = 20;
        Taro.Mother = "MotherofUltra";
        Taro.BirthPlace = "M78星云";
        Taro.CurrentLocation = "仙女座星云";

        Ultraman Seven21 = new Ultraman();
        Seven21.Name = "赛文21";
        Seven21.Height = 56;
        Seven21.Weight = 57000;
        Seven21.Speed = 26;
        Seven21.Partner = "Neos";
        Seven21.BirthPlace = "M78星云";
        Seven21.CurrentLocation = "M78星云";

        int taroSpeed = CalculateSpeed(ref Taro);
        int seven21Speed = CalculateSpeed(ref Seven21);
        Debug.Log("5." + "泰罗的速度： " + taroSpeed + "米每秒; " + "赛文21的速度： " + seven21Speed + "米每秒");


        int distanceTaro = 254;
        int distanceSeven21 = 300;

        string firstArrive = FirstUltraman(ref Taro, ref distanceTaro, ref Seven21, ref distanceSeven21);
        Debug.Log("6." + firstArrive + "奥特曼先到地球");

        //From wupeng----------------------------------------------------
        Hero Link = new Hero();
        Link.Name = "林克";
        Link.Health = 100;
        Link.Attack = 60;
        Link.Defend = 40;

        HeroSkill Karlsruhe = new HeroSkill();
        Karlsruhe.SelfDamage = 60;
        Karlsruhe.AddAttack = 100;

        CallHeroSkill(ref Link, ref Karlsruhe);
        string calledKarlsruhe = PrintProperty(ref Link);
        Debug.Log("7." + "大喊一声：“卡尔斯鲁厄”后" + calledKarlsruhe);

        Hero christina = new Hero();
        christina.Name = "克里斯提娜";
        christina.Health = 60;
        christina.Attack = 100;
        christina.Defend = 70;

        HeroPossess(ref Link, ref christina);
        string calledChristinaPossess = PrintProperty(ref Link);
        Debug.Log("8." + "大喊一身“克里斯提娜附身！" + calledChristinaPossess);

        Hero Yahaha = new Hero();
        Yahaha.Health = 30;
        Yahaha.Attack = 1;
        Yahaha.Defend = 5;

        HeroDecay(ref Link, 10);
        HeroPossess(ref Yahaha, ref Link);
        string calledLinkPossess = PrintProperty(ref Yahaha);
        Debug.Log("9." + "10年后，当呀哈哈喊出“林克附身”这句话时" + calledLinkPossess);

        //From mengmeng----------------------------------------------------
        //2. 实例化一套牌。

        Card[] spade = new Card[13];
        Card[] heart = new Card[13];
        Card[] club = new Card[13];
        Card[] diamond = new Card[13];
        Card[] joker = new Card[2];
        Deck theDeck = new Deck();
        theDeck.Spade = spade;
        theDeck.Heart = heart;
        theDeck.Club = club;
        theDeck.Diamond = diamond;
        theDeck.Joker = joker;

        //3.请写一个函数（传入的参数是刚刚实例化的那套牌）为他们三个人发牌，并打印出每个人的手牌


    }
}
