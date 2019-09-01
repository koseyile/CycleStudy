using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNode
{
    public GameObject snakeObj;
    private GameObject SnakeBody;
    private GameObject SnakeTail;
    private float speed;
    private Vector3 dir;
    private float passTime; 
    private Color NodeColor;

    static public float xMax = 10.0f;
    static public float zMax = 10.0f;

    private SnakeNode nextNode;

    public SnakeNode(GameObject _snakePrefab,GameObject _body,GameObject _tail, Vector3 _pos)
    {
        speed = 1.0f;
        dir = new Vector3(-1, 0, 0);
        snakeObj = GameObject.Instantiate(_snakePrefab, _pos, Quaternion.identity);
        _body = GameObject.Instantiate(_snakePrefab, _pos - dir, Quaternion.identity);
        _tail= GameObject.Instantiate(_snakePrefab, _pos - (dir*2) , Quaternion.identity);
    }
  
    public void Update()
    {
        passTime+=Time.deltaTime;
        if(passTime>0.3f)
        {
            passTime = 0.0f;

            Move(nextNode, snakeObj.transform.position);
            Vector3 newPos = snakeObj.transform.position + (dir*speed);

            if(newPos.x>xMax)
            {
                newPos.x=xMax;
            }

            if(newPos.x<-xMax)
            {
                newPos.x=-xMax;
            }

            if(newPos.z>zMax)
            {
                newPos.z=zMax;
            }

            if(newPos.z<-zMax)
            {
                newPos.z=-zMax;
            }

            snakeObj.transform.position = newPos;
        }
    }

    public void Move(SnakeNode node, Vector3 _pos)
    {
        if(node==null)
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
            eatFood(this);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = new Vector3(-1, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = new Vector3(1, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = new Vector3(0, 0, 1);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = new Vector3(0, 0, -1);
        }

    }

    public void eatFood(SnakeNode node)
    {

        if (node.nextNode == null)
        {
            node.nextNode = new SnakeNode(snakeObj,SnakeBody,SnakeTail, snakeObj.transform.position);
        }
        else
        {
            eatFood(node.nextNode);
        }
    }


}
public class Fruit
{
    public GameObject FruitObj;
    private Vector3 vec;
    private string Name;
     Color fruitColor;

    public Fruit(string _name,GameObject _fruitPrefab, Vector3 _vec,Color _fColor)
    {
        FruitObj = GameObject.Instantiate(_fruitPrefab, _vec, Quaternion.identity);
    }

    void eaten(SnakeNode _snakeNode, Fruit _fruit)
    {
         if(_snakeNode.snakeObj.transform.position == _fruit.FruitObj.transform.position)
        {
            //_fruit.FruitObj.
        }
    }
}


public class SnakeGame : MonoBehaviour
{
    public GameObject snakePrefab;
    public GameObject snakeBody;
    public GameObject snakeTail;
    public GameObject FruitPrefab;
    public GameObject ApplePrefab;

    static public float xMax = 10.0f;
    static public float zMax = 10.0f;

    private SnakeNode snakeNode;

    // Start is called before the first frame update
    void Start()
    {
        SnakeNode snakeGrey = new SnakeNode(snakePrefab, snakeBody, snakeTail, new Vector3(3, 0.5f, 0));

    }

    // Update is called once per frame
    void Update()
    {
        snakeNode.Update();
        snakeNode.UpdateInput();
    }
}
