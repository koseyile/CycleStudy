using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BAIBAI11;

public class BillBoardControl : MonoBehaviour
{
    private BAIBAI11.BoardCell unit;
    private BAIBAI11.TimeChainCell[] timeChainUnits;
    private BAIBAI11.RanSpeedCell[] ranUnits;
    private BAIBAI11.BillboardSim[] billUnits;

    [SerializeField]
    private string cellPath = "Prefab/UnitCell";
    GameObject cellPrefab;

    Camera main;

    bool rotateTest = false;
    bool timerOn = false;
    bool waveOn = false;

    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Camera>();


        cellPrefab = Resources.Load(cellPath) as GameObject;
        CreateUnit();

    }

    // Update is called once per frame
    void Update()
    {
        if (rotateTest && unit != null)
        {
            unit.CellRotate();
        }

        if (ranUnits != null) {
            RotateRandomSpeedCells();
        }

        if (timerOn && timeChainUnits != null) {
            UpdateTimeChainCells();
        }

        if(waveOn == false && billUnits != null) {
            RotateBillBoardCells();
        }

        if(waveOn && billUnits != null) {
            WaveBillBoardCells();
        }
    }


    // Q1-Q3
    void CreateUnit()
    {
        unit = new BAIBAI11.BoardCell(cellPrefab, new Vector3(0, 0, 0), 1f);
        unit.UpdateFace("9", "7");
    }


    //4.测试功能:点击按钮时调用动画函数，播放卡片旋转动画
    public void TestRotation() {
        //adjust camera
        main.transform.position = new Vector3(0, 0, -100);

        if (ranUnits != null)
        {
            ClearRanSpeedCells();
        }

        if (timeChainUnits != null)
        {
            ClearTimeChainCells();
        }

        if (billUnits != null)
        {
            ClearBillBoardCells();
        }

        if (unit == null) {
            CreateUnit();
        }
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

    void CreateTimeChainCells() {

        // set chain values
        float[] durationValues = new float[] { 24 * 3600f, 3600f, 600f, 60f, 10f, 1f, 1 / 6f, 1 / 60f };
        int[] boundValues = new int[] { 24, 10, 6, 10, 6, 10, 6, 10 };

        //initiate cells
        timeChainUnits = new BAIBAI11.TimeChainCell[8];
        float w = (BAIBAI11.BoardCell.width + 1);
        for (int i = 0; i < timeChainUnits.Length; i++) {
            timeChainUnits[i] = new BAIBAI11.TimeChainCell(cellPrefab, new Vector3((-1 * timeChainUnits.Length / 2) * w + w * i, 30, 0), -0f);
            timeChainUnits[i].UpdateFace(timeChainUnits[i].TimeValue.ToString(), (timeChainUnits[i].TimeValue + 1).ToString());

            //set duration & bound
            timeChainUnits[i].Duration = durationValues[i];
            timeChainUnits[i].UpperBound = boundValues[i];

            //set fwd cell
            if (i >= 1) {
                timeChainUnits[i].fwdCell = timeChainUnits[i - 1];
            }

        }
    }

    void UpdateTimeChainCells() {
        for (int i = 0; i < timeChainUnits.Length; i++) {
            timeChainUnits[i].Checker += Time.deltaTime;
            timeChainUnits[i].CellRotate();
            StartCoroutine(timeChainUnits[i].SnapRotation());
        }

        timeChainUnits[timeChainUnits.Length - 1].rotateOn = true;
        timeChainUnits[timeChainUnits.Length-1].UpdateDuration();
    }

    void ClearTimeChainCells() {
        for (int i = 0; i < timeChainUnits.Length; i++) {
            timeChainUnits[i].ClearCell();
        }
        timeChainUnits = null;
    }



    //7. 计时功能 测试button
    public void StartTimer()
    {
        //adjust camera
        main.transform.position = new Vector3(0, 20, -150); 

        if(ranUnits != null) {
            ClearRanSpeedCells();
        }

        if (unit != null)
        {
            unit.ClearCell();
            unit = null;
        }

        if (billUnits != null)
        {
            ClearBillBoardCells();
        }

        if (timeChainUnits == null) {
            CreateTimeChainCells();
        }

        if (!timerOn)
        {
            timerOn = true;
        }
        else {
            timerOn = false;
        }

    }



    //9.实例化600个C，在屏幕上组成一个大矩形，所有卡面使用随机速度翻转。
    public void CreateRandom600() {

        if (ranUnits == null) {
            CreateRandomSpeedCells(20, 30);
        }
        else {
            ClearRanSpeedCells();
        }

        if(timeChainUnits != null) {
            ClearTimeChainCells();
        }

        if (unit != null)
        {
            unit.ClearCell();
            unit = null;
        }

        if (billUnits != null)
        {
            ClearBillBoardCells();
        }
    }

    void CreateRandomSpeedCells(int row, int col) {

        ranUnits = new BAIBAI11.RanSpeedCell[row * col];

        //adjust camera according to the size
        main.transform.position = new Vector3(col, row * 2, -100 * (Mathf.Ceil(Mathf.Log(ranUnits.Length,4f))-1f));

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

    void ClearRanSpeedCells() {
        for (int i = 0; i < ranUnits.Length; i++)
        {
            ranUnits[i].ClearCell();

        }
        ranUnits = null;
    }


    /*10.实现机场机械广告牌功能。完成如下要求：
    * 如视频展示的那样，部分区域快速翻转。部分区域则维持稳定状态。
    * 可进行微创新，像球场人浪那样，利用时间差，让部分区域展示规律渐进的翻转效果。
    * 自由发挥自己想要的效果。  
     */

    // Button A: create billboarad test
    public void CreateBillboardTest() {
        if (billUnits == null) { 
        CreateBillboardSim(25, 40); }

        if (ranUnits != null)
        {
            ClearRanSpeedCells();
        }

        if (timeChainUnits != null)
        {
            ClearTimeChainCells();
        }

        if (unit != null)
        {
            unit.ClearCell();
            unit = null;
        }
    }

    void CreateBillboardSim(int row, int col)
    {

        billUnits = new BAIBAI11.BillboardSim[row * col];

        //adjust camera according to the size
        main.transform.position = new Vector3(col, row * 2, -100 * (Mathf.Ceil(Mathf.Log(billUnits.Length, 4f)) - 0.5f));

        float w = (BAIBAI11.BoardCell.width + 1);
        float h = BAIBAI11.BoardCell.height;

        for (int i = 0; i < billUnits.Length; i++)
        {
            billUnits[i] = new BAIBAI11.BillboardSim(cellPrefab, new Vector3(((-1 * col / 2 * w)) + w * (i % col), (-1 * row / 2 * w) + h * (i / col), 0), 1f, Random.Range(0,2));

            if (i % col != 0) {
                billUnits[i].leftCell = billUnits[i - 1];
            }

            if(i / col > 0) {
                billUnits[i].downCell = billUnits[i - col];
            }
        }

        BillboardSim.BoardCol = col;
        BillboardSim.BoardRow = row;

    }

    // test B: wave from right
    public void WaveEffect(int  waveLen)
    {
        waveOn = true;

        for (int i = 0; i < billUnits.Length; i++) {

            billUnits[i].Duration = 1.5f;

            if (i % BillboardSim.BoardCol == BillboardSim.BoardCol - 1)
            {
                for (int j=0; j<waveLen; j++) {
                    billUnits[i-j].rotateOn = true;
                }

            }
        }

    }


    void RotateBillBoardCells()
    {
        for (int i = 0; i < billUnits.Length; i++)
        {
            billUnits[i].CellRotate();
            billUnits[i].Checker += Time.deltaTime;
        }
    }


    void WaveBillBoardCells()
    {
        for (int i = 0; i < billUnits.Length; i++)
        {
            billUnits[i].CellRotate(); 
            billUnits[i].Checker += Time.deltaTime;
            billUnits[i].Wave();
        }
    }



    // test C: copy value from left
    public void CopyValuefromLeft() {
        for (int i = 0; i < billUnits.Length; i++)
        {
            if (i % BillboardSim.BoardCol != 0)
            {
                billUnits[i].CellValue = billUnits[i].leftCell.CellValue;
                billUnits[i].UpdateCellValue();
            }
        }
    }


    void ClearBillBoardCells()
    {
        for (int i = 0; i < billUnits.Length; i++)
        {
            billUnits[i].ClearCell();

        }
        billUnits = null;
    }

}
