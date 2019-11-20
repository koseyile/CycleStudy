using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBHW14 {


    public class GameCell
    {
        private Vector2 pos;
        private int num;


        public GameCell(Vector2 pos, int n)
        {
            this.pos = pos;
            this.num = n;
        }


        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public Vector2 Pos { get => pos; set => pos = value; }

        public void Merge()
        {

        }

        public void DestroySelf()
        {

        }

        public override string ToString()
        {

            return num.ToString();
        }
    }
    
}