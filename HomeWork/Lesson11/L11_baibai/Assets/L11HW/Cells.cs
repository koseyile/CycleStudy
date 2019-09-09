using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BAIBAI11
{

    //3.编写一个class A，输入为上述prefab和旋转速度，编写一个卡片绕X轴旋转的动画函数。
    public class BoardCell
    {

        protected GameObject unitCell;

        protected Vector3 currentE;
        protected float speed = 0f;

        static public float width = 12f;
        static public float height = 18f;

        public BoardCell(GameObject _prefab, Vector3 _pos, float sp)
        {
            unitCell = Object.Instantiate(_prefab, _pos, Quaternion.identity);
            currentE = unitCell.transform.eulerAngles;
            speed = sp;
            //width = unitCell.transform.GetChild(1).GetComponent<Transform>().localScale.x * 2f;
            //height = unitCell.transform.GetChild(1).GetComponent<Transform>().localScale.y * 2f;
        }

        public virtual void CellRotate()
        {

            currentE.x += speed * 360f * Time.deltaTime;
            currentE.x = currentE.x % 360f;
            unitCell.transform.eulerAngles = currentE;
            //Debug.Log("unit" + unitCell.transform.eulerAngles);
        }

        //5.文本函数，可改变正反两面的文本
        public void UpdateFace(string face, string back)
        {
            unitCell.transform.GetChild(0).GetComponent<TextMesh>().text = back;
            unitCell.transform.GetChild(2).GetComponent<TextMesh>().text = face;
        }

        public virtual void RandomFace()
        {
            int x = Random.Range(0, 10);
            int y = Random.Range(0, 10);
            Debug.Log("change text: " + x + ", " + y);
            UpdateFace(x.ToString(), y.ToString());
        }

        public virtual void ClearCell()
        {
            Object.Destroy(unitCell);
        }
    }



    //6.编写一个class B继承自A，请自由发挥，为class B赋予这样的功能：每旋转一次，卡片的文本会变化。WIP
    // 改：实现是实现了，比较hard code。是不是使用statemachin比较干净？
    // 是否base的rotate方法写的有问题？不能顺利转到位，这能用了snap的方式。

    public class TimeChainCell : BoardCell
    {

        float upperBound; // the bound of value
        float timeValue; // the current value on the frontFace
        float nextValue; // current value + 1
        float duration; // a duration is past the cell will rotate and change value
        float checker; // updated with time

        bool frontFace = true; // if frontFace is facing the camera
        public bool rotateOn = false;

        public TimeChainCell fwdCell; // the cell before 

        public float TimeValue { get => timeValue; set => timeValue = value; }
        public float Duration { get => duration; set => duration = value; }
        public float UpperBound { get => upperBound; set => upperBound = value; }
        public float Checker { get => checker; set => checker = value; }

        public TimeChainCell(GameObject _prefab, Vector3 _pos, float sp) : base(_prefab, _pos, sp)
        {
            timeValue = 0f;
            nextValue = timeValue + 1f;
        }

        public void UpdateDuration()
        {

            //CellRotate();

            if (checker >= duration)
            {
                //CellRotate();
                rotateOn = true;
                timeValue += 1f;
                checker = 0f;

                if (Mathf.Approximately(nextValue, 0))
                {
                    //if (timeValue >= (upperBound-0.1f)) {
                    timeValue = 0f;
                    if (fwdCell != null)
                    {
                        fwdCell.rotateOn = true;
                        fwdCell.UpdateDuration();
                    }
                }

                nextValue = timeValue + 1;
                if (Mathf.Approximately(nextValue, upperBound))
                {
                    nextValue = 0f;
                }
                if (frontFace)
                {
                    UpdateFace(nextValue.ToString(), timeValue.ToString());
                    frontFace = false;
                }
                else
                {
                    UpdateFace(timeValue.ToString(), nextValue.ToString());
                    frontFace = true;
                }

            }



        }

        public override void CellRotate()
        {
            if (rotateOn)
            {
                currentE.x += 900f * Time.deltaTime;
                unitCell.transform.eulerAngles = currentE;
                if (Mathf.Approximately(currentE.x % 180f, 0f))
                {
                    rotateOn = false;

                }
            }
        }

        public IEnumerator SnapRotation()
        {
            if (rotateOn)
            {
                yield return new WaitForSeconds(0.1f);
                if (frontFace)
                {
                    currentE.x = 0f;
                }
                else
                {
                    currentE.x = -180f;
                }
                unitCell.transform.eulerAngles = currentE;
                rotateOn = false;
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


    //10.billboard
    public class BillboardSim : BoardCell
    {
        static int boardRow;
        static int boardCol;

        static string textDisplay = "ABCDEFGHIJKOPQRSTUVWXYZ";
        static string digitDisplay = "0123456789";
        string cellValue;
        float duration;
        float checker;

        public BillboardSim leftCell;
        public BillboardSim downCell;

        bool frontFace = true; // if frontFace is facing the camera
        public bool rotateOn = false;

        public static int BoardRow { get => boardRow; set => boardRow = value; }
        public static int BoardCol { get => boardCol; set => boardCol = value; }
        public string CellValue { get => cellValue; set => cellValue = value; }
        public float Duration { get => duration; set => duration = value; }
        public float Checker { get => checker; set => checker = value; }

        public BillboardSim(GameObject _prefab, Vector3 _pos, float sp, int isText) : base(_prefab, _pos, sp)
        {
            if (isText == 0)
            {
                cellValue = digitDisplay[Random.Range(0, digitDisplay.Length)].ToString();
                speed = 4f;
            }
            else
            {
                cellValue = textDisplay[Random.Range(0, textDisplay.Length)].ToString();
                speed = 1f;
            }

            UpdateFace(cellValue, cellValue);
            //rotateOn = true;
            checker = 0f;

        }

        public void UpdateCellValue()
        {
            UpdateFace(cellValue, cellValue);
        }

        public override void CellRotate()
        {
            if (rotateOn)
            {

                currentE.x += speed * 360f * Time.deltaTime;
                currentE.x = currentE.x % 360f;
                unitCell.transform.eulerAngles = currentE;

            }
        }


        public void Wave()
        {

            if (rotateOn == true && checker >= duration)
            {

                if (leftCell != null && leftCell.rotateOn == false)
                {
                    leftCell.rotateOn = true;
                    leftCell.checker = 0f;
                    leftCell.Wave();
                }



                if ((currentE.x%180f) >= (currentE.x % 360f))
                {
                    currentE.x = 180f;
                }
                else
                {
                    currentE.x = 360f;
                }

                unitCell.transform.eulerAngles = currentE; 
                rotateOn = false;

                
            }

        }

    }

}
