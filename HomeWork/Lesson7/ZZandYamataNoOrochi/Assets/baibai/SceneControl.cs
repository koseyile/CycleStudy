using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    /*
     * 习题：
    Zz坐在船上，观赏着沿岸美景，船顺流而下，斐伊川的河流具有非常多的支流，当船行至出现8条支流的地方时，zz发现那里稳稳插着一把剑。
    Zz拔出了这把剑，突然河水翻滚，8条支流变身为8条蛇慢慢升起，当蛇全部升起后，zz发现，不是8条蛇，是一条蛇有8个头。
    8蛇怪害怕zz手中的剑，钻入河水中消失不见了。
    被释放出来的8蛇怪其实是八岐大蛇，数百年前被速須佐与奇稻田姬引诱，喝了足足八大桶美酒，趁八岐大蛇沉睡时，速須佐将天从云剑插入八岐大蛇的腹部，从此
    将八岐大蛇封印，八岐大蛇的身体化身为河流，滋养着斐伊川的人们。
    八岐大蛇被解除封印后，隐藏在斐伊川附近的山中，伺机而动。
    Zz回到家后，把这件事情告诉了好朋友们，白白，巫巫，hongyi，Naomi，suye，wupeng，mengmeng表示都不相信，zz你少来，当zz拿出天从云剑时，他们就都相信了。
    这8个人讨论了一天一夜随后决定，为了避免八岐大蛇祸害人类，他们要模仿古法，用美酒醉倒八岐大蛇，然后用天从云剑再次封印八岐大蛇。
    造美酒可没那么简单，第一步需要采集足够多的清澈山泉水，第二步需要优良品质的粮食，再配合充分时间的发酵，8桶美酒终于造出来了。
    8人抱着8桶美酒开始寻找八岐大蛇，在寻找的过程中，zz偷偷尝了一口酒，发现怎么这么好喝啊，不知不觉，一桶酒都被zz喝光了。
    他们终于找到八岐大蛇了，趁它睡觉的时候，轻轻将八桶酒放在它旁边，八岐大蛇醒后，闻到了酒香，发现了美酒，这头天真的蛇并没有吸取从前的教训，急切地将头伸进了酒桶，一口气喝光了所有的酒，不一会，八岐大蛇的七个头醉倒在地，剩下一头呆呆立在那里，好像在说，为什么只有我没有酒喝！
    朋友们也惊呆了，为什么啊，难道那个头喝了假酒吗？
    Zz说，不，因为它没有喝到酒，酒被我喝光了，因为太好喝了，你们也应该尝一口的哈哈，好吧，我对不起大家。
    你个渣渣！大家齐声喊，那现在我们怎么办。
    Zz自信地说，别急，看我的，天从云剑拿来，我去封印它。
    Zz哆哆嗦嗦地靠近八岐大蛇，举起了天从云剑，突然天空中出现了一只巨大火鸟，火鸟直扑向zz，嘴里喷出烈焰，凶狠的眼神，好像憎恨所有人类。
    八岐大蛇没等烈焰靠近zz，一跃而起挡在了zz前面，由于八岐大蛇只剩一个可以活动的头，与火鸟的搏斗处尽了下风，最后八岐大蛇不得不用身体死死缠绕住烈焰火鸟，八岐大蛇忍受着超强的高温，慢慢被烧为灰烬，zz利用这一刻，扑了上去，将天从云剑插入了火鸟的胸膛，烈焰火鸟疼痛难忍，死去时释放出巨大的火焰能量，即使是天从云剑也逐渐在火焰中熔化。
    当火焰消失后，zz和朋友们发现，天从云剑被熔化后变成了一个小金属块，方方正正的，很轻巧，zz捡起了它，看到了八岐大蛇被封印在其中，用手轻轻滑动金属块的表面，八岐大蛇居然还能和zz互动！
    在之后的日子，白白，巫巫，hongyi，Naomi，suye，wupeng，mengmeng发现zz像谈了恋爱一般，总是盯着这个方方正正的小金属块傻笑，灵巧地小手指在上面滑动着，有时还兴奋地喊：“SSR，给我出SSR！”


    利用unity2019.1.0f1打开ZZandYamataNoOrochi工程，并在Assets目录下创建以自己名字命名的文件夹，在此文件夹内创建scene。
    尽你所能利用unity image,label摆出上述故事中的一帧画面，满足如下要求：
    1. 画面中要有八岐大蛇，烈焰火鸟，酒桶，天从云剑，zz及七位小伙伴。
    2. 假设八岐大蛇的攻击力为10,血量为1000，每次攻击有一半的机率产生爆击，爆击伤害为攻击力的2倍。
    烈焰火鸟的攻击力为15, 血量为1200，每次攻击有30%的机率发生爆击，爆击伤害为攻击力的3倍。
    八岐大蛇与烈焰火鸟回合制进行战斗，烈焰火鸟先攻击，一回合的时间需要3秒，请使用状态机模拟此过程。
    3. 八岐大蛇攻击时会喷射毒液，请在状态机中插入毒液动画。
    4. 烈焰火鸟攻击时会释放火焰，请在状态机中插入火焰攻击动画。
    5. 用label显示八岐大蛇与烈焰火鸟的当前的血量，要一直显示。
    6. 用label显示八岐大蛇与烈焰火鸟的当前受到的攻击伤害，显示完之后要消失。
    7. 当烈焰火鸟血量少于500时，zz会将天从云剑插入了火鸟的胸膛，这个过程耗时5秒，请在状态机中插入代码，模拟这个过程。
    8. 烈焰火鸟被zz攻击后，小伙伴们齐声喊出了“哇！”，请使用label显示这些“哇！”
    9. “哇！”声之后，整个画面fade in到白屏，白屏显示3秒，再fade out出来，fade的过程都是2秒，请使用状态机实现此过程。
    10. 烈焰鸟消失，八岐大蛇也化为灰烬，灰烬中有个方方正正小金属块在闪烁。
     */



    // initiate mobs
    Mob orochi;
    Mob fireBird;
    Hero heroZZ;
    Cube cb;
    Screen screen;

    // UI text, image, transform
    public UIitem uiItem;
    Image orcImage;
    Image fbImage;

    // initiate states
    AttackTurn attackTurn;

    void Start()
    {
        InitiateScene();
    }


    void Update()
    {
        TurnPlay(ref attackTurn, ref orochi, ref fireBird, ref heroZZ, ref screen, ref cb, ref uiItem);
    }


    void InitiateScene()
    {
        // initate screen & UI fellows
        screen = new Screen(ScreenState.PreState,2f,3f,2f);

        uiItem.dialogFellow.enabled = false;
        uiItem.cubeImage.gameObject.SetActive(false);
        orcImage = uiItem.orochiBody.GetChild(0).GetComponent<Image>();
        fbImage = uiItem.firebirdBody.GetChild(0).GetComponent<Image>();


        // initate hero
        Vector3 pA = uiItem.heroZZ.position;
        Vector3 pB = uiItem.midPoint.position;
        Vector3 pC = uiItem.firebirdBody.position;
        heroZZ = new Hero(pA, pB, pC);

        // initiate mobs
        Vector3 orcPA = uiItem.orochiBody.GetChild(1).position;
        Vector3 orcPB = uiItem.orochiBody.GetChild(2).position;
        orochi = new Mob(10f, 1000f, 50, 2f, orcPA, orcPB,1f,0.8f);
        Vector3 fbPA = uiItem.firebirdBody.GetChild(1).position;
        Vector3 fbPB = uiItem.firebirdBody.GetChild(2).position;
        fireBird = new Mob(15f, 600f, 30, 3f, fbPA, fbPB,1f,0.8f);

        HealthUpdate(ref orochi,uiItem.orcHealth);
        HealthUpdate(ref fireBird, uiItem.fbHealth);


        // initiate prop
        cb = new Cube(CubeState.Off, 0.5f, 6f);

        // initiate turnplay
        attackTurn = AttackTurn.Init;

        Debug.Log("scene initialized");
    }


    struct Mob {
        public float Attack;
        public float Health;
        public int CriticalStrike; // ?%
        public float CriticalDamage; // ?times * Attack
        public float TurnCritital; // current turn critialDamange
        //public bool StartAttk; // false
        public bool Moved; // false
        public float TurnTime;
        public Projectile Pjt;
        public DamangeShow DamageShow;

        public Mob(float attack, float health, int cs, float cd, Vector3 pA, Vector3 pB, float tCons, float dSec)
        {
            Attack = attack;
            Health = health;
            CriticalStrike = cs;
            CriticalDamage = cd;
            TurnCritital = 0f;
            //StartAttk = false;
            Moved = false;
            TurnTime = 0f;
            Pjt = new Projectile(pA, pB, tCons);
            DamageShow = new DamangeShow(dSec);
        }

    }

    public struct Projectile {
        public ProjectileState PState;
        public Vector3 StartPoint;
        public Vector3 EndPoint;
        public float TimeConstant;

        public Projectile(Vector3 startPoint, Vector3 endPoint, float timeCons) {
            PState = ProjectileState.Disable;
            StartPoint = startPoint;
            EndPoint = endPoint;
            TimeConstant = timeCons;
        }
    }

    public struct Hero {
        public float HeroTime;
        public Vector3 HeroPosA;
        public Vector3 HeroPosB;
        public Vector3 HeroPosC;

        public Hero(Vector3 posA, Vector3 posB, Vector3 posC) {
            HeroTime = 0f;
            HeroPosA = posA;
            HeroPosB = posB;
            HeroPosC = posC;
        }
    }

    public struct Cube {
        public CubeState CState;
        public float CubeTime;
        public float CubeInterval;
        public float GlitterSec;
        public float CloseTime;

        public Cube(CubeState cs, float glitter, float close) {
            CState = cs;
            CubeTime = 0f;
            CubeInterval = 0f;
            GlitterSec = glitter;
            CloseTime = close;
        }
    }

    public struct Screen {
        public ScreenState SState;
        public float ScreenTime;
        public float FadeInTime;
        public float WhiteTime;
        public float FadeOutTime;

        public Screen(ScreenState ss, float fadein, float white, float fadeout) {
            SState = ss;
            ScreenTime = 0f;
            FadeInTime = fadein;
            WhiteTime = white;
            FadeOutTime = fadeout;
        }
    }

    public struct DamangeShow {
        public DamangeUIState UIstate;
        public float TotalDamangeRec;
        public float DamageTxtSec;
        public float DisplayTime;

        public DamangeShow(float ds) {
            UIstate = DamangeUIState.Disable;
            TotalDamangeRec = 0f;
            DamageTxtSec = ds; // set max time for display
            DisplayTime = 0f;
        }
    }


    [System.Serializable]
    public struct UIitem {

        // UI text

        public Text orcHealth;
        public Text fbHealth;
        public Text attOnFB;
        public Text ctcOnFB;
        public Text attOnORC;
        public Text ctcOnORC;
        public bool UITextClear;

        public Text dialogFellow;

        // UI image
        public Image screenImage;
        public Image orcCriticalImage;
        public Image fbCriticalImage;

        // UI transform
        public Transform orochiBody;
        public Transform firebirdBody;

        public Transform heroZZ;
        public Transform fellow7;
        public Transform midPoint;

        public Transform barrel;
        public Transform swordCloud;

        public Transform fireImage;
        public Transform poisonImage;
        public Transform cubeImage;
    }


    enum AttackTurn {
        Init,
        FireBirdTurn,
        OrochiTurn,
        HeroTurn,
        HeroTurnPost,
        BattleOver,
        CubeOut,
        GameOver,
    }

    public enum ScreenState {
        PreState,
        FadeIn,
        WhiteScreen,
        FadeOut,
        PostState,
    }

    public enum CubeState {
        Off,
        On,
    }

    public enum ProjectileState {
        Enable,
        Shooting,
        ShowDamage,
        Disable,
    }

    public enum DamangeUIState {
        Disable,
        Enable,
        Display,
    }

    void TurnPlay(ref AttackTurn attT, ref Mob orc, ref Mob fb, ref Hero hero, ref Screen sc, ref Cube cube, ref UIitem uiItems)
    {

        DisplayDamange(ref orc, uiItems.orcHealth, uiItems.attOnORC, uiItems.ctcOnORC);
        DisplayDamange(ref fb, uiItems.fbHealth, uiItems.attOnFB, uiItems.ctcOnFB);

        switch (attT)
        {
            case AttackTurn.Init:
                {
                    attT = AttackTurn.FireBirdTurn;
                }
                break;
            case AttackTurn.FireBirdTurn:
                {
                    fb.TurnTime += Time.deltaTime;

                    if (fb.Moved == false) {
                        // firebird attack!!每次攻击有30%的机率发生爆击，爆击伤害为攻击力的3倍
                        fb.TurnCritital = 0f;
                        int x = Random.Range(0, 100);
                        if (x <= fb.CriticalStrike) {
                            fb.TurnCritital = fb.Attack * fb.CriticalDamage;
                        }

                        orc.Health = orc.Health - fb.Attack - fb.TurnCritital;
                        orc.DamageShow.TotalDamangeRec = fb.Attack + fb.TurnCritital;

                        // enalbe projectile
                        if (fb.Pjt.PState == ProjectileState.Disable) {
                            fb.Pjt.PState = ProjectileState.Enable;
                        }

                        fb.Moved = true;
                        orc.Moved = false;
                    }

                    // firebird fire animation
                    MobAttackAnime(ref fb, uiItems.fireImage);

                    if (fb.TurnTime > fb.Pjt.TimeConstant) {

                        if (fb.Health >= 500f)
                        {
                            attT = AttackTurn.OrochiTurn;
                            fb.TurnTime = 0f;
                        }
                        else {
                            attT = AttackTurn.HeroTurn;
                            fb.TurnTime = 0f;
                        }         
                    }
                }
                break;
            case AttackTurn.OrochiTurn:
                {
                    orc.TurnTime += Time.deltaTime;

                    if (orc.Moved == false)
                    {
                        // orc attack!!每次攻击有一半的机率产生爆击，爆击伤害为攻击力的2倍。
                        orc.TurnCritital = 0f;
                        int x = Random.Range(0, 100);
                        if (x <= orc.CriticalStrike)
                        {
                            orc.TurnCritital = orc.Attack * orc.CriticalDamage;
                        }

                        fb.Health = fb.Health - orc.Attack - orc.TurnCritital;
                        fb.DamageShow.TotalDamangeRec = orc.Attack + orc.TurnCritital;

                        // enalbe projectile
                        if (orc.Pjt.PState == ProjectileState.Disable)
                        {
                            orc.Pjt.PState = ProjectileState.Enable;
                        }

                        //Debug.Log("orc attack: " + orc.Attack + "orc Ctc: " + orc.TurnCritital);
                        orc.Moved = true;
                        fb.Moved = false;
                    }

                    // orc poison animation
                    MobAttackAnime(ref orc, uiItems.poisonImage);

                    if (orc.TurnTime > orc.Pjt.TimeConstant)
                    {
                        if (fb.Health >= 500f)
                        {
                            attT = AttackTurn.FireBirdTurn;
                            orc.TurnTime = 0f;
                        }
                        else
                        {
                            attT = AttackTurn.HeroTurn;
                            orc.TurnTime = 0f;
                        }
                    }
                }
                break;
            case AttackTurn.HeroTurn:
                {
                    hero.HeroTime += Time.deltaTime;

                    // zz attack firebird animation
                    ZZMove(ref hero, ref uiItems, ref attT);

                    // fellows shout
                    if (uiItems.dialogFellow.enabled == false) {
                        uiItems.dialogFellow.enabled = true;
                    }

                    if (hero.HeroTime > 1.5f) {
                        uiItems.dialogFellow.enabled = false;
                        attT = AttackTurn.HeroTurnPost;
                        hero.HeroTime = 0f;
                        Debug.Log("Wa is over.");
                    }
                }
                break;
            case AttackTurn.HeroTurnPost:
                {                  
                    hero.HeroTime += Time.deltaTime;

                    // zz attack firebird animation still on
                    ZZMove(ref hero, ref uiItems, ref attT);

                    // fellows shout over & start screen change
                    if (sc.SState == ScreenState.PreState)
                    {
                        sc.SState = ScreenState.FadeIn;
                        Debug.Log("Starting fade in");
                    }

                    ScreenChange(ref sc, ref uiItems);

                    if (hero.HeroTime > 3.5f)
                    {
                        attT = AttackTurn.BattleOver;
                        hero.HeroTime = 0f;
                        Debug.Log("ZZ attack is over.");
                     }
                }
                break;
            case AttackTurn.BattleOver:
                {
                    ScreenChange(ref sc, ref uiItems);

                    // mobs fade
                    if (uiItems.UITextClear==false) {
                        MobUItxtClear(ref uiItems);
                        uiItems.UITextClear = true;
                    }

                    MobFadeOut(ref orc, orcImage, 3.5f);
                    MobFadeOut(ref fb, fbImage, 3.5f);

                    if (sc.SState == ScreenState.PostState) {
                        Debug.Log("Battle is over.");
                        // orc & firebird disappear 
                        uiItems.orochiBody.gameObject.SetActive(false);
                        uiItems.firebirdBody.gameObject.SetActive(false);
                        
                        // cube out  
                        attT = AttackTurn.CubeOut;
                        Debug.Log("Cube is out.");
                    }    
                }
                break;
            case AttackTurn.CubeOut:
                {
                    cube.CubeTime += Time.deltaTime;
                    
                    // cube glitter - animation
                    CubeGlitter(ref cube, ref uiItems);

                    if (cube.CubeTime > cube.CloseTime) {
                        attT = AttackTurn.GameOver;
                        cube.CubeTime = 0f;
                        cube.CState = CubeState.On;
                        uiItem.cubeImage.gameObject.SetActive(true);
                    }
                }
                break;
            case AttackTurn.GameOver:
                {
                    // do nothing
                }
                break;
        }


    }

    void ScreenChange(ref Screen scr, ref UIitem ui) {

        scr.ScreenTime += Time.deltaTime;

        switch (scr.SState)
        {
            case ScreenState.PreState:
                {
                    // do nothing
                }
                break;
            case ScreenState.FadeIn:
                {
                    // 2s  (0,1)
                    float k = (scr.ScreenTime / scr.FadeInTime);
                    ui.screenImage.color = new Color(1,1,1,k);

                    if (scr.ScreenTime > scr.FadeInTime)
                    {
                        scr.SState = ScreenState.WhiteScreen;
                        scr.ScreenTime = 0f;
                        Debug.Log("Starting WhiteScreen");
                    }
                }
                break;
            case ScreenState.WhiteScreen:
                {
                    //change to white for 3s
                    if (scr.ScreenTime > scr.WhiteTime)
                    {
                        scr.SState = ScreenState.FadeOut;
                        scr.ScreenTime = 0f;
                        Debug.Log("Starting fade out");
                    }
                }
                break;

            case ScreenState.FadeOut:
                {
                    //2s
                    float k = 1 - (scr.ScreenTime / scr.FadeOutTime);
                    ui.screenImage.color = new Color(1, 1, 1, k);

                    if (scr.ScreenTime > scr.FadeOutTime)
                    {
                        scr.SState = ScreenState.PostState;
                        scr.ScreenTime = 0f;
                        Debug.Log("Post State now");
                    }        
                }
                break;
            case ScreenState.PostState:
                {
                    // do nothing                   
                }
                break;
        }
    }

    
    void HealthUpdate(ref Mob receiver, Text health) {
        //health update
        health.text = receiver.Health.ToString();
    }

    void DisplayDamange(ref Mob receiver, Text health, Text attD, Text ctcD) {
        //damage update & disappear
        switch (receiver.DamageShow.UIstate){
            case DamangeUIState.Disable:
                {
                    //do nothing
                }
                break;
            case DamangeUIState.Enable:
                {
                    receiver.DamageShow.DisplayTime = 0f;
                    attD.text = receiver.DamageShow.TotalDamangeRec.ToString();
                    //ctcD.text = receiver.DamageShow.DtcFromEnemy.ToString();
                    HealthUpdate(ref receiver, health);
                    receiver.DamageShow.UIstate = DamangeUIState.Display;
                }
                break;
            case DamangeUIState.Display:
                {
                    receiver.DamageShow.DisplayTime += Time.deltaTime;

                    if (receiver.DamageShow.DisplayTime > receiver.DamageShow.DamageTxtSec) {
                        receiver.DamageShow.UIstate = DamangeUIState.Disable;
                        attD.text = "";
                        ctcD.text = "";
                    }
                }
                break;
        }
    }



    void ZZMove(ref Hero zz, ref UIitem uiHero, ref AttackTurn attT) {
        
        if (attT == AttackTurn.HeroTurn)
        {
            // zz jump up move to mid point
            float k = (zz.HeroTime / 1.5f);
            float x = (zz.HeroPosB.x - zz.HeroPosA.x) * k;
            float y = (zz.HeroPosB.y - zz.HeroPosA.y) * k;
            uiHero.heroZZ.position = zz.HeroPosA + new Vector3(x,y,0f);
        }
        else if (attT == AttackTurn.HeroTurnPost) {
            // zz move to strike firebird
            float p = (zz.HeroTime / 3.5f);
            float x = (zz.HeroPosC.x - zz.HeroPosB.x) * p;
            float y = (zz.HeroPosC.y - zz.HeroPosB.y) * p;
            uiHero.heroZZ.position = zz.HeroPosB + new Vector3(x, y, 0f);
        }
    }

    void CubeGlitter(ref Cube cube, ref UIitem ui)
    {
        cube.CubeInterval += Time.deltaTime;

        switch (cube.CState)
        {
            case CubeState.Off:
                {
                    if (cube.CubeInterval > cube.GlitterSec)
                    {
                        cube.CState = CubeState.On;
                        ui.cubeImage.gameObject.SetActive(true);
                        cube.CubeInterval = 0f;
                    }
                }
                break;
            case CubeState.On:
                {
                    if (cube.CubeInterval > cube.GlitterSec)
                    {
                        cube.CState = CubeState.Off;
                        ui.cubeImage.gameObject.SetActive(false);
                        cube.CubeInterval = 0f;
                    }
                }
                break;
        }
    }

    void MobUItxtClear(ref UIitem ui) {
        ui.orcHealth.enabled = false;
        ui.fbHealth.enabled = false;
        ui.attOnFB.enabled = false;
        ui.ctcOnFB.enabled = false;
        ui.attOnORC.enabled = false;
        ui.ctcOnORC.enabled = false;
    }

    void MobFadeOut(ref Mob mb, Image img, float fadeTime) {
        mb.TurnTime += Time.deltaTime;
        float k = 1 - (mb.TurnTime / fadeTime);
        img.color = new Color(img.color.r, img.color.g, img.color.b, k);
    }

    void MobAttackAnime(ref Mob mb, Transform pjtImage) {

        switch (mb.Pjt.PState) {
            case ProjectileState.Disable:
                {
                    //do nothing
                }
                break;
            case ProjectileState.Enable:
                {
                    pjtImage.position = mb.Pjt.StartPoint;
                    pjtImage.gameObject.SetActive(true);
                    mb.Pjt.PState = ProjectileState.Shooting;
                }
                break;
            case ProjectileState.Shooting:
                {
                    if (mb.TurnTime <= mb.Pjt.TimeConstant - mb.DamageShow.DamageTxtSec)
                    {
                        float k = (mb.TurnTime / mb.Pjt.TimeConstant);
                        float x = (mb.Pjt.StartPoint.x - mb.Pjt.EndPoint.x) * k;
                        pjtImage.position = mb.Pjt.StartPoint - new Vector3(x, 0f, 0f);
                    }
                    else {            
                        //show damange
                        mb.DamageShow.UIstate = DamangeUIState.Enable;
                        mb.Pjt.PState = ProjectileState.ShowDamage;
                    }
                }
                break;
            case ProjectileState.ShowDamage:
                {
                    if (mb.TurnTime <= mb.Pjt.TimeConstant)
                    {
                        float k = (mb.TurnTime / mb.Pjt.TimeConstant);
                        float x = (mb.Pjt.StartPoint.x - mb.Pjt.EndPoint.x) * k;
                        pjtImage.position = mb.Pjt.StartPoint - new Vector3(x, 0f, 0f);
                    }
                    else
                    {
                        pjtImage.gameObject.SetActive(false);
                        mb.Pjt.PState = ProjectileState.Disable;
                    }
                }
                break;
        }

    }

}
