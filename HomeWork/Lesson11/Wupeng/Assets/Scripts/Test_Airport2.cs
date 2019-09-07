using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WuPeng
{
    public class Test_Airport2 : MonoBehaviour
    {
        LetterCard[,] m_letterCards;

        [SerializeField]
        private Vector3 m_begainPos = new Vector3(-15, 10, 0);
        private float m_timer = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            m_letterCards = new LetterCard[30, 20];

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    m_letterCards[i, j] = new LetterCard(m_begainPos + new Vector3(i * 2, j * 2, 0));

                    m_letterCards[i, j].SetActive(false);

                    m_letterCards[i, j].SetWaveState(true);

                    m_letterCards[i, j].SetTimeUnit(1.0f);
                    m_letterCards[i, j].SetSpeed(360.0f);
                }
            }

        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    m_letterCards[i, j].Update();
                }
            }

            Wave();
        }


        //波浪效果

        public void Wave()
        {
            m_timer += Time.deltaTime;

            for (int i = 0; i < 30; i ++)
            {
                for (int j = 0; j < 20; j ++)
                {
                    if (Mathf.Sin(m_timer + 3.1f * i  + 3.2f * j ) > 0.99f)
                    {
                        m_letterCards[i, j].SetActive(true);
                    }

                }
            }

            
        }

    }
}


