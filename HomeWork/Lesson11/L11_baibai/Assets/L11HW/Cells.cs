using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BAIBAI11 {

    //3.编写一个class A，输入为上述prefab和旋转速度，编写一个卡片绕X轴旋转的动画函数。
    public class BoardCell
    {

        protected GameObject unitCell;

        protected Vector3 currentE;
        protected float speed = 0f;

        static public float width = 12f;
        static public float height = 18f;

        public BoardCell(GameObject _prefab, Vector3 _pos, float sp) {
            unitCell = Object.Instantiate(_prefab, _pos, Quaternion.identity);
            currentE = unitCell.transform.eulerAngles;
            speed = sp;
            //width = unitCell.transform.GetChild(1).GetComponent<Transform>().localScale.x * 2f;
            //height = unitCell.transform.GetChild(1).GetComponent<Transform>().localScale.y * 2f;
        }

        public virtual void CellRotate() {

            currentE.x += speed * 360f * Time.deltaTime;
            currentE.x = currentE.x % 360f;
            unitCell.transform.eulerAngles = currentE;
            //Debug.Log("unit" + unitCell.transform.eulerAngles);
        }

        //5.文本函数，可改变正反两面的文本
        public void UpdateFace(string face, string back) {
            unitCell.transform.GetChild(0).GetComponent<TextMesh>().text = back;
            unitCell.transform.GetChild(2).GetComponent<TextMesh>().text = face;
        }

        public virtual void RandomFace() {
            int x = Random.Range(0, 10);
            int y = Random.Range(0, 10);
            Debug.Log("change text: " + x + ", " + y);
            UpdateFace(x.ToString(), y.ToString());
        }
    }



    //6.编写一个class B继承自A，请自由发挥，为class B赋予这样的功能：每旋转一次，卡片的文本会变化。WIP
    // 改： 使用statemachine？ flip/ flop/ idle /increment above
    // 存入text变量存储秒、分钟等

    public class TimeCell : BoardCell
    {
        private bool flip = false;
        private int currentNum;
        private int nextNum;

        public TimeCell(GameObject _prefab, Vector3 _pos, float sp) : base(_prefab, _pos, sp)
        {

        }

        public override void CellRotate()
        {
            currentE.x += speed * 360f * Time.deltaTime;
            //currentE.x = currentE.x % 360f;

            if (currentE.x > 360f || currentE.x < -360f)
            {
                currentE.x = currentE.x % 360f;
                RandomFace();
            }


            unitCell.transform.eulerAngles = currentE;
            //Debug.Log("unit" + unitCell.transform.eulerAngles);
        }

        public void SetInitalFace() {
            currentNum = 0;
            nextNum = currentNum + 1;
            UpdateFace(currentNum.ToString(),nextNum.ToString());
        }

        //public void UpdateFace() {
        //    currentNum = (nextNum + 1) % 10;
        //    nextNum = (currentNum + 1) % 10;
        //    UpdateFace(currentNum.ToString(), nextNum.ToString());
        //}

        public void SetFlip(bool b) {
            flip = b;
        }

        public bool GetFlip() {
            return flip;
        }

        public void Turn()
        {
            if (flip) {
                Debug.Log(currentE.x);
                currentE.x += -2* 360 * Time.deltaTime;



                if ((currentE.x + 180f) > -5f && (currentE.x + 180f) < 5f ) {
                    //currentE.x = -184f;
                    Debug.Log("turning1");
                    flip = false;
                    currentNum = (nextNum + 1)%10;
                    UpdateFace(currentNum.ToString(), nextNum.ToString());
                }

                if ((currentE.x + 360f) > -5f && (currentE.x + 360f) < 5f )
                {
                    //currentE.x = -364f;
                    Debug.Log("turning2");
                    flip = false;
                    nextNum = (currentNum + 1)%10;
                    UpdateFace(currentNum.ToString(), nextNum.ToString());
                }


                unitCell.transform.eulerAngles = currentE;
                currentE.x = currentE.x % 360f;
            }
        }


    }

    //8.编写一个class C继承自A，请自由发挥，为class C赋予这样的功能：每旋转一次，卡片的文本会自加一次。（假设文本只能显示数字和字母）
    public class RanSpeedCell : BoardCell
    {
        static string textDisplay = "0123456789ABCDEFGHIJKOPQRSTUVWXYZ";

        public RanSpeedCell(GameObject _prefab, Vector3 _pos, float sp) : base(_prefab, _pos, sp)
        {
        }

        public override void CellRotate()
        {
            currentE.x += speed * 360f * Time.deltaTime;
            //currentE.x = currentE.x % 360f;

            if (currentE.x > 360f || currentE.x < -360f)
            {
                currentE.x = currentE.x % 360f;
                RandomFace();
            }

            unitCell.transform.eulerAngles = currentE;
            //Debug.Log("unit" + unitCell.transform.eulerAngles);
        }

        public override void RandomFace()
        {
            int x = Random.Range(0, textDisplay.Length);
            int y = Random.Range(0, textDisplay.Length);
            Debug.Log("change text: " + x + ", " + y);
            UpdateFace(textDisplay[x].ToString(), textDisplay[y].ToString());
        }
    }

}
