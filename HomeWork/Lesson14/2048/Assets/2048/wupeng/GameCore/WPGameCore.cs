﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;


namespace WP
{
    public class WPGameCore : IGameCore
    {
        private int size = 4;
        private float waitTime;

        private INumberObject[,] numbers; //动画层
        private Number[,] numbers_data;   //数据层

        private List<Vector2> blank;

        private State numberstate;
        private State playerstate;

        public class Number 
        {
            private int num;
            private Vector2 index;
            private Vector2 lastIndex;
            private bool canbeMerge;

            public void SetNumber(int number)
            {
                this.num = number;
            }

            public int GetNumber()
            {
                return this.num;
            }

            public void SetCurrentIndex(Vector2 index)
            {
                this.index = index;
            }

            public Vector2 GetCurrentIndex()
            {
                return this.index;
            }

            public void SetLastIndex(Vector2 index)
            {
                this.lastIndex = index;
            }

            public Vector2 GetLastIndex()
            {
                return this.lastIndex;
            }

            public void SetMerge(bool merge)
            {
                this.canbeMerge = merge;
            }

            public bool GetMerge()
            {
                return canbeMerge;
            }

        }

        public void ModuleInit()
        {
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
                    numbers_data[i, j].SetCurrentIndex(new Vector2(i, j));
                    numbers_data[i, j].SetLastIndex(new Vector2(i, j));
                    numbers_data[i, j].SetMerge(true);
                }
            }

            RenewBlank();
            numbers_data[0, 0].SetNumber(2);
            numbers[0, 0].SetNumber(2);
            

            numbers_data[0, 1].SetNumber(2);
            numbers[0, 1].SetNumber(2);

            numbers_data[0, 2].SetNumber(4);
            numbers[0, 2].SetNumber(4);
            //GenerateNumbers(); //在数据层和渲染层生成随机2或4
            ShowData();
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

            for (int i = 0; i < count; i++)
            {
                int index = Random.Range((int)0, (int)blank.Count);
               

                Vector2 v = blank[index];

                int num = nums[Random.Range(0, 2)];

                numbers_data[(int)v.x, (int)v.y].SetNumber(num);
                numbers[(int)v.x, (int)v.y].SetNumber(num);
                RenewBlank();
            }

            ShowData();

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
                            ShowData();
                            for (int i = 0; i < size; i ++)
                            {
                                Debug.Log(numbers_data[0, i].GetCurrentIndex());
                                Debug.Log(numbers_data[0, i].GetLastIndex());
                                Debug.Log(numbers_data[0, i].GetMerge());
                                Debug.Log(numbers_data[0, i].GetNumber());
                                Debug.Log(" ");
                            }

                            break;
                        case InputProtocol.MoveLeft:
                            numberstate = State.NumbersLeft;
                            playerstate = State.PlayerWait;
                            Debug.Log("左移");
                            MoveLeft();
                            ShowData();

                            break;
                        case InputProtocol.MoveUp:
                            numberstate = State.NumbersUp;
                            playerstate = State.PlayerWait;
                            Debug.Log("上移");
                            MoveUp();
                            ShowData();

