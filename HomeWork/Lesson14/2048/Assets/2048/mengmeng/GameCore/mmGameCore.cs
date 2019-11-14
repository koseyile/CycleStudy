using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace mm
{
    public class mmGameCore : IGameCore
    {
        private IGameInput gameInput;
        private IGameRender gameRender;
        private ICheckBoardObject checkBoardObject;
        private List<INumberObject> numberObjectsList;

        public void ModuleInit()
        {
            gameInput = GameFramework.singleton.getInput();
            gameRender = GameFramework.singleton.getGameRender();

            //   gameRender.CreateObject(RenderProtocol.CreateBackImgObject);
            checkBoardObject = gameRender.CreateObject(RenderProtocol.CreateCheckBoardObject) as ICheckBoardObject;

            InitGameBoard();
        }

        public void ModuleUpdate()
        {

        }

        public void ModuleDestroy() { }

        private INumberObject CreateNumber(int Num, NumberIndex pos)
        {

            INumberObject numberObject = gameRender.CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
            numberObject.SetNumberIndex(pos);
            numberObject.SetText(Num);
            numberObject.SetColor(Color.black);
            numberObjectsList.Add(numberObject);
            return numberObject;
        }
        private void MoveNumber(INumberObject numberObject, NumberIndex pos)
        {
            if (!numberObject.GetNumberIndex().Equals(pos))
            {
                numberObject.MoveToIndex(pos);
            }
        }
        private void DestoryNumber(INumberObject numberObject)
        {
            numberObjectsList.Remove(numberObject);
            GameFramework.singleton.getGameRender().DestroyObject(numberObject);
        }
        private void MergeNumber(INumberObject numberObjectA, INumberObject numberObjectB)
        {
            numberObjectB.SetText(numberObjectB.GetNumber() + numberObjectA.GetNumber());
            DestoryNumber(numberObjectA);
        }

        int GetNumber(NumberIndex pos)
        {
            foreach (INumberObject Num in numberObjectsList)
            {
                if (Num.GetNumberIndex().Equals(pos))
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
                if (Num.GetNumberIndex().x == x && Num.GetNumberIndex().y == y)
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
                if (numberObject.GetNumberIndex().Equals(new NumberIndex(x, y)))
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
                NumberIndex Pos = new NumberIndex(Random.Range(0, 4), Random.Range(0, 4));
                if (GetNumber(Pos) == 0)
                {
                    CreateNumber(2, Pos);
                }
            }
        }
        void MoveUp()
        {
            for (int j = 0; j < numberObjectsList.Count; j++)
            {
                INumberObject numberObject = numberObjectsList[j];
                int x = numberObject.GetNumberIndex().x;
                int y = numberObject.GetNumberIndex().y;
                int y_max = 4;
                for (int i = y + 1; i > y_max; i++)
                {
                    if (GetNumberObject(x, i) == null)
                    {
                        MoveNumber(numberObject, new NumberIndex(x, i));
                    }
                    else if (GetNumber(x, i) == numberObject.GetNumber())
                    {
                        MergeNumber(numberObject, GetNumberObject(x, i));
                        break;
                    }
                }
            }
        }
    }

}
