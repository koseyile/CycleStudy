using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson6HWbaibai : MonoBehaviour
{
    /*习题：

    //1. Wupeng是一名勇士，有如下属性，名字叫wupeng,初始精力为0 ，攻击力为8 。声明一个Wupeng结构体
    //2. 豆豆是一名可爱的豆豆，有如下属性，名字叫doudou，初始生命值为1000 。声明一个doudou结构体
    //3. Wupeng一天就干三件事，吃饭，睡觉，打豆豆。
    //最开始做的事情是吃饭，wupeng会用3秒吃饭补充精力，当精力达到了100时开始打豆豆，每秒打一下豆豆，每次打豆豆需要消耗10点的精力。
    //当精力为0时，需要睡觉，睡足5秒后起床吃饭。如此循环。请使用状态机实现此过程。

    4. Zz是一名豆豆爱好者，有如下属性，名字叫zz，治疗力为回复5生命值/秒。声明一个zz结构体

    5. Zz会在wupeng睡觉的时候为豆豆补充生命，zz为豆豆补充血量时的过程是这样的：准备医疗工具1秒，为豆豆补血2秒，拆除医疗工具1秒。请使用状态机实现此过程（将代码嵌入第3题的状态机中）

    6. Wuwu是一名啦啦队爱好者，有如下属性，名字叫wuwu，治疗加成为1 。在zz准备工具和治疗的时候为zz加油，wuwu每秒钟能喊出3次加油，每次都能让zz回复能力加成，加成效果在zz治疗结束后消失 。将wuwu的功能嵌入第3题的状态机中。

    7. Mengmeng是鼓手，名字叫mengmeng，攻击力加成为1 ，在wupeng不睡觉的时候敲鼓，mengmeng每秒钟可敲4下鼓，当敲第偶数下鼓的时候，能让wupeng的攻击力加成，加成效果在wupeng睡觉的时候消失。将mengmeng的功能嵌入第3题的状态机中。

    8. 模拟交通信号灯的运行（使用状态机，使用三张unity Image）

    9. 每隔三秒打印当前经过的时间，使用如下格式“年：月：日：小时：分钟：秒”

    10. 模拟火箭升空过程，倒数十秒，点火2秒，升空(使用状态机，unity image充当火箭，请网上查找如何改变image坐标的方法)
     * 
     * 
    */

    //global 
    Worrior wp = new Worrior();
    Doudou dd = new Doudou();
    WPState currentState = WPState.Eat;
    float currentTime = 0f;

    DoudouLover zz = new DoudouLover();
    ZZState zState = ZZState.Prepare;
    float zTime = 0f;
    int healingCount = 0;

    CheerLeader wuwu = new CheerLeader();
    float cheerTime = 0f;
    float cheerAmount = 0f;

    Drummer mm = new Drummer();
    float drumTime = 0f;
    float drumAmount = 0f;
    int drumCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        RunQ1toQ3();
        RunQ4toQ5();
        RunQ6();
        RunQ7();

        lightImageRed.color = Color.red;
        lightImageGreen.color = Color.gray;
        lightImageYellow.color = Color.gray;
        zhujiangxilu.LightType = 0;

        StartTime();

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        WPStateChange();

        TurnOnTrafficLight();

        //PrintTime();
        RefreshTimePast();

        LaunchingRocket();
    }


    // Q1-3
    struct Worrior {
        public string Name;
        public float Spirit;
        public float Attack;
    }

    struct Doudou {
        public string Name;
        public float Health;
    }

    enum WPState {
        Eat,
        Sleep,
        Beat,
    }


    void RunQ1toQ3() {
        //Worrior wp = new Worrior();
        wp.Name = "wupeng";
        wp.Spirit = 0f;
        wp.Attack = 8f;

        Debug.Log(wp.Name + " Spirit: " + wp.Spirit + ", Attack: " + wp.Attack);

        dd.Name = "doudou";
        dd.Health = 1000f;

        Debug.Log(dd.Name + ", Health: " + dd.Health);

    }

    void WPStateChange()
    {

        switch (currentState)
        {
            case WPState.Eat:
                {
                    if (currentTime < 3.0f)
                    {
                        //eat
                    }
                    else {
                        // spirit = 100f;
                        wp.Spirit = 100f;
                        // state change to beat
                        currentState = WPState.Beat;
                        Debug.Log("wupeng starts beating doudou now.");
                        //clear time
                        currentTime = 0f;
                    }

                    //drum effect
                    DrumEffect();
                }
                break;
            case WPState.Beat:
                {
                    if (wp.Spirit > 0)
                    {
                        //beat -10 per second
                        if (currentTime < 1.0f) {
                        } else {
                            // spirit - 10
                            wp.Spirit -= 10f;
                            Debug.Log("wupeng beats doudou -10 sp, spirit: " + wp.Spirit);
                            // clear time
                            currentTime = 0.0f;
                        }
                    }
                    else {
                        // state change to sleep
                        currentState = WPState.Sleep;
                        Debug.Log("wupeng starts sleeping now.");
                        // clear time
                        currentTime = 0f;
                    }

                    //drum effect
                    DrumEffect();
                }
                break;
            case WPState.Sleep:
                {
                    // drum effect reset
                    drumAmount = 0f;
                    drumTime = 0f;
                    drumCount = 0;

                    if (currentTime < 5.0f)
                    { // sleep
                    }
                    else {
                        // state change to eat
                        currentState = WPState.Eat;
                        Debug.Log("wupeng starts eating now.");
                        // clear time
                        currentTime = 0.0f;
                    }

                    //zz healing
                    ZZStateChange();                  
                }
                break;
        }
    }


    //4. Zz是一名豆豆爱好者，有如下属性，名字叫zz，治疗力为回复5生命值/秒。声明一个zz结构体
    //5. Zz会在wupeng睡觉的时候为豆豆补充生命，zz为豆豆补充血量时的过程是这样的：
    //准备医疗工具1秒，为豆豆补血2秒，拆除医疗工具1秒。请使用状态机实现此过程（将代码嵌入第3题的状态机中）

    struct DoudouLover {
        public string Name;
        public float Healing;
    }

    enum ZZState
    {
        Prepare, // 1s
        Heal, // 2s
        Remove, // 1s
    }

    void RunQ4toQ5()
    {

        zz.Name = "zz";
        zz.Healing = 5f; // 5 health per second

        Debug.Log(zz.Name + " Healing: " + zz.Healing);

    }

    void ZZStateChange() {
        // only work when wupeng is sleeping

        zTime += Time.deltaTime;

        switch (zState) {
            case ZZState.Prepare:
                {
                    if (zTime < 1f)
                    {
                        //preparing
                    }
                    else {
                        //change state to heal
                        zState = ZZState.Heal;
                        Debug.Log("zz finish preparation and start healing.");
                        //clear zz time
                        zTime = 0f;
                    }

                    //cheering
                    CheerEffect();
                }
                break;
            case ZZState.Heal:
                {
                    if (zTime < 1f)
                    {
                        //healing for the first time
                    }
                    else if (zTime >= 1f && zTime < 2f)
                    {
                        if (healingCount == 0)
                        {
                            healingCount = 1;
                            dd.Health += zz.Healing + cheerAmount;
                            Debug.Log("zz made 1st healing. cheerAmount: " + cheerAmount  + ", doudou Health: " + dd.Health);
                        }
                        else {
                            // healing for the second time
                        }
                    }
                    else {
                        healingCount = 2;
                        dd.Health += zz.Healing + cheerAmount;  
                        // change state to remove
                        zState = ZZState.Remove;
                        Debug.Log("zz made 2nd healing, and starts to remove. cheerAmount: " + cheerAmount + ", doudou Health: " + dd.Health);
                        // clear time
                        zTime = 0f;
                        // clear count
                        healingCount = 0;

                    }

                    //cheering
                    CheerEffect();

                }
                break;
            case ZZState.Remove:
                {
                    if (zTime < 1f)
                    {
                        //removing 
                    }
                    else
                    {
                        //start preparing again
                        zState = ZZState.Prepare;
                        Debug.Log("zz starts preparation.");
                        //clear time
                        zTime = 0f;
                    }

                    // cheer reset
                    cheerAmount = 0f;
                    cheerTime = 0f;
                }
                break;
        }
    }

    //6. Wuwu是一名啦啦队爱好者，有如下属性，名字叫wuwu，治疗加成为1 。
    //在zz准备工具和治疗的时候为zz加油，wuwu每秒钟能喊出3次加油，每次都能让zz回复能力加成，加成效果在zz治疗结束后消失 。
    //将wuwu的功能嵌入第3题的状态机中。

    struct CheerLeader {
        public string Name;
        public float AddHealing;
        public float Interval;
    }

    void RunQ6() {
        wuwu.Name = "wuwu";
        wuwu.AddHealing = 1f;
        wuwu.Interval = 0.33f;// 3 times per second

        Debug.Log(wuwu.Name + " AddHealing: " + wuwu.AddHealing);
    }

    void CheerEffect() {
        cheerTime += Time.deltaTime;

        if (cheerTime < wuwu.Interval)
        {
            //3 times per second
        }
        else
        {
            cheerAmount += wuwu.AddHealing;
            Debug.Log("Wuwu cheered. cheerAmount: " + cheerAmount);
            // clear cheer time
            cheerTime = 0;
        }
    }

    //7. Mengmeng是鼓手，名字叫mengmeng，攻击力加成为1 ，在wupeng不睡觉的时候敲鼓，
    //mengmeng每秒钟可敲4下鼓，当敲第偶数下鼓的时候，能让wupeng的攻击力加成，加成效果在wupeng睡觉的时候消失。
    //将mengmeng的功能嵌入第3题的状态机中。

    struct Drummer {
        public string Name;
        public float AddAttack;
        public float DrumInterval;
    }

    void RunQ7()
    {
        mm.Name = "mengmeng";
        mm.AddAttack = 1f;
        mm.DrumInterval = 0.25f;// 4 times per second

        Debug.Log(mm.Name + " AddAttack: " + mm.AddAttack);
    }

    void DrumEffect() {

        drumTime += Time.deltaTime;

        if (drumTime < mm.DrumInterval)
        {
        }
        else
        {
            //make a sound
            drumCount += 1;
            //add attack if even
            if (drumCount != 0 && drumCount % 2 == 0)
            {
                drumAmount += mm.AddAttack;
                Debug.Log("mengmeng drumed. drumAmount: " + drumAmount);
            }
            //reset time
            drumTime = 0f;
        }
    }

    //8. 模拟交通信号灯的运行（使用状态机，使用三张unity Image）

    struct TrafficLight {
        public int LightType; //0 - red, 1 - green, 2 - yellow
    }

    enum LightState {
        RedLight,
        GreenLight,
        YellowLight,
    }

    LightState currentLight = LightState.RedLight;
    public Image lightImageRed;
    public Image lightImageYellow;
    public Image lightImageGreen;
    float trafficTime = 0f;
    TrafficLight zhujiangxilu = new TrafficLight();
    [HideInInspector]
    public bool previousRed = true;



    void TurnOnTrafficLight() {

        trafficTime += Time.deltaTime;

        switch (currentLight) {
            case LightState.RedLight:
                {
                    if (trafficTime > 2f) {
                        currentLight = LightState.YellowLight;               
                        //reset time
                        trafficTime = 0f;
                        //set previous
                        previousRed = true;
                        //image change
                        lightImageYellow.color = Color.yellow;
                        lightImageRed.color = Color.gray;
                        //value change
                        zhujiangxilu.LightType = 2;
                        Debug.Log("Light Change to Yellow.");          
                    }
                }
                break;
            case LightState.GreenLight:
                {
                    if (trafficTime > 3f)
                    {
                        currentLight = LightState.YellowLight;
                        //reset time
                        trafficTime = 0f;
                        //set previous
                        previousRed = false;
                        //image change
                        lightImageYellow.color = Color.yellow;
                        lightImageGreen.color = Color.gray;
                        //value change
                        zhujiangxilu.LightType = 2;
                        Debug.Log("Light Change to Yellow.");
                    }
                }
                break;
            case LightState.YellowLight:
                {
                    if (trafficTime > 1f)
                    {
                        if (previousRed == true)
                        {
                            currentLight = LightState.GreenLight;
                            //reset time
                            trafficTime = 0f;
                            //image change
                            lightImageGreen.color = Color.green;
                            lightImageYellow.color = Color.gray;
                            //value change
                            zhujiangxilu.LightType = 1;
                            Debug.Log("Light Change to Green.");
                        }
                        else {
                            currentLight = LightState.RedLight;
                            //reset time
                            trafficTime = 0f;
                            //image change
                            lightImageRed.color = Color.red;
                            lightImageYellow.color = Color.gray;
                            //value change
                            zhujiangxilu.LightType = 0;
                            Debug.Log("Light Change to Red.");

                        }
                    }
                }
                break;
        }
    }

    // 9. 每隔三秒打印当前经过的时间，使用如下格式“年：月：日：小时：分钟：秒”
    float timePast;
    float printTimeNow = 0f;
    float intervalSec = 3f;
    bool prt = true;

    int year;
    int mon;
    int day;
    int hour;
    int min;
    int sec;

    void StartTime() {
        timePast = 0;
        year = 0;
        mon = 0;
        day = 0;
        hour = 0;
        min = 0;
        sec = 0;
    }



    void RefreshTimePast() {
        timePast += Time.deltaTime;

        if (timePast >= 1f) {
            sec += 1;
            prt = false;
            //Debug.Log("timePast " + timePast + ", sec:" + sec);
            timePast = 0f;
        }

        if (sec >= 60) {
            min += 1;
            sec = 0;
        }

        if (min >= 60) {
            hour += 1;
            min = 0;
        }

        if (hour >= 24) {
            day += 1;
            hour = 0;
        }

        if (day >= 30) {
            mon += 1;
            day = 0;
        }

        if (mon >= 12) {
            year += 1;
            mon = 0;
        }

        if (sec % 3 == 0 && prt == false) {
            Debug.Log("年：" + year + ", 月：" + mon + ", 日：" + day + ", 小时：" + hour + ", 分钟：" + min + ", 秒:" + sec);
            prt = true;
        }

    }

    //模拟火箭升空过程，倒数十秒，点火2秒，升空
    //(使用状态机，unity image充当火箭，请网上查找如何改变image坐标的方法)

    enum RocketState {
        Countdown,
        Fire,
        Fly,
        Gone,
    }

    RocketState myRocketState = RocketState.Countdown;
    public Transform myRocket;
    public Text cdText;
    [HideInInspector]
    public float rocketTime = 0f;
    [HideInInspector]
    public int countDown = 10;
    

    void LaunchingRocket() {

        rocketTime += Time.deltaTime;

        switch (myRocketState) {
            case RocketState.Countdown:
                {
                    if (rocketTime >= 1f)
                    {
                        countDown -= 1;
                        cdText.text = countDown.ToString();
                        rocketTime = 0f;
                        Debug.Log("Counting down: " + countDown);
                    }

                    if (countDown == 0) {
                        myRocketState = RocketState.Fire;
                        myRocket.GetComponent<Image>().color = Color.red;
                        rocketTime = 0f;
                        Debug.Log("Start firing up!");
                    }

                }
                break;
            case RocketState.Fire:
                {
                    if (rocketTime >= 2f) {
                        myRocketState = RocketState.Fly;
                        rocketTime = 0f;
                        myRocket.GetComponent<Image>().color = Color.white;
                        Debug.Log("Launch!");
                    }
                }
                break;
            case RocketState.Fly:
                {
                    if (rocketTime >= 10f)
                    {
                        myRocketState = RocketState.Gone;
                        rocketTime = 0f;
                        Destroy(myRocket.gameObject);
                        Debug.Log("My rocket has gone to the space!");
                    }
                    else {
                        myRocket.position += new Vector3(10f, 20f, 0f);
                        //Debug.Log("x:" + myRocket.position.x + ", y:" + myRocket.position.y + ", z:" + myRocket.position.z);
                    }
                }
                break;

        }
    }


}
