using UnityEngine;
using System.Collections;
using Game2048Framework;
using UnityEngine.UI;

namespace WP
{
    public class wupGameRender2 : MonoBehaviour, IGameRender
    {
        int size = 4;
        int width = 800;
        int height = 800;

        INumberObject[,] numbers_data;  //数据层
        Number[,] numbers;  //渲染层

        string path_canvas = "canvas";
        GameObject canvasOb;

        public wupGameRender2()
        {

            GameObject canv = Resources.Load("canvas") as GameObject;
            canvasOb = GameObject.Instantiate(canv);
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
                    renderObject = new Number(size, width, height, canvasOb);
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
            numbers = new Number[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    numbers[i, j] = new Number(size, width, height, canvasOb);
                    numbers[i, j].SetNumber(0);
                    numbers[i, j].SetPosition(new Vector2(i, j));
                }
            }
        }

        //每一帧从数据层获取数据，并更新渲染层
        public void ModuleUpdate()
        {
            numbers_data = GameFramework.singleton.getGameCore().GetNumbers();
            for (int i = 0; i < size; i ++)
            {
                for (int j = 0; j < size; j ++)
                {
                    if (numbers_data[i, j] == null)
                    {
                        DestroyObject(numbers[i, j].objNumber);
                        Debug.Log("销毁");
                    }
                    else
                    {
                        numbers[i, j].SetNumber(numbers_data[i, j].GetNumber());
                        numbers[i, j].SetPosition(numbers_data[i, j].GetCurrentPos());
                    }
                }
            }
        }
    }

    public class Number : INumberObject
    {
        private int width;
        private int height;
        private int size;

        int number;
        Vector2 index;

        public GameObject objNumber;
        private string numberPath = "number";

        public Number(int size, int width, int height, GameObject canvasOb)
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

                this.objNumber.transform.position = new Vector3(w / 2 + index.y * w, h / 2 + index.x * h, 0);
            }
        }
    }

}

