using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hongyi5 : MonoBehaviour
{
    /*军训回来第一次摸底考试之后，今天是选学习委员和班长的日子。班里一共20人。候选人一共有三人：zz数学85分，语文95，英语80分，和20个同学互换了微信成为亲密的朋友；
 wuwu数学88分，语文94分，英语82分，和13个同学互换了微信成为亲密的朋友；baibai数学98分，语文87分，英语90分，和5个同学互换了微信成为亲密的朋友。
 1.建立候选人结构体；
 2.写出以成绩总分最高的来选出学习委员的函数并打印学委的名字。
 3.写出以人缘和成绩总分来选出班长的函数并打印班长的名字。*/

    struct StudentInfo
    {
        public string name;
        public int mathScore;
        public int chineseScore;
        public int englishScore;
        public int friendConnection;
    }

    int TotalScore(ref StudentInfo studentScore)
    {
        return studentScore.mathScore + studentScore.chineseScore + studentScore.englishScore;
    }

    int TotalScore2(ref StudentInfo studentScore)
    {
        return studentScore.mathScore + studentScore.chineseScore + studentScore.englishScore + studentScore.friendConnection;
    }

    void ElectionCommissary(StudentInfo[] studentScore)
    {

        StudentInfo max = studentScore[0];
        for (int i = 0; i < studentScore.Length; i++)
        {
            if (TotalScore(ref studentScore[i]) > TotalScore(ref max))
                max = studentScore[i];

        }
        Debug.Log("学习委员" + max.name);

    }

    void ElectionMonitor(StudentInfo[] studentScore)
    {

        StudentInfo max2 = studentScore[0];
        for (int i = 0; i < studentScore.Length; i++)
        {
            if (TotalScore2(ref studentScore[i]) > TotalScore2(ref max2))
                max2 = studentScore[i];

        }
        Debug.Log("班长" + max2.name);

    }


    /*泰罗奥特曼 
      身高：53米
      体重：55000吨
      飞行速度：20马赫
      母亲：奥特之母
      出生地：M78星云
      现在地：仙女座星云

      塞文21奥特曼
      身高：56米
      体重：57000吨
      飞行速度：26马赫
      搭档：奈欧斯奥特曼
      出生地：M78星云
      现在地：M78星云

      4.定义一个奥特曼结构体，包含上述所有数据
      5.编写一个函数，输入参数为奥特曼结构体，打印泰罗和爱迪的速度各为多少米每秒。
      6.M78星云，距离地球300万光年。仙女座星云距离地球254万光年。现发现怪兽贝劳克恩第9代出现在地球。编写一个函数，输入为奥特曼结构体、星云与地球的距离，求出哪个奥特曼会先到达地球。*/

   struct AltmanInfo

    {
        public string name;
        public int height;
        public int weight;
        public float speed;
        public string mother;
        public string birthPlace;
        public string currentPlace;
        public string partner;

        public float distanceToearth;
    
    }


    float ActualSpeed(ref AltmanInfo altman)
    {

        return altman.speed * 340.3f;
    }



    float GoToEarth(ref AltmanInfo timetogo)
    {

        return timetogo.distanceToearth / timetogo.speed;

        }



    /* 海拉鲁平原上封印着一把上古神剑，传说中曾有四位上古英雄都在不同时间拥有过这把剑，并用它击退恶魔。
       这把神剑的神奇之处在于它会吸收主人的能力封存在剑身之中，当下一任使用者使用该剑时，只要喊出曾经英雄的名字，就可以召唤出已逝英雄的神灵来释放它的一个技能协助作战

       这四位上古英雄和他们的技能分别是：
       - 克里斯提娜（魔法雨 打击敌人30伤害并减少敌人10的速度），
       - 卡罗兰约克（精准砍劈 以打击敌人50伤害，并提高自己的防御的2倍），
       - 卡尔斯鲁厄(献祭：自损60生命值，提高自身战斗力100)，
       - 哥德史密斯（面壁：防御值增加3倍）
       7.如今林克得到了这把剑，他拿着这把剑来到了被恶魔缠绕的城堡门口，面对恶魔它大喊一声：“卡尔斯鲁厄”！如果林克的属性为:生命100, 攻击60, 防御40.请问他此时的属性是多少。请设计相应的数据结构并计算输出。*/


    struct Owner
   {
       public string name;
       public float live; 
       public float attack;
       public float defend;
    }

    struct Skill
    { 
       public float heroattack;
       public float herolive;
       public float herodefend;
       public float speed;
    
    }


    float CurrentLive(ref Owner man, ref Skill hero)
    {

        return man.live + hero.herolive;
    }

    float CurrentAttack(ref Owner man, ref Skill hero)
    {

        return man.attack + hero.heroattack;
    }

    float CurrentDefend(ref Owner man, ref Skill hero)
    {

        return man.defend + hero.herodefend;
    }


    /*这把剑还有一个特殊之处在于，林克只要喊出“英雄的名字” + “附身”这样的咒语，上古英雄的属性便会突然加到林克身上。假设
     - 克里斯提娜的属性生命60, 攻击100 防御 70;
     - 卡罗兰约克的属性为生命150，攻击60， 防御120；
     - 卡尔斯鲁厄的属性为 生命150，攻击90， 防御40；
     - 哥德史密斯 属性  生命70，攻击70， 防御150.
     8.如果这时林克大喊一身“克里斯提娜附身！”，请问这时林克的属性为多少？ 请设计或修改数据结构，并设计附身技能函数，打印并输出结果。  */


    struct Hero
    {
        public float live;
        public float attack;
        public float defend;
    }

    void CurrentEnergy (Hero [] heroes)
    {
        float livenow = heroes[0].live + heroes[1].live;
        float attacknow = heroes[0].attack + heroes[1].attack;
        float defendnow = heroes[0].defend + heroes[1].defend;

        Debug.Log("林克呼喊格里斯蒂娜属性：" + livenow + "," + attacknow + "," + defendnow);

    }


    /*在于恶魔对战的过程中，林克受到了重伤，在林克弥留之际，他将上古神剑交给了呀哈哈。将自己的魂魄注入神剑，与上古英雄们重聚，成为他们的一员。如今呀哈哈拿到了神剑，但是呀哈哈对上古神剑生命的不感冒，把他丢在了角落里。
    神剑生锈了，每一年都会流逝上古英雄的能量，假设每一年上古神剑中所有英雄的属性都会流逝10%。
    9.请问10年后，当呀哈哈喊出“林克附身”这句话时，请打印呀哈哈的属性。假设呀哈哈的当前属性为生命30，攻击1， 防御5.*/

    struct Lastman
    {
        public string name;
        public float live;
        public float attack;
        public float defend;
    }//不知道递归要怎么传参


    /* wuwu、baibai、zz三人斗地主，请用一个结构体表示所有的牌的数据。
       实例化一套牌。
       请写一个函数（传入的参数是刚刚实例化的那套牌）为他们三个人发牌，并打印出每个人的手牌 */


    struct Card
    {
        public string pattern;
        public int number;
    }






    void Start()
    {
        //Naomi 1.2.3
        StudentInfo[] student = new StudentInfo[3];

        student[0].name = "zz";
        student[0].mathScore = 85;
        student[0].chineseScore = 95;
        student[0].englishScore = 80;
        student[0].friendConnection = 20;

        student[1].name = "wuwu";
        student[1].mathScore = 88;
        student[1].chineseScore = 94;
        student[1].englishScore = 82;
        student[1].friendConnection = 13;

        student[2].name = "baibai";
        student[2].mathScore = 98;
        student[2].chineseScore = 87;
        student[2].englishScore = 90;
        student[2].friendConnection = 5;

        ElectionCommissary(student);
        ElectionMonitor(student);


        //baibai 4.5.6
        AltmanInfo Taro = new AltmanInfo();

        Taro.name = "泰罗奥特曼";
        Taro.height = 53;
        Taro.weight = 55000;
        Taro.speed = 20;
        Taro.mother = "奥特之母";
        Taro.birthPlace = "M78星云";
        Taro.currentPlace = "仙女座星云";
        Taro.distanceToearth = 254f;

        AltmanInfo Severn = new AltmanInfo();
        Severn.name = "塞文21奥特曼";
        Severn.height = 56;
        Severn.weight = 57000;
        Severn.speed = 26;
        Severn.partner = "奈欧斯奥特曼";
        Severn.birthPlace = "M78星云";
        Severn.currentPlace = "M78星云";
        Severn.distanceToearth = 300f;


        float tarospeed = ActualSpeed(ref Taro);
        Debug.Log("泰罗奥特曼速度" + tarospeed + "米/秒");
        float severnspeed = ActualSpeed(ref Severn);
        Debug.Log("塞文21奥特曼速度" + severnspeed + "米/秒");

        float tarotime = GoToEarth(ref Taro);
        float severntime = GoToEarth(ref Severn);
        if (tarotime - severntime > 0)
        Debug.Log("首先抵达地球的是塞文21奥特曼");
        if (tarotime - severntime < 0)
        Debug.Log("首先抵达地球的是泰罗奥特曼");




        //wupeng 7

        Owner manL = new Owner();
        manL.name = "林克";
        manL.live = 100f;
        manL.attack = 60f;
        manL.defend = 40f;

        Skill christina = new Skill();
        christina.heroattack = 30f;
        christina.speed = -10f;

        Skill carolanyork = new Skill();
        carolanyork.heroattack = 50f;
        carolanyork.herodefend = manL.defend * 2f;

        Skill karlsruhe = new Skill();
        karlsruhe.herolive = - 60f;
        karlsruhe.heroattack = 100f;

        Skill goldsmith = new Skill();
        goldsmith.herodefend = manL.defend * 3f;

        float currentlive = CurrentLive(ref manL, ref karlsruhe);
        Debug.Log("生命" + currentlive);

        float currentattack = CurrentAttack(ref manL, ref karlsruhe);
        Debug.Log("攻击" + currentattack);

        float currentdefend = CurrentDefend(ref manL, ref karlsruhe);
        Debug.Log("防御" + currentdefend);


        //wupeng 8
        Hero[] heroes = new Hero[5];

        heroes[0].live = 100f;
        heroes[0].attack = 60f;
        heroes[0].defend = 40f;
        
        heroes[1].live = 60f;
        heroes[1].attack = 100f;
        heroes[1].defend = 70f;

        heroes[2].live = 150f;
        heroes[2].attack = 60f;
        heroes[2].defend = 120f;

        heroes[3].live = 150f;
        heroes[3].attack = 90f;
        heroes[3].defend = 40f;

        heroes[4].live = 70f;
        heroes[4].attack = 70f;
        heroes[4].defend = 150f;

        CurrentEnergy(heroes);

        //wupeng 9
        Lastman yhh = new Lastman();
        yhh.name = "呀哈哈";
        yhh.live = 30f;
        yhh.attack = 1f;
        yhh.defend = 5f;

        //LastManCurrent(yhh);

        //mengmeng 10

        Card[] cards = new Card[5];

        cards[0].pattern = "红桃";
        cards[0].number = 13;

        cards[1].pattern = "黑桃";
        cards[1].number = 13;

        cards[2].pattern = "方块";
        cards[2].number = 13;

        cards[3].pattern = "草花";
        cards[3].number = 13;

        cards[4].pattern = "怪";
        cards[4].number = 2;

    }





}
