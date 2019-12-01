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

        public Vector2 GetCurrentPos()
        {
            throw new System.NotImplementedException();
        }

        public int GetNumber()
        {
            throw new System.NotImplementedException();
        }

        public void SetColor(Color color)
        {

        }

        public void SetNumber(int number)
        {
            throw new System.NotImplementedException();
        }

        public void SetPosition(Vector3 pos)
        {
            Debug.Log(pos);
            //set position
        }

        public void SetPosition(Vector2 index)
        {
            throw new System.NotImplementedException();
        }

        public void SetText(string text)
        {
            //set text
        }

        public void SetText(int number)
        {
            throw new System.NotImplementedException();
        }
    }

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

        }
    }
}
