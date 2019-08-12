using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Naomi_Lesson7 : MonoBehaviour
{
    public float scenetime;
    public float fighttime;
    public float FadingTime;

    public Monster orochi;
    public Image imageOro;
    public Image fire;
    public Text oroHP;
    public Text oroDamage;

    public Monster moltres;
    public Image imageMol;
    public Image poison;
    public Text molHP;
    public Text molDamage;

    public Hero zz;
    public Image imageZz;
    public Sprite imageZzAttack;
    public Sprite imageZzEnd;

    public enum AtkState { Init, Attack, Back }

    public enum FightState { PreAttack, MolAttack, OroAttack };
    FightState fightState = FightState.PreAttack;

    public enum SceneState { PreFight, MonsterFight, HeroFight, Wow, Ending }
    SceneState scenestate = SceneState.PreFight;

    public enum FadingState { Init, Fadein, White, Fadeout, End };
    FadingState fadingstate = FadingState.Init;

    public Text wow;
    public Image imagewhite;
    public Metal metal;
    public Image iPhone;

    // Start is called before the first frame update
    void Start()
    {
        orochi = new Monster("orochi", 10, 1000,50,20, imageOro, poison, oroHP, oroDamage);
        zz = new Hero("zz", 2, imageZz, imageZzAttack, imageZzEnd);
        moltres = new Monster("moltres",15,550,30,45,imageMol,fire, molHP, molDamage);
        metal = new Metal(iPhone);
        imagewhite.color = new Color(0, 0, 0, 0);
        fadingstate = FadingState.Fadein;
    }

    // Update is called once per frame
    void Update()
    {
        SceneChanging(ref moltres, ref orochi, ref zz, ref wow, ref metal);
        //FadeInFadeOut(ref metal, ref orochi, ref moltres);
    }

    public void SceneChanging(ref Monster FirstAtk, ref Monster SecondAtk, ref Hero ZZ, ref Text wow, ref Metal metalShining)
    {
        switch (scenestate)
        {
            case SceneState.PreFight:
                {
                    scenetime += Time.deltaTime;
                    metalShining.Image.color = new Color(1,1,1,0);
                    wow.color = new Color(1, 1, 1, 0);
                    if (scenetime > 0.2f)
                    {
                        scenestate = SceneState.MonsterFight;
                        scenetime = 0;
                    }
                }
                break;
            case SceneState.MonsterFight:
                {
                    scenetime += Time.deltaTime;
                    MonsterFighting(ref FirstAtk, ref SecondAtk);
                    if (FirstAtk.HPnow < 500 && FirstAtk.DamageText.color == new Color(1,1,1,0))
                    {
                        ZZ.State = Hero.HeroState.PreAttack;
                        scenestate = SceneState.HeroFight;
                        scenetime = 0;
                    }
                }
                break;
            case SceneState.HeroFight:
                {
                    scenetime += Time.deltaTime;
                    ZZ.zzAttack(ref FirstAtk,ref SecondAtk);
                    if (ZZ.State == Hero.HeroState.Attack)
                    {
                        fadingstate = FadingState.Fadein;
                        scenestate = SceneState.Wow;
                    }
                }
                break;
            case SceneState.Wow:
                {
                    wowUpdate(ref wow);
                    scenetime += Time.deltaTime;
                    ZZ.zzAttack(ref FirstAtk, ref SecondAtk);
                    FadeInFadeOut(ref metal, ref orochi, ref moltres);
                    if(fadingstate == FadingState.White)
                    {
                        scenestate = SceneState.Ending;
                    }
                }
                break;
            case SceneState.Ending:
                {
                    FadeInFadeOut(ref metal, ref orochi, ref moltres);
                    scenestate = SceneState.Ending;
                    ZZ.ImageOri.sprite = ZZ.ImageEnd;
                    ZZ.ImageOri.transform.localPosition = new Vector3(425, -100, 0);
                }
                break;
        }
    }

    public struct Hero
    {
        public string Name;
        public float AtkTime;
        public enum HeroState { Init, PreAttack,Attack, Stand }
        public HeroState State;
        public Image ImageOri;
        public Sprite ImageAtk;
        public Sprite ImageEnd;
        public Hero(string name, int attackTime, Image imageOri, Sprite imageAtk, Sprite imageEnd)
        {
            Name = name;
            AtkTime = attackTime;
            State = HeroState.Init;
            ImageOri = imageOri;
            ImageAtk = imageAtk;
            ImageEnd = imageEnd;
        }
        public void zzAttack(ref Monster mol,ref Monster oro)
        {
            switch (State)
            {
                case HeroState.Init:
                    {
                        if (mol.HPnow < 500)
                        {
                            State = HeroState.PreAttack;
                        }
                    }
                    break;
                case HeroState.PreAttack:
                    {
                        if (ImageOri.transform.localPosition.y < 580 && ImageOri.transform.localPosition.x < 0)
                        {
                            ImageOri.transform.localPosition += new Vector3(0, 20, 0);
                        }
                        else
                        {
                            ImageOri.sprite = ImageAtk;
                            ImageOri.transform.localPosition = new Vector3(425, 620, 0);
                            State = HeroState.Attack;
                        }
                    }
                    break;
                case HeroState.Attack:
                    {
                        ImageOri.transform.localPosition += new Vector3(0, -24, 0);
                        mol.ImageMon.transform.localPosition += new Vector3(0, -10, 0);
                        oro.ImageMon.transform.localPosition += new Vector3(10, 0, 0);
                        if (mol.ImageMon.transform.localPosition.y < -150)
                        {
                            State = HeroState.Stand;
                        }
                    }
                    break;
                case HeroState.Stand:
                    {
                        
                    }
                    break;
            }
        }
    }

    public struct Monster
    {
        public string Name;
        public int Atk;
        public int MaxHP;
        public int HPnow;
        public int Crit;
        public int CritAtk;
        public float AtkTimer;
        public enum AtkState { Init, Attack, Wait }
        public AtkState State;
        public Image ImageMon;
        public Image Skill;
        public Text HPtext;
        public Text DamageText;
        public Monster(string name, int MonAtk, int MonHp, int crit, int critAttack, Image imageMon, Image imageskill, Text textHP, Text textDam)
        {
            Name = name;
            Atk = MonAtk;
            MaxHP = MonHp;
            HPnow = MaxHP;
            Crit = crit;
            CritAtk = critAttack;
            AtkTimer = 0f;
            State = AtkState.Init;
            ImageMon = imageMon;
            Skill = imageskill;
            Skill.color = new Color(1, 1, 1, 0);
            textHP.text = HPnow + "/" + MonHp;
            HPtext = textHP;
            textDam.color = new Color(1, 1, 1, 0);
            DamageText = textDam;
        }

        public void CritAttack()
        {
            if (Random.Range(0, 100) <= Crit)
            {
                Atk = CritAtk;
            }
        }
    }

    public void Attack(ref Monster AtkMon, ref Monster AtkedMon)
    {
        switch (AtkMon.State)
        {
            case Monster.AtkState.Init:
                {
                    AtkedMon.DamageText.transform.localPosition = new Vector3(125, 125, 0);
                    AtkedMon.DamageText.color = new Color(1, 1, 1, 0);
                    AtkMon.Skill.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case Monster.AtkState.Attack:
                {
                    AtkMon.AtkTimer += Time.deltaTime;
                    if (AtkMon.AtkTimer > 0.3f)
                    {
                        AtkMon.CritAttack();
                        AtkedMon.DamageText.text = "-" + AtkMon.Atk;
                        AtkedMon.DamageText.color = new Color(1, 1, 1, 1);
                        AtkMon.Skill.color = new Color(1, 1, 1, 1);
                        AtkedMon.HPnow -= AtkMon.Atk;
                        AtkedMon.HPtext.text = AtkedMon.HPnow + "/" + AtkedMon.MaxHP;
                        AtkMon.State = Monster.AtkState.Wait;
                    }
                }
                break;
            case Monster.AtkState.Wait:
                {
                    AtkMon.AtkTimer += Time.deltaTime;
                    if (AtkMon.AtkTimer > 0.9f)
                    {
                        AtkMon.Skill.color = new Color(1, 1, 1, 0);
                        AtkMon.State = Monster.AtkState.Init;
                        AtkMon.AtkTimer = 0.0f;
                    }
                    else
                    {
                        AtkMon.Skill.transform.localScale += new Vector3(0.001f, 0.001f, 0);
                        AtkedMon.DamageText.color = new Color(1, 1, 1, 1 - AtkMon.AtkTimer/2);
                        AtkedMon.DamageText.transform.localPosition += new Vector3(0, 1, 0);
                    }
                }
                break;
        }
    }

    public void MonsterFighting(ref Monster Mol, ref Monster Oro)
    {
        switch(fightState)
        {
            case FightState.PreAttack:
                {
                    Mol.State = Monster.AtkState.Attack;
                    fightState = FightState.MolAttack;
                }
                break;
            case FightState.MolAttack:
                {
                    fighttime += Time.deltaTime;
                    Attack(ref Mol, ref Oro);
                    if (fighttime > 1.0f)
                    {
                        Oro.State = Monster.AtkState.Attack;
                        fightState = FightState.OroAttack;
                        fighttime = 0f;
                    }
                }
                break;
            case FightState.OroAttack:
                {
                    fighttime += Time.deltaTime;
                    Attack(ref Oro, ref Mol);
                    if (fighttime > 1.0f)
                    {
                        Mol.State = Monster.AtkState.Attack;
                        fightState = FightState.MolAttack;
                        fighttime = 0f;
                    }
                }
                break;
        }
    }

    public void wowUpdate(ref Text wow)
    {
        if(wow.color.a <= 0 && wow.transform.localPosition.y <=100)
        {
            wow.color = new Color(255, 255, 255, 1);
            wow.transform.localPosition += new Vector3(5, 60, 0);
        }
        else
        {
            wow.color -= new Color(0, 0, 0, 0.02f);
            wow.transform.localPosition += new Vector3(1, 2, 0);
            wow.transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
    }

    public void FadeInFadeOut(ref Metal metalShining,ref Monster oro, ref Monster mol)
    {
        switch (fadingstate)
        {
            case FadingState.Init:
                {
                    imagewhite.color = new Color(255, 255, 255, 0);
                }
                break;
            case FadingState.Fadein:
                {
                    FadingTime += Time.deltaTime;
                    if (FadingTime > 2.0f)
                    {
                        imagewhite.color = new Color(255, 255, 255, 1);
                        fadingstate = FadingState.White;
                        FadingTime = 0f;
                    }
                    else
                    {
                        imagewhite.color = new Color(255, 255, 255, FadingTime / 2);
                    }
                }
                break;
            case FadingState.White:
                {
                    oro.ImageMon.color = new Color(0, 0, 0, 0);
                    oro.HPtext.color = new Color(0, 0, 0, 0);
                    mol.ImageMon.color = new Color(0, 0, 0, 0);
                    mol.HPtext.color = new Color(0, 0, 0, 0);
                    wow.color= new Color(0, 0, 0, 0);
                    FadingTime += Time.deltaTime;
                    if (FadingTime > 3.0f)
                    {
                        metalShining.state = Metal.Shining.Hide;
                        fadingstate = FadingState.Fadeout;
                        FadingTime = 0f;
                    }
                }
                break;
            case FadingState.Fadeout:
                {
                    metalShining.MetalShining();
                    FadingTime += Time.deltaTime;
                    if (FadingTime > 2.0f)
                    {
                        imagewhite.color = new Color(255, 255, 255, 0);
                        FadingTime = 0f;
                        fadingstate = FadingState.End;
                    }
                    else
                    {
                        imagewhite.color = new Color(255, 255, 255, 1 - FadingTime / 2);
                    }
                }
                break;
            case FadingState.End:
                {
                    metalShining.MetalShining();
                }
                break;
        }
    }

    public struct Metal
    {
        public Image Image;
        public float Timer;
        public enum Shining { Init,Hide, Show };
        public Shining state;
        public Metal(Image imageMetal)
        {
            Image = imageMetal;
            Timer = 0f;
            state = Shining.Init;
        }

        public void MetalShining()
        {
            switch (state)
            {
                case Shining.Init:
                    {
                        Image.color = new Color(1, 1, 1, 0);
                    }
                    break;
                case Shining.Hide:
                    {
                        Timer += Time.deltaTime;
                        Image.color += new Color(0, 0, 0, 0.3f);
                        if (Timer > 0.2f)
                        {
                            state = Shining.Show;
                            Timer = 0f;
                        }
                    }
                    break;
                case Shining.Show:
                    {
                        Timer += Time.deltaTime;
                        Image.color -= new Color(0, 0, 0, 0.3f);
                        if (Timer > 0.6f)
                        {
                            Image.color = new Color(1, 1, 1,0);
                            state = Shining.Hide;
                            Timer = 0f;
                        }
                    }
                    break;
            }
        }
    }
}
