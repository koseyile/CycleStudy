using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hongyi4 : MonoBehaviour
{



    /* “园长妈妈”是一位出色的校长，她管理的幼儿园有108位学生，男生60名，女生48名。大班30名，中班36名，小班42名。大班男女比例一样，中班男生比女生多4名。
       1.定义一个学校结构体，包含上述所有数据
       2.编写一个函数，输入参数为学校结构体，打印小班男女人数各为多少。*/

    /*
    struct SchoolInfo
    {
        public int csb;
        public int csg;
        public int cmb;
        public int cmg;
        public int cbb;
        public int cbg;
        public int cs;
        public int cm;
        public int cb;
    }



    void start()
    {
        SchoolInfo [] SchoolInfoArray = new SchoolInfo[3];
        SchoolInfoArray[0].cb = 30;
        SchoolInfoArray[1].cm = 36;
        SchoolInfoArray[2].cs = 42;
        SchoolInfoArray[0].cbb = SchoolInfoArray[0].cbg;
        SchoolInfoArray[1].cmb = SchoolInfoArray[1].cmg + 4;


        SchoolInfoArray[2].csb = 60 - SchoolInfoArray[0].cbb - SchoolInfoArray[1].cmb;
        Debug.Log(SchoolInfoArray[2].csb);

        SchoolInfoArray[2].csg = 48 - SchoolInfoArray[0].cbg - SchoolInfoArray[1].cmg;
        Debug.Log(SchoolInfoArray[2].csg);


    }
    */  







    /* 春天快结束了，为了让小朋友们能感受到大自然的美好，“园长妈妈”抓住了春天的尾巴，组织了一次春游。
    这次去日本京都，选择了“日和”旅行社。
    日和旅行社老板给园长妈妈两个账本，一本为白色，一本为黑色。
    白本上是这样记录的：
    大班基础费用为2000元每人
    中班基础费用为2200元每人
    小班基础费用为2500人每人
    黑本是这样记录的：
    大中小班基础费都为1900元每人
    园长妈妈选择了黑本，白本交给了家长们。
    * 3.定义一个旅行社结构体，包含所有旅行社信息
    * 4.编写一个函数，传参为学校结构体和旅行社结构体，求出园长妈妈吃了多少回扣*/

    /* struct TravelAgencyInfo
    {

        public int bp;
        public int mp;
        public int sp;
        public int bnum;
        public int mnum;
        public int snum;
        public int rp;

    }


    int plus(int a, int b, int c)
    {
        return a + b + c;
    }

    int minus(int a, int b)
    {
        return a - b;
    }

    int multiply(int a, int b)
    {
        return a * b;
    }

    int divide(int a, int b)
    {
        return a / b;
    }



    void Start()
    {
        TravelAgencyInfo[] TravelAgencyInfoArray = new TravelAgencyInfo[3];
        TravelAgencyInfoArray[0].bp = 2000;
        TravelAgencyInfoArray[0].bnum = 30;
        TravelAgencyInfoArray[0].rp = 1900;

        TravelAgencyInfoArray[1].mp = 2200;
        TravelAgencyInfoArray[1].mnum = 36;
        TravelAgencyInfoArray[1].rp = 1900;

        TravelAgencyInfoArray[2].sp = 2500;
        TravelAgencyInfoArray[2].snum = 42;
        TravelAgencyInfoArray[2].rp = 1900;

        int i = minus(TravelAgencyInfoArray[0].bp, TravelAgencyInfoArray[0].rp);
        int j = minus(TravelAgencyInfoArray[1].mp, TravelAgencyInfoArray[1].rp);
        int k = minus(TravelAgencyInfoArray[2].sp, TravelAgencyInfoArray[2].rp);
        int l = multiply(i, TravelAgencyInfoArray[0].bnum);
        int m = multiply(j, TravelAgencyInfoArray[1].mnum);
        int n = multiply(k, TravelAgencyInfoArray[2].snum);
        int o = plus(l, m, n);

        Debug.Log(o);
    }
    */



    /*中班里有一位叫Hank的小朋友，右手握着红光剑，左手拿着蓝光盾。红光剑长二尺，宽4寸，攻击80 ，护甲20 ，剑身泛红光。蓝光盾长宽各1尺5寸，攻击30 ，护甲90 ，盾面呈淡蓝色。
     据Hank经常在小朋友面前讲，红光剑在遇到坏人时，剑身会剧烈抖动，并聚集红色光波能量，只要Hank大喊一声：“红光之力攻击！”，红光剑就会发出红光能量射向敌人，
     对敌人造成2倍的攻击伤害，然后吸取敌人的一半的生命值转化为蓝光盾的护甲值，蓝光盾发出鲜艳蓝光。Hank利用这一招吸引了不少同学的注意，但没有人相信他，除了一个叫郭梦琪的小女孩。
     而且今天郭梦琪注意到了，园长妈妈给Hank发糖果的时候，红光剑在抖动。*/
    // 5.定义武器结构体，包含上述所有武器信息，实例化红光剑和蓝光盾。


    /*
    struct WeaponInfo 
    {
        public int redLength;
        public int redWide;
        public int redAttack;
        public int redProtect;
        public int blueLength;
        public int blueWide;
        public int blueAttack;
        public int blueProtect;

    }

    //    * 6.编写一个函数，传参为红光剑和蓝光盾，求出两个武器的面积之和。

    int plus (int a, int b) 
    {
        return a + b;
    }

    int multiply(int a, int b)
    {
        return a * b;
    }

    int badman=1000;

    void Start()
    {
        WeaponInfo[] WeaponInfoArray = new WeaponInfo[2];
        WeaponInfoArray[0].redLength = 20;
        WeaponInfoArray[0].redWide = 4;

        WeaponInfoArray[1].blueLength = 15;
        WeaponInfoArray[1].blueWide = 15;

        int i = multiply(WeaponInfoArray[0].redLength, WeaponInfoArray[0].redWide);
        int j = multiply(WeaponInfoArray[1].blueLength, WeaponInfoArray[0].blueWide);
        int k = plus(i, j);

        Debug.Log(k);

        //7.假设有个坏人血量为1000 ，求出Hank大喊：“红光之力攻击！”后，编写一个函数打印如下数据：坏人剩余血量，蓝光盾的护值。

        WeaponInfoArray[0].redAttack = 80;
        WeaponInfoArray[1].blueProtect = 90;
        int l = badman - 2 * WeaponInfoArray[0].redAttack;
        int m = badman / 2 + WeaponInfoArray[1].blueProtect;

        Debug.Log(l);
        Debug.Log(m);

    }
    */




    /* 终于到了京都，园长妈妈选择了京都一家百年旅店，名叫“喜翠庄”，老板娘是四十万家族第十四代传人，人称“四十万 翠”。喜翠庄的名字来源于店内一只青花瓷，叫喜翠瓶。喜翠瓶本是一只普通的青花瓷，产自中国景德镇，
     四十万一代在中国花4000日币带到日本，四十万二代在战争期间以半价押给典当铺，四十万三代以十倍价格从典当铺赎回，四十万四代为喜翠瓶命名，创立喜翠庄，后经过十代人的苦心经营，现传到四十万翠的手中。
    一件不值钱的玩意，经过时间人情晕染，竟也价值连城起来。
    四十万翠有意立孙女松前 緒花为第十五代传人，但松前 緒花好像没什么兴趣。
    * 8.定义喜翠瓶在每一代的价格结构体
    * 9.假设喜翠瓶在第四代之后，每年价值翻倍，编写一个函数，传入参数为喜翠瓶价格结构体，填充结构体数据，打印喜翠瓶在每一代人手中的价格。*/


    /*
    struct bottleInfo
     {
         public int bottleYearOne;
         public int bottleYearTwo;
         public int bottleYearThree;
         public int bottleYearFour;
         public int bottleYearFive;
         public int bottleYearSix;
         public int bottleYearSeven;
         public int bottleYearEight;
         public int bottleYearNine;
         public int bottleYearTen;
         public int bottleYearEleven;
         public int bottleYearTwelve;
         public int bottleYearThirteen;
         public int bottleYearFourteen;
     }




     void Start()
     {

         bottleInfo[] bottleInfoArray = new bottleInfo[14];
         bottleInfoArray[0].bottleYearOne = 4000;
         Debug.Log(bottleInfoArray[0].bottleYearOne);

         bottleInfoArray[1].bottleYearTwo = bottleInfoArray[0].bottleYearOne / 2;
         Debug.Log(bottleInfoArray[1].bottleYearTwo);

         bottleInfoArray[2].bottleYearThree = bottleInfoArray[1].bottleYearTwo * 10;
         Debug.Log(bottleInfoArray[2].bottleYearThree);

         bottleInfoArray[3].bottleYearFour = bottleInfoArray[2].bottleYearThree;
         Debug.Log(bottleInfoArray[3].bottleYearFour);

         bottleInfoArray[4].bottleYearFive = bottleInfoArray[3].bottleYearFour * 2;
         Debug.Log(bottleInfoArray[4].bottleYearFive);

         bottleInfoArray[5].bottleYearSix = bottleInfoArray[4].bottleYearFive * 2;
         Debug.Log(bottleInfoArray[5].bottleYearSix);

         bottleInfoArray[6].bottleYearSeven = bottleInfoArray[5].bottleYearSix * 2;
         Debug.Log(bottleInfoArray[6].bottleYearSeven);

         bottleInfoArray[7].bottleYearEight = bottleInfoArray[6].bottleYearSeven * 2;
         Debug.Log(bottleInfoArray[7].bottleYearEight);

         bottleInfoArray[8].bottleYearNine = bottleInfoArray[7].bottleYearEight * 2;
         Debug.Log(bottleInfoArray[8].bottleYearNine);

         bottleInfoArray[9].bottleYearTen = bottleInfoArray[8].bottleYearNine * 2;
         Debug.Log(bottleInfoArray[9].bottleYearTen);

         bottleInfoArray[10].bottleYearEleven = bottleInfoArray[9].bottleYearTen * 2;
         Debug.Log(bottleInfoArray[10].bottleYearEleven);

         bottleInfoArray[11].bottleYearTwelve = bottleInfoArray[10].bottleYearEleven * 2;
         Debug.Log(bottleInfoArray[11].bottleYearTwelve);

         bottleInfoArray[12].bottleYearThirteen = bottleInfoArray[11].bottleYearTwelve * 2;
         Debug.Log(bottleInfoArray[12].bottleYearThirteen);

         bottleInfoArray[13].bottleYearFourteen = bottleInfoArray[12].bottleYearThirteen * 2;
         Debug.Log(bottleInfoArray[13].bottleYearFourteen);

         //我觉得这里连续的应该由 i>5; ++i 来做，但是写出来不对，为了继续下面一体 我用了笨办法


     }
     */




    /*郭梦琪举起红光剑，指向园长妈妈，大喊：红光之力攻击！明亮的红光照亮了所有小朋友的脸，小朋友脸上展现出惊叹表情，尤其是Hank，自己的武器居然在郭梦琪手中觉醒了。
     红光能量在接触到园长妈妈的一瞬间，突然调转方向，击碎了喜翠瓶。
    园长妈妈也惊呆了，这得赔不少钱吧。
    园长妈妈经过激烈的讨价还价，最终要赔偿喜翠瓶价值的八成。并让所有小朋友为喜翠庄劳动一天，小朋友们开心地跟着松前 緒花小姐姐劳动去了。松前 緒花小姐姐好像比小朋友们还要开心。
    在随后的几天，松前 緒花带领着小朋友们逛遍京都角落，他们建立了深厚的友谊，就连京都的樱花，古楼，林克，马里奥，宝可梦们都羡慕不已。

    这次春游小朋友们果真获得了成长呢。
    * 10.编写一个函数，传入学校结构体，旅行社结构体及喜翠瓶价格结构体，求出园长妈妈最终的盈亏。
    */

    /* struct SchoolInfo
    {
        public int cb;
        public int cm;
        public int cs;
    }

    struct TravelAgencyInfo
    {
        public int priceA;
        public int priceB;
        public int priceC;
        public int priceD;
    }

    struct BottleInfo
    {
        public int bottleYearOne;
        public int bottleYearTwo;
        public int bottleYearThree;
        public int bottleYearFour;
        public int bottleYearFive;
        public int bottleYearSix;
        public int bottleYearSeven;
        public int bottleYearEight;
        public int bottleYearNine;
        public int bottleYearTen;
        public int bottleYearEleven;
        public int bottleYearTwelve;
        public int bottleYearThirteen;
        public int bottleYearFourteen;
    }


    void Start()
    {

        BottleInfo[] BottleInfoArray = new BottleInfo[14];
        BottleInfoArray[13].bottleYearFourteen = 20480000;

        TravelAgencyInfo[] TravelAgencyInfoArray = new TravelAgencyInfo[4];
        TravelAgencyInfoArray[0].priceA = 2000;
        TravelAgencyInfoArray[1].priceB = 2200;
        TravelAgencyInfoArray[2].priceC = 2500;
        TravelAgencyInfoArray[3].priceD = 1900;

        SchoolInfo[] SchoolInfoArray = new SchoolInfo[3];
        SchoolInfoArray[0].cb = 30;
        SchoolInfoArray[1].cm = 36;
        SchoolInfoArray[2].cs = 42;

        int i = (TravelAgencyInfoArray[0].priceA - TravelAgencyInfoArray[3].priceD) * SchoolInfoArray[0].cb;
        int j = (TravelAgencyInfoArray[1].priceB - TravelAgencyInfoArray[3].priceD) * SchoolInfoArray[1].cm;
        int k = (TravelAgencyInfoArray[2].priceC - TravelAgencyInfoArray[3].priceD) * SchoolInfoArray[2].cs;
        int l = i + j + k- BottleInfoArray[13].bottleYearFourteen;

        Debug.Log(l);



    }*/
}
