using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace BBHW14 {

    public class bbGameInput : IGameInput
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
                //Debug.Log("MoveRight");
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                currentInputData = InputProtocol.MoveLeft;
                //Debug.Log("MoveLeft");
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                currentInputData = InputProtocol.MoveUp;
                //Debug.Log("MoveUp");
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                currentInputData = InputProtocol.MoveDown;
                //Debug.Log("MoveDown");
            }

        }

        public InputProtocol GetInputData()
        {
            return currentInputData;
        }
    }


}
