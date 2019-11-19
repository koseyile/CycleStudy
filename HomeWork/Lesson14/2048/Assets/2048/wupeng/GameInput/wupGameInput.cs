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
                Debug.Log("右移");
            }
        }

        public InputProtocol GetInputData()
        {
            return currentInputData;
        }
    }

}
