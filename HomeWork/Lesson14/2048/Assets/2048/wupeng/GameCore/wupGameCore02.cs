using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;


namespace WP02
{
    public enum GameState
    {
        PlayerInput,
        PlayerWait,

        NumbersUp,
        NumbersDown,
        NumbersLeft,
        NumbersRighgt,

        None,
    }

    public class NumberData    //数据层
    {
        public Vector2 index;
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

    public class wupGameCore02 : IGameCore
    {
        private int size;
        private NumberData[,] numbers;
        private List<Vector2> blank;
        private float waitTime;
        private GameState gamestate;
        private GameState playerstate;

        public void ModuleInit()
        {
            size = 4;
            numbers = new NumberData[4, 4];

            for (int i = 0; i < size; i ++)
            {
                for (int j = 0; j< size; j++)
                {
                    numbers[i, j] = new NumberData(0, new Vector2(i, j));
                }
            }
        }

        public void ModuleDestroy()
        {
            throw new System.NotImplementedException();
        }

        public void ModuleUpdate()
        {
            throw new System.NotImplementedException();
        }

        public bool Move(NumberData number, Vector2 dest, float speed)
        {
            if ((dest - number.GetIndex()).sqrMagnitude > 0.005)
            {
                number.SetIndex(number.GetIndex() + speed * (dest - number.GetIndex() * Time.deltaTime));
                return false;
            }
            else
            {
                number.SetIndex(dest);
                return true;
            }
        }
        
    }

}
