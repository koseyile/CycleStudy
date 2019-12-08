using UnityEngine;
using UnityEditor;
using Game2048Framework;
using UnityEngine.UI;
using System.IO;

namespace mm
{
    public class mmGameRender : IGameRender
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
                        result = new mmNumberObject();
                    }
                    break;
            }

            return result;
        }

        public void DestroyObject(IRenderBase iRenderBase)
        {

        }
    }

    public class mmNumberObject : INumberObject
    {
        GameObject NumberObject;
        int Num;
        Vector2 Index;
        public mmNumberObject()
        {
            NumberObject = (GameObject)GameObject.Instantiate(Resources.Load("number_mm"));
        }
        public mmNumberObject(int number, Vector2 index)
        {
            NumberObject = (GameObject)GameObject.Instantiate(Resources.Load("number_mm"));
            NumberObject.GetComponentInChildren<TextMesh>().text = number.ToString();
            Index = index;
            Num = number;
        }
        public void SetPosition(Vector2 pos)
        {
            NumberObject.transform.position = pos;
        }
        public Vector2 GetCurrentPos()
        {
            return new Vector2(NumberObject.transform.position.x, NumberObject.transform.position.y);
        }
        public void SetIndex(Vector2 index)
        {
            Index = index;
        }
        public Vector2 GetIndex()
        {
            return Index;
        }
        public void SetNumber(int number)
        {
            Num = number;
            if (number == 0)
            {
                NumberObject.GetComponentInChildren<TextMesh>().text = "";
            }
            else
            {
                NumberObject.GetComponentInChildren<TextMesh>().text = number.ToString();
            }
            if(Num>100)
            {
                NumberObject.GetComponentInChildren<TextMesh>().fontSize = 120;
            }
            else if(Num>1000)
            {
                NumberObject.GetComponentInChildren<TextMesh>().fontSize = 80;

            }
            else if (Num > 10000)
            {
                NumberObject.GetComponentInChildren<TextMesh>().fontSize = 70;

            }
            else if (Num > 100000)
            {
                NumberObject.GetComponentInChildren<TextMesh>().fontSize = 60;

            }
        }
        public int GetNumber() { return Num; }
        public void SetColor(Color color)
        {
            NumberObject.GetComponentInChildren<TextMesh>().color = color;
        }

        public void SetLastIndex(Vector2 index)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 GetLastIndex()
        {
            throw new System.NotImplementedException();
        }
    }
}