using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class WuwuLesson7 : MonoBehaviour
{
    //假设八岐大蛇的攻击力为10,血量为1000，每次攻击有一半的机率产生爆击，爆击伤害为攻击力的2倍。烈焰火鸟的攻击力为15, 血量为1200，每次攻击有30%的机率发生爆击，
    //爆击伤害为攻击力的3倍。八岐大蛇与烈焰火鸟回合制进行战斗，烈焰火鸟先攻击，一回合的时间需要3秒，请使用状态机模拟此过程。


    public struct Role
    {
        public int attack;
        public int blood;
        public int criticaldamage;
    }

    public Role snake;
    public Role firebird;

    public Image Snake;
    public Image Firebird;
    public Image Gas;
    public Image Fire;
    public Image ZZ;
    public Image Wapon;
    public Image Friends;
    public Image Wow;
    public Image White;
    public Image SnakeAsh;
    public Image Gold;

    public Text NumofSnakeblood;
    public Text NumofBirdblood;
    public Text NumofSnakeAttack;
    //public Slider snakebloodbar;
    
    public enum FightRound
    {
        snakefight,
        birdfight,
    }
    
    float fightcurrenttime=0.0f;
    
    float gascurrenttime=0.0f;
    float firecurrenttime=0.0f;//这几个不知道应该在哪里初始化
    float whitecurrentime=0.0f;

    FightRound currentFightState = FightRound.birdfight;


    // Start is called before the first frame update
    void Start()
    {
        snake = new Role() { attack = 10, blood = 600, criticaldamage = 2 * 10 };
        firebird = new Role() { attack = 15, blood = 550, criticaldamage = 3 * 15 };
        Wow.color = new Color(1, 1, 1, 0.0f);
        White.color = new Color(1, 1, 1, 0.0f);
        SnakeAsh.color = new Color(1, 1, 1, 0.0f);
        Gold.color = new Color(1, 1, 1, 0.0f);
    }

    public void Fight(ref Role snake, ref Role firebird,ref Text NumofSnakeblood, ref Text NumofBirdblood)
    {

        fightcurrenttime += Time.deltaTime;
        switch (currentFightState)
        {
            case FightRound.birdfight:
                {
                    if (fightcurrenttime > 3.0f)
                    {
                        if (firebird.blood >= 0 && snake.blood >= 0)
                        {
                            Debug.Log("烈焰火鸟开始攻击");
                            if (Random.Range(0, 100) <= 30)
                            {
                                snake.blood = snake.blood - firebird.criticaldamage;
                                if (snake.blood >= 0)
                                {
                                    Debug.Log("八岐大蛇血量还剩" + snake.blood);
                                    //用label显示八岐大蛇与烈焰火鸟的当前的血量，要一直显示。
                                    NumofSnakeblood.text = "血量" + snake.blood.ToString();
                                    Debug.Log("烈焰火鸟触发暴伤产生伤害" + firebird.criticaldamage);
                                    NumofSnakeAttack.text = " ";
                                    //snakebloodbar.value = snake.blood;
                                    NumofBirdblood.text = "血量" + firebird.blood.ToString();
                                }
                            }
                            else
                            {
                                snake.blood = snake.blood - firebird.attack;
                                if (snake.blood >= 0)
                                {
                                    Debug.Log("烈焰火鸟产生伤害" + firebird.attack);
                                    //用label显示八岐大蛇与烈焰火鸟的当前的血量，要一直显示。
                                    NumofSnakeblood.text = "血量" + snake.blood.ToString();
                                    Debug.Log("八岐大蛇血量还剩" + snake.blood);
                                    //snakebloodbar.value = snake.blood; 血条会变，但是这里报错，还应该要怎么实例化呢
                                    NumofBirdblood.text = "血量" + firebird.blood.ToString();
                                    NumofSnakeAttack.text = " ";
                                }
                            }
                            currentFightState = FightRound.snakefight;
                            fightcurrenttime = 0.0f;
                        }
                    }
                }
                break;
            case FightRound.snakefight:
                {
                    if (fightcurrenttime > 3.0f)
                    {
                        if (firebird.blood >= 0 && snake.blood >= 0)
                        {
                            Debug.Log("八岐大蛇开始攻击");
                            if (Random.Range(0, 100) <= 50)
                            {
                                firebird.blood = firebird.blood - snake.criticaldamage;
                                if (firebird.blood >= 0)
                                {
                                    Debug.Log("八岐大蛇触发暴击产生伤害" + snake.criticaldamage);
                                    //用label显示八岐大蛇与烈焰火鸟的当前受到的攻击伤害，显示完之后要消失。
                                    NumofSnakeAttack.text = "受到伤害" + snake.criticaldamage.ToString();
                                    //snakebloodbar.value = snake.blood;
                                    Debug.Log("烈焰火鸟血量还剩" + firebird.blood);
                                    NumofBirdblood.text = "血量" + firebird.blood.ToString();
                                }
                            }
                            else
                            {
                                firebird.blood = firebird.blood - snake.attack;
                                if (firebird.blood >= 0)
                                {
                                    //用label显示八岐大蛇与烈焰火鸟的当前受到的攻击伤害，显示完之后要消失。还不知道怎么消失
                                    Debug.Log("八岐大蛇产生伤害" + snake.attack);
                                    NumofSnakeAttack.text = "受到伤害" + snake.attack.ToString();
                                    Debug.Log("烈焰火鸟血量还剩" + firebird.blood);
                                    //snakebloodbar.value = snake.blood;
                                    NumofBirdblood.text = "血量" + firebird.blood.ToString();
                                }
                            }
                            currentFightState = FightRound.birdfight;
                            fightcurrenttime = 0.0f;
                        }
                    }
                }
                break;
        }
    }

    public void Fight(ref Role snake,ref Role firebird,ref Image Gas, ref Image Fire)
    {
        Fight(ref snake, ref firebird, ref NumofSnakeblood, ref NumofBirdblood);
        SnakeGas(ref Gas);
        Firebirdfire(ref Fire);
    }

    
    public void Fight(ref Role firebird, ref Image ZZ, ref Image Wapon,ref Image Wow, ref Image White, ref Image SnakeAsh, ref Image Snake, ref Image Gold)
    {
        Fight(ref snake, ref firebird, ref NumofSnakeblood, ref NumofBirdblood);
        ZZfight(ref firebird, ref ZZ, ref Wapon, ref Wow, ref White, ref SnakeAsh, ref Snake, ref Gold);
    }

    //毒液函数
   
    public void SnakeGas(ref Image Gas)
    {
        if (currentFightState == FightRound.snakefight)
        {
            int speed = 150;
            gascurrenttime += Time.deltaTime;
            Gas.color = new Color(1, 1, 1, 1.0f);
            Gas.rectTransform.position += new Vector3(speed* Time.deltaTime, speed * Time.deltaTime, 0.0f);
        }
        else
        {
            Gas.color = new Color(1, 1, 1, 0.0f);
            Gas.rectTransform.localPosition = new Vector3(-150.0f, 0.0f, 0.0f);
        }

    }
    //喷火函数
   
    public void Firebirdfire(ref Image Fire)
    {
        if (currentFightState == FightRound.birdfight)
        {
            firecurrenttime += Time.deltaTime;
            int speed = 150;
            Fire.color = new Color(1, 1, 1, 1.0f);
            Fire.rectTransform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else
        {
            Fire.color = new Color(1, 1, 1, 0.0f);
            Fire.rectTransform.localPosition = new Vector3(100, -80.0f, 0.0f);
        }
            
    }
    float zzcurrenttime = 0.0f;

    //7. 当烈焰火鸟血量少于500时，zz会将天从云剑插入了火鸟的胸膛，这个过程耗时5秒，请在状态机中插入代码，模拟这个过程。
    public void ZZfight(ref Role firebird, ref Image ZZ, ref Image Wapon,ref Image Wow, ref Image White,ref Image SnakeAsh, ref Image Snake,ref Image Gold)
    {
        if (firebird.blood <= 500)
        {
            
            zzcurrenttime += Time.deltaTime;
            if (zzcurrenttime <= 5.0f)
            {
                float minus = -30.0f;
                float add = 30.0f;
                ZZ.rectTransform.position += new Vector3(minus * Time.deltaTime, 0, 0);
                Wapon.rectTransform.position += new Vector3(minus * Time.deltaTime, add * Time.deltaTime, 0);
            }
            else
            {
                //8. 烈焰火鸟被zz攻击后，小伙伴们齐声喊出了“哇！”，请使用label显示这些“哇！
                Wow.color = new Color(1, 1, 1, 1.0f);
                ZZ.rectTransform.localPosition = new Vector3(350, -100, 0);
                Wapon.color = new Color(1, 1, 1, 0.0f);
                Whitefade(ref White,ref Snake,ref SnakeAsh,ref Gold);
            }    
        }   
    }
    
    public enum Whitestate
    {
        fadein,
        fadeout,
        iswhite,
    }
    Whitestate whitecurrentstate = Whitestate.fadein;

    //白屏的状态机
    public void Whitefade(ref Image White, ref Image Snake, ref Image SnakeAsh, ref Image Gold)
    {
        whitecurrentime += Time.deltaTime;
        switch (whitecurrentstate)
        {
            case Whitestate.fadein:
                {
                    if (whitecurrentime > 2.0f)
                    {
                        //9. “哇！”声之后，整个画面fade in到白屏，白屏显示3秒，再fade out出来，fade的过程都是2秒，请使用状态机实现此过程。
                        float fadein = 0.5f;
                        White.color = new Color(1, 1, 1, fadein * Time.deltaTime);
                        whitecurrentstate = Whitestate.iswhite;
                        whitecurrentime = 0;
                    }
                }
                break;
            case Whitestate.iswhite:
                {

                    if (whitecurrentime > 3.0f)
                    {
                        //9. 白屏显示3秒
                        White.color = new Color(1, 1, 1, 1.0f);
                        if (whitecurrentime > 3.0f) whitecurrentstate = Whitestate.fadeout;
                        whitecurrentime = 0;
                    }
                }
                break;
            case Whitestate.fadeout:
                {
                    if (whitecurrentime >2.0f)
                    {
                        Snake.color = new Color(1, 1, 1, 0.0f); 
                        SnakeAsh.color = new Color(1, 1, 1, 1.0f);
                        Gold.color = new Color(1, 1, 1, 1.0f);
                        float fadeout = 0.8f;
                        White.color = new Color(1, 1, 1, fadeout * Time.deltaTime);
                        whitecurrentstate = Whitestate.fadein;
                        whitecurrentime = 0;
                    }   
                }
                break;
        }

    }


    // Update is called once per frame
    void Update()
    {
        //题2
        //Fight(ref snake, ref firebird,ref NumofSnakeblood, ref NumofBirdblood);
        //题3-4 喷射毒液和喷火：
        //Fight(ref snake, ref firebird, ref Gas, ref Fire);
        ////题7-10
        Fight(ref firebird, ref ZZ, ref Wapon, ref Wow, ref White, ref SnakeAsh, ref Snake, ref Gold);
    }
}
