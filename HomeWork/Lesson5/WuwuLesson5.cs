using UnityEngine;

public class WuwuLesson5 : MonoBehaviour
{

    //结构体部分：
    // From Naomi 1-3题
    //* 1.建立候选人结构体；
    struct Candidates
    {
        public string Name;
        public int MathScore;
        public int ChineseScore;
        public int EnglishScore;
        public int Popularity;
    }

    ////From baibai 4-6题
    struct Ultraman
    {
        public string Name;
        public int High;
        public int Weight;
        public int Mach;
        public string Mom;
        public string Birth;
        public string Planet;
        public string Partner;
    }

    // From wupeng 7-9题
    struct Hero
    {
        public int life;
        public int attack;
        public int defense;
    }

    struct Heroskill
    {
        public string kind;
        public int addattack;
        public int adddefense;
        public int minusspeed;
        public int addlife;

    }

    //1. wuwu、baibai、zz三人斗地主，请用一个结构体表示所有的牌的数据。
    //J是Jack Q是Queen K是King 每个四张，一共12张；
    //joker大小王 分别1张；
    //四个花色 黑桃，红桃，梅花，方块每个都有1-13；一共4*13=52张

    //enum Pokertype { heart, spade, club, type };
    //方法1：
    //struct Poker
    //{
    //    public string pokertype;
    //    public string point;

    //}
    //方法2：
    //enum Kind { heart,spade,club,dimand}
    //enum Point { A, two, three, four, five, six, seven, eight, nine, ten, J, Q, K }
    //struct Poker
    //{
    //    private string kind;
    //    public string points;
    //    public Poker (string kind,string points)
    //    {
    //        this.kind = kind;
    //        this.points = points;
    //    }//其实不懂this是啥，怎么把这两个分别写成两个数组呢？
    //   void Printp()
    //    {
    //        Debug.Log("{0},{1}",this.kind,this.points);
    //    }
    //}
    
    //void PrintPokerkind(ref Poker poker)
    //{
    //    Debug.Log(poker.kind);
    //}
    //void playcards(string[] args)
    //{
    //    Poker po= new Poker();
    //    ArrayList myPoker = new ArrayList();
    //    ArrayList person1 = new ArrayList();
    //    ArrayList person2 = new ArrayList();
    //    ArrayList person2 = new ArrayList();//ArrayList是系统自带吗
    //    Random r = new Random();//可是原来都没有这样的结构体啊
    //   for(int i=-4;i<=-1;i++)
    //    {
    //        for(int j=0;j<=12;j++)
    //        {
                
    //        }
    //    }

