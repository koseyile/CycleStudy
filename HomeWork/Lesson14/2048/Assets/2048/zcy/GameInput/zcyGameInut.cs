using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace ZCY
{
    public class zcyGameInput : IGameInput
    {
        private InputProtocol currentInputData;
        
        public void ModuleInit()
        {
            currentInputData = InputProtocol.None;
        }

        public void ModuleDestroy()
        {}

        public void ModuleUpdate()
        {
            currentInputData = InputProtocol.None;
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                currentInputData = InputProtocol.MoveRight;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                currentInputData = InputProtocol.MoveLeft;
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                currentInputData = InputProtocol.MoveUp;
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
