using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5HWbaibai : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        RunQ1toQ3();
        RunQ4toQ6();
        RunQ7toQ9();
        RunQ10();
    }

    /*军训回来第一次摸底考试之后，今天是选学习委员和班长的日子。班里一共20人。
     候选人一共有三人：zz数学85分，语文95，英语80分，和20个同学互换了微信成为亲密的朋友；
     wuwu数学88分，语文94分，英语82分，和13个同学互换了微信成为亲密的朋友；
     baibai数学98分，语文87分，英语90分，和5个同学互换了微信成为亲密的朋友。
     1.建立候选人结构体；
     2.写出以成绩总分最高的来选出学习委员的函数并打印学委的名字。
     3.写出以人缘和成绩总分来选出班长的函数并打印班长的名字。
     */

    struct Candidate {
        public string Name;
        public float MathScore;
        public float ChineseScore;
        public float EnglishScore;
        public int WeChatFriends;
    }

    float TotalScore(ref Candidate candidate) {
        //calculate total score of a candidate
        return candidate.MathScore + candidate.ChineseScore + candidate.EnglishScore;
    }

    float TotalImpact(ref Candidate candidate) {
        //calculate total score plus fan numbers of a candidate
        return candidate.MathScore + candidate.ChineseScore + candidate.EnglishScore + (float)candidate.WeChatFriends;
    }

    string SelectStudyRep(Candidate[] candidates) {

        int idx=0;
        float maxScore=0;

        for (int i = 0; i < candidates.Length; i++) {
            float score = TotalScore(ref candidates[i]);
            if (score > maxScore) {
                maxScore = score;
                idx = i;
            }
        }

        return candidates[idx].Name;
    }

    string SelectCaptain(Candidate[] candidates) {

        int idx = 0;
        float maxImpact = 0;

        for (int i = 0; i < candidates.Length; i++)
        {
            float impact = TotalImpact(ref candidates[i]);
            if (impact > maxImpact)
            {
                maxImpact = impact;
                idx = i;
            }
        }

        return candidates[idx].Name;
    }


    void RunQ1toQ3() {

        Candidate[] theTeam = new Candidate[3];

        theTeam[0].Name = "zz";
        theTeam[0].MathScore = 85f;
        theTeam[0].ChineseScore = 95f;
        theTeam[0].EnglishScore = 80f;
        theTeam[0].WeChatFriends = 20;

        theTeam[1].Name = "wuwu";
        theTeam[1].MathScore = 88f;
        theTeam[1].ChineseScore = 94f;
        theTeam[1].EnglishScore = 82f;
        theTeam[1].WeChatFriends = 13;

        theTeam[2].Name = "baibai";
        theTeam[2].MathScore = 98f;
        theTeam[2].ChineseScore = 87f;
        theTeam[2].EnglishScore = 90f;
        theTeam[2].WeChatFriends = 5;

        string studyRep = SelectStudyRep(theTeam);
        Debug.Log("学习委员: " + studyRep);

        string captain = SelectCaptain(theTeam);
        Debug.Log("班长: " + captain);

    }

    /*
    泰罗奥特曼 身高：53米，体重：55000吨，飞行速度：20马赫，母亲：奥特之母，出生地：M78星云， 现在地：仙女座星云
    塞文21奥特曼，身高：56米，体重：57000吨，飞行速度：26马赫，搭档：奈欧斯奥特曼，出生地：M78星云，现在地：M78星云
    4.定义一个奥特曼结构体，包含上述所有数据
    5.编写一个函数，输入参数为奥特曼结构体，打印泰罗和爱迪的速度各为多少米每秒。
    6.M78星云，距离地球300万光年。仙女座星云距离地球254万光年。现发现怪兽贝劳克恩第9代出现在地球。
    编写一个函数，输入为奥特曼结构体、星云与地球的距离，求出哪个奥特曼会先到达地球。
    */

    struct Outman {
        public string Name;
        public float Height;
        public float Weight;
        public float Speed;
        public string Mother;
        public string Buddy;
        public string BirthPlace;
        public string CurrentLoc;
    }

    float CalculateSpeed(ref Outman outman) {
        return outman.Speed * 340.3f;
    }

    string WhoFirst(ref Outman outman1, ref Outman outman2, float d1, float d2) {
        float t1 = d1 / outman1.Speed;
        float t2 = d2 / outman2.Speed;

        if (t1 < t2)
        {
            return outman1.Name;
        }
        else if (t2 < t1)
        {
            return outman2.Name;
        }
        else {
            return outman1.Name + "和" +outman2.Name;
        }
    }


    void RunQ4toQ6() {
        Outman Taro = new Outman();
        Taro.Name = "泰罗";
        Taro.Height = 53f;
        Taro.Weight = 55000f;
        Taro.Speed = 20f; // 马赫
        Taro.Mother = "MotherofUltra";
        Taro.BirthPlace = "M78";
        Taro.CurrentLoc = "Andromeda";

        Outman Seven21 = new Outman();
        Seven21.Name = "赛文21";
        Seven21.Height = 56f;
        Seven21.Weight = 57000f;
        Seven21.Speed = 26f; // 马赫
        Seven21.Buddy = "Neos";
        Seven21.BirthPlace = "M78";
        Seven21.CurrentLoc = "M78";

        float taroSpeed = CalculateSpeed(ref Taro);
        Debug.Log("泰罗奥特曼速度： " + taroSpeed + "米每秒");

        float seven21Speed = CalculateSpeed(ref Seven21);
        Debug.Log("赛文21奥特曼速度： " + seven21Speed + "米每秒");

        float distance_taro = 254f; // 光年
        float distance_seven21 = 300f; // 光年

        string firstCome = WhoFirst(ref Taro, ref Seven21, distance_taro, distance_seven21);
        Debug.Log(firstCome + "奥特曼会先到达地球。");
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
    * 9.请问10年后，当呀哈哈喊出“林克附身”这句话时，请打印呀哈哈的属性。假设呀哈哈的当前属性为生命30，攻击1， 防御5.
    */

    struct Sword {
        public float[] HeroProperty; //附身 英雄属性
        //0 - health, 1 - attack, 2 - guard,
        public float[] SkillProperty; // 对玩玩家属性改变
        //0 - health, 1 - attack, 2 - guard,
        public float[] SkillEnemyImpact; // 对敌人的数值改变改变
        //0 - speed, 1 - damage
    }   

    struct PlayerCharacter {
        public string Name;
        public float[] PlayerProperty; //玩家 属性
        //0 - health, 1 - attack, 2 - guard,
        //攻击 即战斗力
    }

    void PrintProperty(ref PlayerCharacter a) {
        Debug.Log(a.Name + " " + "生命：" + a.PlayerProperty[0] + ", " + "攻击：" + a.PlayerProperty[1] + ", " + "防御：" + a.PlayerProperty[2]);
    }

    void CallHeroSkill(ref PlayerCharacter p, ref Sword s) {
        for (int i = 0; i < p.PlayerProperty.Length; i++) {
            p.PlayerProperty[i] += s.SkillProperty[i];
        }
    }

    void CallPossess(ref PlayerCharacter p, ref Sword s) {
        for (int i = 0; i < p.PlayerProperty.Length; i++)
        {
            p.PlayerProperty[i] += s.HeroProperty[i];
        }
    }

    void BecomeHeroSword(ref Sword s, ref PlayerCharacter p) {
        for (int i = 0; i < p.PlayerProperty.Length; i++) {
            s.HeroProperty[i] = p.PlayerProperty[i];
        }
    }

    float PropertyDecay(float p, int year) {

        if (year == 1) {
            return p * 0.9f;
        }
        else {
            return (PropertyDecay(p, year - 1)) * 0.9f;
        }
    }

    void HeroDecay(ref Sword s, int year) {
        for (int i = 0; i < s.HeroProperty.Length; i++) {
            s.HeroProperty[i]= PropertyDecay(s.HeroProperty[i], year);
            //Debug.Log(s.HeroProperty[i]);
        }
    }


    void RunQ7toQ9()
    {
        //Q7.卡尔斯鲁厄  (献祭：自损60生命值，提高自身战斗力100)；林克的属性为:生命100, 攻击60, 防御40.
        Sword cals = new Sword() {
            SkillProperty = new float[3]
        };
        cals.SkillProperty[0] = -60f;
        cals.SkillProperty[1] = 100f;

        PlayerCharacter klin = new PlayerCharacter();
        klin.Name = "林克";
        klin.PlayerProperty = new float[3];
        klin.PlayerProperty[0] = 100f;
        klin.PlayerProperty[1] = 60f;
        klin.PlayerProperty[2] = 40f;

        Debug.Log("大喊一声：“卡尔斯鲁厄”！");
        CallHeroSkill(ref klin, ref cals);
        PrintProperty(ref klin);

        //Q8. 克里斯提娜（魔法雨 打击敌人 30伤害并减少敌人10的速度）; 克里斯提娜的属性生命60, 攻击100 防御 70;
        Sword christina = new Sword();
        christina.HeroProperty = new float[3];
        christina.HeroProperty[0] = 60f;
        christina.HeroProperty[1] = 100f;
        christina.HeroProperty[2] = 70f;
        christina.SkillEnemyImpact = new float[2];
        christina.SkillEnemyImpact[0] = -10f;
        christina.SkillEnemyImpact[1] = 30f;

        Debug.Log("林克大喊一身“克里斯提娜附身！”");
        CallPossess(ref klin, ref christina);
        PrintProperty(ref klin);

        //Q9. 英雄剑林克，每一年上古神剑中所有英雄的属性都会流逝10%，10年后。呀哈哈的当前属性为生命30，攻击1， 防御5.
        Sword linke = new Sword();
        linke.HeroProperty = new float[3];
        BecomeHeroSword(ref linke, ref klin);
        HeroDecay(ref linke, 10);

        PlayerCharacter yahh = new PlayerCharacter();
        yahh.Name = "呀哈哈";
        yahh.PlayerProperty = new float[3];
        yahh.PlayerProperty[0] = 30f;
        yahh.PlayerProperty[1] = 1f;
        yahh.PlayerProperty[2] = 5f;
      
        Debug.Log("当呀哈哈喊出“林克附身”");
        CallPossess(ref yahh, ref linke);
        PrintProperty(ref yahh);
    }

    /*
    10-1. wuwu、baibai、zz三人斗地主，请用一个结构体表示所有的牌的数据。
    10-2. 实例化一套牌。
    10-3. 请写一个函数（传入的参数是刚刚实例化的那套牌）为他们三个人发牌，并打印出每个人的手牌
    */

    struct Card {
        public int Type; // 1 - Spade, 2 - Heart, 3 - Diamond, 4 - Club; 0 - joker
        public int Face; // 1-A, 2-10, 11 - J, 12 - Q, 13 - K; 1 - red joker, 2 - black joker
    }


    struct CardDeck {
        public Card[] cards;
    }


    void MakeDeck(ref CardDeck deck) {
        for (int i = 0; i < deck.cards.Length; i++) {
            if (i / 13 == 0)
            {
                deck.cards[i].Type = 1; // spade
            }
            else if (i / 13 == 1)
            {
                deck.cards[i].Type = 2;// heart
            }
            else if (i / 13 == 2)
            {
                deck.cards[i].Type = 3;// diamond
            }
            else if (i / 13 == 3)
            {
                deck.cards[i].Type = 4;// club 
            }
            else {
                deck.cards[i].Type = 0;// joker
            }
            deck.cards[i].Face = (i % 13 + 1);
        }
    }

    void ShuffleCards(ref CardDeck deck) {
        //Fisher–Yates shuffle
        for (int i = deck.cards.Length -1; i>1; i--)
        {
            int j = Random.Range(0, i);
            Card temp = new Card();
            temp = deck.cards[i];
            deck.cards[i] = deck.cards[j];
            deck.cards[j] = temp;
        }

    }


    void DealCards(ref CardDeck deck, Card[] hand1, Card[] hand2, Card[] hand3) {
        // 3 hands - 54/3
        for (int i = 0; i < deck.cards.Length; i++) {
            if (i % 3 == 0)
            {
                hand1[i / 3] = deck.cards[i];
            }
            else if (i % 3 == 1)
            {
                hand2[i / 3] = deck.cards[i];
            }
            else {
                hand3[i / 3] = deck.cards[i];
            }
        }
    }


    void PrintDeck(ref CardDeck deck) {
        string deckSigns = "";

        for (int i = 0; i < deck.cards.Length; i++) {
            deckSigns += PrintCard(ref deck.cards[i]);

            if (i != deck.cards.Length - 1) {
                deckSigns += " ";
            }
        }

        Debug.Log(deckSigns);
    }


    void PrintCardinHand(string handName, Card[] hand)
    {
        string handSigns = "";

        for (int i = 0; i < hand.Length; i++)
        {
            handSigns += PrintCard(ref hand[i]);

            if (i != hand.Length - 1)
            {
                handSigns += " ";
            }
        }

        Debug.Log(handName + ": "+ handSigns);
    }

    string PrintCard(ref Card card) {
        string cardSign = "";

        switch (card.Type)
        {
            case 0:
                cardSign = "Joker";
                break;
            case 1:
                cardSign = "Spade";
                break;
            case 2:
                cardSign = "Heart";
                break;
            case 3:
                cardSign = "Diamond";
                break;
            case 4:
                cardSign = "Club";
                break;
        }

        if (card.Type == 0)
        {
            if (card.Face == 1)
            {
                cardSign += "Red";
            }
            else
            {
                cardSign += "Black";
            }
        }
        else
        {
            if (card.Face == 11)
            {
                cardSign += "J";
            }
            else if (card.Face == 12)
            {
                cardSign += "Q";
            }
            else if (card.Face == 13)
            {
                cardSign += "K";
            }
            else if (card.Face == 1)
            {
                cardSign += "A";
            }
            else
            {
                cardSign += card.Face;
            }

        }

        return cardSign;
        
    }


    void RunQ10() {

        //make a deck
        CardDeck myDeck = new CardDeck();
        myDeck.cards = new Card[54];
        MakeDeck(ref myDeck);
        //PrintDeck(ref myDeck);

        ShuffleCards(ref myDeck);

        int n = 54 / 3;
        Card[] HandZZ = new Card[n];
        Card[] HandWW = new Card[n];
        Card[] HandBB = new Card[n];

        DealCards(ref myDeck, HandZZ, HandWW, HandBB);

        PrintCardinHand("zz", HandZZ);
        PrintCardinHand("ww", HandWW);
        PrintCardinHand("bb", HandBB);

    }
}
