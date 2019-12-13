using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace ZCY
{
    public class zcyGameCore : IGameCore
    {
        public void ModuleInit()
        {
            INumberObject iNumberObj = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, 4) as INumberObject;
            iNumberObj.SetPosition(new Vector3(0, 0, 0));
            iNumberObj.SetNumber(2048);
        }
        public void ModuleDestroy()
        {

        }


        public void ModuleUpdate()
        {

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