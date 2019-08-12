using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hongyi7 : MonoBehaviour
{

    public Snake snake;
    public Bird firebird;

    public Text numText1;
    public Text numText2;
    public Text harmbird;
    public Text harmsnake;
    public Text wa;

    public Fire fire;
    public Venom venom;
    public Image fireimg;
    public Image venomimg;

    public Wappon sword;
    public Image swordimg;

    public Image whitebg;

    public Sprite nextsprite;
    public Image image;


    public struct Snake
    {
        public string name;
        public int attack;
        public int blood;
        public int burst;
    }

    public struct Bird
    {
        public string name;
        public int attack;
        public int blood;
        public int burst;
    }

    public struct Fire
    {
        public Image image;
        public float speed;
    }

    public struct Venom
    {
        public Image image;
        public float speed;
    }

    public struct Wappon
    {
        public Image image;
        public float speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        snake = new Snake() { name = "大蛇", attack = 10, blood = 1500};
        snake.burst = 2 * snake.attack;
        firebird = new Bird() { name = "火鸟", attack = 15, blood = 1200};
        firebird.burst = 3 * firebird.attack;
        fire = new Fire() { image = fireimg, speed = 50.0f };
        venom = new Venom() { image = venomimg, speed = 50.0f };
        sword = new Wappon() { image = swordimg, speed = 25.0f };
    }

    enum attackState
    {
        attackState_snake,
        attackState_bird,
    }

    enum fadeState
    { 
        fadeState_noeffect,
        fadeState_fadein,
        fadeState_white,
        fadeState_fadeout,
    }

    attackState currentState = attackState.attackState_bird;
    float currentTime = 0.0f;


    // Update is called once per frame
    void Update()
    {
        RunMain(ref snake, ref firebird, ref venom, ref fire, ref venomimg, ref fireimg);
        RunZzattack(ref firebird, ref sword, ref swordimg);
        RunFade();
    }


    public void RunMain (ref Snake snake, ref Bird firebire, ref Venom venom, ref Fire fire,ref Image venomimg, ref Image fireimg)
    {
        switch (currentState)
        {
            case attackState.attackState_bird:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime <=3.0f)
                    {
                        fire.image.color = new Color(1, 1, 1, 1.0f);//火出现
                        venom.image.color = new Color(1, 1, 1, 0.0f);//毒液开始不存在
                        harmsnake.color = new Color(1, 1, 1, 0.0f);//开始蛇没有受伤，所以不显示
                        fire.image.rectTransform.position -= new Vector3(Time.deltaTime * fire.speed, 0.0f , 0.0f);//火移动
                    }
                    if (currentTime > 3.0f)
                    {
                        fire.image.color = new Color(1, 1, 1, 0.0f);//火消失
                        if (Random.Range(0, 100) <= 30) //机率为30%
                        {
                            snake.blood = snake.blood - firebird.burst;
                            harmsnake.text = "-" + firebird.burst;
                            harmsnake.color = new Color(1, 1, 1, 1.0f);
                        }
                        else
                        {
                            snake.blood = snake.blood - firebird.attack;
                            harmsnake.text = "-" + firebird.attack;
                            harmsnake.color = new Color(1, 1, 1, 1.0f);
                        }
                        numText1.text = snake.blood.ToString();
                        currentState = attackState.attackState_snake;
                        currentTime = 0.0f;
                        fire.image.rectTransform.localPosition = new Vector3(128.0f,33.0f,0.0f); //火回到原来的地方
                        Debug.Log("换蛇进行攻击"+snake.blood);
                    }
                }
                break;

            case attackState.attackState_snake:
                {
                    currentTime += Time.deltaTime;
                    if (currentTime<=3.0f)
                    {
                        venom.image.color = new Color(1, 1, 1, 1.0f);//毒液出现
                        venom.image.rectTransform.position += new Vector3(Time.deltaTime * venom.speed, 0.0f, 0.0f);//毒液移动
                        harmbird.color = new Color(1, 1, 1, 0.0f);//开始鸟没有受伤，所以不显示
                    }
                    if (currentTime > 3.0f)
                    {
                        venom.image.color = new Color(1, 1, 1, 0.0f);//毒液消失
                        if (Random.Range(0, 100) <= 50) //机率为50%
                        {
                            firebird.blood = firebird.blood - snake.burst;
                            harmbird.text = "-" + snake.burst;
                            harmbird.color = new Color(1, 1, 1, 1.0f);
                        }
                        else
                        {
                            firebird.blood = firebird.blood - snake.attack;
                            harmbird.text = "-" + snake.attack;
                            harmbird.color = new Color(1, 1, 1, 1.0f);
                        }
                        numText2.text = firebird.blood.ToString();
                        currentState = attackState.attackState_bird;
                        currentTime = 0.0f;
                        venom.image.rectTransform.localPosition = new Vector3(29.0f, -12.0f, 0.0f); //毒液回到原来的地方
                        Debug.Log("换火鸟进行攻击"+firebird.blood);
                    }
                }
                break;
        }
    }

    float zzTime =0.0f;
    public void RunZzattack(ref Bird firebird, ref Wappon sword, ref Image swordimg)
    {
        whitebg.color = new Color(1, 1, 1, 0.0f);
        if (firebird.blood < 500)
        {
            zzTime += Time.deltaTime;
            sword.image.rectTransform.position += new Vector3(Time.deltaTime * sword.speed, Time.deltaTime * sword.speed, 0.0f);
        }
        if(zzTime >5.0f)
        {
            sword.image.color = new Color(1, 1, 1, 0.0f);
            wa.text = "哇";
        }
        if (zzTime >10.0f)
        {
            image.sprite = nextsprite; //因为白屏没写出来 所以我把蛇变成铁块写在这里了
        }
    }

    fadeState currentFadeState = fadeState.fadeState_noeffect;
    float fadeTime = 0.0f;

    void RunFade()
    {
        switch (currentFadeState)
        {
            case fadeState.fadeState_fadein:
                {
                    if (fadeTime > 2.0f)
                    {
                        whitebg.color = new Color(1, 1, 1, fadeTime/2.0f);
                        currentFadeState = fadeState.fadeState_white;
                        fadeTime = 0.0f;
                    }
                }
                break;
            case fadeState.fadeState_white:
                {
                    if (fadeTime > 5.0f)
                    {
                        whitebg.color = new Color(1, 1, 1, 1.0f);
                        currentFadeState = fadeState.fadeState_fadeout;
                        fadeTime = 0.0f;
                    }
                }
                break;
            case fadeState.fadeState_fadeout:
                {
                    if (fadeTime > 2.0f)
                    {
                        whitebg.color = new Color(1, 1, 1, 0.0f);
                        currentFadeState = fadeState.fadeState_noeffect;
                        fadeTime = 0.0f;
                    }
                }
                break;
        }
    }
}
