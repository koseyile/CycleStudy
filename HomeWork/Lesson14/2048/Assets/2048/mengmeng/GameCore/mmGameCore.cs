using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;
using System;

namespace mm
{
    public class mmGameCore : IGameCore
    {
        private IGameInput gameInput;
        private IGameRender gameRender;

        private List<INumberObject> numberObjList = new List<INumberObject>();
        private NumberData[,] numberTable = new NumberData[4, 4];


        static float IndexToPos = 25f;         //元素位置和屏幕坐标的转换，左下角是0,0 右上角是3,3
        bool bGetInput = true;                  //数字移动时锁定输入
        static float MoveTime = 0.5f;           //移动时间为0.5秒
        float CurrentTime = 0;

        public void ModuleInit()
        {
            gameInput = GameFramework.singleton.getInput();
            gameRender = GameFramework.singleton.getGameRender();

            InitGame();
        }

        public void ModuleUpdate()
        {
            if (bGetInput)
            {
                switch (gameInput.GetInputData())
                {
                    case InputProtocol.MoveUp:
                        bGetInput = false;
                        MoveUp();
                        break;
                    case InputProtocol.MoveDown:
                        bGetInput = false;
                        MoveDown();
                        break;
                    case InputProtocol.MoveLeft:
                        bGetInput = false;
                        MoveLeft();
                        break;
                    case InputProtocol.MoveRight:
                        bGetInput = false;
                        MoveRight();
                        break;
                }
            }
            else
            {
                MoveAllNum();
            }

        }

        public void ModuleDestroy() { }

        void InitGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Vector2 index = new Vector2(i, j);
                    INumberObject numberObject = (INumberObject)gameRender.CreateObject(RenderProtocol.CreateNumberObject, 0);
                    numberObject.SetNumber(2);
                    numberObject.SetIndex(index);
                    numberObject.SetPosition(index * IndexToPos);
                    numberObjList.Add(numberObject);

