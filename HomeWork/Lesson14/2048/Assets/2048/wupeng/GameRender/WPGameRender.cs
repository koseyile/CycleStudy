using UnityEngine;
using System.Collections;
using Game2048Framework;
using UnityEngine.UI;
using System.Collections.Generic;

namespace WP
{
    public class WPGameRender : MonoBehaviour, IGameRender
    {
        string path_canvas = "canvas";
        GameObject canvasOb;

        public WPGameRender()
        {
            //创建游戏背景
            GameObject canv = Resources.Load("canvas") as GameObject;
            canvasOb = Instantiate(canv);
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
                    renderObject = new Number(gameSize, Screen.width, Screen.height, canvasOb);
                    break;
            }

            return renderObject;
        }

        public void DestroyObject(IRenderBase iRenderBase)
        {
            Number go = (Number)iRenderBase;
            Destroy(go.objNumber);
        }

        public void ModuleDestroy()
        {
        }

        public void ModuleInit()
        {

        }

        //每一帧从数据层获取数据，并更新渲染层
        public void ModuleUpdate()
        {

        }
    }

    public class Number : INumberObject
    {
        public GameObject objNumber;
        int number;
        Vector2 position;
        Vector2 index;
        Vector2 lastIndex;
        int gameSize;
        int width_Screen;
        int height_Screen;
        private string numberPath = "number";

        public Number(int gamesize, int wScreen, int hScreen, GameObject canvasOb)
        {
            this.gameSize = gamesize;
            this.width_Screen = wScreen;
            this.height_Screen = hScreen;

            GameObject obj = Resources.Load(numberPath) as GameObject;

            int length = Mathf.Min(width_Screen, height_Screen);
            int len_num = length / gamesize - (length / gamesize / 10);

            RectTransform recttrans = obj.GetComponent<RectTransform>();
            if (recttrans)
            {
                float s = len_num / recttrans.rect.width;
                obj.transform.localScale = new Vector3(s, s, s);
            }
            else
            {
                Debug.Log("数字没有Rect");
            }
            
            objNumber = GameObject.Instantiate(obj);
            objNumber.transform.SetParent(canvasOb.transform);
        }

        public Vector2 GetCurrentPos()
        {
            return this.position;
        }

        public Vector2 GetIndex()
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

        public void SetIndex(Vector2 index)
        {
            this.index = index;
        }

        public void SetNumber(int number)
        {
            if (objNumber)
            {
                this.number = number;

                if (this.objNumber.GetComponentInChildren<Text>())
                {
                    if (number == 0)
                        return;
                    else
                        this.objNumber.GetComponentInChildren<Text>().text = number.ToString();
                }
                else
                {
                    Debug.Log("设置数字错误：未找到Text组件");
                }

            }
        }

        
        public void SetPosition(Vector2 _pos)
        {
            if (objNumber)
            {
                this.position = _pos;//索引

                int interval = Mathf.Min(width_Screen, height_Screen) / gameSize;

                Vector3 pos = new Vector3(interval / 2 + _pos.y * interval, interval / 2 + _pos.x * interval, 0);

                pos += width_Screen > height_Screen ? new Vector3((width_Screen - height_Screen) / 2, 0, 0)
                    : new Vector3(0, (height_Screen - width_Screen) / 2 , 0);

                this.objNumber.transform.position = pos;

            }
        }

        public void SetLastIndex(Vector2 index)
        {
            this.lastIndex = index;
        }

        public Vector2 GetLastIndex()
        {
            return this.lastIndex;
        }
        
    }

}

