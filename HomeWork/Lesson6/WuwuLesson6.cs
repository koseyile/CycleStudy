using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WuwuLesson6 : MonoBehaviour
{

  //本期困惑：
  //start 、结构体、实例化、初始值设定、枚举、函数、状态机、传参、打印xxx、update()
  //互相的顺序如何排列？
  //谁必须包含谁？
  //多个项目的时间 如何先后进行？currenttime是unity系统自带的吗？

    //1.Wupeng是一名勇士，有如下属性，名字叫wupeng,初始精力为0 ，攻击力为8 。声明一个Wupeng结构体
    //2.豆豆是一名可爱的豆豆，有如下属性，名字叫doudou，初始生命值为1000 。声明一个doudou结构体
    struct Wupeng
    {
        public string Name;
        public int Energy;
        public int Attack;
    }

    struct Doudou
    {
        public string Name;
        public int Life;
    }

    //4.Zz是一名豆豆爱好者，有如下属性，名字叫zz，治疗力为回复5生命值 / 秒。声明一个zz结构体
    struct Zz
    {
        public string Name;
        public int CureLife;
    }

    //6.Wuwu是一名啦啦队爱好者，有如下属性，名字叫wuwu，治疗加成为1 
    struct Wuwu
    {
        public string Name;
        public int Cureplus;
    }

    //7.Mengmeng是鼓手，名字叫mengmeng，攻击力加成为1 
    struct Mengmeng
    {
        public string Name;
        public int AddAttack;
        public int drumcounts;
    }


    // Start is called before the first frame update
    void Start()
    {
        Question1to7();
        //Question9();
        //Question10();
    }

    void Question1to7()
    {
        wupeng.Name = "wupeng";
        wupeng.Energy = 0;
        wupeng.Attack = 8;

        doudou.Name = "doudou";
        doudou.Life = 1000;

        zz.Name = "zz";
        zz.CureLife = 5;

        wuwu.Name = "wuwu";
        wuwu.Cureplus = 1;

        mengmeng.Name = "mengmeng";
        mengmeng.AddAttack = 1;
        mengmeng.drumcounts = 4;

    }


    //3.Wupeng一天就干三件事，吃饭，睡觉，打豆豆。最开始做的事情是吃饭，wupeng会用3秒吃饭补充精力
    //当精力达到了100时开始打豆豆，每秒打一下豆豆，每次打豆豆需要消耗10点的精力。当精力为0时，需要睡觉，睡足5秒后起床吃饭。
    //如此循环。请使用状态机实现此过程。
    enum WupengState
    {
        WupengState_Eating,
        WupengState_Sleeping,
        WupengState_Hitting,
    }

    enum ZzState
    {
        ZzState_prepare,
        ZzState_healing,
        ZzState_remove,
    }

    enum WuwuState
    {
        WuwuState_plushealing,
        WuwuState_finishhealing,
    }

    enum MengmengState
    {
        MengmengState_playingdrum,
        MengmengState_notplaying,
    }

    enum LightState
    {
        LightState_red,
        LightState_green,
        LightState_yellow,
    }

    enum RocketState
    {
        RocketState_counting,
        RocketState_firing,
        RocketState_flying,
    }

    Wupeng wupeng = new Wupeng();
    Doudou doudou = new Doudou();
    Zz zz = new Zz();
    Wuwu wuwu = new Wuwu();
    Mengmeng mengmeng = new Mengmeng();

    float currentTime = 0.0f;

    public int countSeconds = 0;
   //这里说什么是 根据默认值初始化字段是冗余的？

    public int countNumber = 10;


    WupengState currentWupengState = WupengState.WupengState_Eating;
    ZzState currentZzState = ZzState.ZzState_prepare;
    MengmengState currentMengmengState = MengmengState.MengmengState_notplaying;

    LightState currentLightState = LightState.LightState_red;
    public Image redlight;
    public Image greenlight;
    public Image yellowlight;

    RocketState currentRocketState = RocketState.RocketState_counting;
    public Image Rocket;
     

    void Update()
    {
        switch (currentWupengState)
        {
            case WupengState.WupengState_Eating:
                {
                    currentTime += Time.deltaTime;
                    //在wupeng不睡觉的时候敲鼓，mengmeng每秒钟可敲4下鼓，
                    //当敲第偶数下鼓的时候，能让wupeng的攻击力加成，加成效果在wupeng睡觉的时候消失。将mengmeng的功能嵌入第3题的状态机中。
                    switch (currentMengmengState)//状态机可以只有一个状态吗？ 出现在3秒前的变化应该写在这儿吗？
                    {
                        case MengmengState.MengmengState_playingdrum:
                            {
                                for (int h = 0; h <= Time.deltaTime; h++)
                                {
                                    int TimesofDrum = h * mengmeng.drumcounts;
                                    if (TimesofDrum % 2 == 0)
                                    {
                                        wupeng.Attack += mengmeng.AddAttack;
                                    }
                                }

                            }
                            break;

                    }
                    if (currentTime > 3.0f)
                    {
                        currentWupengState = WupengState.WupengState_Hitting;
                        currentTime = 0.0f;
                        Debug.Log("Wupeng begin to hit doudou");
                    }

                }
                break;
            case WupengState.WupengState_Hitting:
                {
                    currentTime += Time.deltaTime;
                    wupeng.Energy = 100;
                    switch (currentMengmengState)//状态机可以只有一个状态吗？
                    {
                        case MengmengState.MengmengState_playingdrum:
                            {
                                for (int h = 0; h <= Time.deltaTime; h++)
                                {
                                    int TimesofDrum = h * mengmeng.drumcounts;
                                    if (TimesofDrum % 2 == 0)
                                    {
                                        wupeng.Attack += mengmeng.AddAttack;
                                    }
                                }

                            }
                            break;

                    }
                    if (currentTime > 3.0f && wupeng.Energy > 0 && doudou.Life > 0)
                    {
                        for (int i = 0; i <= Time.deltaTime; i++)
                        {
                            doudou.Life -= wupeng.Attack * i;
                            wupeng.Energy -= 10 * i;
                            currentWupengState = WupengState.WupengState_Sleeping;
                            currentTime = 0.0f;
                            Debug.Log("Wupeng begin to sleep");

                        }

                    }
                }
                break;

            case WupengState.WupengState_Sleeping:
                //5.Zz会在wupeng睡觉的时候为豆豆补充生命，zz为豆豆补充血量时的过程是这样的：
                //准备医疗工具1秒，为豆豆补血2秒，拆除医疗工具1秒。
                //请使用状态机实现此过程（将代码嵌入第3题的状态机中）
                {
                    currentTime += Time.deltaTime;
                    switch (currentZzState)
                    //在zz准备工具和治疗的时候为zz加油，wuwu每秒钟能喊出3次加油，每次都能让zz回复能力加成
                    //加成效果在zz治疗结束后消失 。将wuwu的功能嵌入第3题的状态机中。
                    {
                        case ZzState.ZzState_prepare:
                            {
                                currentTime += Time.deltaTime;

                                for (int k = 0; k <= Time.deltaTime; k++)//过去了几秒怎么写
                                {
                                    zz.CureLife += 3 * wuwu.Cureplus * k;
                                }

                                if (currentTime > 1.0f)
                                {
                                    currentZzState = ZzState.ZzState_healing;
                                    currentTime = 0.0f;
                                    Debug.Log("zz is adding blood");
                                }
                            }
                            break;
                        case ZzState.ZzState_healing:
                            {
                                currentTime += Time.deltaTime;
                                for (int l = 0; l <= Time.deltaTime; l++)
                                {
                                    zz.CureLife += 3 * wuwu.Cureplus * l;

                                }

                                if (currentTime > 2.0f)
                                {
                                    for (int j = 0; j <= Time.deltaTime; j++)
                                    {
                                        doudou.Life += zz.CureLife * j;
                                    }
                                    currentZzState = ZzState.ZzState_remove;
                                    currentTime = 0.0f;
                                    Debug.Log("zz is removing tools");

                                }
                            }
                            break;
                        case ZzState.ZzState_remove://这里意思是开始运行准备阶段还是开始卸载阶段。。
                            {
                                if (currentTime > 1.0f)
                                {
                                    currentZzState = ZzState.ZzState_prepare;
                                    currentTime = 0.0f;
                                    Debug.Log("zz is preparing");
                                }
                            }
                            break;
                    }


                    if (currentTime > 5.0f)
                    {
                        currentWupengState = WupengState.WupengState_Eating;
                        Debug.Log("Wupeng begin to eat");
                    }


                }

                break;
        }


        //8，模拟交通信号灯
        switch (currentLightState)
        {
            case LightState.LightState_red:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime > 2.0f)
                    {
                        currentLightState = LightState.LightState_yellow;
                        currentTime = 0.0f;
                        yellowlight.color = Color.yellow;
                        redlight.color = Color.black;
                        greenlight.color = Color.black;

                        Debug.Log("red to yellow");
                    }


                }
                break;

            case LightState.LightState_yellow:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime > 2.0f)
                    {
                        currentLightState = LightState.LightState_green;
                        yellowlight.color = Color.black;
                        redlight.color = Color.black;
                        greenlight.color = Color.green;
                        currentTime = 0.0f;
                        Debug.Log("yellow to green");
                    }
                }
                break;
            case LightState.LightState_green:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime > 2.0f)
                    {
                        currentLightState = LightState.LightState_red;
                        yellowlight.color = Color.black;
                        redlight.color = Color.red;
                        greenlight.color = Color.black;
                        currentTime = 0.0f;
                        Debug.Log("green to red");
                    }
                }
                break;

        }


        //9.每隔三秒打印当前经过的时间，使用如下格式“年：月：日：小时：分钟：秒”

        currentTime += Time.deltaTime;
        int year, month, date, hour, minute, second;

        if (currentTime > 1.0f)
        {
            countSeconds++;
            second = countSeconds % 60;
            minute = second % 60;
            hour = minute % 60;
            date = hour % 60;
            month = date % 30;
            year = month % 365;
            if (countSeconds % 3 == 0)
            {
                Debug.Log("年：" + year + "月：" + month + "日：" + date + "小时:" + hour + "分钟：" + minute + "秒:" + second);
            }

        }
        //每三秒打印的是从头到尾的时间吗？不暂停的？每个月日期不同，每年还有闰年。。。。不会。。。

        //10.模拟火箭升空过程，倒数十秒，点火2秒，升空(使用状态机，unity image充当火箭，请网上查找如何改变image坐标的方法)


        switch (currentRocketState)
        {
            case RocketState.RocketState_counting:
                {
                    
                    currentTime += Time.deltaTime;
                    if (currentTime >= 1.0f && countNumber > 0)
                    {
                        countNumber--;
                        Debug.Log(countNumber);
                        if (currentTime > 10.0f)
                        {
                            currentRocketState = RocketState.RocketState_firing;
                            currentTime = 0.0f;
                        }
                    }
                }
                break;
            case RocketState.RocketState_firing:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime > 2.0f)
                    {
                        currentRocketState = RocketState.RocketState_flying;
                        currentTime = 0.0f;
                    }

                }
                break;
            case RocketState.RocketState_flying:
                {
                   
                    currentTime += Time.deltaTime;
                    int PositionY = (int)GameObject.Find("Rocket").GetComponent<Transform>().position.y;
                    PositionY += 10 * countSeconds;

                }
                break;
        }


    }
}
