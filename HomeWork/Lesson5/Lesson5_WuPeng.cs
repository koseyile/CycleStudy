using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_WuPeng : MonoBehaviour {

    
    // Use this for initialization
    void Start ()
    {
        //======work01======
        Candidate zz = new Candidate() { name = "zz", math = 85, chinese = 95,english = 80, fellowShip = 20 };
        Candidate wuwu = new Candidate() { name = "wuwu", math = 88, chinese = 94, english = 82, fellowShip = 13 };
        Candidate baibai = new Candidate() { name = "baibai", math = 98, chinese = 87, english = 90, fellowShip = 13 };

        //======work02======
        Candidate[] candidates = new Candidate[3] { zz, wuwu, baibai};
        Select_LearningRepresentative(candidates);

        //======work03======
        Select_ClassChief(candidates);

        //======work04======
        Ultraman Tylor = new Ultraman() { name = "Tylor", height = 53, weight = 55000, speed = 20, birth = "M78", now = "仙女", mother = "Ultraman mother" };

        Ultraman Adi = new Ultraman() { name = "Adi", height = 56, weight = 57000, speed = 26, birth = "M78", now = "M78", parterner = "Naos" };

        //======work05======
        ShowUltramanSpeed(ref Tylor);
        ShowUltramanSpeed(ref Adi);

        //======work07======
        float timeTyloy = TimeTravel(ref Tylor, 300);
        float timeAdi = TimeTravel(ref Adi, 254);

        Debug.Log((timeAdi < timeTyloy ? "Adi" : "Tyler") + "先到达");



        //================================== work07，08， 09 ==================================
        //创建Link
        Owner Link = new Owner() {name = "Link", hp= 100, attack = 60, defend = 40};


        //创建英雄集合
        Hero Criststina = new Hero() { name = "Criststina", hp = 60, attack = 100, defend = 70 };

        Hero CarlueJerk = new Hero() { name = "CarlueJerk", hp = 150, attack = 60, defend = 120 };

        Hero KalsLuer = new Hero() { name = "KalsLuer", hp = 150, attack = 90, defend = 40 };

        Hero GoldSmith = new Hero() { name = "GoldSmith", hp = 70, attack = 70, defend = 150 };

        Hero[] heros = new Hero[4] { Criststina, CarlueJerk, KalsLuer, GoldSmith };

        //创建上古神剑
        Sword acientSward = new Sword() { owner = Link, herosSealed = heros};

        //创建敌人
        Enemy enemy = new Enemy() { name = "xxx", attack = 111, hp = 111, defend = 111};

        //实例化一个技能添加到link的技能数组
        Skill skill_KalsLuer = new Skill() { belong = "KalsLuer", name = "sacrifice", selfImpact = new float[3] {-60, 100, 0}, enemyImpact = new float[3] { 20, 20, 20} };

        Link.skill = new Skill[4];

        Link.skill[0] = skill_KalsLuer;

        //work07
        Link.YielName("KalsLuer", ref enemy);

        //work08
        Link.ReCallHero(ref acientSward, "Criststina");

        //work09

        //将Link加入上古神剑
        Owner Yahaha = new Owner() {name = "Yahaha", hp = 30, attack = 1, defend = 5 };
        Hero deadLink = new Hero() { name = "Link", hp = Link.hp, attack = Link.attack, defend = Link.defend};

        Hero[] newHeros = new Hero[5] { Criststina, CarlueJerk, KalsLuer, GoldSmith, deadLink };

        acientSward = new Sword() { owner = Yahaha, herosSealed = newHeros };

        DecreaseSward(ref acientSward, 10);

        Yahaha.ReCallHero(ref acientSward, "Link");

        //======================== work10-1 2 3=============================

        //1
        Player wu = new Player() { name = "wuwu"};

        Player z = new Player() { name = "zz"};

        Player bai = new Player() {name = "baibai" };

        //2
        Cards cards = InstanseTwoCards();

        //3
        DrawCard(ref wu, ref bai, ref z, ref cards);

        ShowPlayerCard(ref wu);

        ShowPlayerCard(ref z);

        ShowPlayerCard(ref bai);




    }

    /*军训回来第一次摸底考试之后，今天是选学习委员和班长的日子。班里一共20人。
      候选人一共有三人：zz数学85分，语文95，英语80分，和20个同学互换了微信成为亲密的朋友；
      wuwu数学88分，语文94分，英语82分，和13个同学互换了微信成为亲密的朋友；
      baibai数学98分，语文87分，英语90分，和5个同学互换了微信成为亲密的朋友。
      1.建立候选人结构体；
      2.写出以成绩总分最高的来选出学习委员的函数并打印学委的名字。
      3.写出以人缘和成绩总分来选出班长的函数并打印班长的名字。
    */
    //work01
    struct Candidate
    {
        public string name;
        public int math;
        public int chinese;
        public int english;
        public int fellowShip;
    }

    //work02 以分数最高 选出学习委员 并打印
    void Select_LearningRepresentative(Candidate[] candidates)
    {
        Candidate top = candidates[0]; //分配了内存，比较占用空间

        for (int i = 0; i < candidates.Length; i++)
        {
            if (TotalScore(ref candidates[i]) > TotalScore(ref top))
                top = candidates[i];
        }

        Debug.Log("学习委员：" + top.name);
    }

    int TotalScore(ref Candidate candidate)
    {
        return candidate.math + candidate.chinese + candidate.english;
    }


    //work03

    void Select_ClassChief(Candidate[] candidates)
    {
        int k = 0;//只分配2个int内存，比较省空间
        int top = 0;

        for (int i = 0; i < candidates.Length; i++)
        {
            if (TotalImpact(ref candidates[i]) > top)
            {
                k = i;
                top = TotalImpact(ref candidates[i]);
            }
        }

        Debug.Log("班长：" + candidates[k].name);
    }

    int TotalImpact(ref Candidate candidate)
    {
        return candidate.math + candidate.chinese + candidate.english + candidate.fellowShip;
    }

    /*
      泰罗奥特曼 身高：53米，体重：55000吨，飞行速度：20马赫，母亲：奥特之母，出生地：M78星云， 现在地：仙女座星云
      塞文21奥特曼，身高：56米，体重：57000吨，飞行速度：26马赫，搭档：奈欧斯奥特曼，出生地：M78星云，现在地：M78星云
      4.定义一个奥特曼结构体，包含上述所有数据
      5.编写一个函数，输入参数为奥特曼结构体，打印泰罗和爱迪的速度各为多少米每秒。
      6.M78星云，距离地球300万光年。仙女座星云距离地球254万光年。现发现怪兽贝劳克恩第9代出现在地球。
      编写一个函数，输入为奥特曼结构体、星云与地球的距离，求出哪个奥特曼会先到达地球。
    */

    struct Ultraman
    {
        public string name;
        public int height;
        public int weight;
        public int speed;

        public string mother;
        public string parterner;
        public string birth;
        public string now;

    };

    void ShowUltramanSpeed(ref Ultraman ultraman)
    {
        Debug.Log(ultraman.name  + "速度：" + ultraman.speed + "马赫");
    }

    float TimeTravel(ref Ultraman ultraman, int dist)
    {
        return dist / ultraman.speed;
    }

    /*
    海拉鲁平原上封印着一把上古神剑，传说中曾有四位上古英雄都在不同时间拥有过这把剑，并用它击退恶魔。
    这把神剑的神奇之处在于它会吸收主人的能力封存在剑身之中，
    当下一任使用者使用该剑时，只要喊出曾经英雄的名字，就可以召唤出已逝英雄的神灵来释放它的一个技能协助作战
    
    这四位上古英雄和他们的技能分别是：
    - 克里斯提娜（魔法雨 打击敌人 30伤害并减少敌人10的速度），
    - 卡罗兰约克（精准砍劈 以打击敌人50伤害，并提高自己的防御的2倍），
    - 卡尔斯鲁厄  (献祭：自损60生命值，提高自身战斗力100)，
    - 哥德史密斯（面壁：防御值增加3倍）
    * 7.如今林克得到了这把剑，他拿着这把剑来到了被恶魔缠绕的城堡门口，
    * 面对恶魔它大喊一声：“卡尔斯鲁厄”！如果林克的属性为:生命100, 攻击60, 防御40.
    * 请问他此时的属性是多少。请设计相应的数据结构并计算输出。
     这把剑还有一个特殊之处在于，林克只要喊出“英雄的名字” + “附身”这样的咒语，上古英雄的属性便会突然加到林克身上。假设
    - 克里斯提娜的属性生命60, 攻击100 防御 70;
    - 卡罗兰约克的属性为生命150，攻击60， 防御120；
    - 卡尔斯鲁厄的属性为 生命150，攻击90， 防御40；
    - 哥德史密斯 属性  生命70，攻击70， 防御150.
    * 8.如果这时林克大喊一身“克里斯提娜附身！”，请问这时林克的属性为多少？ 请设计或修改数据结构，并设计附身技能函数，打印并输出结果。
     在于恶魔对战的过程中，林克受到了重伤，在林克弥留之际，他将上古神剑交给了呀哈哈。
    将自己的魂魄注入神剑，与上古英雄们重聚，成为他们的一员。如今呀哈哈拿到了神剑，但是呀哈哈对上古神剑生命的不感冒，把他丢在了角落里。
    神剑生锈了，每一年都会流逝上古英雄的能量，假设每一年上古神剑中所有英雄的属性都会流逝10%。
    * 9.请问10年后，当呀哈哈喊出“林克附身”这句话时，请打印呀哈哈的属性。假设呀哈哈的当前属性为生命30，攻击1， 防御5.*/


    struct Owner
    {
        public string name;
        public float hp;
        public float attack;
        public float defend;

        public Skill[] skill;

        public void YielName(string name, ref Enemy enemy)
        {
            for (int i = 0; i < skill.Length; i++)
            {
                if (name == skill[i].belong)
                {
                    this.hp += skill[i].selfImpact[0];
                    this.attack += skill[i].selfImpact[1];
                    this.defend += skill[i].selfImpact[2];
                    
                    Debug.Log( this.name + "喊出" + name + ", 林克当前hp:" + this.hp + " attack : " + this.attack + " defend :" + this.defend);
                    
                    enemy.hp += skill[i].enemyImpact[0];
                    enemy.attack += skill[i].enemyImpact[1];
                    enemy.defend += skill[i].enemyImpact[2];
                    Debug.Log("敌人" + enemy.name + ", hp:" + enemy.hp + " attack : " + enemy.attack + " defend :" + enemy.defend);

                }
            }
        }

        public void ReCallHero(ref Sword sword, string name)
        {
            Hero hero;

            for (int i = 0; i < sword.herosSealed.Length; i++)
            {
                if (name == sword.herosSealed[i].name)
                {
                    hero = sword.herosSealed[i];
                    this.hp += hero.hp;
                    this.attack += hero.attack;
                    this.defend += hero.defend;
                    Debug.Log(this.name + "喊出" + name + "附身" + this.name + ", 当前hp:" + this.hp + " attack : " + this.attack + " defend :" + this.defend);
                }
            }
        }
    }

    struct Hero
    {
        public string name;
        public float hp;
        public float attack;
        public float defend;
    }

    struct Enemy
    {
        public string name;
        public float hp;
        public float attack;
        public float defend;
    }

    struct Sword
    {
        public Owner owner;
        public Hero[] herosSealed;
    }

    struct Skill
    {
        public string belong;
        public string name;
        public float[] selfImpact;
        public float[] enemyImpact;
    };
    

    //递归训练
    void DecreaseSward(ref Sword sward, int years)
    {

        int y = years;

        if (y <= 0)
            return;

        for (int i = 0; i < sward .herosSealed.Length; i ++)
        {
            sward.herosSealed[i].hp *= 0.9f;
            sward.herosSealed[i].attack *= 0.9f;
            sward.herosSealed[i].defend *= 0.9f;
        }

        y--;

        DecreaseSward(ref sward, y);
    }



    /*   10-1. wuwu、baibai、zz三人斗地主，请用一个结构体表示所有的牌的数据。
         10-2. 实例化一套牌。
         10-3. 请写一个函数（传入的参数是刚刚实例化的那套牌）为他们三个人发牌，并打印出每个人的手牌 Joker Spade Herat Diamond Club*/

    struct Card
    {
        public string color;
        public int num;
    }

    struct Cards
    {
        public Card[] cards;
    }

    struct Player
    {
        public string name;
        public Card[] cards;
    }

    Cards InstanseCards()
    {
        Cards c = new Cards() { cards = new Card[54]};

        for (int i = 0; i < 52; i ++)
        {
            if (i < 13)
            {
                c.cards[i].color = "Spade";
                c.cards[i].num = i;
            }
            else if (i >= 13 && i < 26)
            {
                c.cards[i].color = "Heart";
                c.cards[i].num = i - 13;
            }
            else if (i >= 26 && i < 39)
            {
                c.cards[i].color = "Diamond";
                c.cards[i].num = i - 26;
            }
            else if (i >= 39 && i < 52)
            {
                c.cards[i].color = "Club";
                c.cards[i].num = i - 39;
            }
        }

        c.cards[52].color = "Joker";
        c.cards[52].num = 0;

        c.cards[53].color = "Joker";
        c.cards[53].num = 1;

        return c;
    }

    Cards InstanseTwoCards()
    {
        Cards c = new Cards() { cards = new Card[108] };

        for (int i = 0; i < 52; i++)
        {
            if (i < 13)
            {
                c.cards[i].color = "Spade";
                c.cards[i].num = i;
                c.cards[i + 54].color = "Spade";
                c.cards[i + 54].num = i;
            }
            else if (i >= 13 && i < 26)
            {
                c.cards[i].color = "Heart";
                c.cards[i].num = i - 13;
                c.cards[i + 54].color = "Heart";
                c.cards[i + 54].num = i - 13;
            }
            else if (i >= 26 && i < 39)
            {
                c.cards[i].color = "Diamond";
                c.cards[i].num = i - 26;

                c.cards[i + 54].color = "Diamond";
                c.cards[i + 54].num = i - 26;
            }
            else if (i >= 39 && i < 52)
            {
                c.cards[i].color = "Club";
                c.cards[i].num = i - 39;
                c.cards[i + 54].color = "Club";
                c.cards[i + 54].num = i - 39;
            }
        }

        c.cards[52].color = "Joker";
        c.cards[52].num = 0;

        c.cards[53].color = "Joker";
        c.cards[53].num = 1;

        c.cards[106].color = "Joker";
        c.cards[106].num = 0;

        c.cards[107].color = "Joker";
        c.cards[107].num = 1;

        return c;


    }


    void DrawCard(ref Player player1,ref Player player2,ref Player player3, ref Cards card)//参数顺序
    {
        int i = 65536;

        int[] randomNum = new int[card.cards.Length];

        //生成随机数
        for (int j = 0; j < card.cards.Length; j ++)
        {
            while  (true)
            {
                int r = Random.Range(1, card.cards.Length + 1);
                if(IsRandomOK(r, randomNum) && r!=i)
                {
                    randomNum[j] = r;
                    i = r;
                    break;
                }           
            }
        }

        ////发牌
        player1.cards = new Card[card.cards.Length / 3];
        player2.cards = new Card[card.cards.Length / 3];
        player3.cards = new Card[card.cards.Length / 3];
        
        for (int k = 0; k < card.cards.Length / 3; k ++)
        {
            player1.cards[k] = card.cards[randomNum[k] - 1];
            player2.cards[k] = card.cards[randomNum[k + card.cards.Length / 3] - 1];
            player3.cards[k] = card.cards[randomNum[k + 2 * card.cards.Length / 3] - 1];
        }

    }

    bool IsRandomOK(int r, int[] num)
    {
        for (int i = 0; i < num.Length; i ++)
        {
            if (r == num[i])
            {
                return false;
            }
        }
        return true;
    }

    void ShowPlayerCard(ref Player player)
    {
        Debug.Log(player.name);

        for (int i = 0; i < player.cards.Length; i ++)
        {
            ShowCard(ref player.cards[i]);
        }
    }

    void ShowCard(ref Card card)
    {
        string[] numCard = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        string[] numJoker = { "Big", "Little"};


        switch (card.color)
        {
            case "Joker":
                Debug.Log("Joker " + numJoker[card.num]);
                break;
            case "Heart":
                Debug.Log("Heart " + numCard[card.num]);
                break;
            case "Diamond":
                Debug.Log("Diamond " + numCard[card.num]);
                break;
            case "Spade":
                Debug.Log("Spade " + numCard[card.num]);
                break;
            case "Club":
                Debug.Log("Club " + numCard[card.num]);
                break;

        }
    }


}
