using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;


namespace WP
{
    public class WPGameCore : IGameCore
    {
        private int size;
        private float waitTime;

        private INumberObject[,] numbers; //动画层
        private Number[,] numbers_data;   //数据层

        private List<Vector2> blank;

        private State numberstate;
        private State playerstate;

        public class Number : INumberObject
        {
            private int num;
            private Vector2 index;

            public Vector2 GetCurrentPos()
            {
                return this.index;
            }

            public int GetNumber()
            {
                return this.num;
            }

            public void SetColor(Color color)
            {

            }

            public void SetNumber(int number)
            {
                this.num = number;
            }

            public void SetPosition(Vector2 index)
            {
                this.index = index;
            }
        }

        public void ModuleInit()
        {
            size = 4;
            waitTime = 1.2f;
            numbers = new INumberObject[4, 4];//声明渲染层
            numbers_data = new Number[4, 4];  //声明数据层
            blank = new List<Vector2>();      //声明空格

            numberstate = State.None;         //初始化游戏状态
            playerstate = State.PlayerInput;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //初始化渲染层
                    numbers[i, j] = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, size) as INumberObject;
                    numbers[i, j].SetNumber(0);
                    numbers[i, j].SetPosition(new Vector2(i, j));
                    //初始化数据层
                    numbers_data[i, j] = new Number();
                    numbers_data[i, j].SetNumber(0);
                    numbers_data[i, j].SetPosition(new Vector2(i, j));
                }
            }

            RenewBlank();

            numbers_data[0, 0].SetNumber(2);
            numbers_data[0, 1].SetNumber(2);
            numbers_data[0, 2].SetNumber(2);
            numbers_data[0, 3].SetNumber(2);
            //GenerateNumbers(); //在数据层和渲染层生成随机2或4


            Debug.Log(numbers_data[3, 0].GetNumber() + " " + numbers_data[3, 1].GetNumber() + " "
               + numbers_data[3, 2].GetNumber() + " " + numbers_data[3, 3].GetNumber());

            Debug.Log(numbers_data[2, 0].GetNumber() + " " + numbers_data[2, 1].GetNumber() + " " +
               numbers_data[2, 2].GetNumber() + " " + numbers_data[2, 3].GetNumber());
            Debug.Log(numbers_data[1, 0].GetNumber() + " " + numbers_data[1, 1].GetNumber() + " " +
              numbers_data[1, 2].GetNumber() + " " + numbers_data[1, 3].GetNumber());
            Debug.Log(numbers_data[0, 0].GetNumber() + " " + numbers_data[0, 1].GetNumber() + " " +
              numbers_data[0, 2].GetNumber() + " " + numbers_data[0, 3].GetNumber());
        }

        public void ModuleDestroy()
        {

        }

        public void ModuleUpdate()
        {
            GamePlay();
        }

        public void RenewBlank()
        {
            blank.Clear();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (numbers_data[i, j].GetNumber() == 0)
                    {
                        blank.Add(new Vector2(i, j));
                    }
                }
            }
        }//从数据层更新空格数据

        public bool GenerateNumbers() //在数据层和渲染层随机生成2或4
        {
            int[] nums = { 2, 4 };

            int count = 0;

            if (blank.Count == 1)
                count = 1;
            else if (blank.Count > 1)
                count = 2;
            else if (blank.Count == 0)
            {
                Debug.Log("There is no space in checkboard! Can't genarate numbers!");
                return false;
            }

            Debug.Log("生成了"+count+"个");

            for (int i = 0; i < count; i++)
            {
                int index = Random.Range((int)0, (int)blank.Count);
               

                Vector2 v = blank[index];

                Debug.Log("位置：" + v.x + " " + v.y);

                int num = nums[Random.Range(0, 2)];

                numbers_data[(int)v.x, (int)v.y].SetNumber(num);

                RenewBlank();
                Debug.Log("blank还剩"+blank.Count);
            }

            return true;
        }

        public void GamePlay()
        {
            switch (playerstate)
            {
                case State.PlayerInput:
                    switch (GameFramework.singleton.getInput().GetInputData())
                    {
                        case InputProtocol.None:
                            break;
                        case InputProtocol.MoveRight:
                            numberstate = State.NumbersRighgt;
                            playerstate = State.PlayerWait;
                            Debug.Log("右移");
                            MoveRight();

                            Debug.Log(numbers_data[3, 0].GetNumber() + " " + numbers_data[3, 1].GetNumber() + " "
                                + numbers_data[3, 2].GetNumber() + " " + numbers_data[3, 3].GetNumber());

                            Debug.Log(numbers_data[2, 0].GetNumber() + " " + numbers_data[2, 1].GetNumber() + " " +
                               numbers_data[2, 2].GetNumber() + " " + numbers_data[2, 3].GetNumber());
                            Debug.Log(numbers_data[1, 0].GetNumber() + " " + numbers_data[1, 1].GetNumber() + " " +
                              numbers_data[1, 2].GetNumber() + " " + numbers_data[1, 3].GetNumber());
                            Debug.Log(numbers_data[0, 0].GetNumber() + " " + numbers_data[0, 1].GetNumber() + " " +
                              numbers_data[0, 2].GetNumber() + " " + numbers_data[0, 3].GetNumber());

                            break;
                        case InputProtocol.MoveLeft:
                            numberstate = State.NumbersLeft;
                            playerstate = State.PlayerWait;
                            Debug.Log("左移");
                            break;
                        case InputProtocol.MoveUp:
                            numberstate = State.NumbersUp;
                            playerstate = State.PlayerWait;
                            Debug.Log("上移");
                            break;
                        case InputProtocol.MoveDown:
                            numberstate = State.NumbersDown;
                            playerstate = State.PlayerWait;
                            Debug.Log("下移");
                            break;
                    }
                    break;
                case State.PlayerWait:
                    switch (numberstate)
                    {
                        case State.NumbersRighgt:

                            break;
                       
                    }

                    break;
                default:
                    break;
            }
        }

        public bool MoveRight()
        {
            //先更新数据层，根据数据层再更新动画层
            for (int i = 0; i < size; i++)
            {
                for (int j = size - 2; j >= 0; j--)
                {
                    Number current = numbers_data[i, j];
                    DataMoveToEnd(current, "right");
                }
            }

            return false;
        }

        //数据层：数字按照方向持续向下一个方向左动作：可以合并就合并，不能合并就判断移动，直到不能移动
        public void DataMoveToEnd(Number current, string orien)
        {
            switch(orien)
            {
                case "right":
                    
                    int x = (int)current.GetCurrentPos().x;
                    int y = (int)current.GetCurrentPos().y;

                    Debug.Log(current.GetCurrentPos().x + "" + current.GetCurrentPos().y);

                    int mergeCount = 1;
                    for (int i = y; i < size - 1; i ++)
                    {
                        
                        Vector2 dest = new Vector2(x, i + 1);
                        Debug.Log("原" + current.GetCurrentPos().x + " " + current.GetCurrentPos().y + "与" + dest.x + " " + dest.y);
                        if (mergeCount == 1)
                        {
                            DataMerge(current, dest);//每个数只能Merge一次
                            mergeCount--;
                        }

                        DataMove(current, dest);                      
                    }

                    break;
                case "left":
                    break;
                case "up":
                    break;
                case "down":
                    break;
            }
        }

        //数据层单元移动,完成后更新数据
        public void DataMove(Number number, Vector2 dest)
        {
            if (number.GetCurrentPos() == dest ||
                number.GetNumber() == 0 ||
                numbers_data[(int)dest.x, (int)dest.y].GetNumber() != 0)
            {
                return;
            }
            else
            {
                //Debug.Log("move");
                Vector2 origin = number.GetCurrentPos();
                number.SetPosition(dest);

                //更新data数据
                numbers_data[(int)dest.x, (int)dest.y] = number;
                //Debug.Log(number.GetNumber());                          
                numbers_data[(int)origin.x, (int)origin.y] = new Number();
                numbers_data[(int)origin.x, (int)origin.y].SetNumber(0);
                numbers_data[(int)origin.x, (int)origin.y].SetPosition(origin);

                //Debug.Log(numbers_data[(int)dest.x, (int)dest.y].GetNumber());
                return;
            }
        }

        //数据层单元Merge
        public void DataMerge(Number number, Vector2 dest)
        {
            if (number.GetCurrentPos() == dest ||
                number.GetNumber() != numbers_data[(int)dest.x, (int)dest.y].GetNumber() ||
                number.GetNumber() == 0)
            {
                return;
            }
            else
            {
                Debug.Log("merge");
                Vector2 origin = number.GetCurrentPos();
                number.SetPosition(dest);
                number.SetNumber(number.GetNumber() + numbers_data[(int)dest.x, (int)dest.y].GetNumber());

                Debug.Log(number.GetNumber() + "+" + numbers_data[(int)dest.x, (int)dest.y].GetNumber());

                //更新数据层
                numbers_data[(int)dest.x, (int)dest.y] = number;                
                numbers_data[(int)origin.x, (int)origin.y] = new Number();
                numbers_data[(int)origin.x, (int)origin.y].SetNumber(0);
                numbers_data[(int)origin.x, (int)origin.y].SetPosition(origin);
                
                return;
            }
        }

        //渲染层单元移动
        public bool Move(Vector2 origin, Vector2 dest, float speed)
        {
            if (origin == dest)
            {
                return true;
            }

            INumberObject number = numbers[(int)origin.x, (int)origin.y];

            if ((dest - number.GetCurrentPos()).sqrMagnitude > 0.005)
            {
                number.SetPosition(number.GetCurrentPos() + speed * (dest - number.GetCurrentPos()).normalized * Time.deltaTime);
                return false;
            }
            else
            {
                number.SetPosition(dest);
                numbers[(int)dest.x, (int)dest.y] = number;

                numbers[(int)origin.x, (int)origin.y] = new Number();
                numbers[(int)origin.x, (int)origin.y].SetNumber(0);
                numbers[(int)origin.x, (int)origin.y].SetPosition(origin);
                return true;
            }
        }



        //渲染层单元Merge
        public bool Merge(Vector2 origin, Vector2 dest, float speed)
        {
            if (origin == dest)
            {
                return true;
            }

            INumberObject number = numbers[(int)origin.x, (int)origin.y];
            if ((dest - number.GetCurrentPos()).sqrMagnitude > 0.005)
            {
                number.SetPosition(number.GetCurrentPos() + speed * (dest - number.GetCurrentPos()).normalized * Time.deltaTime);
                return false;
            }
            else
            {
                number.SetPosition(dest);
                number.SetNumber(number.GetNumber() + numbers[(int)dest.x, (int)dest.y].GetNumber());
                numbers[(int)dest.x, (int)dest.y] = number;

                numbers[(int)origin.x, (int)origin.y] = new Number();
                numbers[(int)origin.x, (int)origin.y].SetNumber(0);
                numbers[(int)origin.x, (int)origin.y].SetPosition(origin);
                return true;
            }
        }
    }

}
