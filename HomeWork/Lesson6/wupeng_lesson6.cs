using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class wupeng_lesson6 : MonoBehaviour
{
    public Wupeng wupeng;

    public Doudou doudou;

    public ZZ zz;

    public Wuwu wuwu;

    public MengMeng meng;

    public Image imgRed;

    public Image imgGreen;

    public Image imgYellow;

    public TrafficLight tlight;

    public Timer timer;

    public Image imgRocket;

    public Rocket rocket;


    void Start()
    {
        //work01
        wupeng = new Wupeng() { enegy = 0, attack = 8, state = State_Wupeng.Eat, timer = 0.0f, buff = 0 };

        //work02
        doudou = new Doudou() { name = "DouDou", hp = 1000 };

        //work04
        zz = new ZZ() { name = "zz", recover = 5, timer = 0.0f, state = State_ZZ.Prepare, count = 0 , buff = 0};


        //work06
        wuwu = new Wuwu() { name = "wuwu", recoverAdd = 1, recoverSpeed = 3, timer = 0.0f};

        //work07
        meng = new MengMeng() { name = "meng", attackAdd = 1, attackSpeed = 4, timer = 0.0f, count = 0};

        //work08
        tlight = new TrafficLight() { state = State_TrafficLight.Yellow, green_last = 2.0f, red_last = 3.0f, yello_last = 1.5f, timer = 0.0f,
            yellow = imgYellow, green = imgGreen, red = imgRed };

        //work09
        timer = new Timer() { timer = 0.0f};

        //work10
        rocket = new Rocket()
        {
            image = imgRocket,
            speed = 2f,
            state = State_Rocket.counting,
            lunchDevice = new LunchDevice() { countdown_Prepare = new Timer() { timer = 10.0f,temper = 10.0f }, countdown_lunch = new Timer() { timer = 2.0f , temper = 2.0f} }
        };



    }


    void Update()
    {
        //===work03  wupeng打豆豆===
        //WupengUpdate(ref wupeng);

        //===work05  wupeng打豆豆 zz给doudou加血===
        //WupengUpdate(ref wupeng, ref zz, ref doudou);

        //===work06  wupeng打豆豆 zz给doudou加血，wuwu给zz加油===
        //WupengUpdate(ref wupeng, ref zz, ref doudou, ref wuwu);

        //===work07  wupeng打豆豆 zz给doudou加血，wuwu给zz加油， mengmeng给wupeng打鼓===
        //WupengUpdate(ref wupeng, ref zz, ref doudou, ref wuwu, ref meng);

        //work08  模拟红绿灯
        //TrafficLight(ref tlight);

        //work09 输出时间
        //LogDateTimer(ref timer);

        //work10 火箭发射
        RocketFly(ref rocket);
    }


    public void RocketFly(ref Rocket rocket)
    {

        switch (rocket.state)
        {

            case State_Rocket.counting:
                rocket.lunchDevice.countdown_Prepare.temper -= Time.deltaTime;
                if ((rocket.lunchDevice.countdown_Prepare.timer - rocket.lunchDevice.countdown_Prepare.temper) > 1.0f)
                {
                    Debug.Log("倒数" + (int)rocket.lunchDevice.countdown_Prepare.timer);
                    rocket.lunchDevice.countdown_Prepare.timer = rocket.lunchDevice.countdown_Prepare.temper;                 
                }
                if (rocket.lunchDevice.countdown_Prepare.temper < 0.0f)
                {
                    Debug.Log("发射");
                    rocket.state = State_Rocket.lunching;
                }
                break;
            case State_Rocket.lunching:
                rocket.lunchDevice.countdown_lunch.temper -= Time.deltaTime;
                if (rocket.lunchDevice.countdown_lunch.timer - rocket.lunchDevice.countdown_lunch.temper > 1.0f)
                {
                    Debug.Log("火箭离地" + (3 - (int)rocket.lunchDevice.countdown_lunch.timer) + "秒" );
                    rocket.lunchDevice.countdown_lunch.timer = rocket.lunchDevice.countdown_lunch.temper;
                }
                if (rocket.lunchDevice.countdown_lunch.temper < 0.0f)
                {
                    Debug.Log("火箭成功起飞");
                    rocket.state = State_Rocket.flying;
                }

                break;
            case State_Rocket.flying:

                rocket.image.rectTransform.position += new Vector3(0.0f, Time.deltaTime * rocket.speed, 0.0f);
                break;

        }

    }

    public void LogDateTimer(ref Timer t)
    {
        t.timer += Time.deltaTime;
        if (t.timer > 3.0)
        {
            t.timer = 0.0f;
            Debug.Log(System.DateTime.Now);
        }
    }

    public void TrafficLight(ref TrafficLight t)
    {

        switch (t.state)
        {
            case State_TrafficLight.Yellow:
                t.yellow.color = Color.yellow;
                t.timer += Time.deltaTime;
                if (t.timer > t.yello_last)
                {
                    t.timer = 0.0f;
                    t.state = State_TrafficLight.Green;
                    t.yellow.color = Color.gray;
                }
                break;
            case State_TrafficLight.Green:
                t.green.color = Color.green;

                t.timer += Time.deltaTime;
                if (t.timer > t.green_last)
                {
                    t.timer = 0.0f;
                    t.state = State_TrafficLight.Red;
                    t.green.color = Color.gray;
                }
                break;
            case State_TrafficLight.Red:
                t.red.color = Color.red;

                t.timer += Time.deltaTime;
                if (t.timer > t.red_last)
                {
                    t.timer = 0.0f;
                    t.state = State_TrafficLight.Yellow;
                    t.red.color = Color.gray;
                }

                break;
        }


    }


    public void WupengUpdate(ref Wupeng wupeng, ref Doudou doudou)
    {
        switch (wupeng.state)
        {
            case State_Wupeng.Eat:
                wupeng.timer += Time.deltaTime;
                if (wupeng.timer > 3.0f)
                {
                    wupeng.enegy += 100;
                    wupeng.timer = 0.0f;
                }

                if (wupeng.enegy == 100)
                {
                    Debug.Log("wupeng打豆豆");
                    wupeng.state = State_Wupeng.Beat;
                    wupeng.timer = 0.0f;

                }

                break;
            case State_Wupeng.Beat:
                wupeng.timer += Time.deltaTime;
                if (wupeng.timer > 1.0)
                {
                    wupeng.timer = 0.0f;
                    wupeng.enegy -= 10;

                    doudou.hp -= wupeng.attack;
                    Debug.Log("doudou被打" + wupeng.attack + "点血");
                }
                if (wupeng.enegy == 0)
                {

                    wupeng.state = State_Wupeng.Sleep;
                    Debug.Log("wupeng睡觉");
                }
                break;
            case State_Wupeng.Sleep:
                wupeng.timer += Time.deltaTime;
                if (wupeng.timer > 5.0)
                {
                    wupeng.timer = 0.0f;
                    wupeng.state = State_Wupeng.Eat;
                    Debug.Log("wupeng吃饭");
                }
                break;
        }
    }

    public void WupengUpdate(ref Wupeng wupeng, ref ZZ zz, ref Doudou doudou)
    {

        WupengUpdate(ref wupeng, ref doudou);

        ZZRecoverDoudou(ref wupeng, ref zz,ref doudou);

    }

    public void WupengUpdate(ref Wupeng wupeng, ref ZZ zz, ref Doudou doudou, ref Wuwu wuwu)
    {


        WupengUpdate(ref wupeng, ref doudou);

        ZZRecoverDoudou(ref wupeng, ref zz, ref doudou);

        WuwuComeOn(ref zz, ref wuwu);

    }

    public void WupengUpdate(ref Wupeng wupeng, ref ZZ zz, ref Doudou doudou, ref Wuwu wuwu, ref MengMeng meng)
    {


        WupengUpdate(ref wupeng, ref doudou);

        ZZRecoverDoudou(ref wupeng, ref zz, ref doudou);

        WuwuComeOn(ref zz, ref wuwu);

        MengmengComeOn(ref meng , ref wupeng);

    }


    public void ZZRecoverDoudou(ref Wupeng wupeng, ref ZZ zz, ref Doudou doudou)
    {
        if (wupeng.state == State_Wupeng.Sleep)
        {
            if(zz.state == State_ZZ.Wait)
            {
                zz.state = State_ZZ.Prepare;
            }

            switch (zz.state)
            {
                case State_ZZ.Prepare:
                    zz.timer += Time.deltaTime;
                    if (zz.timer > 1.0f)
                    {
                        zz.timer = 0.0f;
                        Debug.Log("zz开始治疗");
                        zz.state = State_ZZ.ReCover;
                    }
                    break;

                case State_ZZ.ReCover:

                    zz.timer += Time.deltaTime;
                    if (zz.timer > 1.0f)
                    {
                        doudou.hp += zz.recover;
                        zz.timer = 0.0f;
                        zz.count += 1;
                        Debug.Log("zz给doudou加血" + zz.recover);

                        if (zz.count == 2) //加完两次血更换状态
                        {
                            zz.state = State_ZZ.End;
                            Debug.Log("zz拆除工具");
                        }
                    }
                    break;

                case State_ZZ.End:
                    zz.timer += Time.deltaTime;
                    if (zz.timer > 1.0f)
                    {
                        zz.timer = 0.0f;
                        Debug.Log("zz治疗结束");
                        zz.state = State_ZZ.Wait;
                    }
                    break;
            }

        }
        else
        {
            zz.state = State_ZZ.Wait;
        }
    }

    public void WuwuComeOn(ref ZZ zz, ref Wuwu wuwu)
    {
        if (zz.state == State_ZZ.Prepare && zz.state == State_ZZ.ReCover)
        {
            wuwu.timer += Time.deltaTime;
            if (wuwu.timer > 1.0f / (float)wuwu.recoverSpeed)
            {
                zz.recover += wuwu.recoverAdd;
                zz.buff += wuwu.recoverSpeed * wuwu.recoverAdd;

                Debug.Log("wuwu加油1次,zz获得 "+ wuwu.recoverAdd + " 点治疗增益");
                wuwu.timer = 0.0f;
            }
        }
        if (zz.state == State_ZZ.End)
        {

            zz.recover -= zz.buff;
            zz.buff = 0;
        }
    }

    public void MengmengComeOn(ref MengMeng meng, ref Wupeng wupeng)
    {
        if (wupeng.state != State_Wupeng.Sleep)
        {
            meng.timer += Time.deltaTime;

            if (meng.timer > (1.0f / (float)meng.attackSpeed))
            {
                meng.timer = 0.0f;
                meng.count += 1;

                if (meng.count % 2 == 0)
                {
                    Debug.Log("meng打鼓加buff，wupeng获得 " + meng.attackAdd + " 点攻击增益");
                    wupeng.attack += meng.attackAdd;
                    wupeng.buff += meng.attackAdd;
                }

            }
        }
        if (wupeng.state == State_Wupeng.Sleep)
        {

            wupeng.attack -= wupeng.buff;
            wupeng.buff = 0;
        }

    }

}

