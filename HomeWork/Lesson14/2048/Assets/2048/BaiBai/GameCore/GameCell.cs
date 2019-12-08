using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;


namespace BBHW14 {

    public class bbNumberObject : INumberObject
    {
        //private INumberObject numData;
        private GameObject numberGameObject;
        private string numberPath = "number";
        private Vector2 index;
        private int num;



        public bbNumberObject()
        {
            GameObject obj = Resources.Load(numberPath) as GameObject;
            numberGameObject = GameObject.Instantiate(obj);
        }

        public Vector2 GetCurrentPos()
        {
            return this.index;
            //throw new System.NotImplementedException();
        }

        public int GetNumber()
        {
            return num;
            //throw new System.NotImplementedException();
        }

        public void SetColor(Color color)
        {

        }

        public void SetNumber(int number)
        {

            this.num = number;
            //throw new System.NotImplementedException();
        }

        public void SetPosition(Vector3 pos)
        {
            Debug.Log(pos);
            //set position
            numberGameObject.transform.position = pos;
        }

        public void SetPosition(Vector2 index)
        {
            this.index = index;
            //throw new System.NotImplementedException();
        }

        public void SetText(string text)
        {
            //set text
        }

        public void SetText(int number)
        {
            throw new System.NotImplementedException();
        }

        public void SetIndex(Vector2 index) { }
        public Vector2 GetIndex() { return new Vector2(); }

        public void SetLastIndex(Vector2 index)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 GetLastIndex()
        {
            throw new System.NotImplementedException();
        }
    }





    public class GameCell: INumberObject
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

        void INumberObject.SetPosition(Vector2 index)
        {
            throw new System.NotImplementedException();
        }

        Vector2 INumberObject.GetCurrentPos()
        {
            throw new System.NotImplementedException();
        }

        void INumberObject.SetNumber(int number)
        {
            throw new System.NotImplementedException();
        }

        int INumberObject.GetNumber()
        {
            throw new System.NotImplementedException();
        }

        void INumberObject.SetColor(Color color)
        {
            throw new System.NotImplementedException();
        }

        public void SetIndex(Vector2 index) { }
        public Vector2 GetIndex() { return new Vector2(); }

        public void SetLastIndex(Vector2 index)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 GetLastIndex()
        {
            throw new System.NotImplementedException();
        }
    }


    
}