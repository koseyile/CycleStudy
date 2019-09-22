using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wupeng
{
    public class UI_Manager
    {

        public float m_Height;

        public float m_Speed = 6000.0f;

        static UI_Manager _current;

        static public UI_Manager Current
        {

            get
            {
                if (_current != null) { return _current; }

                return new UI_Manager();
            }
        }

        public UI_Manager()
        {
            this.m_Height = Screen.height - 100;
        }
    }

}
