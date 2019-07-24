using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_MengMeng : MonoBehaviour
{
    //    习题
    //“园长妈妈”是一位出色的校长，她管理的幼儿园有108位学生，男生60名，女生48名。大班30名，中班36名，小班42名。大班男女比例一样，中班男生比女生多4名。
    //* 1.定义一个学校结构体，包含上述所有数据
    //* 2.编写一个函数，输入参数为学校结构体，打印小班男女人数各为多少。

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
    //* 3.定义一个旅行社结构体，包含所有旅行社信息
    //* 4.编写一个函数，传参为学校结构体和旅行社结构体，求出园长妈妈吃了多少回扣

    //中班里有一位叫Hank的小朋友，右手握着红光剑，左手拿着蓝光盾。红光剑长二尺，宽4寸，攻击80 ，护甲20 ，剑身泛红光。蓝光盾长宽各1尺5寸，攻击30 ，护甲90 ，盾面呈淡蓝色。
    //据Hank经常在小朋友面前讲，红光剑在遇到坏人时，剑身会剧烈抖动，并聚集红色光波能量，只要Hank大喊一声：“红光之力攻击！”，红光剑就会发出红光能量射向敌人，对敌人造成2倍的攻击伤害，
    //然后吸取敌人的一半的生命值转化为蓝光盾的护甲值，蓝光盾发出鲜艳蓝光。Hank利用这一招吸引了不少同学的注意，但没有人相信他，除了一个叫郭梦琪的小女孩。
    //而且今天郭梦琪注意到了，园长妈妈给Hank发糖果的时候，红光剑在抖动。

    //* 5.定义武器结构体，包含上述所有武器信息，实例化红光剑和蓝光盾。
    //* 6.编写一个函数，传参为红光剑和蓝光盾，求出两个武器的面积之和。
    //* 7.假设有个坏人血量为1000 ，求出Hank大喊：“红光之力攻击！”后，编写一个函数打印如下数据：坏人剩余血量，蓝光盾的护值。


    //终于到了京都，园长妈妈选择了京都一家百年旅店，名叫“喜翠庄”，老板娘是四十万家族第十四代传人，人称“四十万 翠”。喜翠庄的名字来源于店内一只青花瓷，叫喜翠瓶。喜翠瓶本是一只普通的青花瓷，产自中国景德镇，四十万一代在中国花4000日币带到日本，四十万二代在战争期间以半价押给典当铺，四十万三代以十倍价格从典当铺赎回，四十万四代为喜翠瓶命名，创立喜翠庄，后经过十代人的苦心经营，现传到四十万翠的手中。
    //一件不值钱的玩意，经过时间人情晕染，竟也价值连城起来。
    //四十万翠有意立孙女松前 緒花为第十五代传人，但松前 緒花好像没什么兴趣。
    //* 8.定义喜翠瓶在每一代的价格结构体
    //* 9.假设喜翠瓶在第四代之后，每年价值翻倍，编写一个函数，传入参数为喜翠瓶价格结构体，填充结构体数据，打印喜翠瓶在每一代人手中的价格。

    //郭梦琪举起红光剑，指向园长妈妈，大喊：红光之力攻击！明亮的红光照亮了所有小朋友的脸，小朋友脸上展现出惊叹表情，尤其是Hank，自己的武器居然在郭梦琪手中觉醒了。红光能量在接触到园长妈妈的一瞬间，突然调转方向，击碎了喜翠瓶。
    //园长妈妈也惊呆了，这得赔不少钱吧。
    //园长妈妈经过激烈的讨价还价，最终要赔偿喜翠瓶价值的八成。并让所有小朋友为喜翠庄劳动一天，小朋友们开心地跟着松前 緒花小姐姐劳动去了。松前 緒花小姐姐好像比小朋友们还要开心。
    //在随后的几天，松前 緒花带领着小朋友们逛遍京都角落，他们建立了深厚的友谊，就连京都的樱花，古楼，林克，马里奥，宝可梦们都羡慕不已。

    //这次春游小朋友们果真获得了成长呢。
    //* 10.编写一个函数，传入学校结构体，旅行社结构体及喜翠瓶价格结构体，求出园长妈妈最终的盈亏。

    // Use this for initialization
    #region 结构体部分
    struct Grade
    {
        public int BoyNum;
        public int GirlNum;
    }
    struct Kindergarten
    {
        public Grade Bottom;
        public Grade Middle;
        public Grade Top;
    }

    struct Quotation
    {
        public int BottomCost;
        public int MiddleCost;
        public int TopCost;
    }
    struct Travel_Agency
    {
        public Quotation Black;
        public Quotation White;


        public Travel_Agency(int White_Bottom, int White_Middle, int White_Top, int Black_Bottom, int Black_Middle, int Black_Top)
        {
            Black.BottomCost = Black_Bottom;
            Black.MiddleCost = Black_Middle;
            Black.TopCost = Black_Top;
            White.BottomCost = White_Bottom;
            White.MiddleCost = White_Middle;
            White.TopCost = White_Top;
        }
    }

    struct Equipment
    {
        public enum EquipmentType { Sword, Shield };
        public EquipmentType type;
        public enum EquipmentColor { Red, Blue };
        public EquipmentColor color;

        public int Length;
        public int Width;
        public int Atk;
        public int Armor;

        public Equipment(EquipmentType _type, EquipmentColor _color, int _Length, int _Width, int _Atk, int _Def)
        {
            type = _type;
            color = _color;
            Length = _Length;
            Width = _Width;
            Atk = _Atk;
            Armor = _Def;
        }
    }

    struct XiCui
    {
        public List<ulong> Price;

        //由于前四代的价格已经确定，所以直接在构造函数里定义就好。传参a没有意义，只是因为struct的构造函数必须要有参数而已
        public XiCui(int a)
        {
            Price = new List<ulong>
            {
                0,      //第0代是0
                256,    //第1代是4000日元，为了方便后面计算我就直接折算成人民币了
                128,
                1280,
                1280
            };
        }
    }

    #endregion

    #region 方法部分

    //虽然很多地方没必要用ref，但是为了节约内存，我都统一加上了ref

    //先直接写个函数把幼儿园给构造好
    Kindergarten SetKindergarten()
    {
        Kindergarten kindergarten = new Kindergarten();
        kindergarten.Top.BoyNum = 15;
        kindergarten.Top.GirlNum = 15;
        kindergarten.Middle.BoyNum = 20;
        kindergarten.Middle.GirlNum = 16;
        kindergarten.Bottom.BoyNum = 60 - kindergarten.Top.BoyNum - kindergarten.Middle.BoyNum;
        kindergarten.Bottom.GirlNum = 48 - kindergarten.Top.GirlNum - kindergarten.Middle.GirlNum;
        return kindergarten;
    }
    //打印小班男女人数
    void ShowBottomGrade(ref Kindergarten kindergarten)
    {
        Debug.Log("该幼儿园的小班的男生人数为：" + kindergarten.Bottom.BoyNum);
        Debug.Log("该幼儿园的小班的女生人数为：" + kindergarten.Bottom.GirlNum);
    }
    //求出妈妈的回扣
    int GetMaMaIncomings(ref Kindergarten kindergarten, ref Travel_Agency travel_Agency)
    {
        return
              (travel_Agency.White.TopCost - travel_Agency.Black.TopCost) * (kindergarten.Top.BoyNum + kindergarten.Top.GirlNum) +
              (travel_Agency.White.MiddleCost - travel_Agency.Black.MiddleCost) * (kindergarten.Middle.BoyNum + kindergarten.Middle.GirlNum) +
              (travel_Agency.White.BottomCost - travel_Agency.Black.BottomCost) * (kindergarten.Bottom.BoyNum + kindergarten.Bottom.GirlNum);
    }
    //求出2件装备的面积和
    int GetEquipmentsArea(ref Equipment A, ref Equipment B)
    {
        return A.Length * A.Width + B.Length + B.Width;
    }
    //打印红光攻击的效果
    void Skill_RedLightAttack(int EnemyHp, ref Equipment Sword, ref Equipment Shield)
    {
        EnemyHp = Mathf.Max(0, EnemyHp - 2 * Sword.Atk);
        EnemyHp /= 2;
        Shield.Armor += EnemyHp;
        Debug.Log("该敌人还剩" + EnemyHp + "点生命，盾的护甲现在是" + Shield.Armor);
    }
    //打印每一代的价格
    void SetXiCui_Price(ref XiCui xicui, int Gengeration)
    {
        while (Gengeration >= xicui.Price.Count)
        {
            xicui.Price.Add(xicui.Price[xicui.Price.Count - 1] * 2);
        }
        for (int i = 0; i < xicui.Price.Count; i++)
        {
            Debug.Log("第" + i + "代喜翠瓶的价格为" + xicui.Price[i] + "人民币。");
        }
    }
    void GetMaMaMoney(ref Kindergarten kindergarten, ref Travel_Agency travel_Agency, ref XiCui xicui)
    {
        int Money = GetMaMaIncomings(ref kindergarten, ref travel_Agency) - (int)(xicui.Price[xicui.Price.Count - 1] * 0.8f);
        Debug.Log("园长妈妈这一趟下来一共赚了" + Money + "人民币。");
    }
    #endregion

    void Start()
    {
        Debug.Log("----------第1、2题-----------");
        Kindergarten kindergarten = SetKindergarten();
        ShowBottomGrade(ref kindergarten);

        Debug.Log("----------第3、4题-----------");
        Travel_Agency travel_Agency = new Travel_Agency(2500, 2200, 2000, 1900, 1900, 1900);
        int MaMaIncomings = GetMaMaIncomings(ref kindergarten, ref travel_Agency);
        Debug.Log("园长妈妈这一单净赚" + MaMaIncomings + "元。");

        Debug.Log("---------第5、6、7题-----------");
        Equipment RedSword = new Equipment(Equipment.EquipmentType.Sword, Equipment.EquipmentColor.Red, 20, 4, 80, 20);
        Equipment BlueShield = new Equipment(Equipment.EquipmentType.Shield, Equipment.EquipmentColor.Blue, 15, 15, 30, 90);
        Debug.Log("两件武器的面积和为" + GetEquipmentsArea(ref RedSword, ref BlueShield) + "平方寸。");
        Skill_RedLightAttack(1000, ref RedSword, ref BlueShield);

        Debug.Log("---------第8、9、10题-----------");
        XiCui xicui = new XiCui(1);
        SetXiCui_Price(ref xicui, 15);
        GetMaMaMoney(ref kindergarten, ref travel_Agency, ref xicui);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