    //}
   

}

    }

     void Pokerpoints()

    //函数部分：

    //naomi 1-3题
    //* 2.写出以成绩总分最高的来选出学习委员的函数并打印学委的名字。
    void PrintStudy(ref Candidates x, ref Candidates y, ref Candidates z)//函数里定义的时候先用三个结构体的变量的意思吗
    {
        int TotalscoreX = x.ChineseScore + x.ChineseScore + x.EnglishScore;
        int TotalscoreY = y.ChineseScore + y.ChineseScore + y.EnglishScore;
        int TotalscoreZ = z.ChineseScore + z.ChineseScore + z.EnglishScore;
        if ((TotalscoreX - TotalscoreY) * (TotalscoreX - TotalscoreZ) > 0)
            Debug.Log("分数最高的" + x.Name + "是学习委员");
        else
             if ((TotalscoreY - TotalscoreZ) * (TotalscoreY - TotalscoreX) > 0)
            Debug.Log("分数最高的" + y.Name + "是学习委员");
        else
             if ((TotalscoreZ - TotalscoreY) * (TotalscoreZ - TotalscoreX) > 0)
            Debug.Log("分数最高的" + z.Name + "是学习委员");
    }


    //* 3.写出以人缘和成绩总分来选出班长的函数并打印班长的名字。

    void PrintMonitor(ref Candidates x, ref Candidates y, ref Candidates z)//不同的函数可以用一样的变量名吗
    {
        int MonitorX = x.Popularity + x.ChineseScore + x.EnglishScore + x.MathScore;
        int MonitorY = y.Popularity + y.ChineseScore + y.EnglishScore + y.MathScore;
        int MonitorZ = z.Popularity + z.ChineseScore + z.EnglishScore + z.MathScore;
        if ((MonitorX - MonitorY) * (MonitorX - MonitorZ) > 0)
            Debug.Log("人缘和成绩总分最高的" + x.Name + "是班长");
        if ((MonitorY - MonitorZ) * (MonitorY - MonitorX) > 0)
            Debug.Log("人缘和成绩总分最高的" + y.Name + "是班长");
        else
            if ((MonitorZ - MonitorY) * (MonitorZ - MonitorX) > 0)
            Debug.Log("人缘和成绩总分最高的" + z.Name + "是班长");

    }

    //From baibai 4-6题
    //* 5.编写一个函数，输入参数为奥特曼结构体，打印泰罗和赛文的速度各为多少米每秒
    float Speed(ref Ultraman x)
    {
        return x.Mach * 340.3f;
    }


    //* 6.M78星云，距离地球300万光年。仙女座星云距离地球254万光年。现发现怪兽贝劳克恩第9代出现在地球。
    //编写一个函数，输入为奥特曼结构体、星云与地球的距离，求出哪个奥特曼会先到达地球。

    void PrintFirst(ref Ultraman x, ref Ultraman y)
    {
        float distancex = 300 * 9.46f * 1012 * 1000;
        float distancey = 254 * 9.46f * 1012 * 1000;
        if (distancex / Speed(ref x) - distancey / Speed(ref y) > 0)
            Debug.Log("先到地球的是" + x.Name);
        else
            Debug.Log("先到地球的是" + y.Name);
    }

    //* 7.如今林克得到了这把剑，他拿着这把剑来到了被恶魔缠绕的城堡门口，面对恶魔它大喊一声：“卡尔斯鲁厄”！
    //如果林克的属性为:生命100, 攻击60, 防御40.请问他此时的属性是多少。请设计相应的数据结构并计算输出。
    void PrintHeroPower(ref Hero x, ref Heroskill y)
    {
        int afterlife = x.life + y.addlife;
        int afterattack = x.attack + y.addattack;
        int afterdefense = y.adddefense * x.defense;

        Debug.Log("林克现在的属性是：" + "生命" + afterlife + "," + "攻击" + afterattack + "," + "防御" + afterdefense);
    }

    //* 8.如果这时林克大喊一身“克里斯提娜附身！”，请问这时林克的属性为多少？ 请设计或修改数据结构，并设计附身技能函数，打印并输出结果。
    void PrintGetSkill(ref Hero x, ref Hero y)
    {
        int getlife = x.life + y.life;
        int getattack = x.attack + y.attack;
        int getdefense = x.defense * y.defense;
        Debug.Log("林克现在的属性是：" + "生命" + getlife + "," + "攻击" + getattack + "," + "防御" + getdefense);
    }

    //神剑生锈了，每一年都会流逝上古英雄的能量，假设每一年上古神剑中所有英雄的属性都会流逝10%。
    //* 9.请问10年后，当呀哈哈喊出“林克附身”这句话时，请打印呀哈哈的属性。假设呀哈哈的当前属性为生命30，攻击1， 防御5.
    void PrintFinalSkill(ref Hero x, ref Hero y)
    {
        float lifex = x.life;
        float attackx = x.attack;
        float defensex = x.defense;
        float loose = 0.9f;
        int years = 10;
        float finallife = Finalskill(lifex, loose, years) + y.life;
        float finalattack = Finalskill(attackx, loose, years) + y.attack;
        float finaldefense = Finalskill(defensex, loose, years) + y.defense;
        Debug.Log("呀哈哈现在的属性是：" + "生命" + finallife + "," + "攻击" + finalattack + "," + "防御" + finaldefense);
    }

    float Finalskill(float a, float b, int count)
    {
        if (count == 1)
        {
            return a * b;
        }
        else
        {
            return Finalskill(a, b, (count - 1)) * b;
        }
    }



    // From mengmeing:
   


    // Start is called before the first frame update
    void Start()
    {
        //naomi 1-3题
        //zz数学85分，语文95，英语80分，和20个同学互换了微信成为亲密的朋友
        Candidates candidatea;
        candidatea.Name = "zz";
        candidatea.Popularity = 20;
        candidatea.MathScore = 85;
        candidatea.ChineseScore = 95;
        candidatea.EnglishScore = 80;
        //wuwu数学88分，语文94分，英语82分，和13个同学互换了微信成为亲密的朋友；
        Candidates candidateb;
        candidateb.Name = "wuwu";
        candidateb.Popularity = 13;
        candidateb.MathScore = 88;
        candidateb.ChineseScore = 94;
        candidateb.EnglishScore = 82;
        //baibai数学98分，语文87分，英语90分，和5个同学互换了微信成为亲密的朋友。
        Candidates candidatec;
        candidatec.Name = "baibai";
        candidatec.Popularity = 5;
        candidatec.MathScore = 98;
        candidatec.ChineseScore = 87;
        candidatec.EnglishScore = 90;


        Debug.Log("naomi第2题");
        PrintStudy(ref candidatea, ref candidateb, ref candidatec);
        Debug.Log("naomi第3题");
        PrintMonitor(ref candidatea, ref candidateb, ref candidatec);


        //From baibai 4-6题
        //泰罗奥特曼
        Ultraman Thyrode = new Ultraman();
        Thyrode.Name = "泰罗";
        Thyrode.High = 53;
        Thyrode.Weight = 55000;
        Thyrode.Mach = 20;
        Thyrode.Mom = "奥特之母";
        Thyrode.Birth = "M78星云";
        Thyrode.Planet = "仙女座星云";


        //塞文21奥特曼
        Ultraman Severn21 = new Ultraman();
        Severn21.Name = "赛文21";
        Severn21.High = 56;
        Severn21.Weight = 57000;
        Severn21.Mach = 26;
        Severn21.Partner = "奈欧斯奥特曼";
        Severn21.Birth = "M78星云";
        Severn21.Planet = "M78星云";


        Debug.Log("amber第5题");
        float speedofThyrode= Speed(ref Thyrode);
        Debug.Log("泰罗的速度是" + speedofThyrode + "米/秒");
        float speedofSevern21 = Speed(ref Severn21);
        Debug.Log("赛文21的速度是" + speedofSevern21 + "米/秒");

        Debug.Log("amber第6题");
        PrintFirst(ref Thyrode, ref Severn21);

       //fromwupeng 7-9题
        //- 克里斯提娜（魔法雨 打击敌人 30伤害并减少敌人10的速度），
        Heroskill Magicrain = new Heroskill();
        Magicrain.kind= "魔法雨";
        Magicrain.addattack=30;
        Magicrain.minusspeed=-10;

        //- 卡罗兰约克（精准砍劈 以打击敌人50伤害，并提高自己的防御的2倍）
        Heroskill Knife = new Heroskill();
        Knife.kind = "精准砍劈";
        Knife.addattack =50;
        Knife.adddefense =2;

        //- 卡尔斯鲁厄(献祭：自损60生命值，提高自身战斗力100)，
        Heroskill Sacrifice = new Heroskill();
        Sacrifice.kind = "献祭";
        Sacrifice.addlife = -60;
        Sacrifice.addattack =100;

        //- 哥德史密斯（面壁：防御值增加3倍）
        Heroskill FaceWall = new Heroskill();
        FaceWall.kind = "面壁";
        FaceWall.adddefense= 3;

        //林克
        Hero link = new Hero();
        link.life = 100;
        link.attack = 60;
        link.defense = 40;

        //- 克里斯提娜
        Hero Christina;
        Christina.life = 60;
        Christina.attack = 100;
        Christina.defense = 70;

        //- 卡罗兰约克
        Hero Carolan;
        Carolan.life = 150;
        Carolan.attack = 60;
        Carolan.defense = 120;

        //- 卡尔斯鲁厄
        Hero Karlsruhe;
        Karlsruhe.life = 150;
        Karlsruhe.attack = 90;
        Karlsruhe.defense = 40;

        //- 哥德史密斯
        Hero Goldsmith;
        Goldsmith.life = 70;
        Goldsmith.attack = 70;
        Goldsmith.defense = 150;

        //- 呀哈哈
        Hero yahaha;
        yahaha.life = 30;
        yahaha.attack = 1;
        yahaha.defense = 5;


        Debug.Log("吴鹏第7题");
        PrintHeroPower(ref link, ref Sacrifice);

        Debug.Log("吴鹏第8题");
        PrintGetSkill(ref link,ref Christina);

        Debug.Log("吴鹏第9题");
        PrintFinalSkill(ref link, ref yahaha);


        //2. 实例化一套牌。
        /* //方法1 
        Poker[] myPoker = new Poker[54];
        for(int i = 0; i <= myPoker.Length; ++i)
        {
            if (i <= 12)
                myPoker[i].pokertype = "heart";
            
            else if (i <= 25)
                myPoker[i].pokertype = "spade";
            else if (i <= 38)
                myPoker[i].pokertype = "club";
            else if (i <= 51)
                myPoker[i].pokertype = "dimond";
            else if (i == 52)
                myPoker[i].pokertype = "smallJoker";
            else if (i == 53)
                myPoker[i].pokertype = "bigJoker";

            switch(i % 13)
            {
                case 0:
                     Debug.Log(myPoker[i].point = "A");
                     break;
                case 1:
                    Debug.Log(myPoker[i].point = "one");
                    break;
                case 2:
                    Debug.Log(myPoker[i].point = "two");
                    break;
                case 3:
                    Debug.Log(myPoker[i].point = "three");
                    break;
                case 4:
                    Debug.Log(myPoker[i].point = "four");
                    break;
                case 5:
                    Debug.Log(myPoker[i].point = "five");
                    break;
                case 6:
                    Debug.Log(myPoker[i].point = "six");
                    break;
                case 7:
                    Debug.Log(myPoker[i].point = "seven");
                    break;
                case 8:
                    Debug.Log(myPoker[i].point = "eight");
                    break;
                case 9:
                    Debug.Log(myPoker[i].point = "nine");
                    break;
                case 10:
                    Debug.Log(myPoker[i].point = "ten");
                    break;
                case 11:
                    Debug.Log(myPoker[i].point = "J");
                    break;
                case 12:
                    Debug.Log(myPoker[i].point = "Q");
                    break;
                case 13:
                    Debug.Log(myPoker[i].point = "K");
                    break;

            }
         
        }

      
        void Printallcard(Poker[] X)
        {
            for (int i = 0; i <= 53;i++)
            {
                if (i <= 51)
                {
                    Debug.Log(X[i].pokertype + X[i].point);

                }
                else
                    Debug.Log(X[i].pokertype);
            }
        }


        Debug.Log("mengmeng第10题");//想试试能不能跑出一套牌，好像不行
        Printallcard(myPoker);
        */

        //方法2 看mengmeng的都是用结构体里加构造函数，我也想学！
        //并且想做成 0-3代表花色，1-13代表牌点的数组，但格式老出错
      


        //3. 请写一个函数（传入的参数是刚刚实例化的那套牌）为他们三个人发牌，并打印出每个人的手牌


    }


}
