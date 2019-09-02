using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
1. 实例化一条蛇，有三节身体，头部显示为暗红色，身体为灰色，尾巴为暗紫色。
2. 实例化一颗七彩苹果，一个芒果，二个草莓，三个水蜜桃，还有一个大西瓜显示在场景中。
3. 实现如下逻辑：
   * 如果小蛇吃到了七彩苹果，接下来小蛇吃到的任意水果，长出的身体都是彩色。
   * 如果小蛇没有吃到七彩苹果，接下来小蛇吃到的任意水果，长出的身体都是灰色。
4. 当小蛇七节身体呈现彩虹颜色时，小蛇消失，打印日志：“小蛇变成了七彩艾希，像彩虹一般出现在Hank眼前。”
*/

public class Fruit
{
    private GameObject fruitObj;
    private string name;
    private Fruit[] fruits;

    public Fruit(GameObject _fruitPrefab,Vector3 _fpos)
    {
        fruitObj = GameObject.Instantiate(_fruitPrefab, _fpos, Quaternion.identity);
    }
}

public class SnakeNode
{
    private GameObject snakeheadObj;
    private GameObject snakebodyObj;
    private GameObject snaketailObj;
    private float speed;
    private Vector3 dir;
    private float passTime;

    static public float xMax = 10.0f;
    static public float zMax = 10.0f;

    private SnakeNode headNode;
    private SnakeNode bodyNode;
    private SnakeNode tailNode;

    public SnakeNode(GameObject _snakeheadPrefab, Vector3 _pos)
    {
        speed = 1.0f;
        dir = new Vector3(-1, 0, 0);
        snakeheadObj = GameObject.Instantiate(_snakeheadPrefab, _pos, Quaternion.identity);
    }


   

    public void Update()
    {
        passTime += Time.deltaTime;
        if (passTime > 0.1f)
        {
            passTime = 0.0f;

            Move(bodyNode, snakeheadObj.transform.position);
            Vector3 newPos = snakeheadObj.transform.position + (dir * speed);

            if (newPos.x > xMax)
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

            snakeheadObj.transform.position = newPos;
        }
    }

    public void Move(SnakeNode node,Vector3 _pos)
    {
        if (node == null)
        {
            return;
        }

        Move(node.bodyNode, node.snakeheadObj.transform.position);
        node.snakeheadObj.transform.position = _pos;
    }

    public void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = new Vector3(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = new Vector3(1, 0, 0);
        }
    }
}

public class SnakeGame : MonoBehaviour
{
    public GameObject snakeheadPrefab;
    public GameObject snakebodyPrefab;
    public GameObject snaketailPrefab;

    public GameObject applePrefab;
    public GameObject mangoPrefab;
    public GameObject berry1Prefab;
    public GameObject berry2Prefab;
    public GameObject peach1Prefab;
    public GameObject peach2Prefab;
    public GameObject peach3Prefab;
    public GameObject melonPrefab;

    private SnakeNode snakehead;
    private SnakeNode snakebody;
    private SnakeNode snaketail;

    private Fruit apple;
    private Fruit mango;
    private Fruit berry1;
    private Fruit berry2;
    private Fruit peach1;
    private Fruit peach2;
    private Fruit peach3;
    private Fruit melon;



    // Start is called before the first frame update
    void Start()
    {
        snakehead = new SnakeNode(snakeheadPrefab, new Vector3(1, 0.5f, 0));
        snakebody = new SnakeNode(snakebodyPrefab, new Vector3(2, 0.5f, 0));
        snaketail = new SnakeNode(snaketailPrefab, new Vector3(3, 0.5f, 0));

        apple = new Fruit(applePrefab, new Vector3(5, 0.5f, -4));
        mango = new Fruit(mangoPrefab, new Vector3(-6, 0.5f, 9));
        melon = new Fruit(melonPrefab, new Vector3(9, 0.5f, 2));
        berry1 = new Fruit(berry1Prefab, new Vector3(8, 0.5f, 8));
        berry2 = new Fruit(berry2Prefab, new Vector3(8, 0.5f, 2));
        peach1 = new Fruit(peach1Prefab, new Vector3(-2, 0.5f, -9));
        peach2 = new Fruit(peach2Prefab, new Vector3(1, 0.5f, -2));
        peach3 = new Fruit(peach3Prefab, new Vector3(4, 0.5f, 9));


    }

    // Update is called once per frame
    void Update()
    {
        snakehead.Update();
        snakehead.UpdateInput();
    }
}
