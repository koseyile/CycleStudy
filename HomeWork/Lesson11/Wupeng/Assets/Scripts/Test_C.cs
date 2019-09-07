using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WuPeng
{
    public class Test_C : MonoBehaviour
    {
        LetterCard m_letter;


        // Start is called before the first frame update
        void Start()
        {
            m_letter = new LetterCard(new Vector3(0, 0, 0));
            m_letter.SetActive(true);
            m_letter.SetTimeUnit(1.0f);
            m_letter.SetSpeed(720.0f);
        }

        // Update is called once per frame
        void Update()
        {
            m_letter.Update();
        }
    }

}