                    numberTable[i, j] = new NumberData
                    {
                        Index = new Vector2(i, j),
                        TargetIndex = new Vector2(i, j),
                        Number = 2
                    };
                }
            }

            for (int i = 0; i < 4; i++)
            {
                SetNewNumber(2);
            }
        }

        void SetNewNumber(int num)
        {
            List<NumberData> TempList = new List<NumberData>();
            foreach (NumberData numberData in numberTable)
            {
                if (numberData.Number == 0)
                {
                    TempList.Add(numberData);
                }
            }
            if (TempList.Count == 0)
                return;
            int RandNum = UnityEngine.Random.Range(0, TempList.Count);
            TempList[RandNum].Number = num;


            INumberObject numberObject = GetNumberObject(TempList[RandNum].Index);
            numberObject.SetNumber(num);
        }

        INumberObject GetNumberObject(Vector2 index)
        {
            foreach (INumberObject numberObject in numberObjList)
            {
                if (numberObject.GetIndex() == index)
                {
                    return numberObject;
                }
            }
            return null;
        }
        void MoveUp()
        {
            for (int y = 2; y >= 0; y--)
            {
                for (int x = 3; x >= 0; x--)
                {
                    if (numberTable[x, y].Number == 0)
                        continue;
                    int MoveCount = 0;
                    for (int i = y + 1; i <= 3; i++)
                    {
                        if (numberTable[x, i].Number != 0 && (numberTable[x, i].Number != numberTable[x, y].Number || numberTable[x, i].bMerged))
                        {
                            break;
                        }
                        MoveCount++;
                    }
                    if (MoveCount > 0)
                    {
                        if (numberTable[x, y + MoveCount].Number != 0)
                        {
                            numberTable[x, y + MoveCount].bMerged = true;
                        }

                        numberTable[x, y + MoveCount].Number += numberTable[x, y].Number;
                        numberTable[x, y].Number = 0;
                        numberTable[x, y].TargetIndex.y += MoveCount;
                    }
                }
            }
        }
        void MoveDown()
        {
            for (int y = 1; y <= 3; y++)
            {
                for (int x = 3; x >= 0; x--)
                {
                    if (numberTable[x, y].Number == 0)
                        continue;
                    int MoveCount = 0;
                    for (int i = y - 1; i >= 0; i--)
                    {
                        if (numberTable[x, i].Number != 0 && (numberTable[x, i].Number != numberTable[x, y].Number || numberTable[x, i].bMerged))
                        {
                            break;
                        }
                        MoveCount++;
                    }
                    if (MoveCount > 0)
                    {
                        if (numberTable[x, y - MoveCount].Number != 0)
                        {
                            numberTable[x, y - MoveCount].bMerged = true;
                        }
                        numberTable[x, y - MoveCount].Number += numberTable[x, y].Number;
                        numberTable[x, y].Number = 0;
                        numberTable[x, y].TargetIndex.y -= MoveCount;
                    }
                }
            }
        }
        void MoveLeft()
        {
            for (int x = 1; x <= 3; x++)
            {
                for (int y = 3; y >= 0; y--)
                {
                    if (numberTable[x, y].Number == 0)
                        continue;
                    int MoveCount = 0;
                    for (int i = x - 1; i >= 0; i--)
                    {
                        if (numberTable[i, y].Number != 0 && (numberTable[i, y].Number != numberTable[x, y].Number || numberTable[i, y].bMerged))
                        {
                            break;
                        }
                        MoveCount++;
                    }
                    if (MoveCount > 0)
                    {
                        if (numberTable[x - MoveCount, y].Number != 0)
                        {
                            numberTable[x - MoveCount, y].bMerged = true;
                        }
                        numberTable[x - MoveCount, y].Number += numberTable[x, y].Number;
                        numberTable[x, y].Number = 0;
                        numberTable[x, y].TargetIndex.x -= MoveCount;
                    }
                }
            }
        }
        void MoveRight()
        {
            for (int x = 2; x >= 0; x--)
            {
                for (int y = 3; y >= 0; y--)
                {
                    if (numberTable[x, y].Number == 0)
                        continue;
                    int MoveCount = 0;
                    for (int i = x + 1; i <= 3; i++)
                    {
                        if (numberTable[i, y].Number != 0 && (numberTable[i, y].Number != numberTable[x, y].Number || numberTable[i, y].bMerged))
                        {
                            break;
                        }
                        MoveCount++;
                    }
                    if (MoveCount > 0)
                    {
                        if(numberTable[x + MoveCount, y].Number!=0)
                        {
                            numberTable[x + MoveCount, y].bMerged = true;
                        }
                        numberTable[x + MoveCount, y].Number += numberTable[x, y].Number;
                        numberTable[x, y].Number = 0;
                        numberTable[x, y].TargetIndex.x += MoveCount;
                    }
                }
            }
        }

        void MoveAllNum()
        {
            //通过targetIndexList来规划运动轨迹
            CurrentTime += Time.deltaTime;
            if (CurrentTime < MoveTime)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (numberTable[x, y].TargetIndex != numberTable[x, y].Index)
                        {
                            Vector2 TargetPos = numberTable[x, y].TargetIndex * IndexToPos;
                            Vector2 StartPos = numberTable[x, y].Index * IndexToPos;

                            INumberObject numberObject = GetNumberObject(numberTable[x, y].Index);
                            numberObject.SetPosition(Vector2.MoveTowards(numberObject.GetCurrentPos(), TargetPos, Vector2.Distance(TargetPos, StartPos) / (MoveTime / Time.deltaTime)));
                        }
                    }
                }
            }
            else
            {
                //foreach (INumberObject numberObject in numberObjList)
                //{
                //    Vector2 index = numberObject.GetIndex();
                //    Vector2 targetindex = numberTable[(int)index.x, (int)index.y].TargetIndex;
                //    if (index != targetindex)
                //    {
                //        numberTable[(int)targetindex.x, (int)targetindex.y].Number += numberObject.GetNumber();
                //        numberTable[(int)index.x, (int)index.y].Number = 0;
                //    }
                //}

                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        numberTable[x, y].Index = new Vector2(x, y);
                        numberTable[x, y].TargetIndex = new Vector2(x, y);
                        numberTable[x, y].bMerged = false;
                    }
                }
                foreach (INumberObject numberObject in numberObjList)
                {
                    Vector2 index = numberObject.GetIndex();
                    numberObject.SetPosition(index * IndexToPos);
                    numberObject.SetNumber(numberTable[(int)index.x, (int)index.y].Number);
                }
                bGetInput = true;
                CurrentTime = 0;
                for (int i = 0; i < 2; i++)
                {
                    SetNewNumber(2);
                }
                DebugLog();
            }


        }

        void DebugLog()
        {
            string LogString = string.Empty;
            for (int y = 3; y >= 0; y--)
            {
                for (int x = 0; x < 4; x++)
                {
                    //Debug.Log(x.ToString() + " " + y.ToString());
                    LogString = string.Concat(LogString, numberTable[x, y].Number.ToString() + " ");
                }
                LogString = string.Concat(LogString, "\n");
            }
            Debug.Log(LogString);
        }
    }

    public class NumberData
    {
        public int Number;
        public Vector2 Index = new Vector2();
        public Vector2 TargetIndex = new Vector2();
        public bool bMerged = false;

        public NumberData()
        {

        }
    }
}
