using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace ZCY
{

    public class zcyNumberObject : INumberObject
    {
        private GameObject numberGameObject;

        public zcyNumberObject()
        {
            //create numberGameObject
        }

        public void setPosition(Vector3 pos)
        {
            Debug.Log(pos);
            //set position
        }

        public void setText(string text)
        {
            //set text
        }
    }

    public class zcyGameRender : IGameRender
    {
        public void ModuleInit()
        {}
        public void ModuleDestroy()
        {}
        public void ModuleUpdate()
        {}

        public IRenderBase CreateObject(RenderProtocol renderProtocol)
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
        {}
    }
}
