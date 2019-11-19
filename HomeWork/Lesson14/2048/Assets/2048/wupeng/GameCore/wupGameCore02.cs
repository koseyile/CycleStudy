using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;


namespace WP
{
    public enum State
    {
        PlayerInput,
        PlayerWait,

        NumbersUp,
        NumbersDown,
        NumbersLeft,
        NumbersRighgt,

        None,
    }

    public class wupGameCore02 : IGameCore
    {
        private int size;
        private INumberObject[,] numbers;
        private List<Vector2> blank;

        private float waitTime;
        private float wait1;
        private float wait2;
        private float wait3;

        private GameState gamestate;
        private GameState playerstate;

        public class Number : INumberObject
        {
            int num;
            Vector2 index;

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
        }

        public void ModuleInit()
        {
            size = 4;
            numbers = new INumberObject[4, 4];
            blank = new List<Vector2>();

            for (int i = 0; i < size; i ++)
            {
                for (int j = 0; j< size; j++)
                {
                    numbers[i, j] = new Number();
                    numbers[i, j].SetNumber(0);
                    numbers[i, j].SetPosition(new Vector2(i, j));
                }
            }

            numbers[0, 0].SetNumber(4);
            numbers[0, 1].SetNumber(2);


            RenewBlank();
            //GenerateNumbers();

            waitTime = 4.0f;
            wait1 = waitTime / 3;
            wait2 = waitTime / 3;
            wait3 = waitTime / 3;

        }

        public void ModuleDestroy()
        {

        }

        public void ModuleUpdate()
        {
            MoveRight();
        }


        public void GamePlay()
        {

        }

        public void MoveRight()
        {
            if (wait1 > 0.0)
            {
                wait1 -= Time.deltaTime;
                for (int i = 0; i < size ; i++)
                {
                    for (int j = size - 2; j >= 0; j--)
                    {
                        if (numbers[i, j].GetNumber() != 0 )
                        {
                            int empty = 0;

                            for (int k = size - 1; k > j; k--)
                            {
                                if (numbers[i, k].GetNumber() == 0)
                                {
                                    empty++;
                                }
                            }

                            float speed = 1 / (waitTime / 3) + empty / (waitTime / 3);
                            Move(new Vector2(i, j), new Vector2(i, j + empty), speed);
                        }
                    }
                }
            }
            else
            {
                wait1 = 0.0f;
            }


       

        }

        public void MoveLeft()
        {

        }

        public void MoveUp()
        {

        }

        public void MoveDonw()
        {

        }

        public void RenewBlank()
        {
            blank.Clear();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (numbers[i, j].GetNumber() == 0)
                    {
                        blank.Add(new Vector2(i, j));
                    }
                }
            }
        }

        public bool GenerateNumbers()
        {
            int[] nums = { 2, 4 };

            if (blank.Count > 0)
            {
                int count = 0;

                if (blank.Count == 1)
                    count = 1;
                else
                    count = 2;

                for (int i = 0; i < count; i ++)
                {
                    int index = Random.Range(0, blank.Count);
                    Vector2 v = blank[index];

                    int num = nums[Random.Range(0, 2)];
                    
                    numbers[(int)v.x, (int)v.y].SetNumber(num);
                    RenewBlank();
                }
            }
            else
            {
                Debug.Log("There is no space in checkboard! Can't genarate numbers!");
                return false;
            }

            return true;
        }

        public bool Move( Vector2 origin, Vector2 dest, float speed)
        {
            if (origin == dest)
            {
                return true;
            }

            INumberObject number = numbers[(int)origin.x, (int)origin.y];

            if ((dest - number.GetCurrentPos()).sqrMagnitude > 0.005)
            {
                number.SetPosition(number.GetCurrentPos() + speed * (dest - number.GetCurrentPos()).normalized * Time.deltaTime);
                return false;
            }
            else
            {
                number.SetPosition(dest);
                numbers[(int)dest.x, (int)dest.y] = number;

                numbers[(int)origin.x, (int)origin.y] = new Number();
                numbers[(int)origin.x, (int)origin.y].SetNumber(0);
                numbers[(int)origin.x, (int)origin.y].SetPosition(origin);
                return true;
            }
        }

        public bool Merge( Vector2 origin, Vector2 dest, float speed)
        {
            if (origin == dest)
            {
                return true;
            }

            INumberObject number = numbers[(int)origin.x, (int)origin.y];
            if ((dest - number.GetCurrentPos()).sqrMagnitude > 0.005)
            {
                number.SetPosition(number.GetCurrentPos() + speed * (dest - number.GetCurrentPos()).normalized * Time.deltaTime);
                return false;
            }
            else
            {
                number.SetPosition(dest);
                number.SetNumber(number.GetNumber() + numbers[(int)dest.x, (int)dest.y].GetNumber());
                numbers[(int)dest.x, (int)dest.y] = number;

                numbers[(int)origin.x, (int)origin.y] = new Number();
                numbers[(int)origin.x, (int)origin.y].SetNumber(0);
                numbers[(int)origin.x, (int)origin.y].SetPosition(origin);
                return true;
            }
        }

        public INumberObject[,] GetNumbers()
        {
            return numbers;
        }
    }

}
