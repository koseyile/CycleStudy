using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WuPeng
{
    public enum RotateState
    {
        Rotate,
        Pause,
    }

    public class CardBase
    {
        protected RotateState m_state;

        protected GameObject m_ob;
        protected TextMesh m_text;

        [SerializeField]
        private string m_path = "Prefabs/Ad_Board";
        protected Vector3 m_axisX = new Vector3(1, 0, 0);
        protected Quaternion m_rotateIdentity;

        protected float m_timeUnit = 0.0f;   //更新间隔
        protected float m_timer = 0.0f;
        protected float m_speed = 0.0f;      //翻转一次的速度
        protected float m_rotateTime = 0.0f; //翻转一次的事件跨度
        protected float m_rotatetimer = 0.0f;

        protected bool m_active = false;

        public CardBase(Vector3 _pos)
        {
            GameObject prefab = Resources.Load(m_path) as GameObject;
            m_ob = GameObject.Instantiate(prefab, _pos, Quaternion.identity);
            m_text = m_ob.transform.Find("ad_number").GetComponent<TextMesh>();
            this.m_state = RotateState.Pause;
            m_rotateIdentity = Quaternion.identity;
            m_active = false;
        }

        public CardBase()
        {
        }

        public virtual void Update()
        {
            if (m_active)
            {
                m_timer -= Time.deltaTime;
                if (m_timer < 0.0f)
                {
                    m_timer = m_timeUnit;

                    if (m_state == RotateState.Pause)
                    {
                        m_state = RotateState.Rotate;
                    }
                }

                switch (m_state)
                {
                    case RotateState.Pause:
                        break;

                    case RotateState.Rotate:

                        m_rotatetimer -= Time.deltaTime;
                        Rotate(m_speed * Time.deltaTime);

                        if (m_rotatetimer < 0)
                        {
                            m_rotatetimer = m_rotateTime;
                            m_ob.transform.rotation = m_rotateIdentity;
                            m_state = RotateState.Pause;
                        }
                        break;
                }
            }
        }

        public void SetActive(bool _isActive)
        {
            this.m_active = _isActive;
        }

        public void SetState(RotateState _state)
        {
            m_state = _state;
        }

        public void Rotate(float _angle)
        {
            if (m_ob)
            {
                m_ob.transform.Rotate(m_axisX, _angle);
            }
        }

        public void SetSpeed(float _speed)
        {
            this.m_speed = _speed;
            this.m_rotateTime = 360 / m_speed;
            this.m_rotatetimer = this.m_rotateTime;
        }

        public void SetTimeUnit(float _timeUnit)
        {
            this.m_timeUnit = _timeUnit;
            this.m_timer = m_timeUnit;
        }
    }
}


