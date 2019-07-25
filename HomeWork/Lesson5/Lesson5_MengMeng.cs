using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_MengMeng : MonoBehaviour
{

    //From Naomi:
    //军训回来第一次摸底考试之后，今天是选学习委员和班长的日子。班里一共20人。候选人一共有三人：zz数学85分，语文95，英语80分，和20个同学互换了微信成为亲密的朋友；wuwu数学88分，语文94分，英语82分，和13个同学互换了微信成为亲密的朋友；baibai数学98分，语文87分，英语90分，和5个同学互换了微信成为亲密的朋友。
    //* 1.建立候选人结构体；
    //* 2.写出以成绩总分最高的来选出学习委员的函数并打印学委的名字。
    //* 3.写出以人缘和成绩总分来选出班长的函数并打印班长的名字。

    //From baibai:
    //泰罗奥特曼
    //身高：53米
    //体重：55000吨
    //飞行速度：20马赫
    //母亲：奥特之母
    //出生地：M78星云
    //现在地：仙女座星云

    //塞文21奥特曼
    //身高：56米
    //体重：57000吨
    //飞行速度：26马赫
    //搭档：奈欧斯奥特曼
    //出生地：M78星云
    //现在地：M78星云

    //* 4.定义一个奥特曼结构体，包含上述所有数据
    //* 5.编写一个函数，输入参数为奥特曼结构体，打印泰罗和爱迪的速度各为多少米每秒。
    //* 6.M78星云，距离地球300万光年。仙女座星云距离地球254万光年。现发现怪兽贝劳克恩第9代出现在地球。编写一个函数，输入为奥特曼结构体、星云与地球的距离，求出哪个奥特曼会先到达地球。

    //From wupeng:
    //海拉鲁平原上封印着一把上古神剑，传说中曾有四位上古英雄都在不同时间拥有过这把剑，并用它击退恶魔。
    //这把神剑的神奇之处在于它会吸收主人的能力封存在剑身之中，当下一任使用者使用该剑时，只要喊出曾经英雄的名字，就可以召唤出已逝英雄的神灵来释放它的一个技能协助作战

    //这四位上古英雄和他们的技能分别是：
    //- 克里斯提娜（魔法雨 打击敌人 30伤害并减少敌人10的速度），
    //- 卡罗兰约克（精准砍劈 以打击敌人50伤害，并提高自己的防御的2倍），
    //- 卡尔斯鲁厄(献祭：自损60生命值，提高自身战斗力100)，
    //- 哥德史密斯（面壁：防御值增加3倍）
    //* 7.如今林克得到了这把剑，他拿着这把剑来到了被恶魔缠绕的城堡门口，面对恶魔它大喊一声：“卡尔斯鲁厄”！如果林克的属性为:生命100, 攻击60, 防御40.请问他此时的属性是多少。请设计相应的数据结构并计算输出。

    //这把剑还有一个特殊之处在于，林克只要喊出“英雄的名字” + “附身”这样的咒语，上古英雄的属性便会突然加到林克身上。假设
    //- 克里斯提娜的属性生命60, 攻击100 防御 70;
    //- 卡罗兰约克的属性为生命150，攻击60， 防御120；
    //- 卡尔斯鲁厄的属性为 生命150，攻击90， 防御40；
    //- 哥德史密斯 属性  生命70，攻击70， 防御150.
    //* 8.如果这时林克大喊一身“克里斯提娜附身！”，请问这时林克的属性为多少？ 请设计或修改数据结构，并设计附身技能函数，打印并输出结果。  

    //在于恶魔对战的过程中，林克受到了重伤，在林克弥留之际，他将上古神剑交给了呀哈哈。将自己的魂魄注入神剑，与上古英雄们重聚，成为他们的一员。如今呀哈哈拿到了神剑，但是呀哈哈对上古神剑生命的不感冒，把他丢在了角落里。
    //神剑生锈了，每一年都会流逝上古英雄的能量，假设每一年上古神剑中所有英雄的属性都会流逝10%。
    //* 9.请问10年后，当呀哈哈喊出“林克附身”这句话时，请打印呀哈哈的属性。假设呀哈哈的当前属性为生命30，攻击1， 防御5.

    //From mengmeing:
    //1. wuwu、baibai、zz三人斗地主，请用一个结构体表示所有的牌的数据。
    //2. 实例化一套牌。
    //3. 请写一个函数（传入的参数是刚刚实例化的那套牌）为他们三个人发牌，并打印出每个人的手牌



    // Start is called before the first frame update
    // -------------------------------------------------------------------------------------
    struct Student
    {
        public string Name;
        public int ChineseScore;
        public int MathScore;
        public int EnglishScore;
        public int WechatFriendsNum;
        public Student(string name, int chinese, int math, int english, int friends)
        {
            Name = name;
            ChineseScore = chinese;
            MathScore = math;
            EnglishScore = english;
            WechatFriendsNum = friends;
        }
    }

    Student SelectStudySecretary(params Student[] students)
    {
        Student StudySecretary = new Student();
        int MaxScore = 0;
        foreach (Student student in students)
        {
            if (student.ChineseScore + student.EnglishScore + student.MathScore > MaxScore)
            {
                MaxScore = student.ChineseScore + student.EnglishScore + student.MathScore;
                StudySecretary = student;
            }
        }
        return StudySecretary;
    }
    Student SelectMonitor(params Student[] students)
    {
        Student Monitor = new Student();
        int MaxScore = 0;
        foreach (Student student in students)
        {
            if (student.ChineseScore + student.EnglishScore + student.MathScore + student.WechatFriendsNum > MaxScore)
            {
                MaxScore = student.ChineseScore + student.EnglishScore + student.MathScore + student.WechatFriendsNum;
                Monitor = student;
            }
        }
        return Monitor;
    }

    // -------------------------------------------------------------------------------------
    struct Ultraman
    {
        public string Name;
        public int Height;
        public int Weight;
        public int Speed;
        public string Monther;
        public string Partener;
        public string Brithplace;
        public string Livingplace;

        public Ultraman(string name, int height, int weight, int speed, string monther, string partener, string brithplace, string livingplace)
        {
            Name = name;
            Height = height;
            Weight = weight;
            Speed = speed;
            Monther = monther;
            Partener = partener;
            Brithplace = brithplace;
            Livingplace = livingplace;
        }
    }

    int GetUltramanSpeed(ref Ultraman ultraman)
    {
        Debug.Log(ultraman.Name + "的速度为" + (ultraman.Speed * 340).ToString() + "米每秒");
        return ultraman.Speed * 340;
    }
    void GetFristArriveUltraman(ref Ultraman ultramanA, int DistanceA, ref Ultraman ultramanB, int DistanceB)
    {
        if (DistanceA / ultramanA.Speed < DistanceB / ultramanB.Speed)
            Debug.Log(ultramanA.Name + "先到地球");
        else if (DistanceA / ultramanA.Speed > DistanceB / ultramanB.Speed)
            Debug.Log(ultramanB.Name + "先到地球");
        else
            Debug.Log("两者一起到");

    }


    // -------------------------------------------------------------------------------------
    struct Hero
    {
        public string Name;
        public int Health;
        public int Attack;
        public int Defend;

        //题目里还提到里速度属性，但也没用上，我就偷懒不加了
        public Hero(string name, int hp, int atk, int def)
        {
            Name = name;
            Health = hp;
            Attack = atk;
            Defend = def;
        }
    }

    //只实现技能卡尔斯鲁厄的话，skill的结构不需要太复杂，如果还要实现其他技能的效果的话，那就要再加很多东西，或者用到反射之类的方法，这里就不做了
    struct Skill
    {
        public string Name;
        public int Damage;
        public int AddAtk;
        public Skill(string name, int damage, int addatk)
        {
            Name = name;
            Damage = damage;
            AddAtk = addatk;
        }
    }

    void CastSkill(Skill skill, ref Hero Caster, ref Hero Target)
    {
        Target.Health = Mathf.Max(0, Target.Health - skill.Damage);
        Target.Attack += skill.AddAtk;
    }
    void AddAttribute(ref Hero Carrier, ref Hero Adder)
    {
        Carrier.Health += Adder.Health;
        Carrier.Attack += Adder.Attack;
        Carrier.Defend += Adder.Defend;
    }
    void HeroLostPower(ref Hero hero, int year)
    {
        if (year > 0)
        {
            hero.Health -= hero.Health / 10;
            hero.Attack -= hero.Attack / 10;
            hero.Defend -= hero.Defend / 10;
            HeroLostPower(ref hero, --year);
        }

    }
    void ShowHeroAttribute(ref Hero hero)
    {
        Debug.Log(hero.Name + "的生命值为：" + hero.Health + "，攻击力为：" + hero.Attack + "， 防御力为：" + hero.Defend);
    }


    // -------------------------------------------------------------------------------------
    struct Poker
    {
        public enum Variety { 黑桃, 红心, 梅花, 方片, 王 };
        public Variety variety;
        public int points;

        public Poker(int var, int P)
        {
            variety = (Variety)var;
            points = P;
        }
        public Poker(Variety var, int P)
        {
            variety = var;
            points = P;
        }
    }

    void SetPokers(ref List<Poker> pokers)
    {
        for (int i = 1; i <= 13; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Poker card = new Poker(j, i);
                pokers.Add(card);
            }
        }
        pokers.Add(new Poker(Poker.Variety.王, 1));
        pokers.Add(new Poker(Poker.Variety.王, 2));
    }
    void DrawaCard(ref List<Poker> PlayerCards, ref List<Poker> CardsPile)
    {
        int Dice = Random.Range(1, CardsPile.Count);
        PlayerCards.Add(CardsPile[Dice]);
        CardsPile.RemoveAt(Dice);
    }
    void GetHandCards(ref List<Poker> PlayerA, ref List<Poker> PlayerB, ref List<Poker> PlayerC, ref List<Poker> CardsPile)
    {
        for(int i = 1; i<=17;i++)
        {
            DrawaCard(ref PlayerA, ref CardsPile);
            DrawaCard(ref PlayerB, ref CardsPile);
            DrawaCard(ref PlayerC, ref CardsPile);
        }
        PlayerC.AddRange(CardsPile);
        CardsPile = new List<Poker>();
    }
    void ShowPlayerHand(string PlayerName , ref List<Poker> PlayerCards)
    {
        string Result = PlayerName + "的手牌：";
        foreach(Poker poker in PlayerCards )
        {
           if(poker.variety != Poker.Variety.王)
            {
                Result += poker.variety.ToString() + poker.points.ToString();
            }
           else
            {
                if (poker.points == 1)
                    Result += "小王";
                else if (poker.points == 2)
                    Result += "大王";
            }
           if(PlayerCards.LastIndexOf(poker) < PlayerCards.Count -1)
            {
                Result += "，";
            }
            else
            {
                Result += "。";
            }
        }
        Debug.Log(Result);
    }

    void Start()
    {
        Debug.Log("------------From Naomi:--------------");
        Student zz = new Student("zz", 95, 85, 80, 20);
        Student wuwu = new Student("wuwu", 94, 88, 82, 13);
        Student baibai = new Student("baibai", 87, 98, 90, 5);

        Student StudySecretary = SelectStudySecretary(zz, wuwu, baibai);
        Debug.Log("学习委员是" + StudySecretary.Name);
        Student Monitor = SelectMonitor(zz, wuwu, baibai);
        Debug.Log("班长是" + Monitor.Name);


        Debug.Log("------------From baibai:--------------");
        Ultraman Taylor = new Ultraman("泰罗", 53, 55000, 20, "奥特之母", "", "M78星云", "仙女座星云");
        Ultraman Seven = new Ultraman("塞文", 56, 57000, 26, "", "奈欧斯奥特曼", "M78星云", "M78星云");
        GetUltramanSpeed(ref Taylor);
        GetUltramanSpeed(ref Seven);
        GetFristArriveUltraman(ref Taylor, 254, ref Seven, 300);


        Debug.Log("------------From wupeng:--------------");
        Hero Link = new Hero("林克", 100, 60, 40);
        Skill Karlsruhe = new Skill("卡尔斯鲁厄", 60, 100);
        CastSkill(Karlsruhe, ref Link, ref Link);
        ShowHeroAttribute(ref Link);

        Hero Cristina = new Hero("Cristina", 60, 100, 70);
        AddAttribute(ref Link, ref Cristina);
        ShowHeroAttribute(ref Link);

        Hero Yahaha = new Hero("Yahaha", 30, 1, 5);
        HeroLostPower(ref Link, 10);
        AddAttribute(ref Yahaha, ref Link);
        ShowHeroAttribute(ref Yahaha);

        Debug.Log("------------From mengmeng:--------------");
        List<Poker> pokers = new List<Poker>();
        SetPokers(ref pokers);
        List<Poker> ZZ = new List<Poker>();
        List<Poker> WuWu = new List<Poker>();
        List<Poker> BaiBai = new List<Poker>();
        GetHandCards(ref ZZ, ref WuWu, ref BaiBai, ref pokers);
        ShowPlayerHand("zz", ref ZZ);
        ShowPlayerHand("wuwu", ref WuWu);
        ShowPlayerHand("baibai", ref BaiBai);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
