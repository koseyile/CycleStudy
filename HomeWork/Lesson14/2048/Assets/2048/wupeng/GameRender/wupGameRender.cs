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
            switch (GameFramework.singleton.getGameCore().GetGameSize())
            {
                case RenderProtocol.X44:
                    gameSize = 4;
                    break;
                case RenderProtocol.X66:
                    gameSize = 6;
                    break;
                default:
                    gameSize = 4;
                    break;
            }
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
                    renderObject = new NumberObject(gameSize, width, height);
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
        private int width;
        private int height;
        private int size;

        int number;
        Vector2 index;

        private GameObject objNumber;
        private string numberPath = "";

        public NumberObject(int size, int width, int height)
        {
            this.size = size;
            this.width = width;
            this.height = width;

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

                if (this.objNumber.GetComponent<Text>())
                {
                    this.objNumber.GetComponent<Text>().text = number.ToString();
                }
                else
                {
                    Debug.Log("设置数字错误：未找到Text组件");
                }
                
            }
        }

        public void SetPosition(Vector2 index)
        {
            if (objNumber)
            {
                this.index = index;//索引

                //计算对象具体位置
                int w = this.width / size;
                int h = this.height / size;

                this.objNumber.transform.position = new Vector3(w / 2 + index.x, h / 2 + index.y, 0);

            }
        }

    }
}
