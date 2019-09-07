using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WuPeng
{
    /*
     问题1: 我需要让Card继承mono吗？ 还是在另一个类中继承Mono统一管理Card的运动？

     */
    public enum TimeType
    {
        HourDigit,
        HourUnit,

        MinuteDigit,
        MinuteUnit,

        SecondDigit,
        SecondUnit,

        MiSecondDigit,
        MiSecondUnit,
    }

    public class TimeCard : CardBase
    {

        private string m_path = "Prefabs/Ad_Board";

        [SerializeField]
        private int m_number = 0;          //显示数字
        private int m_carry = 0;           //进位数字

        public TimeCard(Vector3 _pos, TimeType _type) 
        {
            GameObject prefab = Resources.Load(m_path) as GameObject;
            m_ob = GameObject.Instantiate(prefab, _pos, Quaternion.identity);
            m_text = m_ob.transform.Find("ad_number").GetComponent<TextMesh>();
            this.m_state = RotateState.Pause;
            m_rotateIdentity = Quaternion.identity;
            m_active = false;

            switch (_type)
            {
                case TimeType.MiSecondUnit:
                    m_ob.name = "MiSecondUnit";
                    m_carry = 9;
                    m_timeUnit = 1.0f / 60.0f;
                    m_timer = m_timeUnit;
                    m_speed = 6 * 360.0f;
                    m_rotateTime = 360.0f / m_speed;
                    m_rotatetimer = m_rotateTime;
                    break;

                case TimeType.MiSecondDigit:
                    m_ob.name = "MiSecondDigit";
                    m_carry = 6;
                    m_timeUnit = 1.0f / 6.0f;
                    m_timer = m_timeUnit;
                    m_speed = 1.0f / m_timeUnit * 360.0f;
                    m_rotateTime = 360.0f / m_speed;
                    m_rotatetimer = m_rotateTime;
                    break;

                case TimeType.SecondUnit:
                    m_ob.name = "SecondUnit";
                    m_carry = 9;
                    m_timeUnit = 1.0f;
                    m_timer = m_timeUnit;
                    m_speed = 2 * 360.0f;
                    m_rotateTime = 360.0f / m_speed;
                    m_rotatetimer = m_rotateTime;
                    break;

                case TimeType.SecondDigit:
                    m_ob.name = "SecondDigit";
                    m_carry = 6;;
                    m_timeUnit = 10.0f;
                    m_timer = m_timeUnit;
                    m_speed =  360.0f;
                    m_rotateTime = 360.0f / m_speed;
                    m_rotatetimer = m_rotateTime;
                    break;

                case TimeType.MinuteUnit:
                    m_ob.name = "MinuteUnit";
                    m_carry = 9;
                    m_timeUnit = 60.0f;
                    m_timer = m_timeUnit;
                    m_speed = 180.0f;
                    m_rotateTime = 360.0f / m_speed;
                    m_rotatetimer = m_rotateTime;
                    break;

                case TimeType.MinuteDigit:
                    m_ob.name = "MinuteDigit";
                    m_carry = 6;
                    m_timeUnit = 600.0f;
                    m_timer = m_timeUnit;
                    m_speed = 180.0f;
                    m_rotateTime = 360.0f / m_speed;
                    m_rotatetimer = m_rotateTime;
                    break;

                case TimeType.HourUnit:
                    m_ob.name = "HourUnit";
                    m_carry = 9;
                    m_timeUnit = 3600.0f;
                    m_timer = m_timeUnit;
                    m_speed = 180.0f;
                    m_rotateTime = 360.0f / m_speed;
                    m_rotatetimer = m_rotateTime;
                    break;

                case TimeType.HourDigit:
                    m_ob.name = "HourUnit";
                    m_carry = 9;
                    m_timeUnit = 36000.0f;
                    m_timer = m_timeUnit;
                    m_speed = 180.0f;
                    m_rotateTime = 360.0f / m_speed;
                    m_rotatetimer = m_rotateTime;
                    break;
            }
        }

        public override void Update()
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
                            ChangeNumber();
                        }
                        break;
                }
            }
        }

        private void ChangeNumber()
        {
            if (m_text)
            {
                m_number += 1;
                if (m_number > m_carry)
                {
                    m_number = 0;
                }
                m_text.text = m_number.ToString();
            }
        }

    }
}
