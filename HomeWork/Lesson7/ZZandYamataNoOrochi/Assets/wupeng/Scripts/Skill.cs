using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum SkillState { off, on, attacked }

public class Skill : MonoBehaviour
{
    public string name_Skill;

    public GameObject owner;
    public float timer;//重定位时间间隔
    public float speed;
    public Vector3 orient;

    public bool isAttaked = false;//技能是否打击到

    public SkillState state = SkillState.off;

    public Skill(GameObject owner)
    {
        this.owner = owner;
        this.state = SkillState.off;
    }

    void Update()
    {
        switch (state)
        {
            case SkillState.off:
                break;
            case SkillState.on:
                SkillMove();
                break;
            case SkillState.attacked:
                SkillDestroy();
                break;
        }
    }

    void SkillMove()
    {

        orient = Vector3.Normalize(owner.GetComponent<Charactor>().target.transform.position - this.transform.position);

        this.GetComponent<RectTransform>().position += orient * speed;


        if (Mathf.Abs (this.transform.position.x - owner.GetComponent<Charactor>().target.transform.position.x )< 1
            && Mathf.Abs( this.transform.position.y - owner.GetComponent<Charactor>().target.transform.position.y) < 1)
        {
            state = SkillState.attacked;
            Debug.Log("击中");
        }
    }

    public void SkillDestroy()
    {
        Destroy(this.gameObject);
    }

    public void Shoot()
    {
        this.state = SkillState.on;
    }
}
