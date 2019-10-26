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
        }

        public InputProtocol GetInputData()
        {
            return currentInputData;
        }
    }
}
