﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace WP
{
    public enum GameState
    {
        //游戏状态
        Gaming,
        PlayerInput,
        NumberAnimation,
        NumbersUp,
        NumbersDown,
        NumbersLeft,
        NumbersRighgt,
        End,
        None,
    }

    public class NumberData    //数据层
    {
        public Vector2  index;
        public int number;
        public NumberData(int number, Vector2 index)
        {
            this.number = number;
            this.index = index;
        }

        public void SetIndex(Vector2 index)
        {
            this.index = index;
        }

        public void SetNumber(int number)
        {
            this.number = number;
        }

        public int GetNumber()
        {
            return this.number;
        }

        public Vector2 GetIndex()
        {
            return this.index;
        }
    }


    public class wupGameCore : IGameCore
    {
        private RenderProtocol Size = RenderProtocol.X44;
        private int   gameSize = 4;
        private float speed_move = 0.5f;
        private float waitTime = 0.6f;


        private float move1Time;
        private float mergeTime;
        private float move2Time;

        private GameState gameState;
        private GameState turn;
        private GameState numbersState;

        private INumberObject[,] numbers;
        private NumberData[,] numbers_data;

        private List<Vector2> blank;

        public void ModuleInit()
        {
            gameState = GameState.None;
            turn = GameState.None;
            numbersState = GameState.None;

            switch (Size)
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

            numbers = new INumberObject[gameSize, gameSize];
            numbers_data = new NumberData[gameSize, gameSize];
            blank = new List<Vector2>();

            Begin();
        }

        public void ModuleUpdate()
        {
            switch (gameState)
            {
                case GameState.None:
                    break;
                case GameState.Gaming:
                    GamePlay(); //执行游戏逻辑
                    break;
            }
        }

        public void ModuleDestroy()
        {

        }

        //游戏逻辑
        public void GamePlay()
        {
            switch (turn)
            {
                case GameState.PlayerInput:
                    switch (GameFramework.singleton.getInput().GetInputData())
                    {
                        case InputProtocol.MoveUp:
                            numbersState = GameState.NumbersUp;
                            turn = GameState.NumberAnimation;
                            break;
                        case InputProtocol.MoveDown:
                            numbersState = GameState.NumbersDown;
                            turn = GameState.NumberAnimation;
                            break;
                        case InputProtocol.MoveLeft:
                            numbersState = GameState.NumbersLeft;
                            turn = GameState.NumberAnimation;
                            break;
                        case InputProtocol.MoveRight:
                            Debug.Log(1111);
                            numbersState = GameState.NumbersRighgt;
                            
                            turn = GameState.NumberAnimation;
                            break;
                        default:
                            numbersState = GameState.None;
                            break;


                    }
                    break;

                case GameState.NumberAnimation:

                    switch (numbersState)
                    {
                        case GameState.NumbersUp:
                            break;
                        case GameState.NumbersDown:
                            break;
                        case GameState.NumbersLeft:
                            break;
                        case GameState.NumbersRighgt:
                            if (NumbersRight())
                            {
                                numbersState = GameState.None;
                                turn = GameState.PlayerInput;
                            }
                            break;
                        default:
                            break;

                    }
                    break;
                default:
                    break;
            }

        }

        public void Begin()
        {
            gameState = GameState.Gaming;

            for (int i = 0; i < gameSize; i++)
            {
                for (int j = 0; j < gameSize; j++)
                {
                    numbers[i, j] = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, 4) as INumberObject;
                    numbers[i, j].SetNumber(0);
                    numbers[i, j].SetPosition(new Vector2(i, j));

                    numbers_data[i, j] = new NumberData(0, new Vector2(i, j));

                    blank.Add(new Vector2(i, j));
                }
            }

            GenarateRandomNumbers();

            turn = GameState.PlayerInput;
        }

        //更新blank, 随机生成数字，更新数据层
        public bool GenarateRandomNumbers()
        {
            for (int i = 0; i < gameSize; i ++)
            {
                for (int j = 0; j < gameSize; j ++)
                {
                    if (numbers[i, j].GetNumber() == 0)
                    {
                        blank.Add(new Vector2(i, j));
                    }
                }
            }

            int[] nums = { 2, 4 };

            for (int i = 0; i < 2; i ++)
            {            
                if (blank.Count > 0)
                {
                    int index = Random.Range(0, blank.Count);
                    Vector2 v = blank[index];
                    blank.RemoveAt(index);

                    int num = nums[Random.Range(0, 1)];

                    numbers[(int)v.x, (int)v.y].SetNumber(num);
                    RenewNumbersData(numbers, numbers_data);

                }
                else
                {
                    Debug.Log("There is no space in checkboard! Can't genarate numbers!");
                    return false;
                }
            }
            return true;
        }


        public void PlayerMove()
        {
            switch (GameFramework.singleton.getInput().GetInputData())
            {
                case InputProtocol.MoveUp:

                    break;
                case InputProtocol.MoveDown:

                    break;
                case InputProtocol.MoveRight:

                    break;
                case InputProtocol.MoveLeft:

                    break;
                default:
                    break;
            }

        }

        public bool NumbersRight() //在此帧中，以数据层计算所有的numbers，进行动画层调用:当每一个动画层number移动或合并结束，更新numbersdata数据层
        {
            int allDoneNum = 0;

            for (int i = 0; i < gameSize; i ++) //此帧遍历每一行
            {
                bool isMove1Done = false;
                bool isMergeDone = false;

                //位移1
                while (!isMove1Done)
                {
                    int doneNum = 0;

                    for (int j = gameSize - 2; j >= 0; j--) // 此帧遍历该行中的后面的元素
                    {
                        if (numbers_data[i, j].GetNumber() != 0) //用数据层做判断
                        {
                            int empty = 0;

                            for (int k = gameSize - 1; k > j; k--)
                            {
                                if (numbers_data[i, k].GetNumber() == 0)
                                {
                                    empty++;
                                }
                            }

                            if (MoveNumber(numbers, new Vector2(i, j), new Vector2(i, j + empty), speed_move * empty))//移动完成以后已经更改了显示层
                            {
                                RenewNumbersData(numbers, numbers_data);
                                doneNum += 1;
                            }

                        }
                        else
                            doneNum += 1;
                    }

                    if (doneNum == gameSize - 1)
                    {
                        isMove1Done = true;
                        allDoneNum += gameSize - 1;
                    }

                }

                //合并
                while (isMove1Done && !isMergeDone)
                {
                    int doneNum = 0;

                    //位移1完成后，合并
                    for (int m = gameSize - 2; m >= 0; m--)
                    {
                        if (numbers_data[i, m].GetNumber() == numbers_data[i, m + 1].GetNumber())
                        {
                            numbers_data[i, m].SetNumber(0);//当合并启动，该位置数据层设置为0
                            if (Merge(numbers, new Vector2(i, m), new Vector2(i, m + 1), speed_move))
                            {
                                RenewNumbersData(numbers, numbers_data);
                                doneNum += 1;
                            }
                        }
                        else
                            doneNum += 1;
                    }

                    if (doneNum == gameSize - 1)
                    {
                        isMergeDone = true;
                        allDoneNum += gameSize - 1;
                    }
                }

                //位移2
                while (isMergeDone)
                {
                    int doneNum = 0;

                    for (int j = gameSize - 2; j >= 0; j--) // 此帧遍历该行中的后面的元素
                    {
                        if (numbers_data[i, j].GetNumber() != 0) //用数据层做判断
                        {
                            int empty = 0;

                            for (int k = gameSize - 1; k > j; k--)
                            {
                                if (numbers_data[i, k].GetNumber() == 0)
                                {
                                    empty++;
                                }
                            }

                            if (MoveNumber(numbers, new Vector2(i, j), new Vector2(i, j + empty), speed_move * empty))//移动完成以后已经更改了显示层
                            {
                                RenewNumbersData(numbers, numbers_data);
                                doneNum += 1;
                            }

                        }
                        else
                            doneNum += 1;
                    }

                    if (doneNum == gameSize - 1)
                    {
                        isMove1Done = true;
                        allDoneNum += gameSize - 1;

                    }
                }               
            }

            if (allDoneNum == (gameSize - 1) * gameSize * 3)
                return true;
            else
                return false;

        }

        //更新数据层
        public bool RenewNumbersData(INumberObject[,] numbers, NumberData[,] datas)
        {
            int row1 = numbers.GetLength(0);
            int col1 = numbers.GetLength(1);

            int row2 = numbers.GetLength(0);
            int col2 = numbers.GetLength(1);

            if (row1 != row2 && col1 != col2)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < row1; i++)
                {
                    for (int j = 0; j < col2; j++)
                    {
                        datas[i, j].SetNumber(numbers[i, j].GetNumber());
                    }

                }
                return true;
            }                 
        }


        //移动完成返回true，未完成返回false
        public bool MoveNumber(INumberObject[,] numbers, Vector2 origin, Vector2 dest, float speed)
        {
            INumberObject current_o = numbers[(int)origin.x, (int)origin.y];
            INumberObject current_d = numbers[(int)dest.x, (int)dest.y];

            Vector2 pos_current = current_o.GetCurrentPos();

            Vector2 dir_origin = dest - pos_current;

            if (Mathf.Abs(dir_origin.magnitude) > 0.001)
            {
                pos_current += dir_origin * speed * Time.deltaTime;

                current_o.SetPosition(pos_current);

                return false;
            }
            else
            {
                current_d.SetPosition(origin);
                numbers[(int)origin.x, (int)origin.y] = current_d;

                current_o.SetPosition(dest);
                numbers[(int)dest.x, (int)dest.y] = current_o;

                return true;
            }
        }


        //合并完成返回true,未完成返回false
        public bool Merge(INumberObject[,] numbers, Vector2 origion, Vector2 dest, float speed)
        {
            if (MoveNumber(numbers, origion, dest, speed))
            {
                int res = numbers[(int)dest.x, (int)dest.y].GetNumber() + numbers[(int)origion.x, (int)origion.y].GetNumber();
                numbers[(int)dest.x, (int)dest.y].SetNumber(res);
                numbers[(int)origion.x, (int)origion.y].SetNumber(0);
                return true;
            }
            else
            {
                return false;
            }
        }


        public RenderProtocol GetGameSize()
        {
            return this.Size;
        }

        public INumberObject[,] GetNumbers()
        {
            throw new System.NotImplementedException();
        }
    }

}


