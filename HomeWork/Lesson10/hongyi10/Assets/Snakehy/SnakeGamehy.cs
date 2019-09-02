using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNode
{
    private GameObject snakeObj;
    private float speed;
    private Vector3 dir;
    private float passTime;
    private string color;

    static public float xMax = 10.0f;
    static public float zMax = 10.0f;
    static public int count = 0;

    private SnakeNode nextNode;


    public SnakeNode(GameObject _snakePrefab, Vector3 _pos, Color color, Texture texutre)
    {
        speed = 0.5f;
        dir = new Vector3(-0.5f, 0, 0);
        snakeObj = Object.Instantiate(_snakePrefab, _pos, Quaternion.identity);
    }

    public void Update()
    {
        passTime += Time.deltaTime;
        if(passTime>0.1f)
        {
            passTime = 0.0f;
            Vector3 newPos = snakeObj.transform.position+ (dir * speed);

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


            Move(nextNode,newPos);
            snakeObj.transform.position=newPos;
        }
    }

    public void Move(SnakeNode node,Vector3 _pos)
    { 
        if (node ==null)
        {
            return;
        }

        Move(node.nextNode, node.snakeObj.transform.position);
        node.snakeObj.transform.position = _pos;
    }

    //按空格加一格
    public void UpdateInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            dir = new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            dir = new Vector3(1, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            dir = new Vector3(0, 0, 1);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            dir = new Vector3(0, 0, -1);
        }
    }


    public void eatFood(SnakeNode node, Color color, Texture texture)
    {
        if (node.nextNode == null)
        {
            node.nextNode = new SnakeNode(snakeObj, snakeObj.transform.position, color, texture);
            if (texture != null)
            {
                count += 1;
            }
        }
        else
        {
            eatFood(node.nextNode, color, texture);
        }
    }
    public Vector3 GetPosition()
    {
        return snakeObj.transform.position;
    }

}

public class Fruit
{
    public string name;
    private GameObject foodObj;
    private Vector3 position;

    public Vector3 GetPosition()
    {
        return foodObj.transform.position;
    }


    public Fruit(string _name, Color color, Vector3 _pos, GameObject _Object)
    {
        this.name = _name;
        foodObj = Object.Instantiate(_Object, _pos, Quaternion.identity);
    }

}


public class SnakeGamehy : MonoBehaviour
{
    public GameObject snakePrefab;
    public GameObject rainbowApple;
    public GameObject mangoPrefab;
    public GameObject strawbPrefab;
    public GameObject peachPrefab;
    public GameObject watermelonPrefab;

    private SnakeNode snakeNode;

    private Color[] Colors;

    private List<Fruit> Snakes;


    // Start is called before the first frame update
    void Start()
    {
        Colors = new Color[3];
        Colors[0].r = 173F;
        Colors[0].g = 0f;
        Colors[0].b = 0f;
        Colors[1] = Color.gray;
        Colors[2].r = 105F;
        Colors[2].g = 0f;
        Colors[2].b = 179f;
        OriginalSnake(Colors);
    }

    List<Fruit> CreateFruits()
    {
        List<Fruit> Snacks = new List<Fruit>
            {
                new Fruit("apple", new Color (255f,0f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), rainbowApple),
                new Fruit("mango", new Color (0f,0f,255f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), mangoPrefab),
                new Fruit("strawberry1", new Color (255f,0f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), strawbPrefab),
                new Fruit("strawberry2", new Color (255f,0f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), strawbPrefab),
                new Fruit("peach1", new Color (0f,29f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), peachPrefab),
                new Fruit("peach2", new Color (0f,29f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), peachPrefab),
                new Fruit("peach3", new Color (0f,29f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), peachPrefab),
                new Fruit("watermelon", new Color (255f,0f,0f,255f), new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f)), watermelonPrefab),
            };
        return Snacks;
    }


    void OriginalSnake(Color[] colors)
    {

        snakeNode = new SnakeNode(snakePrefab, new Vector3(3, 0.5f, 0), colors[0], null);

        for (int i = 1; i < colors.Length; i++)
        {
            snakeNode.eatFood(snakeNode, colors[i], null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        snakeNode.Update();
        snakeNode.UpdateInput();
    }
}
