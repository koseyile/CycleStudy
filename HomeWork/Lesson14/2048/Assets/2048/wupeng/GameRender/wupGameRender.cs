using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;


namespace WP
{
    public class NumberObject : INumberObject
    {
        public void SetColor(Color color)
        {
        }

        public void SetPosition(Vector3 pos)
        {
        }

        public void SetText(string text)
        {
        }
    }

    public class CheckBoardObject : ICheckBoardObject
    {
        public void SetColor(Color color)
        {
        }

        public void SetPos(Vector3 pos)
        {
        }

        public void SetScale(Vector3 scale)
        {
        }

        public void SetSprite(Sprite sprite)
        {
        }
    }

    public class UIObject : IUIObject
    {
        public void SetPos(Vector3 pos)
        {
        }

        public void SetSprite(Sprite sprite)
        {
        }

        public void SetText(string text)
        {
        }
    }


    public class wupGameRender : IGameRender
    {
        public wupGameRender() { }

        public IRenderBase CreateObject(RenderProtocol renderProtocol)
        {
            IRenderBase renderObject = null;

            switch (renderProtocol)
            {
                case RenderProtocol.None:
                    renderObject = null;
                    break;
                case RenderProtocol.CreateNumberObject:
                    renderObject = new NumberObject();
                    break;
                case RenderProtocol.CreateCheckBoardObject:
                    renderObject = new CheckBoardObject();
                    break;
                case RenderProtocol.CreateUIObject:
                    renderObject = new UIObject();
                    break;
            }

            return renderObject;
        }

        public void DestroyObject(IRenderBase iRenderBase)
        {
        }

        public void ModuleDestroy()
        {
        }

        public void ModuleInit()
        {
        }

        public void ModuleUpdate()
        {
        }
    }
}
