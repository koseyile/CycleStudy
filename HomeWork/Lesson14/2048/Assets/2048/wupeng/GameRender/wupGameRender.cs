﻿using System.Collections;
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

        public int GetNumber()
        {
            throw new System.NotImplementedException();
        }

        public NumberIndex GetPos()
        {
            throw new System.NotImplementedException();
        }

        public void Move(NumberIndex des)
        {
            throw new System.NotImplementedException();
        }

        public void SetColor(Color _color)
        {
            //设置数字颜色
            objNumber.GetComponent<Image>().color = _color;
        }

        public void SetNumber(int number)
        {
            throw new System.NotImplementedException();
        }

        public void SetPosition(Vector2 _pos)
        {
            //设置数字位置
            objNumber.transform.position = _pos;
        }

        public void SetPosition(NumberIndex pos)
        {
            throw new System.NotImplementedException();
        }

        public void SetText(int number)
        {
            //设置数字
            string text = number.ToString();

            //To Do...
        }
    }
}