                            break;
                        case InputProtocol.MoveDown:
                            numberstate = State.NumbersDown;
                            playerstate = State.PlayerWait;
                            Debug.Log("下移");
                            MoveDown();
                            ShowData();
                            break;
                    }
                    break;
                case State.PlayerWait:
                    switch (numberstate)
                    {
                        case State.NumbersRighgt:
                            //执行动画化To Do...

                            if (NumberAnimate(0.5f))
                            {
                                ShowData();
                                numberstate = State.None;
                                playerstate = State.PlayerInput;
                            }
                            //动画结束
                            //GenerateNumbers();
                            //numberstate = State.None;
                            //playerstate = State.PlayerInput;
                            break;
                        case State.NumbersLeft:
                            //执行动画化To Do...
                            //动画结束
                            GenerateNumbers();
                            numberstate = State.None;
                            playerstate = State.PlayerInput;
                            break;
                        case State.NumbersUp:
                            //执行动画化To Do...
                            //动画结束
                            GenerateNumbers();
                            numberstate = State.None;
                            playerstate = State.PlayerInput;
                            break;
                        case State.NumbersDown:
                            //执行动画化To Do...
                            //动画结束
                            GenerateNumbers();
                            numberstate = State.None;
                            playerstate = State.PlayerInput;
                            break;
                       
                    }

                    break;
                default:
                    break;
            }
        }

        public void MoveRight()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = size - 2; j >= 0; j--)
                {
                    Number current = numbers_data[i, j];
                    DataMoveToEnd(current, "right");
                }
            }
        }

        public void MoveLeft()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j =  1; j < size; j++)
                {
                    Number current = numbers_data[i, j];
                    DataMoveToEnd(current, "left");
                }
            }
        }

        public void MoveUp()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = size - 2; j >= 0; j--)
                {
                    Number current = numbers_data[j, i];
                    DataMoveToEnd(current, "up");
                }
            }
        }

        public void MoveDown()
        {
            //先更新数据层，根据数据层再更新动画层
            for (int i = 0; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    Number current = numbers_data[j, i];
                    DataMoveToEnd(current, "down");
                }
            }
        }


        //====数据层无动画逻辑开始====
        //数据层单元移动,完成后更新数据
        public bool DataMove(Number number, Vector2 dest)
        {
            if (number.GetCurrentIndex() == dest ||
                number.GetNumber() == 0 ||
                numbers_data[(int)dest.x, (int)dest.y].GetNumber() != 0)
            {
                return false;
            }
            else
            {
                number.SetCurrentIndex(dest);

                
                //更新数据层
                numbers_data[(int)dest.x, (int)dest.y] = number;

                Vector2 lastIndex = number.GetLastIndex();

                numbers_data[(int)lastIndex.x, (int)lastIndex.y] = new Number();
                numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetCurrentIndex(new Vector2((int)lastIndex.x, (int)lastIndex.y));
                numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetLastIndex(new Vector2((int)lastIndex.x, (int)lastIndex.y));
                numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetMerge(true);
                numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetNumber(0);

                return true;

            }
        }

        //数据层单元Merge
        public bool DataMerge(Number number, Number dest)
        {
            if (number.GetCurrentIndex() == dest.GetCurrentIndex() ||
                number.GetNumber() != dest.GetNumber() ||
                number.GetNumber() == 0 || dest.GetMerge() == false)
            {
                return false ;
            }
            else
            {
                Vector2 destIndex = dest.GetCurrentIndex();
                Vector2 lastIndex = number.GetCurrentIndex();
                number.SetCurrentIndex(destIndex);
                number.SetNumber(number.GetNumber() + dest.GetNumber());
                number.SetMerge(false);

                //更新数据层
                numbers_data[(int)destIndex.x, (int)destIndex.y] = number;
                numbers_data[(int)lastIndex.x, (int)lastIndex.y] = new Number();
                numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetCurrentIndex(lastIndex);
                numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetLastIndex(lastIndex);
                numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetMerge(true);
                numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetNumber(0);

                return true;
            }
        }

        //数据层：单个数字按照方向持续向下一个方向左动作：可以合并就合并，不能合并就判断移动，直到不能移动
        public void DataMoveToEnd(Number current, string orien)
        {
            int x = (int)current.GetCurrentIndex().x;
            int y = (int)current.GetCurrentIndex().y;

            switch (orien)
            {
                case "right":

                    if (y == size - 1)
                        return;

                    for (int i = y + 1; i < size; i ++)
                    {
                        DataMerge(current, numbers_data[x, i]);

                        if (!DataMove(current, new Vector2(x, i)))
                        {
                            return;
                        }
                    }


                    break;
                //case "left":
                //    for (int i = y; i > 0; i--)
                //    {
                //        Vector2 dest = new Vector2(x, i - 1);
                //        if (mergeCount == 1)
                //        {
                //            if (DataMerge(current, dest))//每个数只能Merge一次
                //            {
                //                mergeCount--;
                //            }
                //        }
                //        DataMove(current, dest);
                //    }
                //    break;
                //case "up":
                //    for (int i = x; i < size - 1; i++)
                //    {
                //        Vector2 dest = new Vector2(i + 1, y);
                //        if (mergeCount == 1)
                //        {
                //            if (DataMerge(current, dest))//每个数只能Merge一次
                //            {
                //                mergeCount--;
                //            }
                //        }
                //        DataMove(current, dest);
                //    }
                //
                //    break;
                //case "down":
                //    for (int i = x; i > 0; i--)
                //    {
                //        Vector2 dest = new Vector2(i - 1, y);
                //        if (mergeCount == 1)
                //        {
                //            if (DataMerge(current, dest))//每个数只能Merge一次
                //            {
                //                mergeCount--;
                //            }
                //        }
                //        DataMove(current, dest);
                //    }
                //    break;
            }
        }
        //====数据层无动画逻辑结束====

        //====渲染层动画逻辑开始====
        public bool NumberAnimate(float speed)
        {
            for (int i = 0; i < size; i ++)
            {
                for (int j = 3; j >= 0; j --)
                {
                    if (numbers_data[i, j].GetCurrentIndex() != numbers_data[i, j].GetLastIndex())
                    {
                        Vector2 dest = numbers_data[i, j].GetCurrentIndex();
                        Vector2 last = numbers_data[i, j].GetLastIndex();
                        Vector2 direct = (dest - last).normalized;
                        Vector2 currentPos = numbers[(int)last.x, (int)last.y].GetCurrentPos();

                        currentPos += direct * speed * Time.deltaTime * (dest.y - last.y);
                        numbers[(int)last.x, (int)last.y].SetPosition(currentPos);

                        if (i == 0 && j == 2)
                        {
                            Debug.Log(numbers_data[i, j].GetNumber());
                        }

                        if (Mathf.Abs((dest - currentPos).magnitude) < 0.01)
                        {

                            int res = numbers_data[i, j].GetNumber();

                            //更新动画层
                            GameFramework.singleton.getGameRender().DestroyObject(numbers[i, j]);
                            INumberObject num = numbers[(int)last.x, (int)last.y];                            
                            num.SetPosition(dest);
                            num.SetNumber(res);
                            //numbers[i, j] = numbers[(int)last.x, (int)last.y];
                            //
                            //
                            ////更新数据层
                            numbers_data[i, j].SetLastIndex(dest);
                            numbers_data[i, j].SetMerge(true);
                            //
                            //numbers_data[(int)last.x, (int)last.y] = new Number();
                            //numbers_data[(int)last.x, (int)last.y].SetNumber(0);
                            //numbers_data[(int)last.x, (int)last.y].SetCurrentIndex(new Vector2(last.x, last.y));
                            //numbers_data[(int)last.x, (int)last.y].SetLastIndex(new Vector2(last.x, last.y));
                            //numbers_data[(int)last.x, (int)last.y].SetMerge(true);

                            return true;
                        }
                        
                    }          
                }

                
            }
            return false;



        }

        //====渲染层动画逻辑结束


        public void ShowData()
        {
            Debug.Log(numbers_data[3, 0].GetNumber() + " " + numbers_data[3, 1].GetNumber() + " "
            + numbers_data[3, 2].GetNumber() + " " + numbers_data[3, 3].GetNumber());

            Debug.Log(numbers_data[2, 0].GetNumber() + " " + numbers_data[2, 1].GetNumber() + " " +
               numbers_data[2, 2].GetNumber() + " " + numbers_data[2, 3].GetNumber());
            Debug.Log(numbers_data[1, 0].GetNumber() + " " + numbers_data[1, 1].GetNumber() + " " +
              numbers_data[1, 2].GetNumber() + " " + numbers_data[1, 3].GetNumber());
            Debug.Log(numbers_data[0, 0].GetNumber() + " " + numbers_data[0, 1].GetNumber() + " " +
              numbers_data[0, 2].GetNumber() + " " + numbers_data[0, 3].GetNumber());
            Debug.Log(" ");
        }

        public void ShowNumber()
        {
            Debug.Log(numbers[3, 0].GetNumber() + " " + numbers[3, 1].GetNumber() + " "
            + numbers[3, 2].GetNumber() + " " + numbers[3, 3].GetNumber());

            Debug.Log(numbers[2, 0].GetNumber() + " " + numbers[2, 1].GetNumber() + " " +
               numbers[2, 2].GetNumber() + " " + numbers[2, 3].GetNumber());
            Debug.Log(numbers[1, 0].GetNumber() + " " + numbers[1, 1].GetNumber() + " " +
              numbers[1, 2].GetNumber() + " " + numbers[1, 3].GetNumber());
            Debug.Log(numbers[0, 0].GetNumber() + " " + numbers[0, 1].GetNumber() + " " +
              numbers[0, 2].GetNumber() + " " + numbers[0, 3].GetNumber());
            Debug.Log(" ");
        }
    }

}


