using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson6_Naomi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    //1-7题---------------------------------------------------------------------

    Wupeng wupenG = new Wupeng(0, 8);
    Doudou doudoU = new Doudou(1000);
    Zz zZ = new Zz(5);
    Wuwu wuwU = new Wuwu(1);
    Mengmeng meng = new Mengmeng(1);

    //8题-----------------------------------------------------------------------

    LightState lightState = LightState.RedLight;
    float trafficTime = 0.0f;
    public Image redLight;
    public Image greenLight;
    public Image yellowLight;

    //9题-----------------------------------------------------------------------
    float timenow = 0.0f;
    float timer = 3.0f;

    //10题-------------------------------------------------------------------
    int countNumber = 10;
    float rocketTime = 0.0f;
    RocketState rocketstate = RocketState.Countdown;
    public Image rocket;

    // Update is called once per frame
    void Update()
    {
        //1-7题-----------------------------------------------------------------
        //问：调用函数时如果和声明函数的时候用的是同样的名字，会报错？
        //EatingSleepingBeatingDoudou(ref wupenG, ref doudoU, ref zZ, ref wuwU, ref meng);

        //8题-------------------------------------------------------------------
        //TrafficState(ref trafficTime,ref lightState);

        //9题-------------------------------------------------------------------
        //PrintDateTime(ref timenow,ref timer);

        //10题-------------------------------------------------------------------
        Rocket(ref rocketTime, ref rocketstate);
    }

    //1-7题---------------------------------------------------------------------

    struct Wupeng
    {
        public float Nrg;//energy
        public float Atk;//当前attack值
        public float AtkBase;//attack起始值
        //问：enum为什么不用打分号呀
        public enum Stats
        {
            Eat,
            Sleep,
            Beat
        }
        public Stats CurrentStats;
        public float CurrentTime;
        public Wupeng(int nrg,int atk)
        {
            Nrg = nrg;
            AtkBase = atk;
            Atk = atk;
            CurrentStats = Stats.Eat;
            CurrentTime = 0.0f;
        }
    }

    struct Doudou
    {
        public float HP;
        public Doudou(float hp)
        {
            HP = hp;
        }
    }

    struct Zz
    {
        public float Heal;
        public float HealBase;
        public enum Stats
        {
            Prepare,
            Heal,
            Remove
        }
        public Stats CurrentStats;
        public float CurrentTime;
        public float HealingTime;
        public Zz(float heal)
        {
            Heal = heal;
            HealBase = heal;
            CurrentStats = Stats.Prepare;
            CurrentTime = 0.0f;
            HealingTime = 0.0f;
        }
    }

    struct Wuwu
    {
        public float HealAdd;
        public float HealAddTime;
        public float CurrentTime; 
        public Wuwu(float healadd)
        {
            HealAdd = healadd;
            CurrentTime = 0.0f;
            HealAddTime = 1.0f / 3.0f;
        }
        public void HealAdding(ref Zz zz)//成员函数？所以声明函数和struct这些都是没有先后顺序的？
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= HealAddTime)
            {
                zz.Heal += HealAdd;
                CurrentTime = 0.0f;
                Debug.Log("zz.Heal rises to" + zz.Heal);
            }
        }
    }

    struct Mengmeng
    {
        public float AtkAdd;//攻击加成
        public float AtkAddTime;//攻击加成一次的时间
        public int BuffTimes;//攻击加成的次数
        public float CurrentTime;
        public Mengmeng(float atkAdd)
        {
            AtkAdd = atkAdd;
            AtkAddTime = 1.0f / 4.0f;
            CurrentTime = 0.0f;
            BuffTimes = 0;
        }

        public void AtkAdding(ref Wupeng wupeng)
        {
            CurrentTime += Time.deltaTime;
            if( CurrentTime > AtkAddTime)
            {
                BuffTimes++;
                CurrentTime = 0.0f;
                if (BuffTimes % 2 == 0)
                {
                    wupeng.Atk += AtkAdd;
                    Debug.Log("wupeng.Atk rises to" + wupeng.Atk);
                }
            }
        }
    }

    void Healing(ref Zz zz, ref Wuwu wuwu, ref Doudou doudou)
    {
        switch (zz.CurrentStats)
        {
            case Zz.Stats.Prepare:
                {
                    wuwu.HealAdding(ref zz);
                    zz.CurrentTime += Time.deltaTime;
                    if (zz.CurrentTime >= 1.0f)
                    {
                        zz.CurrentStats = Zz.Stats.Heal;
                        zz.CurrentTime = 0.0f;
                        Debug.Log("zz starts Healing doudou");
                    }
                }
                break;
            case Zz.Stats.Heal:
                {
                    wuwu.HealAdding(ref zz);
                    zz.CurrentTime += Time.deltaTime;
                    zz.HealingTime += Time.deltaTime;
                    if (zz.HealingTime >= 1.0f)
                    {
                        doudou.HP += zz.Heal;
                        zz.HealingTime = 0.0f;
                        Debug.Log("After healing, Doudou.HP is" + doudou.HP);
                    }

                    if (zz.CurrentTime >= 2.0f)
                    {
                        zz.CurrentStats = Zz.Stats.Remove;
                        zz.CurrentTime = 0.0f;
                        Debug.Log("zz starts Removing");
                    }
                }
                break;
            case Zz.Stats.Remove:
                if (zz.CurrentTime >= 1f)
                {
                    zz.CurrentStats = Zz.Stats.Prepare;
                    zz.CurrentTime = 0.0f;
                    Debug.Log("zz starts Preparing");
                }
                break;
        }
    }

    void EatingSleepingBeatingDoudou(ref Wupeng wupeng,ref Doudou doudou,ref Zz zz,ref Wuwu wuwu,ref Mengmeng mengmeng)
    {
        switch(wupeng.CurrentStats)
        {
            case Wupeng.Stats.Eat:
            {
                    wupeng.CurrentTime += Time.deltaTime;
                    mengmeng.AtkAdding(ref wupeng);
                    if (wupeng.CurrentTime >= 3.0f)//问：大于和等于的时间应该是不一样的？
                    {
                        wupeng.Nrg = 100f;
                        wupeng.CurrentStats = Wupeng.Stats.Beat;
                        wupeng.CurrentTime = 0.0f;
                        Debug.Log("wupeng starts beating doudou");
                    }
            }
            break;
            case Wupeng.Stats.Beat:
            {
                    wupeng.CurrentTime += Time.deltaTime;
                    wupeng.Nrg -= 10;
                    Debug.Log("Wupeng.Energy drops to " + wupeng.Nrg);
                    mengmeng.AtkAdding(ref wupeng);
                    doudou.HP -= wupeng.Atk;
                    Debug.Log("doudou.HP drops to" + doudou.HP);
                    if (wupeng.Nrg < 0.0f)
                    {
                        wupeng.CurrentStats = Wupeng.Stats.Sleep;
                        wupeng.CurrentTime = 0.0f;
                        wupeng.Atk = wupeng.AtkBase;
                        Debug.Log("Wupeng.Atk returns to" + wupeng.Atk);
                        Debug.Log("Wupeng starts sleeping");
                    }
            }
            break;
            case Wupeng.Stats.Sleep:
            {
                    wupeng.CurrentTime += Time.deltaTime;
                    Healing(ref zz, ref wuwu, ref doudou);
                    if (wupeng.CurrentTime >= 5.0f)
                    {
                        zz.Heal = zz.HealBase;
                        Debug.Log("zz.Heal returns to" + zz.Heal);
                        wupeng.CurrentStats = Wupeng.Stats.Eat;
                        wupeng.CurrentTime = 0.0f;
                        Debug.Log("Wupeng starts eating");
                    }
            }
            break;
        }
    }

    //8题---------------------------------------------------------------------

    enum LightState
    {
        RedLight,
        GreenLight,
        YellowLight2G,//红灯变绿灯之间的黄灯
        YellowLight2R//绿灯变红灯之间的黄灯
    }

    void TrafficState(ref float TrafficTime, ref LightState currentState)
    {
        switch (currentState)
        {
            case LightState.RedLight:
                {
                    TrafficTime += Time.deltaTime;
                    if(TrafficTime > 4.0f)
                    {
                        currentState = LightState.YellowLight2G;
                        redLight.color = Color.black;
                        greenLight.color = Color.black;
                        yellowLight.color = Color.yellow;
                        TrafficTime = 0.0f;
                    }
                }
                break;
            case LightState.YellowLight2G:
                {
                    TrafficTime += Time.deltaTime;
                    if (TrafficTime > 1.0f)
                    {
                        currentState = LightState.GreenLight;
                        yellowLight.color = Color.black;
                        greenLight.color = Color.green;
                        TrafficTime = 0.0f;
                    }
                }
                break;
            case LightState.GreenLight:
                {
                    TrafficTime += Time.deltaTime;
                    if (TrafficTime > 4.0f)
                    {
                        currentState = LightState.YellowLight2R;
                        greenLight.color = Color.black;
                        yellowLight.color = Color.yellow;
                        TrafficTime = 0.0f;
                    }
                }
                break;
            case LightState.YellowLight2R:
                {
                    TrafficTime += Time.deltaTime;
                    if (TrafficTime > 2.0f)
                    {
                        currentState = LightState.RedLight;
                        yellowLight.color = Color.black;
                        redLight.color = Color.red;
                        TrafficTime = 0.0f;
                    }
                }
                break;
        }
    }

    //9题-----------------------------------------------------------------------

    void PrintDateTime(ref float TimeNow,ref float Timer)
    {
        TimeNow += Time.deltaTime;
        if (TimeNow > Timer)
        {
            TimeNow = 0.0f;
            Debug.Log(System.DateTime.Now);
        }
    }

    //10题----------------------------------------------------------------------

    enum RocketState
    {
        Countdown,
        Fire,
        Launch,
    }

    void Rocket(ref float RocketTime, ref RocketState rocketstate)
    {
        switch (rocketstate)
        {
            case RocketState.Countdown:
                {
                    RocketTime += Time.deltaTime;
                    if (RocketTime > 1.0f && countNumber >= 0)
                    {
                        countNumber--;
                        Debug.Log(countNumber);
                        RocketTime = 0.0f;
                        if (countNumber == 1)
                        {
                            rocketstate = RocketState.Fire;
                            rocket.color = Color.red; 
                            RocketTime = 0.0f;
                            Debug.Log("Fire");
                        }
                    }
                }
                break;
            case RocketState.Fire:
                {
                    RocketTime += Time.deltaTime;
                    if (RocketTime > 2.0f)
                    {
                        rocketstate = RocketState.Launch;
                        rocket.color = Color.white;
                        RocketTime = 0.0f;
                        Debug.Log("Launch");
                    }

                }
                break;
            case RocketState.Launch:
                {
                    RocketTime += Time.deltaTime;
                    rocket.transform.localPosition += new Vector3(0, 20, 0);
                }
                break;

        }
    }
}
