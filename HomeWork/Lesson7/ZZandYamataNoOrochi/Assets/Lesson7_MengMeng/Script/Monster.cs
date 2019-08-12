using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private void Start()
    {
        GetEnermy();
        SetHpLabel();
    }
    float CurrentTime = 0;
    private void Update()
    {
        StateMachine(ref CurrentTime);
    }


    public Text HpText;
    public Text DamageNumText;
    public Image AttackImg;

    public string MonsterName;
    public int MaxHP;
    public int CurrentHP;
    public int Atk;
    public int crit;
    public int critAtk;

    public enum State { Start, Wait, Attack }
    public State state;
    Monster Enermy = null;

    public Monster(string _Name, int _MaxHP, int _Atk, int _crit, int _critAtk)
    {
        MonsterName = _Name;
        MaxHP = _MaxHP;
        CurrentHP = MaxHP;
        Atk = _Atk;
        crit = _crit;
        critAtk = _critAtk;
        state = State.Start;
        SetHpLabel();

    }

    void GetEnermy()
    {
        if (MonsterName == "Bird")
        {
            Enermy = transform.parent.Find("Snake").GetComponent<Monster>();
        }
        else
        {
            Enermy = transform.parent.Find("Bird").GetComponent<Monster>();
        }
    }


    public IEnumerator Attack(Monster Target)
    {
        if (Target == null)
            yield break;
        //Debug.Log(MonsterName + "attack");
        AttackImg.enabled = true;
        int MoveTimes = (int)(1.5f / Time.deltaTime);
        Vector3 Move = (Target.transform.position - AttackImg.transform.position) / MoveTimes;
        for (int i = 0; i < MoveTimes; i++)
        {
            AttackImg.transform.Translate(Move);
            yield return 0;
        }

        AttackImg.enabled = false;
        AttackImg.transform.localPosition = new Vector3(0, 0, 0);
        int Damagenum = (Random.Range(0, 100) < crit) ? critAtk : Atk;
        Target.CurrentHP -= Damagenum;
        Target.SetHpLabel();
        StartCoroutine(Target.SetDamageNum(Damagenum));
    }
    void SetHpLabel()
    {
        HpText.text = CurrentHP.ToString() + " / " + MaxHP.ToString();
    }
    IEnumerator SetDamageNum(int Damage)
    {
        DamageNumText.enabled = true;
        DamageNumText.text = "-" + Damage;
        yield return new WaitForSeconds(1.5f);
        DamageNumText.enabled = false;
    }

    void StateMachine(ref float CurrentTime)
    {
        CurrentTime += Time.deltaTime;
        switch (state)
        {
            case State.Start:
                CurrentTime = 0;
                break;
            case State.Wait:
                if (CurrentTime > 3f)
                {
                    CurrentTime = 0;
                    state = State.Attack;
                }
                break;
            case State.Attack:
                StartCoroutine(Attack(Enermy));
                CurrentTime = 0;
                state = State.Wait;
                break;
        }
    }

}
