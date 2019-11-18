using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game2048Framework;


namespace WP
{
    public class wupGameRender : IGameRender
    {
        int gameSize;
        int width;
        int height;

        public wupGameRender(int w, int h)
        {
            this.gameSize = size;
            this.width = w;
            this.height = h;
        }




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

    public class NumberObject : INumberObject
    {
        int number;
        Vector2 index;

        private GameObject objNumber;
        private string numberPath = "";

        public NumberObject()
        {
            GameObject obj = Resources.Load(numberPath) as GameObject;
            objNumber = GameObject.Instantiate(obj);
        }

        public Vector2 GetCurrentPos()
        {
            return this.index;
        }

        public int GetNumber()
        {
            return this.number;
        }

        public void SetColor(Color color)
        {
            Image img = objNumber.GetComponent<Image>();
            if (img)
            {
                img.color = color;
            }
        }

        public void SetNumber(int number)
        {
            if (objNumber)
            {
                this.number = number;
            }
        }

        public void SetPosition(Vector2 pos)
        {
            if (objNumber)
            {
                this.index = pos;
                
            }
        }

    }
}
