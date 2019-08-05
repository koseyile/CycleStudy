using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//我的这个UI不会自动识别出现。

public class Lesson6zz : MonoBehaviour
{
    /*
    习题：
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
    struct Wupeng
    {
        public string Name;
        public float Energy;
        public float Attack;
    }

    struct doudou
    {
        public string Name;
        public float BaseHP;
    }

    struct Zz
    {
        public string Name;
        public float Heal;
    }

    struct Wuwu
    {
        public string Name;
        public float Healup;
    }

    struct Mengmeng
    {
        public string Name;
        public float Attackup;
    }

    struct TrafficLight
    //不能拖拽脚本！！！！根本不让我拖拽！！！说我代码还有编译错误，不能进行这个操作！
    //Wupeng wupeng = new wupeng();
    //Zz zz = new zz();
    //Wuwu wuwu = new wuwu();
    //Mengmeng mengmeng = new mengmeng();

    enum WupengState
    {
        WupengState_eat,
        WupengState_sleep,
        WupengState_hit,
    }
    WupengState wupengcurrentState = WupengState.WupengState_eat;

    enum ZzState
    {
        ZzState_prepare,
        ZzState_heal,
        ZzState_close,
    }
    ZzState zzcurrentState = ZzState.ZzState_prepare;

    enum WuwuState
    {
        WuwuState_comeon,
    }
    
    float currentTime = 0.0f;
    float zzcurrentTime = 0.0f;
    float wuwucurrentTime = 0.0f;

    

    void WupengStateupdate()
    {
       switch (wupengcurrentState)
        {
            case WupengState.WupengState_eat:
            {
                currentTime+=Time.deltaTime;
                if(currentTime>3.0f)
                {
                    Wupeng.Energy=100.0f;
                    wupengcurrentState = WupengState.WupengState_hit;
                    currentTime = 0.0f;
                    Debug.Log("wupeng开始打豆豆啦");
                }
            }
            break;
            case WupengState.WupengState_hit:
            {
                currentTime+=Time.deltaTime;
                if(currentTime>10.0f)
                {
                    Wupeng.Energy=0.0f;
                    wupengcurrentState = WupengState.WupengState_sleep;
                    currentTime = 0.0f;
                    Debug.Log("wupeng开始睡觉啦");
                }
            }
            break;
            case WupengState.WupengState_sleep:
            {
                currentTime+=Time.deltaTime;
                    
                if(currentTime>5.0f)
                {
                    ZZStateupdate();
                    wupengcurrentState = WupengState.WupengState_eat;
                    currentTime = 0.0f;
                    Debug.Log("wupeng开始吃饭啦");
                }
            }
            break;
        }
    }
    
    void ZZStateupdate()
    {
        switch (zzcurrentState)
        {
            zzcurrentTime+=Time.deltaTime;
            case ZzState.ZzState_prepare:
            {
                if(zzcurrentTime>1.0f)
                {
                    zzcurrentState = ZzState.ZzState_prepare;
                    zzcurrentTime = 0.0f;
                    Debug.Log("zz开始为豆豆补血啦");
                }
            }
            break;
            case ZzState.ZzState_heal:【
            {   
                float zzbaseheal = Zz.Heal*2.0f;//等待wuwu的加成
                if(zzcurrentTime>2.0f)
                {
                    zzcurrentState = ZzState.ZzState_heal;
                    zzcurrentTime = 0.0f;
                    Debug.Log("zz开始拆卸医疗工具");
                 }
            }
            break;
            case ZzState.ZzState_close:
            {
                if(zzcurrentTime>1.0f)
                {
                    zzcurrentState = ZzState.ZzState_close;
                    zzcurrentTime = 0.0f;
                    Debug.Log("zz开始准备医疗工具啦");
                }
            }
            break;
        }
    } 
    
    void Wuwupower()
    {
     wuwu.Healup
     wuwucurrentTime+=Time.deltaTime;
    }

    public Image lightimage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WupengStateupdate();
    }
}
    
