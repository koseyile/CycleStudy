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
        private float waitTime = 0.5f;

        private GameState gameState;
        private UserState userState;

        private INumberObject[,] numbers;


        private List<Vector2> blank;

        public void ModuleInit()
        {
            gameState = GameState.None;
            userState = UserState.None;
            numbers = new INumberObject[gameSize, gameSize];

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

                    blank.Add(new Vector2(i, j));
                }
            }

            GenarateRandomNumbers();

            userState = UserState.PlayerInput;
        }

        public void GenarateRandomNumbers()
        {
            int[] nums = { 2, 4 };

            for (int i = 0; i < 2; i ++)
            {            
                int index = Random.Range(0, blank.Count);

                if (index >= 0)
                {
                    Vector2 first = blank[index];
                    blank.RemoveAt(index);


                    INumberObject number = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;

                    number.SetNumber(nums[Random.Range(0, 1)]);
                    number.SetPosition(first);
                }
                else
                {
                    Debug.Log("There is no space in checkboard! Can't genarate numbers!");
                }
            }
        }

        public void CreateNumber(int number, Vector2 index)
        {
            INumberObject numberOb = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
            numberOb.SetPosition(index);
            numberOb.SetNumber(number);
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

        public void NumbersRight() //在此帧中，需要对所有的Number进行计算，并完成动画函数的调用
        {
            for (int i = 0; i < gameSize; i ++)
            {
                for (int j = gameSize - 2; j >= 0; j -- ) //所有的行元素做位移
                {
                    if (numbers[i, j].GetNumber() != 0)
                    {
                        int empty = 0;
                        for (int k = gameSize - 1; k > j; k--)
                        {
                            if (numbers[i, k].GetNumber() == 0)
                            {
                                empty++;
                            }
                        }

                        MoveNumber(numbers[i, j], new Vector2(i, j + empty));
                        INumberObject zero =  GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
                        zero.SetNumber(0);
                        zero.SetPosition(new Vector2(i, j));
                    }
                    else
                        continue;
                }//行元素位移完成

                for (int m = gameSize - 2; )//所有行元素判断合并
                {

                }
            }
        }

        public void NumbersLeft()
        {

        }



        //合并完成返回true,未完成返回false
        public bool Merge(INumberObject source, INumberObject dest)
        {
            Vector2 index_source = source.GetLastPos();
            Vector2 index_des = dest.GetCurrentPos();

            if (MoveNumber(source, index_des))
            {
                dest.SetNumber(source.GetNumber() + dest.GetNumber());
                INumberObject newNumber = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;

                newNumber.SetPosition(index_source);
                newNumber.SetNumber(0);
                return true;
            }

            return false;
        }

        //移动完成返回true，未完成返回false
        public bool MoveNumber(INumberObject number, Vector2 pos_dest)
        {
            Vector2 pos_current = number.GetCurrentPos();
            Vector2 direction = pos_dest - pos_current;

            if (Mathf.Abs(direction.magnitude) > 0.001)
            {
                pos_current += direction * speed_move * Time.deltaTime;

                number.SetPosition(pos_current);

                return false;
            }
            number.SetPosition(pos_dest);
            return true;
        }

    }

}


