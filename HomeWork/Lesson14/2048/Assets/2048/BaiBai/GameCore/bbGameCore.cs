using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace BBHW14
{
    public class bbGameCore : IGameCore
    {
        private RenderProtocol gameSize = RenderProtocol.X44;
        private INumberObject[,] board;
        private bool gameOver;
        private int initialCell = 2;

        public int InitialCell { get => initialCell; set => initialCell = value; }


        public void ModuleInit()
        {
            InitiateBoard();

            InitializeGame(InitialCell);

            gameOver = false;
        }

        public void ModuleDestroy()
        {
            gameOver = true;
        }

        public void ModuleUpdate()
        {
            Move();
            Merge();
            Move();
        }


        // setup the game grid
        private void InitiateBoard() {
            int boardSize = 0;

            switch (gameSize)
            {
                case RenderProtocol.X44:
                    boardSize = 4;
                    break;
                case RenderProtocol.X66:
                    boardSize = 6;
                    break;
                default:
                    boardSize = 4;
                    break;
            }

            board = new INumberObject[boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i,j] = null;
                }
            }

        }

        // start the game by randomly generating "p" cells on the board 
        public void InitializeGame(int p)
        {

            while (p > 0)
            {

                Vector2Int rndPos = GetRamdonPos();

                int initVal = GetRamdonVal();

                if (board[rndPos.x,rndPos.y] == null)
                {
                    INumberObject iNumberObj = GameFramework.singleton.getGameRender().CreateObject(RenderProtocol.CreateNumberObject, 4) as INumberObject;
                    iNumberObj.SetPosition(new Vector3(100 * rndPos.x, 100 * rndPos.y, 0));
                    iNumberObj.SetNumber(initVal);

                    board[rndPos.x, rndPos.y] = iNumberObj;
                }

                p -= 1;
            }

            Debug.Log("Game start!");

        }

        // helper function: get a random position on the board
        private Vector2Int GetRamdonPos()
        {
            int row = Random.Range(0, 4);
            int col = Random.Range(0, 4);
            Debug.Log(row + " " + col);

            return new Vector2Int(row, col);
        }

        // helper function: get a random initial value of 2 or 4
        private int GetRamdonVal()
        {
            int val = Random.Range(0, 2);

            if (val == 0)
            {
                return 2;
            }
            else
            {
                return 4;
            }
        }


        private void Merge() {
        }


        private void Move() {



        }


        public RenderProtocol GetGameSize()
        {
            return gameSize;
            //throw new System.NotImplementedException();
        }

        public INumberObject[,] GetNumbers()
        {
            return board;
            //throw new System.NotImplementedException();
        }
    }
}