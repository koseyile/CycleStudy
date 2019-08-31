using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    /*问题： 我实例化一条小蛇的时候需要用到一些数据，比如位置速度方向什么的，我应该把这些数据序列化吗？*/

    private Snake snake;

    [SerializeField]
    private string snakePath = "Prefab/snake";
    //private string planPath = "";
    //private string uiPath = "";

    [SerializeField]
    private Vector3 generisPos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f);
    private float moveSpan = 1.4f;
    private float moveWait = 0.7f;
    private float scale = 1.4f;

    private Control controler1;

    void Start()
    {
        InitiateScene();

    }

    void Update()
    {
        snake.UpdateMove(controler1);
    }

    void InitiateScene()
    {
        //加载预制
        GameObject snakePrefab = Resources.Load(snakePath) as GameObject;

        //初始化控制器
        controler1 = new Control();

        //生成小蛇
        snake = new Snake(snakePrefab, generisPos, direction, moveSpan, moveWait, scale, controler1);
        snake.Act(true);

    }

}