public struct Wupeng
{
    public int enegy;
    public int attack;
    public State_Wupeng state;
    public float timer;
    public int buff;

}

public enum State_Wupeng
{
    Eat,
    Sleep,
    Beat
}

public struct Doudou
{
    public string name;
    public int hp;
}

public struct ZZ
{
    public string name;
    public int recover;
    public float timer;
    public State_ZZ state;
    public int count;
    public int buff;
}

public enum State_ZZ
{
    Wait,
    Prepare,
    ReCover,
    End
}

public struct Wuwu
{
    public string name;
    public int recoverAdd;
    public int recoverSpeed;
    public float timer;

}

public struct MengMeng
{
    public string name;
    public int attackAdd;
    public int attackSpeed;
    public float timer;
    public int count;

}



public struct TrafficLight
{

    public Image red;
    public Image green;
    public Image yellow;
    public State_TrafficLight state;
    public float red_last;
    public float green_last;
    public float yello_last;
    public float timer;
}


public enum State_TrafficLight
{
    Red,Green, Yellow
}

public struct Timer
{
    public float timer;
    public float temper;
}

public struct Rocket
{
    public Image image;

    public State_Rocket state;

    public LunchDevice lunchDevice;

    public float speed;
}

public struct LunchDevice
{
    public Timer countdown_Prepare;
    public Timer countdown_lunch;
}

public enum State_Rocket
{
    counting,

    lunching,

    flying
}


//习题：
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


