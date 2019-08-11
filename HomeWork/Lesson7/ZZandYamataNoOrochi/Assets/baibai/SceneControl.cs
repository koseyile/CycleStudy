using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
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
        uiItem.dialogFellow.gameObject.SetActive(true);
        uiItem.dialogFellow.enabled = false;
        uiItem.cubeImage.gameObject.SetActive(false);
        orcImage = uiItem.orochiBody.GetChild(0).GetComponent<Image>();
        fbImage = uiItem.firebirdBody.GetChild(0).GetComponent<Image>();


        // initate hero
        Vector3 pA = uiItem.heroZZ.position;
        Vector3 pB = uiItem.midPoint.position;
        Vector3 pC = uiItem.firebirdBody.position - new Vector3(40f,0,0);
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
                        if (Random.Range(0, 100) <= fb.CriticalStrike) {
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
                        if (Random.Range(0, 100) <= orc.CriticalStrike)
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
                    HeroMove(ref hero, ref uiItems, ref attT);

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
                    HeroMove(ref hero, ref uiItems, ref attT);

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



    void HeroMove(ref Hero zz, ref UIitem uiHero, ref AttackTurn attT) {
        
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
