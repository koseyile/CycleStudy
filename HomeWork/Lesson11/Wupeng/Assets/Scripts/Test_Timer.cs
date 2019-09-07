using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WuPeng
{
    public class Test_Timer : MonoBehaviour//总体控制
    {
        static private TimeCard[] m_timer;
        static private bool m_state;

        private void Start()
        {
            m_timer = new TimeCard[8];
            m_state = false;

            m_timer[0] = new TimeCard(new Vector3(10, 0, 0), TimeType.MiSecondUnit);
            m_timer[1] = new TimeCard(new Vector3(8, 0, 0), TimeType.MiSecondDigit);
            
            m_timer[2] = new TimeCard(new Vector3(5, 0, 0), TimeType.SecondUnit);
            m_timer[3] = new TimeCard(new Vector3(3, 0, 0), TimeType.SecondDigit);
            
            m_timer[4] = new TimeCard(new Vector3(0, 0, 0), TimeType.MinuteUnit);
            m_timer[5] = new TimeCard(new Vector3(-2, 0, 0), TimeType.MinuteDigit);
            
            m_timer[6] = new TimeCard(new Vector3(-5, 0, 0), TimeType.HourUnit);
            m_timer[7] = new TimeCard(new Vector3(-7, 0, 0), TimeType.HourDigit);

            SetTimerActive();
        }

        private void Update()
        {

            m_timer[1].Update();

           for (int i = 0; i < m_timer.Length; i ++)
           {
               m_timer[i].Update();
           }

        }

        static public void SetTimerActive()
        {
            if (!m_state)
            {
                for (int i = 0; i < m_timer.Length; i++)
                {
                    m_timer[i].SetActive(true);

                }
                m_state = true;
            }
            else
            {
                for (int i = 0; i < m_timer.Length; i++)
                {
                    m_timer[i].SetActive(false);

                }
                m_state = false;
            }

        }
    }
}

