using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson6_MengMeng : MonoBehaviour
{
    //    习题：
    //1. Wupeng是一名勇士，有如下属性，名字叫wupeng,初始精力为0 ，攻击力为8 。声明一个Wupeng结构体
    //2. 豆豆是一名可爱的豆豆，有如下属性，名字叫doudou，初始生命值为1000 。声明一个doudou结构体
    //3. Wupeng一天就干三件事，吃饭，睡觉，打豆豆。最开始做的事情是吃饭，wupeng会用3秒吃饭补充精力，当精力达到了100时开始打豆豆，每秒打一下豆豆，每次打豆豆需要消耗10点的精力。当精力为0时，需要睡觉，睡足5秒后起床吃饭。如此循环。请使用状态机实现此过程。
    //4. Zz是一名豆豆爱好者，有如下属性，名字叫zz，治疗力为回复5生命值/秒。声明一个zz结构体
    //5. Zz会在wupeng睡觉的时候为豆豆补充生命，zz为豆豆补充血量时的过程是这样的：准备医疗工具1秒，为豆豆补血2秒，拆除医疗工具1秒。请使用状态机实现此过程（将代码嵌入第3题的状态机中）
    //6. Wuwu是一名啦啦队爱好者，有如下属性，名字叫wuwu，治疗加成为1 。在zz准备工具和治疗的时候为zz加油，wuwu每秒钟能喊出3次加油，每次都能让zz回复能力加成，加成效果在zz治疗结束后消失 。将wuwu的功能嵌入第3题的状态机中。
    //7. Mengmeng是鼓手，名字叫mengmeng，攻击力加成为1 ，在wupeng不睡觉的时候敲鼓，mengmeng每秒钟可敲4下鼓，当敲第偶数下鼓的时候，能让wupeng的攻击力加成，加成效果在wupeng睡觉的时候消失。将mengmeng的功能嵌入第3题的状态机中。
    //8. 模拟交通信号灯的运行（使用状态机，使用三张unity Image）
    //9. 每隔三秒打印当前经过的时间，使用如下格式“年：月：日：小时：分钟：秒”
    //10. 模拟火箭升空过程，倒数十秒，点火2秒，升空(使用状态机，unity image充当火箭，请网上查找如何改变image坐标的方法)


    struct Wupeng
    {
        public int Energy;
        readonly int Base_Atk;
        public int Atk;
        public enum State { Eating, Sleeping, Beating };
        public State state;
        public float CurrentTime;
        public Wupeng(int energy, int atk)
        {
            Energy = energy;
            Base_Atk = atk;
            Atk = Base_Atk;
            state = State.Eating;
            CurrentTime = 0;
        }

        public void SateMachine(ref Doudou doudou, ref Zz zz, ref WuWu wuwu, ref MengMeng meng)
        {
            CurrentTime += Time.deltaTime;
            //Debug.Log(CurrentTime);
            switch (state)
            {
                case Wupeng.State.Eating:
                    meng.StateMachine(ref this);
                    if (CurrentTime - 3f >= 0)
                    {
                        CurrentTime = 0;
                        Energy = 100;
                        state = Wupeng.State.Beating;
                        Debug.Log("Wupeng is Beating");
                    }
                    break;
                case Wupeng.State.Beating:
                    meng.StateMachine(ref this);
                    if (CurrentTime - 1f >= 0)
                    {
                        CurrentTime = 0;
                        Energy -= 10;
                        doudou.HP -= Atk;
                        Debug.Log("doudou.HP is " + doudou.HP);
                        Debug.Log("Wupeng.Energy is " + Energy);
                        if (Energy <= 0)
                        {
                            state = Wupeng.State.Sleeping;
                            Debug.Log("Wupeng is Sleeping");
                        }
                    }
                    break;
                case Wupeng.State.Sleeping:
                    Atk = Base_Atk;
                    zz.SateMachine(ref doudou, ref wuwu);
                    if (CurrentTime - 5f >= 0)
                    {
                        CurrentTime = 0;
                        state = Wupeng.State.Eating;
                        Debug.Log("Wupeng is Eating");
                    }
                    break;
            }
        }

    }
    struct Doudou
    {
        public int HP;
        public Doudou(int hp)
        {
            HP = hp;
        }
    }
    struct Zz
    {
        readonly int Base_Heal;
        public int Heal;
        public enum State { Preparing, Healing, Removing };
        public State state;
        public float HealingTime;
        public float CurrentTime;
        public Zz(int heal)
        {
            Base_Heal = heal;
            Heal = Base_Heal;
            HealingTime = 1f;
            state = State.Preparing;
            CurrentTime = 0;
        }

        public void SateMachine(ref Doudou doudou, ref WuWu wuwu)
        {
            CurrentTime += Time.deltaTime;
            switch (state)
            {
                case Zz.State.Preparing:
                    wuwu.StateMachine(ref this);
                    if (CurrentTime >= 1f)
                    {
                        CurrentTime = 0;
                        state = Zz.State.Healing;
                        Debug.Log("zz is Healing");
                    }
                    break;
                case Zz.State.Healing:
                    wuwu.StateMachine(ref this);
                    if (CurrentTime > HealingTime)
                    {
                        HealingTime++;
                        doudou.HP += Heal;
                        Heal = Base_Heal;
                        Debug.Log("doudou.Hp is" + doudou.HP);
                    }
                    if (CurrentTime >= 2f)
                    {
                        CurrentTime = 0;
                        HealingTime = 1f;
                        state = Zz.State.Removing;
                        Debug.Log("zz is Removing");
                    }
                    break;
                case Zz.State.Removing:
                    if (CurrentTime >= 1f)
                    {
                        CurrentTime = 0;
                        state = Zz.State.Preparing;
                        Debug.Log("zz is Preparing");
                    }
                    break;
            }
        }

    }
    struct WuWu
    {
        public int HealAdd;
        public float CurrentTime;
        public float HealAddTime;
        public WuWu(int healadd)
        {
            HealAdd = healadd;
            CurrentTime = 0;
            HealAddTime = 1.0f / 3.0f;
        }
        public void StateMachine(ref Zz zz)
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= HealAddTime)
            {
                HealAddTime += 1.0f / 3.0f;
                zz.Heal += HealAdd;
                Debug.Log("zz.Heal is" + zz.Heal);
            }
        }
    }
    struct MengMeng
    {
        public int AtkAdd;
        public int BangingTimes;
        public float CurrentTime;
        public float AtkAddTime;
        public MengMeng(int add)
        {
            AtkAdd = add;
            CurrentTime = 0;
            AtkAddTime = 1.0f / 4.0f;
            BangingTimes = 0;
        }
        public void StateMachine(ref Wupeng wupeng)
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= AtkAddTime)
            {
                AtkAddTime += 1.0f / 4.0f;
                BangingTimes++;
                Debug.Log(BangingTimes);
                if (BangingTimes % 2 == 0)
                {
                    wupeng.Atk += AtkAdd;
                    Debug.Log("wupeng.Atk is" + wupeng.Atk);
                }
            }
        }
    }


    enum LightState { RedState, GreenState, YellowState }

    void TrafficStateMachine(ref float CurrentTime, ref LightState lightState)
    {
        Image RedLight = transform.Find("/Canvas/TrafficLight_Panel/TrafficLight_Red").GetComponent<Image>();
        Image GreenLight = transform.Find("/Canvas/TrafficLight_Panel/TrafficLight_Green").GetComponent<Image>();
        Image YellowLight = transform.Find("/Canvas/TrafficLight_Panel/TrafficLight_Yellow").GetComponent<Image>();
        Text Countdowm = transform.Find("/Canvas/TrafficLight_Panel/Countdown").GetComponent<Text>();

        Color DarkGreen = new Color(0, 0.5f, 0, 1);
        Color DarkRed = new Color(0.5f, 0, 0, 1);
        Color DarkYellow = new Color(0.5f, 0.5f, 0, 1);

        CurrentTime -= Time.deltaTime;
        Countdowm.text = Mathf.FloorToInt(CurrentTime).ToString();
        switch (lightState)
        {
            case LightState.RedState:
                RedLight.color = Color.red;
                GreenLight.color = DarkGreen;
                YellowLight.color = DarkYellow;
                if (CurrentTime <= 0)
                {
                    lightState = LightState.GreenState;
                    CurrentTime = 8.5f;
                }
                break;
            case LightState.GreenState:
                RedLight.color = DarkRed;
                GreenLight.color = Color.green;
                YellowLight.color = DarkYellow;
                if (CurrentTime <= 0)
                {
                    lightState = LightState.YellowState;
                    CurrentTime = 2.5f;
                }
                break;
            case LightState.YellowState:
                RedLight.color = DarkRed;
                GreenLight.color = DarkGreen;
                YellowLight.color = Color.yellow;
                if (CurrentTime <= 0)
                {
                    lightState = LightState.RedState;
                    CurrentTime = 10.5f;
                }
                break;
        }
    }

    void ShowPassedTime(ref float currentTime, ref int SecondsCount)
    {
        currentTime += Time.deltaTime;
        if (currentTime - SecondsCount >= 0)
        {
            SecondsCount += 3;
            int TotalTime = Mathf.FloorToInt(currentTime);
            int second = TotalTime % 60;
            int minute = TotalTime / 60 % 60;
            int hour = TotalTime / 60 / 60 % 24;
            int day = TotalTime / 60 / 60 / 24 % 30;
            int month = TotalTime / 60 / 60 / 24 / 30 % 12;
            int year = TotalTime / 60 / 60 / 24 / 30 / 12;
            Debug.Log("已经过去了" + year + "年" + month + "月" + day + "日" + hour + "时" + minute + "分" + second + "秒");
        }
    }

    void Rocket(ref float CurrentTime, ref int RocketState)
    {
        RawImage Rocket = transform.Find("/Canvas/Rocket").GetComponent<RawImage>();
        Text RocketDescribe = transform.Find("/Canvas/Rocket/Text").GetComponent<Text>();
        switch (RocketState)
        {
            case 2:
                CurrentTime -= Time.deltaTime;
                RocketDescribe.text = "火箭发射：" + Mathf.CeilToInt(CurrentTime);
                if (CurrentTime <= 0)
                {
                    CurrentTime = 2;
                    RocketState = 1;
                }
                break;
            case 1:
                CurrentTime -= Time.deltaTime;
                RocketDescribe.text = "火箭点火：" + Mathf.CeilToInt(CurrentTime);
                if (CurrentTime <= 0)
                {
                    RocketState = 0;
                    CurrentTime = 0;
                }
                break;
            case 0:
                CurrentTime += Time.deltaTime;
                RocketDescribe.text = "起飞！";
                //火箭发射要有一个加速度，我就默认是一个a=1的匀加速了，不然计算太麻烦。
                Rocket.transform.Translate(new Vector3(0, CurrentTime, 0));
                break;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    Wupeng wupeng = new Wupeng(0, 8);
    Doudou doudou = new Doudou(1000);
    Zz zz = new Zz(5);
    WuWu wuwu = new WuWu(1);
    MengMeng meng = new MengMeng(1);
    // Update is called once per frame
    float TrafficTime = 10.5f;
    LightState lightState = LightState.RedState;
    float CountTime = 0;
    int SecondsCount = 3;
    float RockteTime = 10;
    int RocketState = 2;
    void Update()
    {
        while (doudou.HP > 0)
        {
            wupeng.SateMachine(ref doudou, ref zz, ref wuwu, ref meng);
        }

        TrafficStateMachine(ref TrafficTime, ref lightState);

        ShowPassedTime(ref CountTime, ref SecondsCount);
        Rocket(ref RockteTime, ref RocketState);
    }
}
