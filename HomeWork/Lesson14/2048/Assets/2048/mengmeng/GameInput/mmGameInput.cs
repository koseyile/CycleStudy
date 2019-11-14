using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace mm
{
    public class mmGameInput : IGameInput
    {
        private InputProtocol InputData;
        private Vector2 startPoint;
        private Vector2 endPoint;
        private readonly float OffsetDistance = 25f;



        public void ModuleInit()
        {
            InputData = InputProtocol.None;
        }
        public InputProtocol GetInputData()
        {
            return InputData;
        }

        public void ModuleUpdate()
        {
            InputData = InputProtocol.None;
            //键盘输入
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                InputData = InputProtocol.MoveRight;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                InputData = InputProtocol.MoveLeft;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                InputData = InputProtocol.MoveUp;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                InputData = InputProtocol.MoveDown;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                InputData = InputProtocol.Click;
            }

            //触屏输入
            else if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPoint = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                endPoint = Input.GetTouch(0).position;
                if (Vector2.Distance(startPoint, endPoint) > OffsetDistance)
                {
                    GetMoveDirection();
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endPoint = Input.GetTouch(0).position;
                if (Vector2.Distance(startPoint,endPoint) < OffsetDistance)
                {
                    InputData = InputProtocol.Click;
                }
            }

            //鼠标输入
            else if (Input.GetMouseButtonDown(0))
            {
                startPoint = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                endPoint = Input.mousePosition;
                if (Vector2.Distance(startPoint, endPoint) > OffsetDistance)
                {
                    GetMoveDirection();
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                endPoint = Input.mousePosition;
                if (Vector2.Distance(startPoint, endPoint) < OffsetDistance)
                {
                    InputData = InputProtocol.Click;
                }
            }
        }
        private void GetMoveDirection()
        {
            float angle = (Vector2.SignedAngle(new Vector2(1, 0), endPoint - startPoint));
            if (angle < 30 && angle > -30)
            {
                InputData = InputProtocol.MoveRight;
            }
            else if(angle > 60 && angle < 120 )
            {
                InputData = InputProtocol.MoveUp;
            }
            else if(angle > 150 && angle < -150)
            {
                InputData = InputProtocol.MoveLeft;
            }
            else if (angle > -120 && angle < -60)
            {
                InputData = InputProtocol.MoveDown;
            }
        }

        public void ModuleDestroy() { }
    }

}
