using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace WP
{
    public class WPGameCore : IGameCore
    {
        public class Number
        {
            private int lastNum;
            private int currentNum;
            private Vector2 lastIndex;
            private Vector2 currentIndex;
            private Vector2 mergeIndex;

            private bool canbeMerge;

            public void SetLastNum(int number)
            {
                this.lastNum = number;
            }

            public int GetLastNum()
            {
                return this.lastNum;
            }

            public void SetCurrentNum(int number)
            {
                this.currentNum = number;
            }

            public int GetCurrentNum()
            {
                return this.currentNum;
            }

            public void SetCurrentIndex(Vector2 index)
            {
                this.currentIndex = index;
            }

            public Vector2 GetCurrentIndex()
            {
                return this.currentIndex;
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

            public void SetMergeIndex(Vector2 mergeIndex)
            {
                this.mergeIndex = mergeIndex;
            }

            public Vector2 GetMergeIndex()
            {
                return this.mergeIndex;
            }
        }
        private INumberObject[,] numbers; //动画层
        private Number[,] numbers_data;   //数据层
        private List<Vector2> blank;      //空格列表
        private State playerstate;        //玩家状态

        private int size = 4;
        private float waitTime;

        public void ModuleInit()
        {
            waitTime = 2.0f;
            numbers = new INumberObject[4, 4];//声明渲染层
            numbers_data = new Number[4, 4];  //声明数据层
            blank = new List<Vector2>();      //声明空格

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
                    numbers_data[i, j].SetLastNum(0);
                    numbers_data[i, j].SetCurrentNum(0);
                    numbers_data[i, j].SetCurrentIndex(new Vector2(i, j));
                    numbers_data[i, j].SetLastIndex(new Vector2(i, j));
                    numbers_data[i, j].SetMergeIndex(new Vector2(i, j));
                    numbers_data[i, j].SetMerge(true);
                }
            }

            RenewBlank();//更新空格列表

            GenerateNumbers(); //在数据层和渲染层生成随机2或4
        }

        public void ModuleDestroy()
        {

        }

        public void ModuleUpdate()
        {
            GamePlay();
        }

        public void RenewBlank()//从数据层更新空格数据
        {
            blank.Clear();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (numbers_data[i, j].GetLastNum() == 0)
                    {
                        blank.Add(new Vector2(i, j));
                    }
                }
            }
        }

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

                numbers_data[(int)v.x, (int)v.y].SetLastNum(num);
                numbers_data[(int)v.x, (int)v.y].SetCurrentNum(num);
                numbers_data[(int)v.x, (int)v.y].SetCurrentIndex(v);
                numbers_data[(int)v.x, (int)v.y].SetLastIndex(v);
                numbers_data[(int)v.x, (int)v.y].SetMergeIndex(v);
                numbers_data[(int)v.x, (int)v.y].SetMerge(true);

                numbers[(int)v.x, (int)v.y].SetNumber(num);
                RenewBlank();
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
                            Debug.Log("right");
                            ShowCurrentData();
                            ShowCurrentDataInfo();
                            MoveRight();
                            ShowCurrentData();
                            ShowCurrentDataInfo();
                            playerstate = State.PlayerWait;
                            break;
                        case InputProtocol.MoveLeft:
                            Debug.Log("left");
                            ShowCurrentData();
                            ShowCurrentDataInfo();
                            MoveLeft(); //计算结果
                            ShowCurrentData();
                            ShowCurrentDataInfo();
                            playerstate = State.PlayerWait;
                            break;
                        case InputProtocol.MoveUp:
                            Debug.Log("up");
                            ShowCurrentData();
                            ShowCurrentDataInfo();
                            MoveUp();//计算结果
                            ShowCurrentData();
                            ShowCurrentDataInfo();
                            playerstate = State.PlayerWait;
                            break;
                        case InputProtocol.MoveDown:
                            ShowCurrentData();
                            ShowCurrentDataInfo();
                            MoveDown();//计算结果
                            ShowCurrentData();
                            ShowCurrentDataInfo();
                            playerstate = State.PlayerWait;
                            break;
                    }
                    break;
                case State.PlayerWait:

                    if (waitTime > 0)
                    {
                        NumberAnimate(2.5f);
                        waitTime -= Time.deltaTime;
                    }
                    else
                    {
                        GenerateNumbers();
                        waitTime = 1.2f;
                        playerstate = State.PlayerInput;

                        ShowCurrentData();
                        ShowCurrentDataInfo();
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
                for (int j = 1; j < size; j++)
                {
                    Number current = numbers_data[i, j];
                    DataMoveToEnd(current, "left");
                }
            }
        }

        public void MoveUp()
        {
            for (int j = 0; j < size; j++)
            {
                for (int i = size -2 ; i >= 0; i--)
                {
                    Number current = numbers_data[i, j];
                    DataMoveToEnd(current, "up");
                }
            }
        }

        public void MoveDown()
        {
            for (int j = 0; j < size; j++)
            {
                for (int i = 1; i < size; i++)
                {
                    Number current = numbers_data[i, j];
                    DataMoveToEnd(current, "down");
                }
            }
        }

        public bool DataMove(Number number, Vector2 dest)
        {
            if (number.GetCurrentIndex() == dest ||
                number.GetCurrentNum() == 0 ||
                numbers_data[(int)dest.x, (int)dest.y].GetCurrentNum() != 0)
            {
                return false;
            }
            else 
            {
                Vector2 lastIndex = number.GetCurrentIndex();
                number.SetCurrentIndex(dest);

                //更新数据层
                numbers_data[(int)dest.x, (int)dest.y] = number;
               

                Number newNum = new Number();

                newNum.SetCurrentIndex(lastIndex);
                newNum.SetLastIndex(lastIndex);
                newNum.SetMergeIndex(lastIndex);
                newNum.SetCurrentNum(0);
                newNum.SetLastNum(0);
                newNum.SetMerge(true);
                numbers_data[(int)lastIndex.x, (int)lastIndex.y] = newNum;

                return true;
            }
        }

        //数据层单元Merge
        public bool DataMerge(Number number, Number dest)
        {
            if (number.GetCurrentIndex() == dest.GetCurrentIndex() ||
                number.GetCurrentNum() != dest.GetCurrentNum() ||
                number.GetCurrentNum() == 0 || dest.GetMerge() == false || number.GetMerge() == false)
            {
                return false ;
            }
            else
            {
                int num1 = number.GetCurrentNum();
                int num2 = dest.GetCurrentNum();

                Vector2 lastIndex = number.GetCurrentIndex();
                Vector2 destIndex = dest.GetCurrentIndex();
                number.SetCurrentIndex(destIndex);
                number.SetCurrentNum(num1 + num2);

                number.SetMerge(false);
                //如果被融合数字之前有移动，则最终融合数字需要记录两个Index: 1.该数字的LastIndex， 2.被融合数字的LastIndex
                //否则判定被融合数字没有移动，动画只从当前number开始，也就是mergeIndex == lastIndex的情况
                if (dest.GetCurrentIndex() != dest.GetLastIndex())
                {
                    number.SetMergeIndex(dest.GetLastIndex());
                }

                //更新数据层
                numbers_data[(int)destIndex.x, (int)destIndex.y] = number;
                

                Number newNum = new Number();

                newNum.SetCurrentIndex(lastIndex);
                newNum.SetLastIndex(lastIndex);
                newNum.SetMergeIndex(lastIndex);
                newNum.SetCurrentNum(0);
                newNum.SetLastNum(0);
                newNum.SetMerge(true);
                numbers_data[(int)lastIndex.x, (int)lastIndex.y] = newNum;
                return true;
            }
        }

        //数据层：单个数字向后方的数字做判断，能合并择合并，不能合并则移动，不能移动则移动到后边数字CurrentIndex的前一位（如果前一位是自己，则不移动）
        public int DataMoveToEnd(Number number, string orien)
        {
            int x = (int)number.GetCurrentIndex().x;
            int y = (int)number.GetCurrentIndex().y;
            int count = 0;
            //Debug.Log("x:" + x + " y:" + y);

            switch (orien)
            {
                case "right":
                    for (int i = y + 1; i < size; i ++)
                    {
                        //Debug.Log("    " + "x:" + x + " y:" + y + "          " + i);

                        if (DataMerge(number, numbers_data[x, i]))
                        {
                            //Debug.Log("merge" + "to" + i);
                            count++;
                        }
                        else
                        {
                            if (DataMove(number, new Vector2(x, i)))
                            {
                                //Debug.Log("move" + "to" + i);
                                count++;
                            }
                            else
                                break;
                        }
                    }

                    break;


                case "left":
                    for (int i = y - 1; i >= 0; i--)
                    {
                        //Debug.Log("    " + "x:" + x + " y:" + y + "          " + i);

                        if (DataMerge(number, numbers_data[x, i]))
                        {
                            //Debug.Log("merge" + "to" + i);
                            count++;
                        }
                        else
                        {
                            if (DataMove(number, new Vector2(x, i)))
                            {
                                //Debug.Log("move" + "to" + i);
                                count++;
                            }
                            else
                                break;
                        }
                    }
                    break;
                case "up":
                    for (int i = x + 1; i < size; i++)
                    {
                        //Debug.Log("    " + "x:" + x + " y:" + y + "          " + i);

                        if (DataMerge(number, numbers_data[i, y]))
                        {
                            //Debug.Log("merge" + "to" + i);
                            count++;
                        }
                        else
                        {
                            if (DataMove(number, new Vector2(i, y)))
                            {
                                //Debug.Log("move" + "to" + i);
                                count++;
                            }
                            else
                                break;
                        }
                    }
                    break;
                case "down":
                    for (int i = x - 1; i >= 0; i--)
                    {
                        //Debug.Log("    " + "x:" + x + " y:" + y + "          " + i);

                        if (DataMerge(number, numbers_data[i, y]))
                        {
                            //Debug.Log("merge" + "to" + i);
                            count++;
                        }
                        else
                        {
                            if (DataMove(number, new Vector2(i, y)))
                            {
                                //Debug.Log("move" + "to" + i);
                                count++;
                            }
                            else
                                break;
                        }
                    }

                    break;
                default:
                    break;
            }

            return count;
        }
        //====数据层无动画逻辑结束====

        //====渲染层动画逻辑开始====
        public void NumberAnimate(float speed)
        {
            for (int i = 0; i < size; i ++)
            {
                for (int j = size - 1; j >= 0; j --)
                {
                    if (numbers_data[i, j].GetMergeIndex() != numbers_data[i, j].GetLastIndex())
                    {
                        Vector2 lastIndex = numbers_data[i, j].GetMergeIndex();
                        Vector2 destIndex = numbers_data[i, j].GetCurrentIndex();

                        Vector2 direct = (destIndex - lastIndex).normalized;
                        Vector2 currentPos = numbers[(int)lastIndex.x, (int)lastIndex.y].GetCurrentPos();

                        currentPos += direct * speed * Time.deltaTime * Mathf.Abs(destIndex.x + destIndex.y - lastIndex.x - lastIndex.y);
                        numbers[(int)lastIndex.x, (int)lastIndex.y].SetPosition(currentPos);

                        if (Mathf.Abs((destIndex - currentPos).magnitude) < 0.06)
                        {
                            int res = numbers_data[i, j].GetCurrentNum();

                            //更新动画层
                            GameFramework.singleton.getGameRender().DestroyObject(numbers[(int)lastIndex.x, (int)lastIndex.y]);

                            INumberObject newNumber = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, size) as INumberObject;
                            newNumber.SetIndex(lastIndex);
                            newNumber.SetLastIndex(lastIndex);
                            newNumber.SetNumber(0);
                            newNumber.SetPosition(lastIndex);
                            numbers[(int)lastIndex.x, (int)lastIndex.y] = newNumber;
                            numbers_data[i, j].SetMergeIndex(destIndex);
                        }

                    }

                    //移动非移动过的合并number
                    if (numbers_data[i, j].GetCurrentIndex() != numbers_data[i, j].GetLastIndex())
                    {
                        Vector2 destIndex = numbers_data[i, j].GetCurrentIndex();
                        Vector2 lastIndex = numbers_data[i, j].GetLastIndex();

                        Vector2 direct = (destIndex - lastIndex).normalized;
                        Vector2 currentPos = numbers[(int)lastIndex.x, (int)lastIndex.y].GetCurrentPos();

                        currentPos += direct * speed * Time.deltaTime * Mathf.Abs(destIndex.x + destIndex.y - lastIndex.x - lastIndex.y);
                        numbers[(int)lastIndex.x, (int)lastIndex.y].SetPosition(currentPos);

                        if (Mathf.Abs((destIndex - currentPos).magnitude) < 0.06)
                        {
                            int res = numbers_data[i, j].GetCurrentNum();

                            //更新动画层
                            GameFramework.singleton.getGameRender().DestroyObject(numbers[i, j]);

                            INumberObject number = numbers[(int)lastIndex.x, (int)lastIndex.y];
                            number.SetPosition(destIndex);
                            number.SetNumber(res);
                            numbers[i, j] = number;
                            INumberObject newNumber = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, size) as INumberObject;
                            newNumber.SetIndex(lastIndex);
                            newNumber.SetLastIndex(lastIndex);
                            newNumber.SetNumber(0);
                            newNumber.SetPosition(lastIndex);
                            numbers[(int)lastIndex.x, (int)lastIndex.y] = newNumber;

                            ////更新数据层
                            numbers_data[i, j].SetLastIndex(destIndex);
                            numbers_data[i, j].SetMergeIndex(destIndex);
                            numbers_data[i, j].SetMerge(true);

                            //ShowCurrentDataInfo();
                        }
                    }
                }
            }
        }

        //====渲染层动画逻辑结束


        public void ShowLastData()
        {
            Debug.Log(numbers_data[3, 0].GetLastNum() + " " + numbers_data[3, 1].GetLastNum() + " "
            + numbers_data[3, 2].GetLastNum() + " " + numbers_data[3, 3].GetLastNum());

            Debug.Log(numbers_data[2, 0].GetLastNum() + " " + numbers_data[2, 1].GetLastNum() + " " +
               numbers_data[2, 2].GetLastNum() + " " + numbers_data[2, 3].GetLastNum());
            Debug.Log(numbers_data[1, 0].GetLastNum() + " " + numbers_data[1, 1].GetLastNum() + " " +
              numbers_data[1, 2].GetLastNum() + " " + numbers_data[1, 3].GetLastNum());
            Debug.Log(numbers_data[0, 0].GetLastNum() + " " + numbers_data[0, 1].GetLastNum() + " " +
              numbers_data[0, 2].GetLastNum() + " " + numbers_data[0, 3].GetLastNum());
            Debug.Log(" ");
        }

        public void ShowCurrentData()
        {
            Debug.Log(numbers_data[3, 0].GetCurrentNum()  + " " + numbers_data[3, 1].GetCurrentNum()  + " "
                + numbers_data[3, 2].GetCurrentNum()  + " " + numbers_data[3, 3].GetCurrentNum() ) ;
            Debug.Log(numbers_data[2, 0].GetCurrentNum() + " " + numbers_data[2, 1].GetCurrentNum() + " "
               + numbers_data[2, 2].GetCurrentNum()  + " " + numbers_data[2, 3].GetCurrentNum());
            Debug.Log(numbers_data[1, 0].GetCurrentNum()  + " " + numbers_data[1, 1].GetCurrentNum()  + " "
                + numbers_data[1, 2].GetCurrentNum()  + " " + numbers_data[1, 3].GetCurrentNum());
            Debug.Log(numbers_data[0, 0].GetCurrentNum()  + " " + numbers_data[0, 1].GetCurrentNum() + " "
                + numbers_data[0, 2].GetCurrentNum() + " " + numbers_data[0, 3].GetCurrentNum() );
            Debug.Log(" ");
        }

        public void ShowCurrentDataInfo()
        {
            Debug.Log("[" + " (" + numbers_data[3, 0].GetCurrentIndex() + ") " + " (" + numbers_data[3, 0].GetLastIndex() + ") " + " (" + numbers_data[3, 0].GetMergeIndex() + ") " + "]  " + 
                      "[" + " (" + numbers_data[3, 1].GetCurrentIndex() + ") " + " (" + numbers_data[3, 1].GetLastIndex() + ") " + " (" + numbers_data[3, 1].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[3, 2].GetCurrentIndex() + ") " + " (" + numbers_data[3, 2].GetLastIndex() + ") " + " (" + numbers_data[3, 2].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[3, 3].GetCurrentIndex() + ") " + " (" + numbers_data[3, 3].GetLastIndex() + ") " + " (" + numbers_data[3, 3].GetMergeIndex() + ") " + "]  ");


            Debug.Log("[" + " (" + numbers_data[2, 0].GetCurrentIndex() + ") " + " (" + numbers_data[2, 0].GetLastIndex() + ") " + " (" + numbers_data[2, 0].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[2, 1].GetCurrentIndex() + ") " + " (" + numbers_data[2, 1].GetLastIndex() + ") " + " (" + numbers_data[2, 1].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[2, 2].GetCurrentIndex() + ") " + " (" + numbers_data[2, 2].GetLastIndex() + ") " + " (" + numbers_data[2, 2].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[2, 3].GetCurrentIndex() + ") " + " (" + numbers_data[2, 3].GetLastIndex() + ") " + " (" + numbers_data[2, 3].GetMergeIndex() + ") " + "]  ");

            Debug.Log("[" + " (" + numbers_data[1, 0].GetCurrentIndex() + ") " + " (" + numbers_data[1, 0].GetLastIndex() + ") " + " (" + numbers_data[1, 0].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[1, 1].GetCurrentIndex() + ") " + " (" + numbers_data[1, 1].GetLastIndex() + ") " + " (" + numbers_data[1, 1].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[1, 2].GetCurrentIndex() + ") " + " (" + numbers_data[1, 2].GetLastIndex() + ") " + " (" + numbers_data[1, 2].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[1, 3].GetCurrentIndex() + ") " + " (" + numbers_data[1, 3].GetLastIndex() + ") " + " (" + numbers_data[1, 3].GetMergeIndex() + ") " + "]  ");

            Debug.Log("[" + " (" + numbers_data[0, 0].GetCurrentIndex() + ") " + " (" + numbers_data[0, 0].GetLastIndex() + ") " + " (" + numbers_data[0, 0].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[0, 1].GetCurrentIndex() + ") " + " (" + numbers_data[0, 1].GetLastIndex() + ") " + " (" + numbers_data[0, 1].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[0, 2].GetCurrentIndex() + ") " + " (" + numbers_data[0, 2].GetLastIndex() + ") " + " (" + numbers_data[0, 2].GetMergeIndex() + ") " + "]  " +
                      "[" + " (" + numbers_data[0, 3].GetCurrentIndex() + ") " + " (" + numbers_data[0, 3].GetLastIndex() + ") " + " (" + numbers_data[0, 3].GetMergeIndex() + ") " + "]  ");

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

