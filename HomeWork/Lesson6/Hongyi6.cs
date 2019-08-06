using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hongyi6 : MonoBehaviour
{
    // Start is called before the first frame update


    /* 
    1. Wupeng是一名勇士，有如下属性，名字叫wupeng,初始精力为0 ，攻击力为8 。声明一个Wupeng结构体
    2. 豆豆是一名可爱的豆豆，有如下属性，名字叫doudou，初始生命值为1000 。声明一个doudou结构体
    3. Wupeng一天就干三件事，吃饭，睡觉，打豆豆。最开始做的事情是吃饭，wupeng会用3秒吃饭补充精力，当精力达到了100时开始打豆豆，每秒打一下豆豆，每次打豆豆需要消耗10点的精力。当精力为0时，需要睡觉，睡足5秒后起床吃饭。如此循环。请使用状态机实现此过程。
    4. Zz是一名豆豆爱好者，有如下属性，名字叫zz，治疗力为回复5生命值/秒。声明一个zz结构体
    5. Zz会在wupeng睡觉的时候为豆豆补充生命，zz为豆豆补充血量时的过程是这样的：准备医疗工具1秒，为豆豆补血2秒，拆除医疗工具1秒。请使用状态机实现此过程（将代码嵌入第3题的状态机中）
    6. Wuwu是一名啦啦队爱好者，有如下属性，名字叫wuwu，治疗加成为1 。在zz准备工具和治疗的时候为zz加油，wuwu每秒钟能喊出3次加油，每次都能让zz回复能力加成，加成效果在zz治疗结束后消失 。将wuwu的功能嵌入第3题的状态机中。
    7. Mengmeng是鼓手，名字叫mengmeng，攻击力加成为1 ，在wupeng不睡觉的时候敲鼓，mengmeng每秒钟可敲4下鼓，当敲第偶数下鼓的时候，能让wupeng的攻击力加成，加成效果在wupeng睡觉的时候消失。将mengmeng的功能嵌入第3题的状态机中。
    8. 模拟交通信号灯的运行（使用状态机，使用三张unity Image）
    9. 每隔三秒打印当前经过的时间，使用如下格式“年：月：日：小时：分钟：秒”
    10. 模拟火箭升空过程，倒数十秒，点火2秒，升空(使用状态机，unity image充当火箭，请网上查找如何改变image坐标的方法)
    */



    struct Warrior
    {
        public string name;
        public int energy;
        public int attack;
        public int wupengType;
    }




    struct Cutedoudou

    {
        public string name;
        public int originalLife;
    }



    struct Aidoudou

    {
        public string name;
        public int recover;
        public int zzType;
    }

    struct Trafficlight
    {
        public int lightType;
    }


    void Start()
    {
    }





    enum wupengState
    {
        wupengState_eat,
        wupengState_beat,
        wupengState_sleep,
    }

    enum zzState
    {
        zzState_prepare,
        zzState_enrich,
        zzState_dismantle,
        zzState_stop,
    }

    enum wuwuState
    { 
        wwState_encourage,
    }

    wupengState currentState = wupengState.wupengState_eat;
    zzState currentStatezz = zzState.zzState_prepare;
    Warrior wupeng = new Warrior();
    Aidoudou zz = new Aidoudou();

    float currentTime = 0.0f;



    enum lightState
    {
        lightState_red,
        lightState_green,
        lightState_yellow,
    }

    lightState currentStatelight = lightState.lightState_red;
    public Image lightImage_red;
    public Image lightImage_yellow;
    public Image lightImage_green;


    int year;
    int month;
    int day;
    int hour;
    int minute;
    int second;


    enum rocketState
    {
        rocketState_countdown,
        rocketState_onfire,
        rocketState_fly,
        reocketState_disappear,
    }

    rocketState currentStaterocket = rocketState.rocketState_countdown;
    public int countDown = 10;
    public Transform rocket;


    // Update is called once per frame

    void Update()
    {
        RunQ1toQ7();
        //RunQ8();
        //RunQ9();
        //RunQ10();
    }



    public void RunQ1toQ7()//打豆豆
    {

        switch (currentState)
        {
            case wupengState.wupengState_eat:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime > 3.0f)
                    {
                        currentState = wupengState.wupengState_beat;
                        currentTime = 0.0f;
                        Debug.Log("wupeng start to beat");
                    }

                }
                break;

            case wupengState.wupengState_beat:
                {
                    wupeng.energy = 100;
                    currentTime += Time.deltaTime;
                    if (currentTime > 10.0f)
                    {
                        currentState = wupengState.wupengState_sleep;
                        Debug.Log("wupeng start to sleep");
                        Debug.Log("zz start to prepare");
                        currentTime = 0.0f;
                    }

                }
                break;


            case wupengState.wupengState_sleep:
                {
                    currentTime += Time.deltaTime;

                    switch (currentStatezz)

                    {
                        case zzState.zzState_prepare:
                            {
                                currentTime += Time.deltaTime;
                                if (currentTime > 1.0f)
                                {
                                    currentStatezz = zzState.zzState_enrich;
                                    Debug.Log("zz starts to enrich");

                                }
                            }
                            break;

                        case zzState.zzState_enrich:
                            {
                                currentTime += Time.deltaTime;
                                if (currentTime > 3.0f)
                                {
                                    currentStatezz = zzState.zzState_dismantle;
                                    Debug.Log("zz starts to dismantle");

                                }
                            }
                            break;

                        case zzState.zzState_dismantle:
                            {
                                currentTime += Time.deltaTime;
                                if (currentTime > 4.0f)
                                {
                                    currentStatezz = zzState.zzState_stop;
                                    Debug.Log("zz starts to stop");

                                }
                            }
                            break;
                    }

                    if (currentTime > 5.0f)
                    {
                        currentState = wupengState.wupengState_eat;
                        currentTime = 0.0f;
                        Debug.Log("wupeng start to eat");
                    }

                }
                break;
        }
    }




    public void RunQ8() //交通信号灯
    {
        switch (currentStatelight)
        {
            case lightState.lightState_red:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime > 5.0f)
                    {
                        currentStatelight = lightState.lightState_yellow;
                        lightImage_red.color = Color.grey;
                        lightImage_yellow.color = Color.yellow;
                        currentTime = 0.0f;
                        Debug.Log("red to yellow");
                    }

                }
                break;

            case lightState.lightState_yellow:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime > 2.0f)
                    {
                        currentStatelight = lightState.lightState_green;
                        lightImage_yellow.color = Color.grey;
                        lightImage_green.color = Color.green;
                        Debug.Log("yellow to green");
                        currentTime = 0.0f;
                    }

                }
                break;

            case lightState.lightState_green:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime > 10.0f)
                    {
                        currentStatelight = lightState.lightState_red;
                        lightImage_green.color = Color.grey;
                        lightImage_red.color = Color.red;
                        Debug.Log("green to red");
                        currentTime = 0.0f;
                    }

                }
                break;

        }
    }



    /*
    public void RunQ9()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 1.0f) { second += 1; }
        if (second >= 60) { minute += 1; second = 0; }
        if (minute >= 60) { hour += 1; minute = 0; }
        if (hour >= 24) { day += 1; hour = 0; }
        if (day >= 30) { month += 1; day = 0; }
        if (month >= 12) { year += 1; month = 0; }

        if (currentTime > 3.0f)
        {

            Debug.Log("年：" + year + "月：" + month + "日：" + day + "小时：" + hour + "分钟：" + minute + "秒：" second);
       
        }


    }
    */


    public void RunQ10()
    {

        switch (currentStaterocket)
        {
            case rocketState.rocketState_countdown:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime >= 1.0f && countDown >0)
                    {
                        countDown -= 1;
                        currentTime = 0.0f;
                        Debug.Log("倒计时" + countDown);
                    }

                    if (countDown == 0.0f)
                    {
                        currentStaterocket = rocketState.rocketState_onfire;
                        currentTime = 0.0f;
                        Debug.Log("开始点火");

                    }

                }
                break;

            case rocketState.rocketState_onfire:
                {

                    currentTime += Time.deltaTime;
                    if (currentTime >= 2.0f)
                    {
                        currentStaterocket = rocketState.rocketState_fly;
                        currentTime = 0.0f;
                        Debug.Log("点火完毕，准备起飞");

                    }
                }
                break;

            case rocketState.rocketState_fly:
                {

                    currentTime += Time.deltaTime;
                    if (currentTime >= 5.0f)
                    {
                        currentStaterocket = rocketState.reocketState_disappear;
                        currentTime = 0.0f;
                        Debug.Log("离开大气层");

                    }
                }
                break;


        }
    }
}