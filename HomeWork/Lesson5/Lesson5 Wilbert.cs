using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    /*军训回来第一次摸底考试之后，今天是选学习委员和班长的日子。班里一共20人。候选人一共有三人：zz数学85分，语文95，英语80分，和20个同学互换了微信成为亲密的朋友；wuwu数学88分，语文94分，英语82分，和13个同学互换了微信成为亲密的朋友；baibai数学98分，语文87分，英语90分，和5个同学互换了微信成为亲密的朋友。
    * 1.建立候选人结构体；
    * 2.写出以成绩总分最高的来选出学习委员的函数并打印学委的名字。
    * 3.写出以人缘和成绩总分来选出班长的函数并打印班长的名字。*/
    public struct Candidate
    {
        public string Name;
        public float Math;
        public float Chinese;
        public float English;
        public float Wechat;
    }

   float XueWei(ref Candidate candidate)
    {
        return candidate.Chinese + candidate.English + candidate.Math;
    }

    float Banzhang(ref Candidate candidate)
    {
        return candidate.Chinese + candidate.English + candidate.Math + candidate.Wechat;
    }

    void Q1Q3(ref Candidate[] candidate)
    {
        Candidate MaxTotal1 = candidate[0];
        Candidate MaxTotal2 = candidate[0];
        for (int i = 1; i < candidate.Length; i++)
        {
            if (XueWei(ref candidate[i]) > XueWei(ref MaxTotal1))
            {
                MaxTotal1 = candidate[i];
            }
            if(Banzhang(ref candidate[i]) > Banzhang(ref MaxTotal2))
            {
                MaxTotal2 = candidate[i];
            }
        }
        Debug.Log("学习委员:" + MaxTotal1.Name);
        Debug.Log("班长:" + MaxTotal2.Name);
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

    * 4.定义一个奥特曼结构体，包含上述所有数据
    * 5.编写一个函数，输入参数为奥特曼结构体，打印泰罗和爱迪的速度各为多少米每秒。
    * 6.M78星云，距离地球300万光年。仙女座星云距离地球254万光年。现发现怪兽贝劳克恩第9代出现在地球。
    * 编写一个函数，输入为奥特曼结构体、星云与地球的距离，求出哪个奥特曼会先到达地球。*/

    public struct Urutora
    {
        public float Height;
        public float Weight;
        public float Speed;
        public string Mother;
        public string Birthplace;
        public string Currentplace;
        public string Partner;
        public string Name;
    }
    void Q5(ref Urutora[] urutora)
    {
        for (int i = 0; i < urutora.Length; i++)
        {
            Debug.Log(urutora[i].Name + ":" + urutora[i].Speed * 340.3f + "m/s");
        }
    }
    void Q6(ref Urutora[] urutora, float[] distance)
    {
        float time1 = (distance[0] * 9.4607f * Mathf.Pow(10, 5))/ urutora[0].Speed;
        float time2 = (distance[1] * 9.4607f * Mathf.Pow(10, 5)) / urutora[1].Speed;
        if (time1 < time2)
        {
            Debug.Log(urutora[0].Name + "先到达地球");
        }
        else
        {
            Debug.Log(urutora[1].Name + "先到达地球");
        }   
    }

    /*海拉鲁平原上封印着一把上古神剑，传说中曾有四位上古英雄都在不同时间拥有过这把剑，并用它击退恶魔。
这把神剑的神奇之处在于它会吸收主人的能力封存在剑身之中，当下一任使用者使用该剑时，只要喊出曾经英雄的名字，就可以召唤出已逝英雄的神灵来释放它的一个技能协助作战

这四位上古英雄和他们的技能分别是：
- 克里斯提娜（魔法雨 打击敌人 30伤害并减少敌人10的速度），
- 卡罗兰约克（精准砍劈 以打击敌人50伤害，并提高自己的防御的2倍），
- 卡尔斯鲁厄  (献祭：自损60生命值，提高自身战斗力100)，
- 哥德史密斯（面壁：防御值增加3倍）
* 7.如今林克得到了这把剑，他拿着这把剑来到了被恶魔缠绕的城堡门口，面对恶魔它大喊一声：“卡尔斯鲁厄”！如果林克的属性为:生命100, 攻击60, 防御40.请问他此时的属性是多少。请设计相应的数据结构并计算输出。

这把剑还有一个特殊之处在于，林克只要喊出“英雄的名字” + “附身”这样的咒语，上古英雄的属性便会突然加到林克身上。假设
- 克里斯提娜的属性生命60, 攻击100 防御 70;
- 卡罗兰约克的属性为生命150，攻击60， 防御120；
- 卡尔斯鲁厄的属性为 生命150，攻击90， 防御40；
- 哥德史密斯 属性  生命70，攻击70， 防御150.
* 8.如果这时林克大喊一身“克里斯提娜附身！”，请问这时林克的属性为多少？ 请设计或修改数据结构，并设计附身技能函数，打印并输出结果。  

在于恶魔对战的过程中，林克受到了重伤，在林克弥留之际，他将上古神剑交给了呀哈哈。将自己的魂魄注入神剑，与上古英雄们重聚，成为他们的一员。如今呀哈哈拿到了神剑，但是呀哈哈对上古神剑生命的不感冒，把他丢在了角落里。
神剑生锈了，每一年都会流逝上古英雄的能量，假设每一年上古神剑中所有英雄的属性都会流逝10%。
* 9.请问10年后，当呀哈哈喊出“林克附身”这句话时，请打印呀哈哈的属性。假设呀哈哈的当前属性为生命30，攻击1， 防御5.*/

    public struct Hero
    {
        public string Name;
        public float ATC;
        public float DEF;
        public float HP;
    }

    void Q7(string Name, float[] data)// data01=atc data02=def data03=hp data04=spd
    {
        if (Name == "克里斯提娜")
        {
            data[0] = data[0] + 30f;
            data[3] = data[3] - 10f;
        }
        else if (Name == "卡罗兰约克")
        {
            data[0] = data[0] + 50f;
            data[1] = data[1] * 2f;
        }
        else if (Name == "卡尔斯鲁厄")
        {
            data[0] = data[0] + 100f;
            data[2] = data[2] - 60f;
        }
        else
        {
            data[1] = data[1] * 3f;
        }
        Debug.Log("面对恶魔它大喊一声："+ Name + "！此时林克的属性为: 生命="+ data[2]+" 攻击="+ data[0]+" 防御="+ data[1]);
    }

    void Q8(string Name, ref Hero[] hero, float[] data)// data01=atc data02=def data03=hp data04=spd
    {
       for (int i = 0; i < hero.Length; i++)
        {
            if (Name == hero[i].Name)
            {
                data[0] = data[0] + hero[i].ATC;
                data[1] = data[1] + hero[i].DEF;
                data[2] = data[2] + hero[i].HP;
            }
       }
       Debug.Log("面对恶魔它大喊一声：" + Name + "附身！此时林克的属性为: 生命=" + data[2] + " 攻击=" + data[0] + " 防御=" + data[1]);
    }

    void Q9(string Name, ref Hero[] hero, float[] data)// data01=atc data02=def data03=hp data04=spd
    {
        for (int i = 0; i < hero.Length; i++)
        {
            if (Name == hero[i].Name)
            {
                data[0] = data[0] + hero[i].ATC * Mathf.Pow(0.9f, 10);
                data[1] = data[1] + hero[i].DEF * Mathf.Pow(0.9f, 10);
                data[2] = data[2] + hero[i].HP * Mathf.Pow(0.9f, 10);
            }
        }
        Debug.Log("10年后,呀哈哈大喊一声：" + Name + "附身！此时呀哈哈的属性为: 生命=" + data[2] + " 攻击=" + data[0] + " 防御=" + data[1]);
    }

    /*1. wuwu、baibai、zz三人斗地主，请用一个结构体表示所有的牌的数据。
    2. 实例化一套牌。
    3. 请写一个函数（传入的参数是刚刚实例化的那套牌）为他们三个人发牌，并打印出每个人的手牌*/
    public struct Card
    {
        public string player;
        public int num;
        public string typ;
    }

    void Q10Q11(ref Card[] card)
    {
        for (int i = 0; i <= 53; i++)
        {
            if (i < 13)
            {
                card[i].typ = "Spade";
                card[i].num = i;
            }
            else if (i >= 13 && i < 26)
            {
                card[i].typ = "Heart";
                card[i].num = i - 12;
            }
            else if (i >= 26 && i < 39)
            {
                card[i].typ = "Diamond";
                card[i].num = i - 25;
            }
            else if (i >= 39 && i < 52)
            {
                card[i].typ = "Club";
                card[i].num = i - 38;
            }
            else
            {
                card[52].typ = "Big Joker";
                card[52].num = 0;

                card[53].typ = "Small Joker";
                card[53].num = 0;
            }
        }
    }

    void Q12(ref Card[] card)
    {
        for (int i = 0; i <= 53; i++)
        {
            if (i % 3 == 0)
            {
                card[i].player = "zz";
            }
            else if (i % 2 == 0)
            {
                card[i].player = "baibai";
            }
            else
            {
                card[i].player = "wuwu";
            }
            Debug.Log(card[i].player +" "+ card[i].num +" "+ card[i].typ);
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        //Q1-Q3
        Candidate[] candidate = new Candidate[3];
        candidate[0].Name = "zz";
        candidate[0].Math = 85f;
        candidate[0].Chinese = 95f;
        candidate[0].English = 80f;
        candidate[0].Wechat = 20f;

        candidate[1].Name = "wuwu";
        candidate[1].Math = 88f;
        candidate[1].Chinese = 94f;
        candidate[1].English = 82f;
        candidate[1].Wechat = 13f;

        candidate[2].Name = "baibai";
        candidate[2].Math = 98f;
        candidate[2].Chinese = 87f;
        candidate[2].English = 90f;
        candidate[2].Wechat = 5f;

        Q1Q3(ref candidate);

        ///////////////////////////////////////////////////////

        //Q4-Q6
        Urutora[] urutora = new Urutora[2];
        urutora[0].Name = "泰罗奥特曼";
        urutora[0].Height = 53f;
        urutora[0].Weight = 55000f;
        urutora[0].Speed = 20f;
        urutora[0].Mother = "奥特之母";
        urutora[0].Partner = " ";
        urutora[0].Birthplace = "M78星云";
        urutora[0].Currentplace = "仙女座星云";

        urutora[1].Name = "塞文21奥特曼";
        urutora[1].Height = 56f;
        urutora[1].Weight = 57000f;
        urutora[1].Speed = 26f;
        urutora[1].Mother = " ";
        urutora[1].Partner = "奈欧斯奥特曼";
        urutora[1].Birthplace = "M78星云";
        urutora[1].Currentplace = "M78星云";

        Q5(ref urutora);
        float[] distance = { 254f, 300f };
        Q6(ref urutora, distance);

        ///////////////////////////////////////////////////////

        //Q7-Q9
        Hero[] hero = new Hero[5];
        hero[0].Name= "克里斯提娜";
        hero[0].ATC=100f;
        hero[0].DEF=70f;
        hero[0].HP=60f;

        hero[1].Name = "卡罗兰约克";
        hero[1].ATC = 60f;
        hero[1].DEF = 120f;
        hero[1].HP = 150f;

        hero[2].Name = "卡尔斯鲁厄";
        hero[2].ATC = 90f;
        hero[2].DEF = 40f;
        hero[2].HP = 150f;

        hero[3].Name = "哥德史密斯";
        hero[3].ATC = 70f;
        hero[3].DEF = 150f;
        hero[3].HP = 70f;

        float[] LinKe = { 60f, 40f, 100f, 0f };// data01=atc data02=def data03=hp data04=spd
        Q7("卡尔斯鲁厄", LinKe);
        Q8("克里斯提娜", ref hero, LinKe);

        hero[4].Name = "林克";
        hero[4].ATC = 60f;
        hero[4].DEF = 40f;
        hero[4].HP = 100f;
        float[] Yahaha= { 1f, 5f, 30f, 0f };
        Q9("林克", ref hero, Yahaha);

        ///////////////////////////////////////////////////////
        //Q10-Q12
        Card[] card = new Card[54];
        Q10Q11(ref card);
        Q12(ref card);
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}


