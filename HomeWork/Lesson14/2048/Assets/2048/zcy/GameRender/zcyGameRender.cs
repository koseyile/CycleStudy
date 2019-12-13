using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;
using TMPro;

namespace ZCY
{
    public class zcyGameRender : IGameRender
    {
        public void ModuleInit()
        {

        }
        public void ModuleDestroy()
        {

        }
        public void ModuleUpdate()
        {

        }

        public IRenderBase CreateObject(RenderProtocol renderProtocol, int gameSize)
        {
            IRenderBase result = null;

            switch (renderProtocol)
            {
                case RenderProtocol.CreateNumberObject:
                {
                    result = new zcyNumberObject();
                }
                break;
            }

            return result;
        }

        public void DestroyObject(IRenderBase iRenderBase)
        {
            zcyNumberObject zcyObj = iRenderBase as zcyNumberObject;
            GameObject.Destroy(zcyObj.numberGameObject);
        }
    }
}