/*
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
            public void SetIndex(Vector2 index) { }
            public Vector2 GetIndex() { return new Vector2(); }
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
            GenerateNumbers(); //在数据层和渲染层生成随机2或4
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

            for (int i = 0; i < count; i++)
            {
                int index = Random.Range((int)0, (int)blank.Count);


                Vector2 v = blank[index];

                int num = nums[Random.Range(0, 2)];

                numbers_data[(int)v.x, (int)v.y].SetNumber(num);

                RenewBlank();
            }

            ShowData();

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
                            ShowData();

                            break;
                        case InputProtocol.MoveLeft:
                            numberstate = State.NumbersLeft;
                            playerstate = State.PlayerWait;
                            Debug.Log("左移");
                            MoveLeft();
                            ShowData();

                            break;
                        case InputProtocol.MoveUp:
                            numberstate = State.NumbersUp;
                            playerstate = State.PlayerWait;
                            Debug.Log("上移");
                            MoveUp();
                            ShowData();

                            break;
                        case InputProtocol.MoveDown:
                            numberstate = State.NumbersDown;
                            playerstate = State.PlayerWait;
                            Debug.Log("下移");
                            MoveDown();
                            ShowData();
                            break;
                    }
                    break;
                case State.PlayerWait:
                    switch (numberstate)
                    {
                        case State.NumbersRighgt:
                            //执行动画化To Do...
                            //动画结束
                            GenerateNumbers();
                            numberstate = State.None;
                            playerstate = State.PlayerInput;
                            break;
                        case State.NumbersLeft:
                            //执行动画化To Do...
                            //动画结束
                            GenerateNumbers();
                            numberstate = State.None;
                            playerstate = State.PlayerInput;
                            break;
                        case State.NumbersUp:
                            //执行动画化To Do...
                            //动画结束
                            GenerateNumbers();
                            numberstate = State.None;
                            playerstate = State.PlayerInput;
                            break;
                        case State.NumbersDown:
                            //执行动画化To Do...
                            //动画结束
                            GenerateNumbers();
                            numberstate = State.None;
                            playerstate = State.PlayerInput;
                            break;

                    }

                    break;
                default:
                    break;
            }
        }

        public void MoveRight()
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
        }

        public void MoveLeft()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    Number current = numbers_data[i, j];
                    DataMoveToEnd(current, "left");
                }
            }
        }

        public void MoveUp()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = size - 2; j >= 0; j--)
                {
                    Number current = numbers_data[j, i];
                    DataMoveToEnd(current, "up");
                }
            }
        }

        public void MoveDown()
        {
            //先更新数据层，根据数据层再更新动画层
            for (int i = 0; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    Number current = numbers_data[j, i];
                    DataMoveToEnd(current, "down");
                }
            }
        }

        //数据层：单个数字按照方向持续向下一个方向左动作：可以合并就合并，不能合并就判断移动，直到不能移动
        public void DataMoveToEnd(Number current, string orien)
        {
            int x = (int)current.GetCurrentPos().x;
            int y = (int)current.GetCurrentPos().y;
            int mergeCount = 1;

            switch (orien)
            {
                case "right":
                    for (int i = y; i < size - 1; i++)
                    {
                        Vector2 dest = new Vector2(x, i + 1);
                        if (mergeCount == 1)
                        {
                            if (DataMerge(current, dest))//每个数只能Merge一次
                            {
                                mergeCount--;
                            }
                        }
                        DataMove(current, dest);
                    }
                    break;
                case "left":
                    for (int i = y; i > 0; i--)
                    {
                        Vector2 dest = new Vector2(x, i - 1);
                        if (mergeCount == 1)
                        {
                            if (DataMerge(current, dest))//每个数只能Merge一次
                            {
                                mergeCount--;
                            }
                        }
                        DataMove(current, dest);
                    }
                    break;
                case "up":
                    for (int i = x; i < size - 1; i++)
                    {
                        Vector2 dest = new Vector2(i + 1, y);
                        if (mergeCount == 1)
                        {
                            if (DataMerge(current, dest))//每个数只能Merge一次
                            {
                                mergeCount--;
                            }
                        }
                        DataMove(current, dest);
                    }

                    break;
                case "down":
                    //Debug.Log(current.GetCurrentPos().x + "" + current.GetCurrentPos().y);
                    for (int i = x; i > 0; i--)
                    {
                        Vector2 dest = new Vector2(i - 1, y);
                        //Debug.Log("原" + current.GetCurrentPos().x + " " + current.GetCurrentPos().y + "与" + dest.x + " " + dest.y);
                        if (mergeCount == 1)
                        {
                            if (DataMerge(current, dest))//每个数只能Merge一次
                            {
                                mergeCount--;
                            }
                        }
                        DataMove(current, dest);
                    }
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
        public bool DataMerge(Number number, Vector2 dest)
        {
            if (number.GetCurrentPos() == dest ||
                number.GetNumber() != numbers_data[(int)dest.x, (int)dest.y].GetNumber() ||
                number.GetNumber() == 0)
            {
                return false;
            }
            else
            {
                //Debug.Log("merge");
                Vector2 origin = number.GetCurrentPos();
                number.SetPosition(dest);
                number.SetNumber(number.GetNumber() + numbers_data[(int)dest.x, (int)dest.y].GetNumber());

                //Debug.Log(number.GetNumber() + "+" + numbers_data[(int)dest.x, (int)dest.y].GetNumber());

                //更新数据层
                numbers_data[(int)dest.x, (int)dest.y] = number;
                numbers_data[(int)origin.x, (int)origin.y] = new Number();
                numbers_data[(int)origin.x, (int)origin.y].SetNumber(0);
                numbers_data[(int)origin.x, (int)origin.y].SetPosition(origin);

                return true;
            }
        }

        public void ShowData()
        {
            Debug.Log(numbers_data[3, 0].GetNumber() + " " + numbers_data[3, 1].GetNumber() + " "
            + numbers_data[3, 2].GetNumber() + " " + numbers_data[3, 3].GetNumber());

            Debug.Log(numbers_data[2, 0].GetNumber() + " " + numbers_data[2, 1].GetNumber() + " " +
               numbers_data[2, 2].GetNumber() + " " + numbers_data[2, 3].GetNumber());
            Debug.Log(numbers_data[1, 0].GetNumber() + " " + numbers_data[1, 1].GetNumber() + " " +
              numbers_data[1, 2].GetNumber() + " " + numbers_data[1, 3].GetNumber());
            Debug.Log(numbers_data[0, 0].GetNumber() + " " + numbers_data[0, 1].GetNumber() + " " +
              numbers_data[0, 2].GetNumber() + " " + numbers_data[0, 3].GetNumber());
            Debug.Log(" ");
        }

        //和数据层比较，移动到相应位置，替换数字
        public void NumberAnimateRight(INumberObject number)
        {
            Vector2 index = number.GetCurrentPos();
            int num = number.GetNumber();

            int x = (int)index.x;
            int y = (int)index.y;



        }


    }

}
*/


