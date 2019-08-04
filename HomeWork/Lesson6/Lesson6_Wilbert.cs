using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson6_Wilbert : MonoBehaviour
{
public struct hero
 {
    public string name;
    public float HP;
    public float ADD_HP;
    public float ADD_HP_PLUS;
    public float ATC;
    public float ADD_ATC_PLUS;

    public hero(string na, float hp, float add_hp, float add_hp_plus, float atc, float add_atc_plus)
    {
        name = na;
        HP = hp;
        ADD_HP = add_hp;
        ADD_HP_PLUS=add_hp_plus;
        ATC = atc;
        ADD_ATC_PLUS = add_atc_plus;
    }
 }
hero wupeng = new hero("wupeng", 0f, 0f, 0f, 8f, 0f);
hero doudou = new hero("doudou", 1000f, 0f, 0f, 0f, 0f);
hero zz = new hero("zz", 0f, 5f, 0f, 0f, 0f);
hero wuwu = new hero("wuwu", 0f, 0f, 1f, 0f, 0f);
hero mengmeng = new hero("mengmeng", 0f, 0f, 0f, 0f, 1f);
enum wupeng_event
 {
    eat, 
    sleep,
    beat,
 }
 wupeng_event current_wupeng_event = wupeng_event.eat;
enum zz_event
 {
    prepare,
    helpdoudou,
    dismantle,
 }

zz_event current_zz_event = zz_event.prepare;
public float current_time = 0.0f;
public float current_time_zz = 0.0f;
public float current_time_mengmeng = 0.0f;
public float current_time_beat=0f;
public void wupengDEATdoudou()
 {
  switch(current_wupeng_event)
  {
    case wupeng_event.eat:////
    {
        current_time+=Time.deltaTime;
        mengmengQIAOGU();
        if(current_time>3.0f)
        {
            wupeng.HP=100f;
            current_wupeng_event=wupeng_event.beat;
            current_time=0f;
            Debug.Log("wepeng吃饭(用时3秒)，结束时精力:"+wupeng.HP);
            
        }
    }
    break;
    case wupeng_event.sleep:
    {   
        current_time+=Time.deltaTime;
        wupeng.ATC=8f;
        if(current_time>5.0f)
        {
            current_wupeng_event=wupeng_event.eat;
            current_time=0f;
            Debug.Log("wupeng睡觉(用时5秒)，结束时精力:"+wupeng.HP);
            Debug.Log("mengmeng加油攻击力加成效果消失，此时wupeng攻击力为："+wupeng.ATC);
        }
        else
        {
            zzHELPdoudou();
        }
    }
    break;
    case wupeng_event.beat://///
    {
        current_time+=Time.deltaTime;
        current_time_beat+=Time.deltaTime;
        mengmengQIAOGU();

     if(current_time_beat>1f)
     {
        if(wupeng.HP>0f)
        {
            wupeng.HP-=10f;
            doudou.HP-=wupeng.ATC;
            //current_wupeng_event=wupeng_event.beat;
            current_time_beat=0f;
            Debug.Log("wupeng打豆豆(用时1秒)，结束时wupeng精力:"+wupeng.HP+" 豆豆生命值:"+doudou.HP);
        }
        else
        {
            wupeng.HP=0f;
            current_wupeng_event=wupeng_event.sleep;
            current_time=0f;
            current_time_beat=0f;
            Debug.Log("wupeng打豆豆累了需要睡觉，此时精力:"+wupeng.HP);
        }
     }
    }
    break;
  }
 }

public void mengmengQIAOGU()
 {
    current_time_mengmeng+=Time.deltaTime;
        if(current_time_mengmeng>1.0f)
        {
            wupeng.ATC+=mengmeng.ADD_ATC_PLUS*2;
            current_time_mengmeng=0f;
            Debug.Log("mengmeng加油为wupeng攻击力加成1次，此时wupeng攻击力为"+wupeng.ATC);
        }
 }

public void zzHELPdoudou()
 {
 if(current_time<4.5f)
  {
    switch(current_zz_event)
   {
    case zz_event.prepare:
    {
        current_time_zz+=Time.deltaTime;
        if(current_time_zz>1.0f)
        {
            current_zz_event=zz_event.helpdoudou;
            zz.ADD_HP+=wuwu.ADD_HP_PLUS*3;
            current_time_zz=0f;
            Debug.Log("zz准备医疗工具(用时1秒), 来自wuwu的加油加成为:"+wuwu.ADD_HP_PLUS*3+" 此时zz治疗加成为:"+zz.ADD_HP);
        }
    }
    break;
    case zz_event.helpdoudou:
    {
        current_time_zz+=Time.deltaTime;
        if(current_time_zz>2.0f)
        {

            current_zz_event=zz_event.dismantle;
            zz.ADD_HP+=wuwu.ADD_HP_PLUS*2*3;
            doudou.HP+= zz.ADD_HP*2;
            current_time_zz=0f;
            Debug.Log("zz为豆豆补血(用时2秒), 来自wuwu的加油加成为:"+wuwu.ADD_HP_PLUS*3*2+" 此时zz治疗加成为:"+zz.ADD_HP);
        }   
    }
    break;
    case zz_event.dismantle:
    {
        current_time_zz+=Time.deltaTime;
        if(current_time_zz>1.0f)
        {
            current_zz_event=zz_event.prepare;
            zz.ADD_HP=5f;
            current_time_zz=0f;
            Debug.Log("zz拆除医疗工具(用时1秒), wuwu的加油加成效果消失，此时zz治疗加成为:"+zz.ADD_HP);
        }
    }
    break;
   } 
  }
  else
  {
  current_zz_event=zz_event.prepare; 
  zz.ADD_HP=5f;
  current_time_zz=0f; 
  }
 }




enum light_event
 {
    red,
    green,
    yellow1,
    yellow2,
 }
 light_event current_light=light_event.red;
 float current_light_time=0f;
 public Image light_imageR;
 public Image light_imageG;
 public Image light_imageY;
public void lightevent()
 {
    switch(current_light)
    {
        case light_event.red:
        {
            current_light_time+=Time.deltaTime;
            if(current_light_time>1f)
            {
                current_light = light_event.yellow1;
                current_light_time=0f;
                light_imageR.color=Color.red; 
                var tempR = light_imageR.color;  tempR.a=1f; light_imageR.color=tempR;
                light_imageG.color=Color.green;
                var tempG = light_imageG.color;  tempG.a=0f; light_imageG.color=tempG;
                light_imageY.color=Color.yellow;
                var tempY = light_imageY.color;  tempY.a=0f; light_imageY.color=tempY;
            }
        }
        break;
        case light_event.yellow1:
        {
            current_light_time+=Time.deltaTime;
            if(current_light_time>1f)
            {
                current_light = light_event.green;
                current_light_time=0f;
                light_imageR.color=Color.red; 
                var tempR = light_imageR.color;  tempR.a=0f; light_imageR.color=tempR;
                light_imageG.color=Color.green;
                var tempG = light_imageG.color;  tempG.a=0f; light_imageG.color=tempG;
                light_imageY.color=Color.yellow;
                var tempY = light_imageY.color;  tempY.a=1f; light_imageY.color=tempY;

            }
        }
        break;
        case light_event.green:
        {
            current_light_time+=Time.deltaTime;
            if(current_light_time>1f)
            {
                current_light = light_event.yellow2;
                current_light_time=0f;
                light_imageR.color=Color.red; 
                var tempR = light_imageR.color;  tempR.a=0f; light_imageR.color=tempR;
                light_imageG.color=Color.green;
                var tempG = light_imageG.color;  tempG.a=1f; light_imageG.color=tempG;
                light_imageY.color=Color.yellow;
                var tempY = light_imageY.color;  tempY.a=0f; light_imageY.color=tempY;
            }
        }
        break;
        case light_event.yellow2:
        {
            current_light_time+=Time.deltaTime;
            if(current_light_time>1f)
            {
                current_light = light_event.red;
                current_light_time=0f;
                light_imageR.color=Color.red; 
                var tempR = light_imageR.color;  tempR.a=0f; light_imageR.color=tempR;
                light_imageG.color=Color.green;
                var tempG = light_imageG.color;  tempG.a=0f; light_imageG.color=tempG;
                light_imageY.color=Color.yellow;
                var tempY = light_imageY.color;  tempY.a=1f; light_imageY.color=tempY;
            }
        }
        break;
    }
 } 

public float starttime=0f;
public float gaptime=0f;
public void counttime()
 {
        starttime += Time.deltaTime;
        gaptime += Time.deltaTime;
        if (gaptime > 3f)
        {
            int Time = Mathf.FloorToInt(starttime);
            int second = Time % 60;
            int minute = Time / 60 % 60;
            int hour = Time / 60 / 60 % 24;
            int day = Time / 60 / 60 / 24 % 30;
            int month = Time / 60 / 60 / 24 / 30 % 12;
            int year = Time / 60 / 60 / 24 / 30 / 12;
            Debug.Log(year + "年" + month + "月" + day + "日" + hour + "时" + minute + "分" + second + "秒");
            gaptime=0f;
        }
 }

enum rock_event
  {
    daoshu,
    dianhuo,
    shengkong,
  }
 rock_event current_rock=rock_event.daoshu;
 public float current_rock_time=0f;
 public float count_time=0f;
 public int num1=11;
 public Image rock_image;
public void rockevent()
 {
    switch(current_rock)
    {
        case rock_event.daoshu:
        {
            //current_rock_time+=Time.deltaTime;
            count_time+=Time.deltaTime;
            if(count_time>1f)
            {
                num1-=1;
                Debug.Log("倒数"+num1+"秒");
                count_time=0f;
            }
            if(num1==1)
            {
                num1=10;
              //  current_rock_time=0f;
                current_rock = rock_event.dianhuo;
            }
        }
        break;
        case rock_event.dianhuo:
        {
            count_time+=Time.deltaTime;
            if(count_time>2f)
            {
                Debug.Log("点火");
                count_time=0f;
                current_rock = rock_event.shengkong;
            }
        }
        break;
        case rock_event.shengkong:
        {
            Vector3 tmp = GameObject.Find("rock_image").transform.position;
            GameObject.Find("rock_image").transform.position = new Vector3(tmp.x, tmp.y +5, tmp.z);
        }
        break;
    }

 } 

 // Start is called before the first frame update
void Start()
 {

 }
 
    // Update is called once per frame
void Update()
 {
/*1. Wupeng是一名勇士，有如下属性，名字叫wupeng,初始精力为0 ，攻击力为8 。声明一个Wupeng结构体
2. 豆豆是一名可爱的豆豆，有如下属性，名字叫doudou，初始生命值为1000 。声明一个doudou结构体
3. Wupeng一天就干三件事，吃饭，睡觉，打豆豆。最开始做的事情是吃饭，wupeng会用3秒吃饭补充精力，当精力达到了100时开始打豆豆，
每秒打一下豆豆，每次打豆豆需要消耗10点的精力。当精力为0时，需要睡觉，睡足5秒后起床吃饭。如此循环。请使用状态机实现此过程。
4. Zz是一名豆豆爱好者，有如下属性，名字叫zz，治疗力为回复5生命值/秒。声明一个zz结构体
5. Zz会在wupeng睡觉的时候为豆豆补充生命，zz为豆豆补充血量时的过程是这样的：准备医疗工具1秒，为豆豆补血2秒，拆除医疗工具1秒。
请使用状态机实现此过程（将代码嵌入第3题的状态机中）
6. Wuwu是一名啦啦队爱好者，有如下属性，名字叫wuwu，治疗加成为1 。在zz准备工具和治疗的时候为zz加油，wuwu每秒钟能喊出3次加油，
每次都能让zz回复能力加成，加成效果在zz治疗结束后消失 。将wuwu的功能嵌入第3题的状态机中。 */
    wupengDEATdoudou();

/*8. 模拟交通信号灯的运行（使用状态机，使用三张unity Image） */
    lightevent();

 /* 9. 每隔三秒打印当前经过的时间，使用如下格式“年：月：日：小时：分钟：秒”*/   
    counttime();

/* 10. 模拟火箭升空过程，倒数十秒，点火2秒，升空(使用状态机，unity image充当火箭，请网上查找如何改变image坐标的方法)*/
    rockevent();
 }
}
