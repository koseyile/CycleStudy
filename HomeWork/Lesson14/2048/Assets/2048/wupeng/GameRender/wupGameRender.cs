using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game2048Framework;


namespace WP
{
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

    public class NumberObject : INumberObject
    {
        private GameObject objNumber;
        private string numberPath = "";

        public NumberObject()
        {
            GameObject obj = Resources.Load(numberPath) as GameObject;
            objNumber = GameObject.Instantiate(obj);
        }

        public void SetColor(Color _color)
        {
            //设置数字颜色
            objNumber.GetComponent<Image>().color = _color;
        }

        public void SetPosition(Vector2 _pos)
        {
            //设置数字位置
            objNumber.transform.position = _pos;
        }

        public void SetText(int number)
        {
            //设置数字
            string text = number.ToString();

            //To Do...
        }
    }

    public class BackImgObject : IBackImgObject
    {
        private GameObject obj;

        private string path_prefab;

        public BackImgObject()
        {

        }
        
        public void SetHighScore()
        {

        }

        public void SetScore()
        {

        }
    }

    public class CheckBoardObject : ICheckBoardObject
    {
        private GameObject objCheckBoard;
        private string checkBoardPath = "";

        public CheckBoardObject()
        {
            GameObject obj = Resources.Load(checkBoardPath) as GameObject;
            objCheckBoard = GameObject.Instantiate(obj);
        }

        public void SetColor(Color color)
        {
            //设置棋盘颜色
            //To Do...
        }

        public void SetPos(Vector2 pos)
        {
            //设置棋盘位置
            //To Do...

        }

        public void SetScale(Vector2 scale)
        {
            //设置棋盘缩放
            //To Do...

        }

    }

    public class Button : IButtonObject
    {
        private GameObject obj;
        private string path;

        public void SetPos(Vector2 pos)
        {
        }

        public void SetSprite(Sprite sprite)
        {
        }

        public void SetText(string text)
        {

        }

        public void SetColor(Color color)
        {

        }
    }

}
