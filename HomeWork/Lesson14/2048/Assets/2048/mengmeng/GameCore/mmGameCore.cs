using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace mm
{
    public class mmGameCore : MonoBehaviour, IGameCore
    {
        private IGameInput gameInput;
        private IGameRender gameRender;

        private List<INumberObject> numberObjectsList;

        public void ModuleInit()
        {
            gameInput = GameFramework.singleton.getInput();
            gameRender = GameFramework.singleton.getGameRender();

            InitGameBoard();
        }

        public void ModuleUpdate()
        {
            switch(gameInput.GetInputData())
            {
                case InputProtocol.MoveUp:
                    MoveUp();
                    break;
                case InputProtocol.MoveDown:
                    MoveDown();
                    break;
                case InputProtocol.MoveLeft:
                    MoveLeft();
                    break;
                case InputProtocol.MoveRight:
                    MoveRight();
                    break;
            }
        }

        public void ModuleDestroy() { }

        private INumberObject CreateNumber(int Num, Vector2 pos)
        {

            INumberObject numberObject = gameRender.CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
            numberObject.SetPosition(pos);
            numberObject.SetNumber(Num);
            numberObject.SetColor(Color.black);
            numberObjectsList.Add(numberObject);
            return numberObject;
        }

        private void MoveNumber(INumberObject numberObject, Vector2 pos)
        {
            if (!numberObject.GetCurrentPos().Equals(pos))
            {
                float MoveTime = 0.5f;
                float MoveDelta = Vector2.Distance(numberObject.GetCurrentPos(), pos) * Time.deltaTime / MoveTime;
                StartCoroutine(MoveObj(numberObject, pos, MoveDelta));
            }
        }
        IEnumerator MoveObj(INumberObject numberObject, Vector2 pos, float MoveDelta)
        {
            if (!numberObject.GetCurrentPos().Equals(pos))
            {
                Vector2 CurrentPos = numberObject.GetCurrentPos();
                Vector2.MoveTowards(numberObject.GetCurrentPos(), pos, MoveDelta);
                yield return 0;
            }
            if(GetNumber(pos) == numberObject.GetNumber())
            {
                MergeNumber(numberObject, GetNumberObject(pos));
            }
        }
        private void DestoryNumber(INumberObject numberObject)
        {
            numberObjectsList.Remove(numberObject);
            GameFramework.singleton.getGameRender().DestroyObject(numberObject);
        }
        private void MergeNumber(INumberObject numberObjectA, INumberObject numberObjectB)
        {
            numberObjectB.SetNumber(numberObjectB.GetNumber() + numberObjectA.GetNumber());
            DestoryNumber(numberObjectA);
        }

        int GetNumber(Vector2 pos)
        {
            foreach (INumberObject Num in numberObjectsList)
            {
                if (Num.GetCurrentPos().Equals(pos))
                {
                    return Num.GetNumber();
                }
            }
            return 0;
        }


        int GetNumber(int x, int y)
        {
            foreach (INumberObject Num in numberObjectsList)
            {
                if (Num.GetCurrentPos().x == x && Num.GetCurrentPos().y == y)
                {
                    return Num.GetNumber();
                }
            }
            return 0;
        }
        INumberObject GetNumberObject(int x, int y)
        {
            foreach (INumberObject numberObject in numberObjectsList)
            {
                if (numberObject.GetCurrentPos().Equals(new Vector2(x, y)))
                {
                    return numberObject;
                }
            }
            return null;
        }
        INumberObject GetNumberObject(Vector2 pos)
        {
            foreach (INumberObject numberObject in numberObjectsList)
            {
                if (numberObject.GetCurrentPos().Equals(pos))
                {
                    return numberObject;
                }
            }
            return null;
        }
        void InitGameBoard()
        {
            while (numberObjectsList.Count < 2)
            {
                Vector2 Pos = new Vector2(Random.Range(0, 4), Random.Range(0, 4));
                if (GetNumber(Pos) == 0)
                {
                    CreateNumber(2, Pos);
                }
            }
        }

        void MoveUp()
        {
            for (int MoveCount = 0; MoveCount < 3; MoveCount++) //移动3次
            {
                for (int j = 0; j < numberObjectsList.Count; j++)
                {
                    INumberObject numberObject = numberObjectsList[j];
                    int x = (int)numberObject.GetCurrentPos().x;
                    int y = (int)numberObject.GetCurrentPos().y;
                    int y_max = 4;

                    for (int i = y + 1; i < y_max; i++)     //每次每个数字往上移动一格，如果遇到相同的，就合并
                    {
                        if (GetNumberObject(x, i) == null|| GetNumber(x, i) == numberObject.GetNumber())
                        {
                            MoveNumber(numberObject, new Vector2(x, i));
                        }
                    }
                }
            }
        }
        void MoveDown()
        {
            for (int MoveCount = 0; MoveCount < 3; MoveCount++) //移动3次
            {
                for (int j = 0; j < numberObjectsList.Count; j++)
                {
                    INumberObject numberObject = numberObjectsList[j];
                    int x = (int)numberObject.GetCurrentPos().x;
                    int y = (int)numberObject.GetCurrentPos().y;
                    int y_min = 0;

                    for (int i = y - 1; i >= y_min; i--)     //每次每个数字往下移动一格，如果遇到相同的，就合并
                    {
                        if (GetNumberObject(x, i) == null|| GetNumber(x, i) == numberObject.GetNumber())
                        {
                            MoveNumber(numberObject, new Vector2(x, i));
                        }
                    }
                }
            }
        }
        void MoveLeft()
        {
            for (int MoveCount = 0; MoveCount < 3; MoveCount++) //移动3次
            {
                for (int j = 0; j < numberObjectsList.Count; j++)
                {
                    INumberObject numberObject = numberObjectsList[j];
                    int x = (int)numberObject.GetCurrentPos().x;
                    int y = (int)numberObject.GetCurrentPos().y;
                    int x_min = 0;

                    for (int i = x - 1; i >= x_min; i--)     //每次每个数字往左移动一格，如果遇到相同的，就合并
                    {
                        if (GetNumberObject(i, y) == null|| GetNumber(i, y) == numberObject.GetNumber())
                        {
                            MoveNumber(numberObject, new Vector2(i, y));
                        }
                    }
                }
            }
        }
        void MoveRight()
        {
            for (int MoveCount = 0; MoveCount < 3; MoveCount++) //移动3次
            {
                for (int j = 0; j < numberObjectsList.Count; j++)
                {
                    INumberObject numberObject = numberObjectsList[j];
                    int x = (int)numberObject.GetCurrentPos().x;
                    int y = (int)numberObject.GetCurrentPos().y;
                    int x_max = 4;

                    for (int i = y + 1; i < x_max; i++)     //每次每个数字往右移动一格，如果遇到相同的，就合并
                    {
                        if (GetNumberObject(i, y) == null|| GetNumber(i, y) == numberObject.GetNumber())
                        {
                            MoveNumber(numberObject, new Vector2(i, y));
                        }
                    }
                }
            }
        }
    }

}
