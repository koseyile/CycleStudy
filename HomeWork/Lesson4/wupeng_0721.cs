using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wupeng_0721 : MonoBehaviour
{
    public struct School
    {
        public int num_students;

        public int num_boys;
        public int num_girls;

        public int num_Junior;
        public int num_Middle;
        public int num_Senior;

        public int boysMuch_Senior;
        public int boysMuch_Middle;
    }

    public struct Travel
    {
        public Book white;
        public Book black;
    }

    public struct Book
    {
        public int cost_Junior;
        public int cost_Middle;
        public int cost_Senior;
    }

    public struct Weapon
    {
        public string color;
        public string name;
        public int length;
        public int width;
        public int attack;
        public int defend;
    }

    public struct Bottle_Price
    {
        public int[] generation_Price;
    }

    // Start is called before the first frame update
    void Start()
    {
        //01
        School school = new School();
        school.num_students = 108;
        school.num_boys = 60;
        school.num_girls = 48;

        school.num_Junior = 42;
        school.num_Middle = 36;
        school.num_Senior = 30;
        school.boysMuch_Middle = 4;
        school.boysMuch_Senior = 0;

        //02
        Work_02(ref school);


        //03
        Book black = new Book();
        black.cost_Junior = 1900;
        black.cost_Middle = 1900;
        black.cost_Senior = 1900;

        Book white = new Book();
        white.cost_Junior = 2500;
        white.cost_Middle = 2200;
        white.cost_Senior = 2000;

        //04
        Travel travel = new Travel();
        travel.black = black;
        travel.white = white;

        Work_04(ref school, ref travel);

        //05
        Weapon redSword = new Weapon() { color = "red", name = "RedSward", length = 20, width = 4, attack = 80, defend = 20 };

        Weapon blueShield = new Weapon() { color = "blue", name = "BlueShield", length = 15, width = 15, attack = 30, defend = 90 };

        //06

        int a = AreaWeapon(ref redSword) + AreaWeapon(ref blueShield);
        Debug.Log("面积之和：" + a + "平方寸");

        //07
        RedLightAttack(1000, ref redSword, ref blueShield);

        //08
        Bottle_Price bp = new Bottle_Price();
        bp.generation_Price = new int[14];
        bp.generation_Price[0] = 4000;
        bp.generation_Price[1] = 4000 / 2;
        bp.generation_Price[2] = 4000 / 2 * 10;
        bp.generation_Price[3] = 4000 / 2 * 10;

        //09
        Work_09(ref bp);

        //10
        Work_10(ref school, ref travel, ref bp);

    }

    public void Work_02(ref School school)
    {
        //打印小班男女人学生人数
        int num_boys = school.num_boys - (school.num_Senior + school.boysMuch_Senior) / 2 -
            (school.num_Middle + school.boysMuch_Middle) / 2;

        int num_girls = school.num_Junior - num_boys;

        Debug.Log("小班男生：" + num_boys);
        Debug.Log("小班女生：" + num_girls);
    }

    public int Work_04(ref School school, ref Travel travel)
    {

        //老师吃了多少回扣
        int whiteMoney = travel.white.cost_Junior * school.num_Junior +
            travel.white.cost_Middle * school.num_Middle +
            travel.white.cost_Senior * school.num_Senior;
        int blackMoney = travel.black.cost_Middle * school.num_students;

        int money = whiteMoney - blackMoney;  

        Debug.Log("回扣：" + money);

        return money;
        
    }

    public int AreaWeapon(ref Weapon weapon)
    {
        return weapon.length * weapon.width * 2;
    }

    public void RedLightAttack(int hp, ref Weapon redSward, ref Weapon blueShield)
    {

        Debug.Log("红光之力攻击！”");
        int hpLeft = hp - redSward.attack * 2;

        int dpGain = hpLeft / 2;

        blueShield.defend = dpGain + blueShield.defend;

        Debug.Log("敌人剩余血量：" + hpLeft + "  " + blueShield.name + "护甲值：" + blueShield.defend);
    }

    public void Work_09(ref Bottle_Price bp)
    {
        for (int i = 4; i < bp.generation_Price.Length; i ++)
        {
            bp.generation_Price[i] = bp.generation_Price[i - 1] * 2;
        }

        for (int i = 0; i < bp.generation_Price.Length; i ++)
        {
            Debug.Log("第" + (i + 1) + "代价格：" + bp.generation_Price[i]);
        }

    }

    public void Work_10(ref School school, ref Travel travel, ref Bottle_Price bp)
    {
        int blackmoney = Work_04(ref school, ref travel);

        float moneyFinal = (float)blackmoney - JANToRMB((float)bp.generation_Price[bp.generation_Price.Length - 1] * 0.8f);

        Debug.Log("园长最终盈亏：" + moneyFinal);
    }


    public float JANToRMB(float jan)
    {
        return 0.063f * jan;
    }
}
