using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace WP
{
    public enum GameState
    {
        //游戏状态
        Gaming,
        End,
        None,
    }

    public enum UserState
    {
        PlayerInput,
        Wait,
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
        private int   gameSize = 4;
        private float speed_move = 0.5f;
        private float waitTime;
        private float move1Time;
        private float mergeTime;
        private float move2Time;

        private GameState gameState;
        private UserState userState;

        private INumberObject[,] numbers;
        private NumberData[,] numbers_data;

        private List<Vector2> blank;

        public void ModuleInit()
        {
            gameState = GameState.None;
            userState = UserState.None;
            numbers = new INumberObject[gameSize, gameSize];
            numbers_data = new NumberData[gameSize, gameSize];

            move1Time = waitTime / 3;
            mergeTime = waitTime / 3;
            move2Time = waitTime / 3;

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
            switch (userState)
            {
                case UserState.Wait:
                    if (waitTime > 0.0f)
                    {
                        waitTime -= Time.deltaTime;
                    }
                    else
                    {
                        userState = UserState.PlayerInput;
                        waitTime = 0.5f;
                    }
                    break;
                case UserState.PlayerInput:
                    PlayerMove();



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
                    numbers[i, j] = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
                    numbers[i, j].SetNumber(0);
                    numbers[i, j].SetPosition(new Vector2(i, j));

                    numbers_data[i, j] = new NumberData(0, new Vector2(i, j));

                    blank.Add(new Vector2(i, j));
                }
            }

            GenarateRandomNumbers();

            userState = UserState.PlayerInput;
        }

        public bool GenarateRandomNumbers()
        {
            int[] nums = { 2, 4 };

            for (int i = 0; i < 2; i ++)
            {            
                int index = Random.Range(0, blank.Count);

                if (index >= 0)
                {
                    Vector2 v = blank[index];
                    blank.RemoveAt(index);

                    int num = nums[Random.Range(0, 1)];

                    numbers[(int)v.x, (int)v.y].SetNumber(num);
                    RenewNumbersData();

                }
                else
                {
                    Debug.Log("There is no space in checkboard! Can't genarate numbers!");
                    return false;
                }
            }
            return true;
        }

        public INumberObject CreateNumber(int number, Vector2 index)
        {
            INumberObject numberOb = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
            numberOb.SetPosition(index);
            numberOb.SetNumber(number);

            return numberOb;
        }

        public void PlayerMove()
        {
            switch (GameFramework.singleton.getInput().GetInputData())
            {
                case InputProtocol.MoveUp:
                    NumbersUp();
                    break;
                case InputProtocol.MoveDown:
                    NumbersDown();
                    break;
                case InputProtocol.MoveRight:
                    NumbersRight();
                    break;
                case InputProtocol.MoveLeft:
                    NumbersLeft();
                    break;
                default:
                    break;
            }

        }

        public void NumbersUp()
        {




        }

        public void NumbersDown()
        {

        }

        public void NumbersRight() //在此帧中，以数据层计算所有的numbers，并完成动画函数的调用,动画结束后更新numbersdata数据层
        {
            for (int i = 0; i < gameSize; i ++) //此帧遍历每一行
            {
                bool isMove1Done = false;
                bool isMergeDone = false;
                bool isMove2Done = false;

                //位移1
                while (!isMove1Done)
                {
                    bool[] isdone = new bool[gameSize - 2];
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

                            isdone[j] = MoveNumber(numbers, new Vector2(i, j), new Vector2(i, j + empty)); //移动完成以后已经更改了显示层
                            if (isdone[j])//更新数据层
                            {
                                RenewNumbersData(numbers, numbers_data);
                            }
                                                        
                            INumberObject zero = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
                            zero.SetNumber(0);
                            zero.SetPosition(new Vector2(i, j));

                        }
                        else
                            continue;
                    }

                    foreach (bool b in isdone)
                    {
                        if (b == true)
                        {
                            doneNum += 1;
                        }
                    }

                    if (doneNum == gameSize - 2)
                    {
                        isMove1Done = true;
                    }

                }

                //合并
                while (isMove1Done && !isMergeDone)
                {
                    //位移1完成后，合并
                    for (int m = gameSize - 2; m >= 0; m--)
                    {



                    }
                }



                //合并完成后，位移2


            }
        }

        public void NumbersLeft()
        {

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
        public bool MoveNumber(INumberObject[,] numbers, Vector2 origin, Vector2 dest)
        {
            INumberObject current_o = numbers[(int)origin.x, (int)origin.y];
            INumberObject current_d = numbers[(int)dest.x, (int)dest.y];

            Vector2 pos_current = current_o.GetCurrentPos();

            Vector2 dir_origin = dest - pos_current;

            if (Mathf.Abs(dir_origin.magnitude) > 0.001)
            {
                pos_current += dir_origin * speed_move * Time.deltaTime;

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
        public bool Merge(INumberObject[,] numbers, Vector2 origion, Vector2 dest)
        {
            if (MoveNumber(numbers, origion, dest))
            {
                int res = numbers[(int)dest.x, (int)dest.y].GetNumber() + numbers[(int)origion.x, (int)origion.y].GetNumber();
                numbers[(int)dest.x, (int)dest.y].SetNumber(res);
                numbers[(int)origion.x, (int)origion.y].SetNumber(0);
            }

            return false;
        }
    }

}


