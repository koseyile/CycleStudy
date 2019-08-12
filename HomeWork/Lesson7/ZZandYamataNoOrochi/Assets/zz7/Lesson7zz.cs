using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson7zz : MonoBehaviour
{
    public Orochi orochi;
    public Firebird firebird;
    public Poison poison;
    public Fire fire;
    public Image imgpoison;
    public Image imgfire;
    public PosionCD posionCD;
    public FireCD fireCD;
    public Image imgpoisonCD;
    public Image imgfireCD;
    public PosionAD posionAD;
    public FireAD fireAD;
    public Image imgposionAD;
    public Image imgfireAD;
    public Text orochihp;
    public Text firebirdhp;
    public Sword sword;
    public Image imgsword;
    public Wow wow;
    public Image imgwow;
    public Wscreen wscreen;
    public Image imgwscreen;


    public struct Wscreen
    {
        public Image image;
        public float speed;
    }

    public struct Wow
    {
        public Image image;
    }

    public struct Sword
    {
        public Image image;
        public float speed;
    }

    public struct PosionAD
    {
        public Image image;
    }

    public struct FireAD
    {
        public Image image;
    }

    public struct PosionCD
    {
        public Image image;
    }

    public struct FireCD
    {
        public Image image;
    }

    public struct Poison
    {
        public Image image;
        public float speed;
    }

    public struct Fire
    {
        public Image image;
        public float speed;
    }

    public struct Orochi
    {
        public int Attack;
        public int HP;
        public int Cridamage;
    }

    public struct Firebird
    {
        public int Attack;
        public int HP;
        public int Cridamage;
    }



    void Start()
    {
        orochi = new Orochi() { Attack = 10, HP = 1500, Cridamage = 20 };
        firebird = new Firebird() { Attack = 15, HP = 1200, Cridamage = 45 };
        poison = new Poison() { image = imgpoison, speed = 100.0f };
        fire = new Fire() { image = imgfire, speed = 100.0f };
        posionAD = new PosionAD() { image = imgposionAD };
        posionCD = new PosionCD() { image = imgpoisonCD };
        fireAD = new FireAD() { image = imgfireAD };
        fireCD = new FireCD() { image = imgfireCD };
        sword = new Sword() { image = imgsword, speed = 60.0f };
        wow = new Wow() { image = imgwow };
        wscreen = new Wscreen() { image = imgwscreen, speed = 1.0f };
    }


    enum ZZandfriState
    {
        SwordState_attack,
        FriendsState_wow,
    }

    enum FightState
    {
        OrochiState_attack,
        FirebirdState_attack,
    }
    FightState fightcurrentState = FightState.FirebirdState_attack;

    enum WscreenState
    {
        fadein,
        white,
        fadeout,
    }
    WscreenState wscreencurrentstate = WscreenState.fadein;


    float fightTime = 0.0f;
    float zzTime = 0.0f;
    float damageTime = 0.0f;
    float wscreenTime = 0.0f;
    float fadein = 0.0f;
    float fadeout = 0.0f;



    //zz扔剑刺火鸟和伙伴们惊呼!
    public void ZZandfriends(ref Firebird firebird, ref Sword sword, ref Wow wow)
    {
        if (firebird.HP < 1150)
        {
            zzTime += Time.deltaTime;
            sword.image.rectTransform.position += new Vector3(Time.deltaTime * sword.speed, Time.deltaTime * sword.speed, 0.0f);
        }
        if (zzTime > 5.0f)
        {
            zzTime += Time.deltaTime;
            sword.image.color = new Color(1, 1, 1, 0.0f);
            wow.image.color = new Color(1, 1, 1, 1.0f);
            Wscreenfade(ref wscreen);
        }

    }


    //白屏状态机
    public void Wscreenfade(ref Wscreen wscreen)
    {
        wscreenTime += Time.deltaTime;
        switch (wscreencurrentstate)
        {
            
            case WscreenState.fadein:
                {
                    fadein += 0.1f * wscreenTime;
                    wscreen.image.color = new Color(1, 1, 1, fadein);
                    if(wscreenTime > 2.0f)
                    {
                        wscreencurrentstate = WscreenState.white;
                        wscreenTime = 0;
                    }
                }
                break;
            case WscreenState.white:
                {
                    wscreen.image.color = new Color(1, 1, 1, 1.0f);
                    if (wscreenTime > 3.0f)
                    {
                        wscreencurrentstate = WscreenState.fadeout;
                        wscreenTime = 0;
                    }
                }
                break;
            case WscreenState.fadeout:
                {
                    fadeout += 0.1f * wscreenTime;
                    wscreen.image.color = new Color(1, 1, 1, 1 - fadeout);
                    if (wscreenTime > 2.0f)
                    {
                        wscreen.image.color = new Color(1, 1, 1, 0.0f);
                    }
                }
                break;
        }
    }


    //想尝试把伤害数值的图片单独做一个状态机，再嵌套回主的boss战斗状态机，but...
    
    public void Bossdamage(ref FireCD fireCD)//想把造成伤害们的图片状态单独拿出来，好停留的时间长一点。。但是不知道放哪。。一直不对。。。。
    //ref Firebird firebird, ref Orochi orochi, ref PosionAD posionAD, ref PosionCD posionCD, ref FireAD fireAD,
    {
        damageTime += Time.deltaTime;
        if (damageTime < 2.0f)
        {
            fireCD.image.color = new Color(1, 1, 1, 1.0f);
        }
        if(damageTime > 3.0f)
        {
            fireCD.image.color = new Color(1, 1, 1, 0.0f);
        }
        damageTime = 0;
    }
    //。。。。。


    //两个boss战斗
    public void Fightstate(ref Orochi orochi, ref Firebird firebird)
    {
        fightTime += Time.deltaTime;
        switch (fightcurrentState)
        {
            case FightState.FirebirdState_attack:
                {
                    wscreen.image.color = new Color(1, 1, 1, 0.0f);
                    wow.image.color = new Color(1, 1, 1, 0.0f);
                    if (fightTime < 2.0f)
                    {
                        posionAD.image.color = new Color(1, 1, 1, 0.0f);
                        posionCD.image.color = new Color(1, 1, 1, 0.0f);
                        fireAD.image.color = new Color(1, 1, 1, 0.0f);
                        fireCD.image.color = new Color(1, 1, 1, 0.0f);
                        fire.image.color = new Color(1, 1, 1, 1.0f);
                        poison.image.color = new Color(1, 1, 1, 0.0f);
                        fire.image.rectTransform.position -= new Vector3(Time.deltaTime * fire.speed, Time.deltaTime * fire.speed, 0.0f);
                    }
                    if (fightTime > 2.0f)
                    {
                        fire.image.color = new Color(1, 1, 1, 0.0f);
                        if (Random.Range(0, 100) <= 30)
                        {
                            //firebird.Attack = firebird.Cridamage;
                            orochi.HP = orochi.HP - firebird.Cridamage;
                            orochihp.text = "HP:" + orochi.HP.ToString();

                            fireCD.image.color = new Color(1, 1, 1, 1.0f);//如何能让这个伤害图片停留的时间长一点？
                            //Bossdamage(ref fireCD);想写个单独的状态，但是不知道放哪里能超脱这个fighttime控制

                            Debug.Log("烈焰火鸟造成暴击伤害" + firebird.Cridamage);
                            Debug.Log("八岐大蛇剩余血量" + orochi.HP);
                        }
                        else
                        {
                            orochi.HP = orochi.HP - firebird.Attack;
                            orochihp.text = "HP:" + orochi.HP.ToString();
                            fireAD.image.color = new Color(1, 1, 1, 1.0f);//如何能让这个伤害图片停留的时间长一点？

                            Debug.Log("烈焰火鸟造成普通伤害" + firebird.Attack);
                            Debug.Log("八岐大蛇剩余血量" + orochi.HP);
                        }
                        fightcurrentState = FightState.OrochiState_attack;
                        fire.image.rectTransform.localPosition = new Vector3(241.0f, 231.0f, 0.0f);
                        fightTime = 0.0f;
                    }
                }
                break;

            case FightState.OrochiState_attack:
                {
                    wscreen.image.color = new Color(1, 1, 1, 0.0f);
                    wow.image.color = new Color(1, 1, 1, 0.0f);
                    if (fightTime < 2.0f)
                    {
                        posionAD.image.color = new Color(1, 1, 1, 0.0f);
                        posionCD.image.color = new Color(1, 1, 1, 0.0f);
                        fireAD.image.color = new Color(1, 1, 1, 0.0f);
                        fireCD.image.color = new Color(1, 1, 1, 0.0f);
                        poison.image.color = new Color(1, 1, 1, 1.0f);
                        poison.image.rectTransform.position += new Vector3(Time.deltaTime * poison.speed, Time.deltaTime * poison.speed, 0.0f);
                    }
                    if (fightTime > 2.0f)
                    {
                        poison.image.color = new Color(1, 1, 1, 0.0f);
                        if (Random.Range(0, 100) <= 50)
                        {
                            //orochi.Attack = orochi.Cridamage;
                            firebird.HP = firebird.HP - orochi.Cridamage;
                            firebirdhp.text = "HP:" + firebird.HP.ToString();
                            posionCD.image.color = new Color(1, 1, 1, 1.0f);//如何能让这个伤害图片停留的时间长一点？

                            Debug.Log("八岐大蛇造成暴击伤害" + orochi.Cridamage);
                            Debug.Log("烈焰火鸟剩余血量" + firebird.HP);
                        }
                        else
                        {
                            firebird.HP = firebird.HP - orochi.Attack;
                            firebirdhp.text = "HP:" + firebird.HP.ToString();
                            posionAD.image.color = new Color(1, 1, 1, 1.0f);//如何能让这个伤害图片停留的时间长一点？

                            Debug.Log("八岐大蛇造成普通伤害" + orochi.Attack);
                            Debug.Log("烈焰火鸟剩余血量" + firebird.HP);
                        }

                        fightcurrentState = FightState.FirebirdState_attack;
                        poison.image.rectTransform.localPosition = new Vector3(-20.0f, 30.0f, 0.0f);//为什么无法回到我定义的坐标？
                        fightTime = 0.0f;
                    }
                }
                break;

        }
    }

    void Update()
    {
        Fightstate(ref orochi, ref firebird);
        ZZandfriends(ref firebird, ref sword, ref wow);
        

    }
}
