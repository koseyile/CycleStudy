using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game2048Framework;


namespace WP
{
    public class wupGameRender : MonoBehaviour, IGameRender
    {
        
        int gameSize;
        int width;
        int height;

        string path_canvas = "canvas";
        GameObject canvasOb;
        
        public wupGameRender(int w, int h)
        {
            gameSize = 4;
            this.width = w;
            this.height = h;

            GameObject canv = Resources.Load("canvas") as GameObject;
            canvasOb = GameObject.Instantiate(canv);
        }

        public IRenderBase CreateObject(RenderProtocol renderProtocol, int gameSize)
        {
            IRenderBase renderObject = null;

            switch (renderProtocol)
            {
                case RenderProtocol.None:
                    renderObject = null;
                    break;
                case RenderProtocol.CreateNumberObject:
                    renderObject = new NumberObject(gameSize, width, height, canvasOb);
                    break;
            }

            return renderObject;
        }

        public void DestroyObject(IRenderBase iRenderBase)
        {
            Destroy(iRenderBase as Object);
        }

        public void ModuleDestroy()
        {
        }

        public void ModuleInit()
        {
            //switch (GameFramework.singleton.getGameCore().GetGameSize())
            //{
            //    case RenderProtocol.X44:
            //        gameSize = 4;
            //        break;
            //    case RenderProtocol.X66:
            //        gameSize = 6;
            //        break;
            //    default:
            //        gameSize = 4;
            //        break;
            //}
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
        private string numberPath = "number";

        public NumberObject(int size, int width, int height, GameObject canvasOb)
        {
            this.size = size;
            this.width = width;
            this.height = height;

            GameObject obj = Resources.Load(numberPath) as GameObject;

            Text t = obj.GetComponentInChildren<Text>();
            Image img = obj.GetComponentInChildren<Image>();

            if (t && img)
            {
                float w = obj.GetComponent<RectTransform>().rect.size.x;
                w = width / (w * size);

                float s = obj.transform.localScale.x * w;

                obj.transform.localScale.Scale(new Vector3(4, 2, 2));
            }

            objNumber = GameObject.Instantiate(obj);
            objNumber.transform.SetParent(canvasOb.transform);
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

                if (this.objNumber.GetComponentInChildren<Text>())
                {
                    this.objNumber.GetComponentInChildren<Text>().text = number.ToString();
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

                this.objNumber.transform.position = new Vector3(w / 2 + index.x * w, h / 2 + index.y * h, 0);
            }

        }
        public void SetIndex(Vector2 index) { }
        public Vector2 GetIndex() { return new Vector2(); }
    }
}
