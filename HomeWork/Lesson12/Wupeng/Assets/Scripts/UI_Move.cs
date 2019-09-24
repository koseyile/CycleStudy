using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Wupeng
{

    public enum UI_STATE
    {
        Still,
        Shrink,
        Grow,
    }

    public class UI_Move : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private UI_STATE m_state;

        private RectTransform m_rectTransform;

        private float m_width;
        private float m_height;

        private float m_center_x;
        private float m_center_y;

        private float m_changing_height;

        private float m_changing_center_y;

        private Vector2 m_size;


        // Start is called before the first frame update
        void Start()
        {
            m_state = UI_STATE.Still;
            m_rectTransform = this.GetComponent<RectTransform>();

            m_width = m_rectTransform.sizeDelta.x;
            m_height = m_rectTransform.sizeDelta.y;
            m_center_x = m_rectTransform.anchoredPosition3D.x;
            m_center_y = m_rectTransform.anchoredPosition3D.y;

            m_changing_height = m_height;

            m_changing_center_y = m_center_y;

            m_size = new Vector2(m_width, 0);
        }


        void Update()
        {
            switch (m_state)
            {
                case UI_STATE.Still:
                    break;
                case UI_STATE.Grow:

                    m_changing_height += UI_Manager.Current.m_Speed * Time.deltaTime;

                    float y = m_center_y + (m_changing_height - m_height) / 2;

                    m_size.y = m_changing_height;



                    if (m_changing_height >= UI_Manager.Current.m_Height)
                    {
                        m_rectTransform.sizeDelta = new Vector2(m_size.x, UI_Manager.Current.m_Height);

                        m_rectTransform.anchoredPosition3D = new Vector3(m_center_x, y, 0);

                        m_state = UI_STATE.Still;

                    }
                    m_rectTransform.sizeDelta = m_size;

                    m_rectTransform.anchoredPosition3D = new Vector3(m_center_x, y, 0);


                    break;

                case UI_STATE.Shrink:

                    m_changing_height -= UI_Manager.Current.m_Speed * Time.deltaTime;

                    float y2 = m_center_y + (m_changing_height - m_height) / 2;

                    m_size.y = m_changing_height;


                    m_rectTransform.sizeDelta = m_size;

                    m_rectTransform.anchoredPosition3D = new Vector3(m_center_x, y2, 0);

                    if (m_changing_height <= m_height)
                    {
                        m_state = UI_STATE.Still;

                        m_rectTransform.sizeDelta = new Vector2(m_width, m_height);

                        m_rectTransform.anchoredPosition3D = new Vector3(m_center_x, m_center_y, 0);
                    }


                    break;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_state = UI_STATE.Grow;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_state = UI_STATE.Shrink;
        }

    }

}
