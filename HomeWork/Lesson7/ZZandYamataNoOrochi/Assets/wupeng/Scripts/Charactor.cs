using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Charactor : MonoBehaviour
{

    public int attack;
    public int hp;
    public int highAttackTime;
    public int probability;
    public bool isHighAttack;
    public GameObject target;
    public GameObject skill;


    public void Attack()
    {

        Debug.Log(this.name + "打击");

        //实例化技能       
        GameObject skillobj = Instantiate(skill, this.transform, false);

        skillobj.GetComponent<RectTransform>().position = this.GetComponent<RectTransform>().position;

        Skill s = skillobj.AddComponent<Skill>();
        s.state = SkillState.off;
        s.owner = this.gameObject;
        s.timer = 2.0f;
        s.speed = 2.0f;
        s.isAttaked = false;
        s.orient = Vector3.zero;

        s.Shoot();

        //此处有问题：为什么访问不到s.state的值？？
        //           本来打算在外部判断 技能s是否击中目标，如果击中，就写伤害血量的代码，并删除技能
        //           但是访问不到s.state，只好在s内部销毁是自己。

        //if (s.state == SkillState.attacked)
        //{
        //    Debug.Log("伤害");
        //    //伤害计算
        //    int damage;
        //    int p = Random.Range(1, 11);
        //    if (p < probability)
        //        isHighAttack = true;
        //
        //    if (isHighAttack)
        //    {
        //        damage = attack * highAttackTime;
        //        isHighAttack = false;
        //        Debug.Log("暴击");
        //    }
        //    else
        //    {
        //        damage = attack;
        //    }
        //
        //    target.GetComponent<Charactor>().hp -= damage;
        //    //删除技能
        //    Destroy(skillobj);
        //}

        //伤害计算
        int damage;
        int p = Random.Range(1, 11);
        if (p < probability)
            isHighAttack = true;

        if (isHighAttack)
        {
            damage = attack * highAttackTime;
            isHighAttack = false;
            Debug.Log("暴击");
        }
        else
        {
            damage = attack;
        }

        target.GetComponent<Charactor>().hp -= damage;

        //血量显示
        Text t = target.gameObject.transform.Find("blood").GetComponent<Text>();
        t.text = target.GetComponent<Charactor>().hp.ToString();

        //伤害显示
        target.gameObject.transform.Find("damage").GetComponent<UIBase>().Show(damage.ToString(), Color.red);

    }

    void Start()
    {
        //问题：此处为什么报错？
        Text text = this.gameObject.transform.Find("blood").GetComponent<Text>();
        text.text = this.hp.ToString();
    }

}
