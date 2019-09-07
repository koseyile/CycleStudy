using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WuPeng
{

    public class Test_Airport : MonoBehaviour
    {
        LetterCard[,] m_letterCards;

        [SerializeField]
        Vector3 m_begainPos = new Vector3(-15, 10, 0);

        // Start is called before the first frame update
        void Start()
        {
            m_letterCards = new LetterCard[30, 20];

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    m_letterCards[i, j] = new LetterCard(m_begainPos + new Vector3(i * 2, j * 2, 0));

                    if (i > 10 && i < 20 && j > 7 && j < 14)
                    {
                        m_letterCards[i, j].SetActive(true);
                    }else
                        m_letterCards[i, j].SetActive(false);

                    m_letterCards[i, j].SetTimeUnit(Random.Range(1.0f, 3.0f));
                    m_letterCards[i, j].SetSpeed(720.0f);
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
        }
    }
}


