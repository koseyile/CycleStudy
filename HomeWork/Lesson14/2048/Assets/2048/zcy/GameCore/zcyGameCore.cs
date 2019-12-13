using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace ZCY
{

    public class NumberMoveObject
    {
        public INumberObject moveNumberObj;
        public NumberMoveObject next;
        public NumberMoveObject parent;

        private InputProtocol moveType;
        private float speed;
        private Vector2 moveDir;
        private Vector2 endPos;
        private bool moveFinished;
        private bool hasMerged;
        private float distanceWithParent;

        public NumberMoveObject(INumberObject _moveNumberObj, InputProtocol _moveType, Vector2 _endPos, float _distanceWithParent)
        {
            moveNumberObj = _moveNumberObj;
            moveType = _moveType;
            endPos = _endPos;
            distanceWithParent = _distanceWithParent;

            switch (moveType)
            {
                case InputProtocol.MoveUp:
                    { moveDir = Vector2.up; }
                    break;
                case InputProtocol.MoveDown:
                    { moveDir = Vector2.down; }
                    break;
                case InputProtocol.MoveLeft:
                    { moveDir = Vector2.left; }
                    break;
                case InputProtocol.MoveRight:
                    { moveDir = Vector2.right; }
                    break;
            }
        }

        public void Moving()
        {
            speed += 10f * Time.deltaTime;
            Vector2 pos = moveNumberObj.GetCurrentPos();
            pos += moveDir * speed;

            if (parent==null && Vector2.Dot(endPos - pos, moveDir) <= 0)
            {
                pos = endPos;
                moveFinished = true;
            }else if(parent!=null && parent.moveFinished==true){
                Vector2 tempEndPos = parent.moveNumberObj.GetCurrentPos()-distanceWithParent*moveDir;
                
                bool needMerge = parent.moveNumberObj.GetNumber()==moveNumberObj.GetNumber() && this.hasMerged==false && parent.hasMerged==false;
                if(needMerge)
                {
                    tempEndPos = parent.moveNumberObj.GetCurrentPos();
                }

                if(Vector2.Dot(tempEndPos - pos, moveDir) <= 0)
                {
                    pos = tempEndPos;
                    moveFinished = true;

                    if(needMerge)
                    {
                        GameFramework.singleton.getGameRender().DestroyObject(this.moveNumberObj);
                        parent.next = this.next;
                        if(this.next!=null)
                        {
                            this.next.parent = parent;
                        }
                        parent.hasMerged = true;
                        parent.moveNumberObj.SetNumber(parent.moveNumberObj.GetNumber()*2);
                    }
                }


            }

            moveNumberObj.SetPosition(pos);

            if (next != null)
            {
                next.Moving();
            }
        }

        public bool CheckMoveFinished()
        {
            bool b = moveFinished;
            if (next != null)
            {
                b &= next.CheckMoveFinished();
            }
            return b;
        }

        private void ReSet()
        {
            hasMerged=false;
            moveFinished=false;
            speed = 0f;
        }

        public void Rebuild(INumberObject[,] numberObjectArray, Vector2 originalPos, Vector2 size, float NumberObjDistance, int Rows, int Cols)
        {
            Vector2 pos = moveNumberObj.GetCurrentPos();
            ReSet();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    float x = originalPos.x + j * (size.x + NumberObjDistance);
                    float y = originalPos.y + i * (size.y + NumberObjDistance);

                    Vector2 v = new Vector2(x, y);
                    if (Vector2.Distance(pos, v) < 0.1f)
                    {
                        numberObjectArray[i, j] = moveNumberObj;
                    }
                }
            }

            if (next != null)
            {
                next.Rebuild(numberObjectArray, originalPos, size, NumberObjDistance, Rows, Cols);
            }

        }
    }

    public class zcyGameCore : IGameCore
    {
        private const float NumberObjDistance = 0.2f;
        private const int Rows = 4;
        private const int Cols = 4;
        private const float NumberW = 1f;
        private const float NumberH = 1f;
        private float x_left_bottom;
        private float y_left_bottom;
        private Vector3 CenterPos = new Vector3(0, 0, 0);
        private INumberObject[,] numberObjectArray = new INumberObject[Rows,Cols];
        private List<NumberMoveObject> moveObjList = new List<NumberMoveObject>();
        private InputProtocol moveType;

        enum GameState{
            GameStart,
            GenerateRandomNumber,
            WaitingPlayerInput,
            MovingBegin,
            Moving,
            MovingEnd,
        }

        

        private GameState currentGameState = GameState.GameStart;

        public void ModuleInit()
        {
            x_left_bottom = CenterPos.x - (Cols / 2 - 1) * NumberW - (Cols / 2 - 1) * NumberObjDistance - (NumberObjDistance + NumberW) / 2;
            y_left_bottom = CenterPos.y - (Rows / 2 - 1) * NumberH - (Rows / 2 - 1) * NumberObjDistance - (NumberObjDistance + NumberH) / 2;
        }

        private List<int> getEmptyNumberIndexList()
        {
            List<int> l = new List<int>();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (numberObjectArray[i, j] == null)
                    {
                        int t = i * Cols + j;
                        l.Add(t);
                    }
                   
                }
            }
            return l;
        }

        private INumberObject GenerateRandomNumber()
        {
            List<int> l = getEmptyNumberIndexList();
            if (l.Count == 0)
            {
                return null;
            }

            int r = Random.Range(0, l.Count);

            int t = l[r];
            int i = t / Rows;
            int j = t % Cols;
            Debug.Log("t=" + t + " i=" + i + " j=" + j);
            numberObjectArray[i, j] = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, 4) as INumberObject;

            int rNum = Random.Range(1, 3);
            numberObjectArray[i, j].SetNumber(rNum*2);

            float x = x_left_bottom + j * (NumberW + NumberObjDistance);
            float y = y_left_bottom + i * (NumberH + NumberObjDistance);
            numberObjectArray[i, j].SetPosition(new Vector2(x, y));

            return numberObjectArray[i, j];
        }

        public void ModuleDestroy()
        {

        }

        public void ModuleUpdate()
        {
            switch (currentGameState)
            {
                case GameState.GameStart:
                    {
                        GenerateRandomNumber();
                        GenerateRandomNumber();   
                        currentGameState = GameState.WaitingPlayerInput;
                    }
                    break;
                case GameState.GenerateRandomNumber:
                    {
                        GenerateRandomNumber();   
                        currentGameState = GameState.WaitingPlayerInput;
                    }
                    break;
                case GameState.WaitingPlayerInput:
                    {
                        ProcessPlayerInput();
                    }
                    break;
                case GameState.MovingBegin:
                    {
                        MovingObjectsBegin();
                    }
                    break;
                case GameState.Moving:
                    {
                        MovingObjects();
                    }
                    break;
                case GameState.MovingEnd:
                    {
                        MovingObjectsEnd();
                    }
                    break;
            }
        }

        private void ProcessPlayerInput()
        {
            if (GameFramework.singleton.getInput().GetInputData() == InputProtocol.None)
            {
                return;
            }
            currentGameState = GameState.MovingBegin;
            moveType = GameFramework.singleton.getInput().GetInputData();
        }

        private void CaculateMoveObjects(InputProtocol moveType)
        {
            int count = 0;
            if (moveType == InputProtocol.MoveRight || moveType == InputProtocol.MoveLeft)
            {
                count = Rows;
            }

            if (moveType == InputProtocol.MoveUp || moveType == InputProtocol.MoveDown)
            {
                count = Cols;
            }

            int[] startIndexs = new int[count];
            moveObjList.Clear();

            for (int c = 0; c < count; ++c)
            {
                int i = 0;
                int j = 0;
                switch (moveType)
                {
                    case InputProtocol.MoveUp:
                        { i = Rows - 1; j = c; }
                        break;
                    case InputProtocol.MoveDown:
                        { i = 0; j = c; }
                        break;
                    case InputProtocol.MoveLeft:
                        { i = c; j = 0; }
                        break;
                    case InputProtocol.MoveRight:
                        { i = c; j = Cols - 1; }
                        break;
                }

                NumberMoveObject moveObj = getMoveObject(i, j, moveType, null);
                moveObj = deleteEmptyMoveObject(moveObj);
                moveObjList.Add(moveObj);
            }
            

        }

        private NumberMoveObject getMoveObject(int i, int j, InputProtocol moveType, NumberMoveObject parent)
        {
            if (i < 0 || i >= Rows) { return null; }
            if (j < 0 || j >= Cols) { return null; }

            Vector2 endPos = new Vector2();
            switch (moveType)
            {
                case InputProtocol.MoveUp:
                    {
                        endPos.x = x_left_bottom + j * (NumberW + NumberObjDistance);
                        endPos.y = y_left_bottom + (Rows-1) * (NumberH + NumberObjDistance);
                    }
                    break;
                case InputProtocol.MoveDown:
                    {
                        endPos.x = x_left_bottom + j * (NumberW + NumberObjDistance);
                        endPos.y = y_left_bottom + 0 * (NumberH + NumberObjDistance);
                    }
                    break;
                case InputProtocol.MoveLeft:
                    {
                        endPos.x = x_left_bottom + 0 * (NumberW + NumberObjDistance);
                        endPos.y = y_left_bottom + i * (NumberH + NumberObjDistance);
                    }
                    break;
                case InputProtocol.MoveRight:
                    {
                        endPos.x = x_left_bottom + (Cols-1) * (NumberW + NumberObjDistance);
                        endPos.y = y_left_bottom + i * (NumberH + NumberObjDistance);
                    }
                    break;
            }

            NumberMoveObject moveObj = new NumberMoveObject(numberObjectArray[i, j], moveType, endPos, NumberW+NumberObjDistance);
            switch (moveType)
            {
                case InputProtocol.MoveUp:
                    { i--; }
                    break;
                case InputProtocol.MoveDown:
                    { i++; }
                    break;
                case InputProtocol.MoveLeft:
                    { j++; }
                    break;
                case InputProtocol.MoveRight:
                    { j--; }
                    break;
            }
            moveObj.next = getMoveObject(i, j, moveType, moveObj);
            moveObj.parent = parent;
            return moveObj;
        }

        private NumberMoveObject deleteEmptyMoveObject(NumberMoveObject moveObj)
        {
            NumberMoveObject tempObj = moveObj;
            NumberMoveObject beginObj = null;

            while (tempObj != null)
            {
                if (tempObj.moveNumberObj != null && beginObj==null)
                {
                    beginObj = tempObj;
                }

                if (tempObj.moveNumberObj == null)
                {
                    NumberMoveObject parent = tempObj.parent;
                    if (parent != null)
                    {
                        parent.next = tempObj.next;
                    }

                    if (tempObj.next != null)
                    {
                        tempObj.next.parent = parent;
                    }
                }
                tempObj = tempObj.next;
            }

            return beginObj;
        }

        private void MovingObjectsBegin()
        {
            CaculateMoveObjects(moveType);
            currentGameState = GameState.Moving;
        }

        private void MovingObjects()
        {
            bool moveFinished = true;
            for (int i = 0; i < moveObjList.Count; ++i)
            {
                if (moveObjList[i] != null)
                {
                    moveObjList[i].Moving();
                    moveFinished &= moveObjList[i].CheckMoveFinished();
                }
            }

            if (moveFinished == true)
            {
                currentGameState = GameState.MovingEnd;
            }
        }

        private void MovingObjectsEnd()
        {
            Clean();
            for (int i = 0; i < moveObjList.Count; ++i)
            {
                if (moveObjList[i] != null)
                {
                    moveObjList[i].Rebuild(numberObjectArray, new Vector2(x_left_bottom, y_left_bottom), new Vector2(NumberW, NumberH), NumberObjDistance, Rows, Cols);
                }
            }

            currentGameState = GameState.GenerateRandomNumber;
        }

        private void Clean()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    numberObjectArray[i, j] = null;
                }
            }
        }

        public RenderProtocol GetGameSize()
        {
            throw new System.NotImplementedException();
        }

        public INumberObject[,] GetNumbers()
        {
            throw new System.NotImplementedException();
        }
    }
}