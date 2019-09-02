using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wupeng
{

public class SnakeManager 
{
    private  static SnakeManager manager;  //单例

    private Snake snake;

    [SerializeField]
    private string snakePath = "Prefab/snake";

    [SerializeField]
    private Vector3 generisPos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f);
    private float moveSpan = 1.4f;
    private float moveWait = 0.4f;
    private float scale = 1.4f;

    private Control controler1;


    public static SnakeManager Manager
    {
        get
        {
            if (manager == null)
            {
                manager =  new SnakeManager();
            }
            return manager;
        }
    }

    public void Initiate()
    {
        //加载小蛇预制
        GameObject snakePrefab = Resources.Load(snakePath) as GameObject;

        //初始化控制器
        controler1 = new Control();

        //初始化小蛇
        snake = new Snake(snakePrefab, generisPos, direction, moveSpan, moveWait, scale, controler1);
        snake.SetActive(true);

        if (snake != null)
        {
            Debug.Log("小蛇初始化");
            Debug.Log(snake.Ob.name);
        }
    }

    public void Update()
    {
        if (snake != null)
        {
            snake.UpdateMove();
        }
        else
        {
            Debug.Log("小蛇未初始化");
        }

    }

    public void EatFood(GameObject food)
    {
        FRUITKIND kind;

        switch (food.name)
        {
            case "Watermelon":
                kind = FRUITKIND.Watermelon;
                break;
            case "Peach":
                kind = FRUITKIND.Peach;
                break;
            case "Strawberry":
                kind = FRUITKIND.Strawberry;
                break;
            case "Apple":
                kind = FRUITKIND.Apple;
                break;
            case "Mango":
                kind = FRUITKIND.Mango;
                break;
            default:
                kind = FRUITKIND.Unknow;
                break;
        }

        snake.AddBody(kind);

    }

}
}
