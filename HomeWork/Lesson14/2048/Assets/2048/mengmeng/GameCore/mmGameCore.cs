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
        private static float MoveSpeed = 3f;

        public void ModuleInit()
        {
            gameInput = GameFramework.singleton.getInput();
            gameRender = GameFramework.singleton.getGameRender();

            //   gameRender.CreateObject(RenderProtocol.CreateBackImgObject);
            checkBoardObject = gameRender.CreateObject(RenderProtocol.CreateCheckBoardObject) as ICheckBoardObject;

        }

        public void ModuleUpdate()
        {

        }

        public void ModuleDestroy() { }

        private INumberObject CreateNumber(int Num, Vector2 pos)
        {
            INumberObject numberObject = gameRender.CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
            numberObject.SetPosition(pos);
            numberObject.SetText(Num);
            numberObject.SetColor(Color.black);
            return numberObject;
        }
        private void MoveNumber(INumberObject numberObject, Vector2 pos)
        {
            if (numberObject.GetPosition() != pos)
            {
                numberObject.SetPosition(Vector2.MoveTowards(numberObject.GetPosition(), pos, MoveSpeed));
            }
        }
        private void DestoryNumber(INumberObject numberObject)
        {
            GameFramework.singleton.getGameRender().DestroyObject(numberObject);
        }
        private void MergeNumber(INumberObject numberObjectA, INumberObject numberObjectB)
        {
            numberObjectB.SetText(numberObjectB.GetNumber() + numberObjectA.GetNumber());
            DestoryNumber(numberObjectA);
        }
    }

}
