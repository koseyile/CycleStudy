using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;


namespace WP
{
    public class wupGameInput : IGameInput
    {
        private InputProtocol currentInputData;

        public void ModuleInit()
        {
            currentInputData = InputProtocol.None;
        }

        public void ModuleDestroy()
        { }

        public void ModuleUpdate()
        {
            currentInputData = InputProtocol.None;
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                currentInputData = InputProtocol.MoveRight;
                //Debug.Log("右移");
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                currentInputData = InputProtocol.MoveLeft;
                //Debug.Log("左移");
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                currentInputData = InputProtocol.MoveUp;
                //Debug.Log("上移");
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                currentInputData = InputProtocol.MoveDown;
            }
        }

        public InputProtocol GetInputData()
        {
            return currentInputData;
        }
    }
}
