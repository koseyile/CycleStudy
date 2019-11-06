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
        None,
    }

    public class wupGameCore : IGameCore
    {
        private GameState gameState;
        private UserState userState;
        private int score;


        private ICheckBoardObject  checkBoard;
        private INumberObject[]    numbers; 

        public wupGameCore() { }


        public void ModuleInit()
        {
            //初始化游戏状态
            gameState = GameState.None;
            userState = UserState.None;

            //创建棋盘
            GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateCheckBoardObject);
            
        }

        public void BeginGame()
        {
            //更新游戏状态
            gameState = GameState.Gaming;

            //随机位置创建最初数字

        }

        public void ModuleDestroy()
        {
            
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
                case GameState.End:
                    GameEnd();
                    gameState = GameState.None;
                    break;
            }

        }

        //游戏逻辑
        public void GamePlay()
        {

        }

        //游戏结束：计分，结束动画
        public void GameEnd()
        {

            //Render模块生成游戏结束UI

        }


        public void CreateNumber(int number, int i)
        {

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

        }

        public void NumbersLeft()
        {

        }


    }

}


