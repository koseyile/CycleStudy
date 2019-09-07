using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WuPeng
{

    public class LetterCard : CardBase
    {
        private string m_path = "Prefabs/Ad_Board";

        [SerializeField]
        private char m_letter = 'A';          //显示数字
        private int m_carry = 'A' + 25;       //进位数字

        private bool m_wave = false;

        public LetterCard(Vector3 _pos)
        {
            GameObject prefab = Resources.Load(m_path) as GameObject;
            m_ob = GameObject.Instantiate(prefab, _pos, Quaternion.identity);
            m_text = m_ob.transform.Find("ad_number").GetComponent<TextMesh>();

            m_text.text = m_letter.ToString();
            this.m_state = RotateState.Pause;
            m_rotateIdentity = Quaternion.identity;
            m_active = false;
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
                            ChangeLetter();

                            m_state = RotateState.Pause;

                            if (m_wave)
                            {
                                m_active = false;
                            }
                        }
                        break;
                }
            }
        }

        public void ChangeLetter()
        {
            m_letter = (m_letter + 1) > m_carry ? 'A' : (char)(m_letter + 1);
            m_text.text = m_letter.ToString();
        }

        public void SetWaveState(bool _state)
        {
            m_wave = _state;
        }

    }
}
