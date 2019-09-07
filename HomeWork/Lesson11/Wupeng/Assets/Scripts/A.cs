using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WuPeng
{
    public class A : MonoBehaviour//总体控制
    {
        private TimeCard m_card;

        private void Start()
        {
            m_card = new TimeCard(new Vector3(0, 0, 0), TimeType.SecondDigit);
        }

        private void Update()
        {
            m_card.Update();
        }
    }
}

