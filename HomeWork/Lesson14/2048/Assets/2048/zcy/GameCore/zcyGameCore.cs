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
            INumberObject iNumberObj = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
            iNumberObj.SetPosition(new Vector3(100, 0, 0));
        }
        public void ModuleDestroy()
        {}
        public void ModuleUpdate()
        {}

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