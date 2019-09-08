using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BAIBAI11;

public class BillBoardControl : MonoBehaviour
{
    private BAIBAI11.BoardCell unit;
    private BAIBAI11.TimeCell[] timeUnits;
    private BAIBAI11.RanSpeedCell[] ranUnits;

    [SerializeField]
    private string cellPath = "Prefab/UnitCell";
    GameObject cellPrefab;

    bool rotateTest = false;

    Camera main;

    private float timer;
    private float minSec;
    private float tenMinSec;
    private float sec;
    private float tenSec;
    private float min;
    private float tenMin;
    private float hour;
    private float tenHour;

    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Camera>();

        cellPrefab = Resources.Load(cellPath) as GameObject;
        unit = new BAIBAI11.BoardCell(cellPrefab, new Vector3(0,0,0),1f);
        unit.UpdateFace("9", "7");
        //Debug.Log("w,h: " + unit.Width + ", " + unit.Height);


        //7.实例化8个B，分别代表小时，分钟，秒，毫秒（为方便制作，我们定义1秒=60毫秒） WIP
        CreateTimeCells();


        //Q9.实例化600个C，在屏幕上组成一个大矩形，所有卡面使用随机速度翻转。
        CreateRandomSpeedCells(20,30);

    }

    // Update is called once per frame
    void Update()
    {
        if (rotateTest)
        {
            unit.CellRotate();
        }

        if(timeUnits != null) {
            RunTimeCells();
        }

        if (ranUnits != null) {
            RotateRandomSpeedCells();
        }

    }

    //4.测试功能:点击按钮时调用动画函数，播放卡片旋转动画
    public void TestRotation() {
        if (!rotateTest)
        {
            rotateTest = true;
        }
        else {
            rotateTest = false;
        }

    }

    //5.测试功能:设置文本函数
    public void RandomText() {
        unit.RandomFace();
    }


    //7.实例化8个B，分别代表小时，分钟，秒，毫秒（为方便制作，我们定义1秒=60毫秒）。
    //实现计时功能，毫秒卡片在飞速旋转变化，秒卡片每隔一秒旋转变化，分钟卡片每隔一分钟旋转变化，小时卡片每隔一小时旋转变化。
    void CreateTimeCells() {

        //adjust camera
        main.transform.position = new Vector3(0, 20, -100);

        //initiate cells
        timeUnits = new BAIBAI11.TimeCell[8];
        float w = (BAIBAI11.BoardCell.width + 1);
        for (int i = 0; i < timeUnits.Length; i++)
        {
            timeUnits[i] = new BAIBAI11.TimeCell(cellPrefab, new Vector3((-1 * timeUnits.Length/2) * w + w * i, 30, 0), -0f);
            timeUnits[i].SetInitalFace();
        }

        ResetTimer();
    }

    void ResetTimer() {
        timer = 0f;
    }



    void RunTimeCells()
    {

        timer += Time.deltaTime;

        if (timer > 0.016f) {
            timeUnits[7].SetFlip(true);
            timer = 0;
            minSec += 1;

        }

        if(minSec > 10) {
            timeUnits[6].SetFlip(true);
            minSec = 0;
            tenMinSec += 1;
        }

        if (tenMinSec > 6)
        {
            timeUnits[5].SetFlip(true);
            tenMinSec = 0;
            sec += 1;
        }

        if (sec > 10)
        {
            timeUnits[4].SetFlip(true);
            sec = 0;
            tenSec += 1;
        }



        for (int i = 0; i < timeUnits.Length; i++)
        {
            timeUnits[i].Turn();
        }
    }


    //9.实例化600个C，在屏幕上组成一个大矩形，所有卡面使用随机速度翻转。

    void CreateRandomSpeedCells(int row, int col) {

        ranUnits = new BAIBAI11.RanSpeedCell[row * col];

        //adjust camera according to the size
        main.transform.position = new Vector3(col, row * 2, -100 * (Mathf.Ceil(Mathf.Log(ranUnits.Length,4f))-1));

        float w = (BAIBAI11.BoardCell.width + 1);
        float h = BAIBAI11.BoardCell.height;

        for (int i = 0; i < ranUnits.Length; i++)
        {
            float x = Random.Range(-5, 5);
            ranUnits[i] = new BAIBAI11.RanSpeedCell(cellPrefab, new Vector3(((-1* col/2 * w)) + w * (i % col), (-1*row/2* w) + h * (i / col), 0), x+0.1f);
            ranUnits[i].RandomFace();
        }
    }

    void RotateRandomSpeedCells() {
        for (int i = 0; i < ranUnits.Length; i++)
        {
            ranUnits[i].CellRotate();
        }
    }

    /*10.实现机场机械广告牌功能。完成如下要求：
    * 如视频展示的那样，部分区域快速翻转。部分区域则维持稳定状态。
    * 可进行微创新，像球场人浪那样，利用时间差，让部分区域展示规律渐进的翻转效果。
    * 自由发挥自己想要的效果。  
     */
     
}
