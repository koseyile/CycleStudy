using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4HWbaibai : MonoBehaviour
{

    /*
    习题
    
    “园长妈妈”是一位出色的校长，她管理的幼儿园有108位学生，男生60名，女生48名。大班30名，中班36名，小班42名。大班男女比例一样，中班男生比女生多4名。
    1.定义一个学校结构体，包含上述所有数据
    2.编写一个函数，输入参数为学校结构体，打印小班男女人数各为多少。
    
    春天快结束了，为了让小朋友们能感受到大自然的美好，“园长妈妈”抓住了春天的尾巴，组织了一次春游。
    这次去日本京都，选择了“日和”旅行社。
    日和旅行社老板给园长妈妈两个账本，一本为白色，一本为黑色。
    白本上是这样记录的：
    大班基础费用为2000元每人
    中班基础费用为2200元每人
    小班基础费用为2500人每人
    黑本是这样记录的：
    大中小班基础费都为1900元每人
    园长妈妈选择了黑本，白本交给了家长们。
    3.定义一个旅行社结构体，包含所有旅行社信息
    4.编写一个函数，传参为学校结构体和旅行社结构体，求出园长妈妈吃了多少回扣

    中班里有一位叫Hank的小朋友，右手握着红光剑，左手拿着蓝光盾。红光剑长二尺，宽4寸，攻击80 ，护甲20 ，剑身泛红光。蓝光盾长宽各1尺5寸，攻击30 ，护甲90 ，盾面呈淡蓝色。据Hank经常在小朋友面前讲，红光剑在遇到坏人时，剑身会剧烈抖动，并聚集红色光波能量，只要Hank大喊一声：“红光之力攻击！”，红光剑就会发出红光能量射向敌人，对敌人造成2倍的攻击伤害，然后吸取敌人的一半的生命值转化为蓝光盾的护甲值，蓝光盾发出鲜艳蓝光。Hank利用这一招吸引了不少同学的注意，但没有人相信他，除了一个叫郭梦琪的小女孩。而且今天郭梦琪注意到了，园长妈妈给Hank发糖果的时候，红光剑在抖动。
    5.定义武器结构体，包含上述所有武器信息，实例化红光剑和蓝光盾。
    6.编写一个函数，传参为红光剑和蓝光盾，求出两个武器的面积之和。
    7.假设有个坏人血量为1000 ，求出Hank大喊：“红光之力攻击！”后，编写一个函数打印如下数据：坏人剩余血量，蓝光盾的护值。


    终于到了京都，园长妈妈选择了京都一家百年旅店，名叫“喜翠庄”，老板娘是四十万家族第十四代传人，人称“四十万 翠”。
    喜翠庄的名字来源于店内一只青花瓷，叫喜翠瓶。喜翠瓶本是一只普通的青花瓷，产自中国景德镇，四十万一代在中国花4000日币带到日本，
    四十万二代在战争期间以半价押给典当铺，四十万三代以十倍价格从典当铺赎回，四十万四代为喜翠瓶命名，创立喜翠庄，后经过十代人的苦心经营，现传到四十万翠的手中。
    一件不值钱的玩意，经过时间人情晕染，竟也价值连城起来。
    四十万翠有意立孙女松前 緒花为第十五代传人，但松前 緒花好像没什么兴趣。
    8.定义喜翠瓶在每一代的价格结构体
    9.假设喜翠瓶在第四代之后，每年价值翻倍，编写一个函数，传入参数为喜翠瓶价格结构体，填充结构体数据，打印喜翠瓶在每一代人手中的价格。

    郭梦琪举起红光剑，指向园长妈妈，大喊：红光之力攻击！明亮的红光照亮了所有小朋友的脸，小朋友脸上展现出惊叹表情，尤其是Hank，自己的武器居然在郭梦琪手中觉醒了。红光能量在接触到园长妈妈的一瞬间，突然调转方向，击碎了喜翠瓶。
    园长妈妈也惊呆了，这得赔不少钱吧。
    园长妈妈经过激烈的讨价还价，最终要赔偿喜翠瓶价值的八成。并让所有小朋友为喜翠庄劳动一天，小朋友们开心地跟着松前 緒花小姐姐劳动去了。松前 緒花小姐姐好像比小朋友们还要开心。
    在随后的几天，松前 緒花带领着小朋友们逛遍京都角落，他们建立了深厚的友谊，就连京都的樱花，古楼，林克，马里奥，宝可梦们都羡慕不已。

    这次春游小朋友们果真获得了成长呢。
    10.编写一个函数，传入学校结构体，旅行社结构体及喜翠瓶价格结构体，求出园长妈妈最终的盈亏。

     */


    //1.定义一个学校结构体，包含上述所有数据
    struct School {
        // 1 for 小班, 2 for 中班, 3 for 大班
        public int TotalStudent;
        public int TotalF;
        public int TotalM;

        public int Level1;
        public int Level2;
        public int Level3;

        public int Level1F;
        public int Level1M;
        public int Level2F;
        public int Level2M;
        public int Level3F;
        public int Level3M;
    }
    
    
    //2.编写一个函数，输入参数为学校结构体，打印小班男女人数各为多少。
    void PrintLevel1(ref School x)
    {
        Debug.Log("小班女生: " + x.Level1F + "名 , 小班男生: " + x.Level1M + "名");
    }

    
    //3.定义一个旅行社结构体，包含所有旅行社信息
    struct Agent {
        public string Name;
        public float BlackCost; // unit元
        public float WhiteCostL1;
        public float WhiteCostL2;
        public float WhiteCostL3;
    }


    //4.编写一个函数，传参为学校结构体和旅行社结构体，求出园长妈妈吃了多少回扣
    float Margin(School p, Agent q) {

        float whiteTotal = p.Level3 * q.WhiteCostL3 + p.Level2 * q.WhiteCostL2 + p.Level1 * q.WhiteCostL1;
        float blackTotal = p.TotalStudent * q.BlackCost;

        return whiteTotal - blackTotal;
    }


    //5.定义武器结构体，包含上述所有武器信息，实例化红光剑和蓝光盾。
    struct Weapon {
        public float Length; // unit 尺
        public float Width;  // unit 尺
        public float Attack;
        public float Guard;
        public string Color;
    }


    //6.编写一个函数，传参为红光剑和蓝光盾，求出两个武器的面积之和。
    float SumArea(ref Weapon a, ref Weapon b) {
        return a.Length * a.Width + b.Length * b.Width;
    }


    //7.假设有个坏人血量为1000 ，求出Hank大喊：“红光之力攻击！”后，编写一个函数打印如下数据：坏人剩余血量，蓝光盾的护值。
    void AfterAttack(float enemyHealth, ref Weapon a, ref Weapon b) {
        //红光剑对敌人造成2倍的攻击伤害
        enemyHealth -= a.Attack * 2;
        //吸取敌人的一半的生命值转化为蓝光盾的护甲值
        b.Guard += enemyHealth / 2;
        enemyHealth -= enemyHealth / 2;

        Debug.Log("坏人剩余血量: " + enemyHealth +  " ,蓝光盾的护值: " + b.Guard );
    }


    //8.定义喜翠瓶在每一代的价格结构体
    struct BottlePrice {

        public float[] Generation;
     }

    //9.假设喜翠瓶在第四代之后，每年价值翻倍，编写一个函数，传入参数为喜翠瓶价格结构体，填充结构体数据，打印喜翠瓶在每一代人手中的价格。
    void PrintPrice(ref BottlePrice bp) {

        bp.Generation = new float[14];

        bp.Generation[0] = 4000f; // JPY
        bp.Generation[1] = bp.Generation[0] / 2f; //半价
        bp.Generation[2] = bp.Generation[1] * 10f; //十倍价格 of 典当价

        for (int i = 0; i < 3; i++) {
            Debug.Log("第" + (i+1) + "代价格： " + bp.Generation[i] + "日元");
        }

        for (int i = 3; i < bp.Generation.Length; i++) {
            bp.Generation[i] = bp.Generation[i - 1] * 2f; //每年价值翻倍 - 每代
            Debug.Log("第" + (i+1) + "代价格： " + bp.Generation[i] + "日元");
        }
    }

    
    //10.编写一个函数，传入学校结构体，旅行社结构体及喜翠瓶价格结构体，求出园长妈妈最终的盈亏。
    float Balance(ref School a, ref Agent b, ref BottlePrice c) {
        float margin = Margin(a, b);
        float cost = c.Generation[c.Generation.Length-1] * 0.8f;
        float rate = 0.0638f; // JPY -> CNY

        return margin - cost * rate; 

    }



    void Start()
    {
        // Q1 & Q2
        School abcSchool;
        abcSchool.TotalStudent = 108;
        abcSchool.TotalF = 48;
        abcSchool.TotalM = 60;
        abcSchool.Level3 = 30;
        abcSchool.Level2 = 36;
        abcSchool.Level1 = 42;
        abcSchool.Level3M = 30 / 2;
        abcSchool.Level3F = 30 / 2;
        abcSchool.Level2M = (36 / 2) + 4 / 2;
        abcSchool.Level2F = 36 - abcSchool.Level2M;
        abcSchool.Level1M = 60 - abcSchool.Level3M - abcSchool.Level2M;
        abcSchool.Level1F = 48 - abcSchool.Level3F - abcSchool.Level2F;

        PrintLevel1(ref abcSchool);


        // Q3 & Q4
        Agent niwa;
        niwa.Name = "日和";
        niwa.BlackCost = 1900f;
        niwa.WhiteCostL1 = 2500f;
        niwa.WhiteCostL2 = 2200f;
        niwa.WhiteCostL3 = 2000f;

        float margin = Margin(abcSchool, niwa);
        Debug.Log("园长妈妈回扣: " + margin + "元");

        // Q5,Q6
        Weapon redSword;
        redSword.Length = 2.0f;
        redSword.Width = 0.4f;
        redSword.Attack = 80f;
        redSword.Guard = 20f;
        redSword.Color = "red";

        Weapon blueShield;
        blueShield.Length = 1.5f;
        blueShield.Width = 1.5f;
        blueShield.Attack = 30f;
        blueShield.Guard = 90f;
        blueShield.Color = "lightblue";

        float area = SumArea(ref redSword, ref blueShield);
        Debug.Log("两个武器的面积之和: " + area + "平方尺");

        // Q7
        float BadGuyHealth = 1000f;
        AfterAttack(BadGuyHealth, ref redSword, ref blueShield);

        //Q8 & Q9
        BottlePrice xcp = new BottlePrice();
        PrintPrice(ref xcp);

        //Q10
        float balance = Balance(ref abcSchool, ref niwa, ref xcp);
        Debug.Log("园长妈妈最终的盈亏: " + balance + "元");
    }



}
