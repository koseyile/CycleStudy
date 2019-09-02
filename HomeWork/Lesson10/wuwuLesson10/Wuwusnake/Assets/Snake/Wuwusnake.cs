using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//一开始以为要创造3个cube，然后就不知道怎么让他们一起动了，因为上下左右的时候，如果新建head和tail他们move的方向也会不同吧? 如果身体在右侧，我又点了往右的方向又怎么办呢？
//我学习amber的方式，创建了3个颜色的color，
//prefab我理解是一个unity里的物品，但class是虚拟的类，是可以绑定某个prfab，也可以复制很多个的？但是他们产生关系就很晕了
//其实我不知道list，是看了别人才会；
//每个水果都创建不同的prefa好像比较费内存，我就想重复建立list，但是设置了颜色，运行后颜色却不改
//最后一题选择放弃

public class SnakeNode
{
    private GameObject snakeObj;
    private float speed;
    private Vector3 dir;
    private float passTime;
    private string color;

    static public float xMax = 10.0f;
    static public float zMax = 10.0f;
    static public int Snakebody= 0;


    Renderer rend;

    private SnakeNode nextNode;


    public SnakeNode(GameObject _snakePrefab, Vector3 _pos,Color color, Texture t)
    {
        speed = 1.0f;
        dir = new Vector3(-1, 0, 0);
        snakeObj = GameObject.Instantiate(_snakePrefab, _pos, Quaternion.identity);
       
        rend = snakeObj.GetComponent<Renderer>();
        rend.material.color = color;
        rend.material.mainTexture = t;
    }

    public void Update()
    {
        passTime += Time.deltaTime;
        if (passTime > 0.1f)
        {
            passTime = 0.0f;

            Move(nextNode, snakeObj.transform.position);
            Vector3 newPos = snakeObj.transform.position + (dir * speed);

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

            snakeObj.transform.position = newPos;
        }

    }

    public void Move(SnakeNode node, Vector3 _pos)
    {
        if (node == null)
        {
            return;
        }

        Move(node.nextNode, node.snakeObj.transform.position);
        node.snakeObj.transform.position = _pos;
    }



    public void UpdateInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            eatFood(this,Color.grey,null);
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

    }

    public void eatFood(SnakeNode node, Color color, Texture t)
    {
        if (node.nextNode == null)
        {
            node.nextNode = new SnakeNode(snakeObj, snakeObj.transform.position,color,t);
            if (t != null)
            {
                Snakebody += 1;
            }
        }
        else
        {
            eatFood(node.nextNode,color,t);
        }
    }
    public Vector3 GetPosition()
    {
        return snakeObj.transform.position;
    }

}

    

public class Food
{
    public string name;
    private GameObject foodObj;
    private Vector3 position;

    public Vector3 GetPosition()
    {
        return foodObj.transform.position;
    }


    public Food(string _name, Color color, Vector3 _pos, GameObject _Object)
    {
        this.name = _name;
        foodObj = GameObject.Instantiate(_Object, _pos, Quaternion.identity);
    }
   
}


public class Wuwusnake : MonoBehaviour
{
    public GameObject snakePrefab;
    private SnakeNode snakeNode;

    public GameObject foodPrefab;
    public GameObject Apple;

    private Color[] Colors;

    private List<Food> Snakes;

    //这个方法我其实不太懂，某个color的数组遍历后，为什么就变成3段了呢
    void ThreeSnake(Color[] colors)
    {

        snakeNode = new SnakeNode(snakePrefab, new Vector3(3, 0.5f, 0), colors[0], null);

        for (int i = 1; i < colors.Length; i++)
        {
            snakeNode.eatFood(snakeNode, colors[i], null);
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
        
        Colors = new Color[3];
        //红色的头
        Colors[0].r = 200f;
        Colors[0].g = 0f;
        Colors[0].b = 0f;

        Colors[1] = Color.gray;
        //紫色
        Colors[2].r = 90f;
        Colors[2].g = 0f;
        Colors[2].b = 90f;
        //实例化一条蛇，有三节身体，头部显示为暗红色，身体为灰色，尾巴为暗紫色。
        ThreeSnake(Colors);

        //实例化一颗七彩苹果，一个芒果，二个草莓，三个水蜜桃，还有一个大西瓜显示在场景中。
        Snakes = Sevenfood();
    }

    List<Food> Sevenfood()
    {
        List<Food> snakeEat = new List<Food>
        
            {
                new Food("apple",new Color (250f,0f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), Apple),
                new Food("strawberry", new Color (250f,0f,140f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), foodPrefab),
                new Food("strawberry", new Color (250f,0f,140f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), foodPrefab),
                new Food("peach", new Color (200f,0f,150f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), foodPrefab),
                new Food("peach", new Color (200f,0f,150f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), foodPrefab),
                new Food("peach", new Color (200f,0f,150f,255f),new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), foodPrefab),
                new Food("waterlemon", new Color (0f,90f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), foodPrefab)
            };
    
        return snakeEat;
    }
    //想让蛇头和每个食物判断位置距离是不是接近，然后新长出的身体是灰色，但是水果们没有颜色
    public void SnakeGrow(SnakeNode node, List<Food> Snakes)
    {
        for (int i = 0; i < Snakes.Count; i++)
        {
            foreach (Food food in Snakes)
            {
                if (Vector3.Distance(Snakes[i].GetPosition(), node.GetPosition()) < 0.5f)
                {
                    snakeNode.eatFood(node, Color.gray, null);
                    Snakes.Remove(food);
                    return;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        snakeNode.Update();
        snakeNode.UpdateInput();
        SnakeGrow(snakeNode,Snakes);
    }
}
