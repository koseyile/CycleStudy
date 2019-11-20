using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace BBHW14 {

    public class GameGrid 
    {
        private int rowNum;
        private int colNum;
        private Dictionary<Vector2, GameCell> board;
        private bool gameOver;
        private Vector2 offSet;


        // make a game grid of row x col, with "p" initial cells
        public GameGrid(int row, int col, int p)
        {
            this.rowNum = row;
            this.colNum = col;

            this.board = new Dictionary<Vector2, GameCell>();

            InitializeBoard();
            InitializeGame(p);

            Debug.Log(PrintBoard());

        }


        // line heads 
        private Vector2[] GetLineHeads(InputProtocol gameInput)
        {

            switch (gameInput)
            {
                case InputProtocol.MoveUp: // UP
                    Vector2[] upHeads = { new Vector2(0, 0), new Vector2(0, 1), new Vector2(0, 2), new Vector2(0, 3) };
                    return upHeads;
                case InputProtocol.MoveDown: // DOWN
                    Vector2[] downHeads = { new Vector2(3, 0), new Vector2(3, 1), new Vector2(3, 2), new Vector2(3, 3) };
                    return downHeads;
                case InputProtocol.MoveLeft: // LEFT
                    Vector2[] leftHeads = { new Vector2(0, 0), new Vector2(1, 0), new Vector2(2, 0), new Vector2(3, 0) };
                    return leftHeads;
                case InputProtocol.MoveRight: // RIGHT
                    Vector2[] rightHeads = { new Vector2(0, 3), new Vector2(1, 3), new Vector2(2, 3), new Vector2(3, 3) };
                    return rightHeads;
                default:
                    break;
            }

            return null;
        }



        // offset
        private Vector2 GetOffset(InputProtocol gameInput)
        {

            switch (gameInput)
            {
                case InputProtocol.MoveUp: // UP
                    Vector2 upOFF= new Vector2(1, 0);
                    return upOFF;
                case InputProtocol.MoveDown: // DOWN
                    Vector2 downOFF = new Vector2(-1, 0);
                    return downOFF;
                case InputProtocol.MoveLeft: // LEFT
                    Vector2 leftOFF =  new Vector2(0, 1);
                    return leftOFF;
                case InputProtocol.MoveRight: // RIGHT
                    Vector2 rightOFF =  new Vector2(0, -1);
                    return rightOFF;
                default:
                    break;
            }

            return new Vector2(0, 0);
        }



        // input
        private Vector2[] GetLines(InputProtocol gameInput) {


            switch (gameInput)
            {
                case InputProtocol.MoveUp: // UP
                    
                    break;
                case InputProtocol.MoveDown: // DOWN
                    
                    break;
                case InputProtocol.MoveLeft: // LEFT
                    
                    break;
                case InputProtocol.MoveRight: // RIGHT
                    
                    break;
                default:
                    break;
            }

            return null;
        }


        private GameCell[] Move(GameCell[] line) {

            return null;
        }


        private void Merge() {
        }


        // setup the game grid
        private void InitializeBoard() {
            for (int i = 0; i < rowNum; i++) {
                for (int j = 0; j < colNum; j++) {
                    board.Add(new Vector2(i,j), null);
                }
            }
        }

        // start the game by randomly generating "p" cells on the board 
        public void InitializeGame(int p) {

            while (p > 0) {

                Vector2 rndPos = GetRamdonPos();
                int initVal = GetRamdonVal();

                if (board[rndPos] == null)
                {
                    GameCell cel = new GameCell(rndPos, initVal);
                    board[rndPos] = cel;
                }

                p -= 1;
            }

            Debug.Log("Game start!");

        }

        // helper function: get a random position on the board
        private Vector2 GetRamdonPos() {
            int row = Random.Range(0, 4);
            int col = Random.Range(0, 4);
            Debug.Log(row + " " + col);

            return new Vector2(row, col);
        }

        // helper function: get a random initial value of 2 or 4
        private int GetRamdonVal()
        {
            int val = Random.Range(0, 2);

            if (val == 0)
            {
                return 2;
            }
            else {
                return 4;
            }
        }

        // output the board as string

        public string PrintBoard()
        {
            string s = "";

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    Vector2 pos = new Vector2(i, j);
                    if (board[pos] != null)
                    {
                        s += board[pos].Num;
                    }
                    else {
                        s += "0";
                    }


                    if (j == colNum - 1)
                    {
                        s += "\n";
                    }
                    else {
                        s += "  ";
                    }
                }
            }

            return s;
        }
    }


}