using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wuwu4 : MonoBehaviour
{

	//“园长妈妈”是一位出色的校长，她管理的幼儿园有108位学生，男生60名，女生48名。大班30名，中班36名，小班42名。大班男女比例一样，中班男生比女生多4名。

	//* 1.定义一个学校结构体，包含上述所有数据
	/*  //方法一：
      struct Kindgardern //声明结构体，但是如果是很多很多班级不就写不下了吗? 班级和男女声的数量不明白
     {
         public int boysa, boysb, boysc;
         public int girlsa, girlsb, girlsc;
         public int classa, classb, classc;

     }


     void Start()
     {
         Kindgardern a1 = new Kindgardern();
         boysa + boysb + boysc = 60;
         girlsa + girlsb + grilsc = 48;
         boysa=boysa=30/2;
         boysc + girlsc=42;
         Debug.Log(boysc, girlsc);
     }

     */

    //方法二：
     struct Cla //声明一个班级的结构体,应该是不对的，但是如果是每个班级一个结构体呢
     {
         public int Boys;
         public int Girls;
 
    }
     //2.编写一个函数，输入参数为学校结构体，打印小班男女人数各为多少
     void Fun(int a1, int a2,int b1, int b2, ref int c1, ref int c2)
     {
        Debug.Log(c1,c2);
        
     }

    void Start()
    {
        int a1, int a2,int b1, int b2, ref int c1, ref int c2
        Cla a = new Cla();
        Cla b = new Cla();
        Cla c = new Cla();//怎么给结构体创造新的空间啊
        a1 = a2 = 30 / 2;
        b1 - b2 = 42;
        b1 + b2 = 36;
        c1 + c2 = 42;
        return c1, c2;
    }  
    //真的不会，都是红的，哈哈哈哈哈

    /*  //方法3

     void NumofStudents(Kindgardern[] KindgardernArray)//声明一个函数
     {
         for (int i = 0; i < KindgardernArray.Length; ++i)
         {
             Kindgardern[] KindgardernArray = new Kindgardern[3];//一共有3个班级，3个数组？
             //同时满足以下条件
             if ((KindgardernArray[0].Boys == 30 / 2)//下标0的男生就是大班男生人数？
             && (KindgardernArray[0].Girls == 30 / 2)//下标0的女生就是大班女生人数？
             && (KindgardernArray[1].Boys - KindgardernArray[1].Girls == 4)//下标1的男生就是中班男生或女生人数，2就是小班男生或女生
             && (KindgardernArray[1].Boys + KindgardernArray[1].Girls == 36)
             && (KindgardernArray[2].Boys + KindgardernArray[2].Girls == 42))
             {
                 Debug.Log(KindgardernArray[2].Boys, KindgardernArray[2].Girls);
             }
     */


    //春天快结束了，为了让小朋友们能感受到大自然的美好，“园长妈妈”抓住了春天的尾巴，组织了一次春游。
    //这次去日本京都，选择了“日和”旅行社。
    //日和旅行社老板给园长妈妈两个账本，一本为白色，一本为黑色。
    //白本上是这样记录的：
    //大班基础费用为2000元每人
    //中班基础费用为2200元每人
    //小班基础费用为2500人每人
    //黑本是这样记录的：
    //大中小班基础费都为1900元每人
    //园长妈妈选择了黑本，白本交给了家长们。
    /*  //3.定义一个旅行社结构体，包含所有旅行社信息
     struct TravelBooks//这是声明结构体
     {
         public int priceA, priceB, priceC;
     }


     //* 4.编写一个函数，传参为学校结构体和旅行社结构体，求出园长妈妈吃了多少回扣
     void Start()
     {
         TravelBooks white = new TravelBooks();
         TravelBooks black = new TravelBooks();
         white.priceA = 2000;
         white.priceB = 2200;
         white.priceC = 2500;
         black.priceA = black.priceB = black.priceC = 1900;

         Debug.Log(get);

         void GetMoney(int studentA, int studentB, int studentC)//声明函数
         {
             get = studentA * (white.priceA - black.priceA) + studentB * (white.priceB - black.priceB) + studentC * (white.priceC - black.priceC)
             return get;

         }
         studentA = 30;
         studentB = 36;
         studentC = 42;
         get = GetMoney(30, 36, 42)



     }
     */

    /* 
    //中班里有一位叫Hank的小朋友，右手握着红光剑，左手拿着蓝光盾。红光剑长二尺，宽4寸，攻击80 ，护甲20 ，剑身泛红光。蓝光盾长宽各1尺5寸，攻击30 ，护甲90 ，盾面呈淡蓝色。据Hank经常在小朋友面前讲，红光剑在遇到坏人时，剑身会剧烈抖动，并聚集红色光波能量，只要Hank大喊一声：“红光之力攻击！”，红光剑就会发出红光能量射向敌人，对敌人造成2倍的攻击伤害，然后吸取敌人的一半的生命值转化为蓝光盾的护甲值，蓝光盾发出鲜艳蓝光。Hank利用这一招吸引了不少同学的注意，但没有人相信他，除了一个叫郭梦琪的小女孩。而且今天郭梦琪注意到了，园长妈妈给Hank发糖果的时候，红光剑在抖动。
    //* 5.定义武器结构体，包含上述所有武器信息，实例化红光剑和蓝光盾。
    struct Sword//这是声明结构体
    {
        public int Long;
        public int Width;
        public int attack;
        public int shield;

    }

    void (Sword red, Sword blue)
    {
    Sword red = new Sword();
    Sword blue = new Sword();
    red.Long=2;
    red.Width=4;
    red.attack=80;
    red.shield=20;
    blue.Long=1.5;
    red.Width=1.5;
    red.attack=30;
    red.shield=90;
    }
     
    //* 6.编写一个函数，传参为红光剑和蓝光盾，求出两个武器的面积之和。
    void area(int s)
{
    s = red.Long * red.Width + blue.Long * blue.Width;
    return s;
}
     */

    /* 

       //* 7.假设有个坏人血量为1000 ，求出Hank大喊：“红光之力攻击！”后，编写一个函数打印如下数据：坏人剩余血量，蓝光盾的护值。
       void hurt(ref int blood,ref int shield)
   {
       blood = red.attack - 1000;
           shield = blue.shield - 1000;
           Debug.Log(blood, shield);
   }
        */

    /*
   //终于到了京都，园长妈妈选择了京都一家百年旅店，名叫“喜翠庄”，老板娘是四十万家族第十四代传人，人称“四十万 翠”。
   //喜翠庄的名字来源于店内一只青花瓷，叫喜翠瓶。
   //喜翠瓶本是一只普通的青花瓷，产自中国景德镇，
   //四十万一代在中国花4000日币带到日本，四十万二代在战争期间以半价押给典当铺，四十万三代以十倍价格从典当铺赎回
   //四十万四代为喜翠瓶命名，创立喜翠庄，后经过十代人的苦心经营，现传到四十万翠的手中。
   //一件不值钱的玩意，经过时间人情晕染，竟也价值连城起来。
   //四十万翠有意立孙女松前 緒花为第十五代传人，但松前 緒花好像没什么兴趣。
   //* 8.定义喜翠瓶在每一代的价格结构体
   struct PriceofVase
   {
       public int price;
       public int generation;
   }
     void Printprice(PriceofVase priceofVase)
   {
       Debug.Log(priceofVase.price);
   }
   void Start()
   {
   PriceofVase[] priceofVaseArray = new PriceofVase[14];
       priceofVaseArray[0].price = 4000;
       priceofVaseArray[1].price = 4000/2;
       priceofVaseArray[2].price = 4000/2*10;

       //* 9.假设喜翠瓶在第四代之后，每年价值翻倍，编写一个函数，传入参数为喜翠瓶价格结构体，填充结构体数据，打印喜翠瓶在每一代人手中的价格。
       for (int i = 0; i <= 14; ++i)
       {
           if (i == 0)
               priceofVaseArray[i].price = 4000;
           if (i == 1)
               priceofVaseArray[i].price = 4000 / 2;
           if (i == 2)
               priceofVaseArray[i].price = 4000 / 2 * 10;
           else
           {
               priceofVaseArray[i + 1].price = priceofVaseArray[i].price * 2;
           }
           Debug.Log(priceofVaseArray[i].price);
       }
   }

    */

    //郭梦琪举起红光剑，指向园长妈妈，大喊：红光之力攻击！明亮的红光照亮了所有小朋友的脸，小朋友脸上展现出惊叹表情，尤其是Hank，自己的武器居然在郭梦琪手中觉醒了。
    //红光能量在接触到园长妈妈的一瞬间，突然调转方向，击碎了喜翠瓶。
    //园长妈妈也惊呆了，这得赔不少钱吧。
    //园长妈妈经过激烈的讨价还价，最终要赔偿喜翠瓶价值的八成。并让所有小朋友为喜翠庄劳动一天，小朋友们开心地跟着松前 緒花小姐姐劳动去了。松前 緒花小姐姐好像比小朋友们还要开心。
    //在随后的几天，松前 緒花带领着小朋友们逛遍京都角落，他们建立了深厚的友谊，就连京都的樱花，古楼，林克，马里奥，宝可梦们都羡慕不已。

    //这次春游小朋友们果真获得了成长呢。
    //* 10.编写一个函数，传入学校结构体，旅行社结构体及喜翠瓶价格结构体，求出园长妈妈最终的盈亏。


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
{

}
}