/*
 *        
        //====动画层+数据层逻辑开始====
        public bool NumberMove(INumberObject number, Vector2 dest, float speed)
        {
            Vector2 lastIndex = number.GetIndex();
            Vector2 pos_current = number.GetCurrentPos();
            Vector2 orien =  (dest - lastIndex).normalized;
           
            if (lastIndex == dest || numbers_data[(int)dest.x, (int)dest.y].GetNumber() != 0 || number.GetNumber() == 0)
            {
                return false;
            }
            else
            {
                //更新数据层
                if (pos_current == lastIndex)
                {
                    numbers_data[(int)lastIndex.x, (int)lastIndex.y].SetNumber(0);
                }

                pos_current += orien * speed * Time.deltaTime;
                number.SetPosition(pos_current);

                if (Mathf.Abs((dest - pos_current).magnitude) < 0.01)
                {
                    number.SetPosition(dest);
                    number.SetIndex(dest);
                    //更新数据层
                    numbers_data[(int)dest.x, (int)dest.y].SetNumber(number.GetNumber());

                    //更新渲染层：
                    //INumberObject newNum = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, size) as INumberObject;
                    //newNum.SetNumber(0);
                    //newNum.SetPosition(lastIndex);
                    //numbers[(int)lastIndex.x, (int)lastIndex.y] = newNum;
                    //GameFramework.singleton.getGameRender().DestroyObject(numbers[(int)dest.x, (int)dest.y]);
                    //numbers[(int)dest.x, (int)dest.y] = number;
                    return true;
                }
                else
                    return false;
            }
        }        
        public bool NumberMerge(INumberObject number, Vector2 dest, float speed)
        {
            if (number.GetNumber() == numbers_data[(int)dest.x, (int)dest.y].GetNumber() &&
                number.GetNumber() != 0)
            {
                Debug.Log("合并");
                Vector2 index = number.GetIndex();

                Vector2 pos_current = number.GetCurrentPos();
                Vector2 orien = (dest - index).normalized;

                //更新数据层
                if (pos_current == number.GetIndex())
                {
                    numbers_data[(int)index.x, (int)index.y].SetNumber(0);
                }

                pos_current += orien * speed * Time.deltaTime;
                number.SetPosition(pos_current);

                if (Mathf.Abs((dest - pos_current).magnitude) < 0.01)
                {
                    int sum = number.GetNumber() + numbers_data[(int)dest.x, (int)dest.y].GetNumber();

                    Debug.Log(sum);
                    number.SetPosition(dest);
                    number.SetNumber(sum);
                    number.SetIndex(dest);
                    //更新数据层
                    numbers_data[(int)dest.x, (int)dest.y].SetNumber(sum);

                    //更新渲染层：
                    //INumberObject newNum = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, size) as INumberObject;
                    //newNum.SetNumber(0);
                    //newNum.SetPosition(index);
                    //numbers[(int)index.x, (int)index.y] = newNum;
                    //GameFramework.singleton.getGameRender().DestroyObject(numbers[(int)dest.x, (int)dest.y]);
                    //numbers[(int)dest.x, (int)dest.y] = number;

                    return true;
                }
                else
                    return false;

            }
            else
                return false;

        }

        public bool NumberMerge(INumberObject origin, INumberObject dest, float speed)
        {
            if (origin.GetNumber() == dest.GetNumber() &&
                origin.GetNumber() != 0)
            {
                Debug.Log("合并");
                Vector2 index = origin.GetIndex();
                Vector2 index_dest = dest.GetCurrentPos();

                Vector2 pos_current = origin.GetCurrentPos();
                Vector2 orien = (index_dest - index).normalized;

                //更新数据层
                if (pos_current == origin.GetIndex())
                {
                    numbers_data[(int)index.x, (int)index.y].SetNumber(0);
                }

                pos_current += orien * speed * Time.deltaTime;
                origin.SetPosition(pos_current);

                if (Mathf.Abs((index_dest - pos_current).magnitude) < 0.01)
                {
                    int sum = origin.GetNumber() + numbers_data[(int)index_dest.x, (int)index_dest.y].GetNumber();

                    Debug.Log(sum);
                    origin.SetPosition(index_dest);
                    origin.SetNumber(sum);
                    origin.SetIndex(index_dest);
                    //更新数据层
                    numbers_data[(int)index_dest.x, (int)index_dest.y].SetNumber(sum);

                    //更新渲染层：
                    //INumberObject newNum = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, size) as INumberObject;
                    //newNum.SetNumber(0);
                    //newNum.SetPosition(index);
                    //numbers[(int)index.x, (int)index.y] = newNum;
                    //GameFramework.singleton.getGameRender().DestroyObject(numbers[(int)dest.x, (int)dest.y]);
                    //numbers[(int)dest.x, (int)dest.y] = number;

                    return true;
                }
                else
                    return false;

            }
            else
                return false;

        }
        public void NumberMoveToEnd(INumberObject current, string orien, float speed)
        {
            Vector2 index = current.GetIndex();

            int mergeCount = 1;
            switch (orien)
            {
                case "right":

                    Vector2 dest = new Vector2(index.x, index.y + 1);



                    if (dest.y < size)
                    {
                        if (mergeCount == 1)
                        {
                            if (NumberMerge(current, dest, speed))
                            {
                                mergeCount--;
                                index.y += 1;
                            }
                        }
                    }
                    
                    if (dest.y < size)
                    {
                        if (NumberMove(current, dest, speed))
                        {
                            index.y += 1;
                        }
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
        //====动画层+数据层逻辑结束====
        
 */
