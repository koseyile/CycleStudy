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
        End,
        None,
    }

    public enum UserState
    {
        PlayerInput,
        Wait,
        None,
    }

    public class wupGameCore : IGameCore
    {
        private int gameSize = 4;
        private float speed_move = 0.5f;

        private GameState gameState;
        private UserState userState;
        private int score;

        private INumberObject[,] numbers;
        private Vector2[,] blank;

        public void ModuleInit()
        {
            gameState = GameState.None;
            userState = UserState.None;
            numbers = new INumberObject[gameSize, gameSize];


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

        public void Begin()
        {
            for (int i = 0; i < gameSize; i++)
            {
                for (int j = 0; j < gameSize; j++)
                {
                    numbers[i, j] = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
                    blank[i, j] = new Vector2(i, j);
                }
            }

            Vector2 first = new Vector2(Random.Range(0, 4), Random.Range(0, 4));
            Vector2 second = new Vector2(Random.Range(0, 4), Random.Range(0, 4)); 

            while (second == first)
            {
                second = new Vector2(Random.Range(0, 4), Random.Range(0, 4));
            }


                

        }


        public void FillBlank(Vector2)
        {

        }


        //游戏逻辑
        public void GamePlay()
        {

        }




        public void CreateNumber(int number, Vector2 index)
        {
            //在棋盘特定位置创建特定数字
            INumberObject numberOb = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject) as INumberObject;
            numberOb.SetPosition(index);
            numberOb.SetNumber(number);
        }

        public void ClearNumber(int[,] index)
        {
            //清理numbers上特定

        }

        //移动数字
        public void Move()
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
            //判断，更新数组

            //调用Render模块，更新显示
        }

        public void NumbersDown()
        {

        }

        public void NumbersRight()
        {
            //伪代码
            for ()
            {
                Move();
                Merge();
                Move();
            }
        }

        public void NumbersLeft()
        {

        }

        //交换完成返回true,未完成返回false
        public bool Swap(INumberObject number1, INumberObject number2)
        {
            Vector2 index1 = number1.GetLastPos();
            Vector2 index2 = number2.GetLastPos();

            bool done1 = MoveNumber(number1, index2, true);
            bool done2 = MoveNumber(number2, index1, true);
            
            if (done1 && done2)
            {
                number1.ResetLastPos(index1);
                number2.ResetLastPos(index2);
                return true;
            }

            return false;
        }

        //合并完成返回true,未完成返回false
        public bool Merge(INumberObject source, INumberObject dest)
        {
            Vector2 index_source = source.GetLastPos();
            Vector2 index_des = dest.GetCurrentPos();

            if (MoveNumber(source, index_des, false))
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
        public bool MoveNumber(INumberObject number, Vector2 pos_dest, bool complexMove)
        {
            Vector2 pos_current = number.GetCurrentPos();
            Vector2 direction = pos_dest - pos_current;

            if (Mathf.Abs(direction.magnitude) > 0.001)
            {
                pos_current += direction * speed_move * Time.deltaTime;

                number.SetPosition(pos_current);

                return false;
            }

            if (!complexMove)
            {
                number.ResetLastPos(pos_dest);
            }

            number.SetPosition(pos_dest);
            return true;
        }

        public float Distance(Vector2 v1, Vector2 v2)
        {
            Vector2 v3 = v1 - v2;
            return Mathf.Sqrt(v3.x * v3.x + v3.y + v3.y);
        }
    }

}


