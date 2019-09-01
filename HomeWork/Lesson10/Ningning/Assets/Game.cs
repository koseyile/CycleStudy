using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit
{
    public GameObject FruitObj;

    public Fruit(GameObject _fruitPrefab, Vector3 _pos)
    {

        FruitObj = GameObject.Instantiate(_fruitPrefab, _pos, Quaternion.identity);
    }

}

public class SnakeNode
{
    //private GameObject snakeObj;
    public GameObject snakeObj;   
    private float speed;
    private Vector3 dir;
    private float passTime;

    static public float xMax = 20.0f;
    static public float zMax = 20.0f;

    private SnakeNode nextNode;
   
    public SnakeNode(GameObject _snakePrefab, Vector3 _pos)  //构造函数 在_pos 生成一个snakeprefab的gameobj
    {
        speed = 1.0f;
        dir = new Vector3(-1, 0, 0);
        snakeObj = GameObject.Instantiate(_snakePrefab, _pos, Quaternion.identity); 
    }

    public void Update()
    {
        passTime += Time.deltaTime;
        if (passTime > 0.1f)   //每秒移动一次
        {
            passTime = 0.0f;

            Move(nextNode, snakeObj.transform.position);  //把 nextnode挪到 snakeobj的position
            Vector3 newPos = snakeObj.transform.position + (dir * speed);   //每秒移动一格

            if (newPos.x > xMax)   //限制范围
            {
                newPos.x = xMax;
            }

            if (newPos.x < -xMax)
            {
                newPos.x = -xMax;
            }

            if (newPos.z > zMax)
            {
                newPos.z = zMax;
            }

            if (newPos.z < -zMax)
            {
                newPos.z = -zMax;
            }

            snakeObj.transform.position = newPos;
        }

    }

    public void Move(SnakeNode a, Vector3 _pos) //把 a 挪到 -pos的位置
    {
        if (a == null)
        {
            return;
        }

        Move(a.nextNode, a.snakeObj.transform.position);
        a.snakeObj.transform.position = _pos;
    }



    public void UpdateInput()
    {
        

         if (Input.GetKeyUp(KeyCode.Space))
            {
                eatFood(this);  //访问自己
            }

        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = new Vector3(0, 0, 1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = new Vector3(0, 0, -1);
        }

    }    //键盘输入上下左右

    public void eatFood(SnakeNode node)  //增加一节node 在最后一节的位置上增加一节
    {
        if (node.nextNode == null)
        {
            node.nextNode = new SnakeNode(snakeObj, snakeObj.transform.position); 
        }
        else
        {
            eatFood(node.nextNode);
        }
    }

    public void getApple()   //苹果来判断 我有没有被吃 让苹果的函数来调用 if applecontroller find the snake attach to apple active this function
    {
        eatFood(this);
                           //+一节 多的那一节变成彩色
    }

    public void getBanana()
    {
        eatFood(this);
                            //+一节 if 上一节是彩色的 多的那一节变成彩色 if上一节不是彩色的 变成灰色

    }

    public void getFood()   
    {
        eatFood(this);
    }


}




public class Game : MonoBehaviour
{

    public GameObject snakePrefab;
    public GameObject Apple;
    public GameObject Banana;


    public SnakeNode snakeNode;
    public Fruit a;    //a apple
    public Fruit[] b = new Fruit[6]; //b six banana
  
    void Start()
    {
        snakeNode = new SnakeNode(snakePrefab, new Vector3(3, 0.5f, 0));
        snakeNode.getFood();
        //snakePrefab.GetComponent<MeshRenderer>().material.color = Color.green;

        snakeNode.getFood();
       
        //snakeNode.eatFood(this); ???直接eatfood 括号里应该是什么

        a = new Fruit(Apple, new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10))); //实例化一个七彩苹果

        for (int n= 0; n < 6;n++) {

            b[n] = new Fruit(Banana, new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10))); //实例化六个灰色香蕉
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        snakeNode.Update();
        snakeNode.UpdateInput();
        //要判断是否到10节 到的话 判断第二节是否为彩色
        

    }
}