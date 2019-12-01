using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;


namespace BBHW14 {


    public class bbGameRender : IGameRender
    {
        //private bbNumberObject[,] numberObjects;

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
                        result = new bbNumberObject();
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
