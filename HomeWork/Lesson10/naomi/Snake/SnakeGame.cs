using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaomiSnake;

namespace NaomiSnake
{
    public class SnakeNode
    {
        private GameObject SnakeObj;
        private float Speed;
        private Vector3 Direction;
        private float UpdateTime;
        private Texture RainbowTexture;

        static public float xMax = 9.5f;
        static public float zMax = 9.5f;

        private SnakeNode NextNode;

        static public bool AteRainbow = false;
       
        public SnakeNode(GameObject _snakeObj, Vector3 _pos, Color _color,Texture _texture)
        {
            Direction = new Vector3(-1, 0, 0);
            Speed = 1.0f;
            SnakeObj = Object.Instantiate(_snakeObj, _pos, Quaternion.identity);
            MeshRenderer renderer = SnakeObj.GetComponent<MeshRenderer>();
            renderer.material.color = _color;
            renderer.material.mainTexture = _texture;
        }

        public void Update()
        {
            UpdateTime += Time.deltaTime;
            if (UpdateTime > 0.2f)
            {
                Follow(NextNode, SnakeObj.transform.position);
                SnakeObj.transform.position += (Direction * Speed);
                SnakeObj.transform.position = BoundaryCheck(SnakeObj.transform.position);
                UpdateTime = 0.0f;
            }
        }

        private void Follow(SnakeNode _node, Vector3 _pos)
        {
            if (_node == null)
            {
                return;
            }

            Follow(_node.NextNode, _node.SnakeObj.transform.position);
            _node.SnakeObj.transform.position = _pos;
        }

        public void Grow(Color _color,Texture _texture)
        {
            if (this.NextNode == null)
            {
                this.NextNode = new SnakeNode(SnakeObj, SnakeObj.transform.position, _color,_texture);
            }
            else
            {
                this.NextNode.Grow(_color,_texture);
            }
        }

        public void EatFood(Fruit fruit)
        {
            Grow(fruit.GetColor(), fruit.GetTexture());
        }

        //使用无返回值的void函数就跑不出来
        Vector3 BoundaryCheck(Vector3 _pos)
        {
            if (_pos.x > xMax)
            {
                _pos.x = xMax;
            }
            if (_pos.x < -xMax)
            {
                _pos.x = -xMax;
            }
            if (_pos.z > zMax)
            {
                _pos.z = zMax;
            }
            if (_pos.z < -zMax)
            {
                _pos.z = -zMax;
            }

            return _pos;
        }

        public void PlayerInput()
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    Grow(Color.gray);
            //}

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Direction = new Vector3(-1, 0, 0);

            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Direction = new Vector3(1, 0, 0);

            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Direction = new Vector3(0, 0, 1);

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Direction = new Vector3(0, 0, -1);

            }
        }

        public Vector3 GetPosition()
        {
            return SnakeObj.transform.position;
        }
    }

    public class Fruit
    {
        public string Name;
        private GameObject FruitObj;

        public Fruit(string _name, Vector3 _pos, GameObject _Object)
        {
            Name = _name;
            FruitObj = Object.Instantiate(_Object, _pos, Quaternion.identity);
            MeshRenderer renderer = FruitObj.GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                switch (_name)
                {
                    case "apple":
                        renderer.material.color = new Color(255, 255, 255) ;
                        break;
                    case "strawberry":
                        renderer.material.color = Color.red;
                        break;
                    case "mango":
                        renderer.material.color = new Color(255, 215, 0);
                        break;
                    case "peach":
                        renderer.material.color = new Color32(255,255, 182, 193);
                        break;
                    case "watermelon":
                        renderer.material.color = new Color(0, 128, 0);
                        break;
                    default:
                        renderer.material.color = Color.gray;
                        break;
                }
            }
        }

        public Vector3 GetPosition()
        {
            return FruitObj.transform.position;
        }

        public Color GetColor()
        {
            return FruitObj.GetComponent<MeshRenderer>().material.color;
        }

        public Texture GetTexture()
        {
            return FruitObj.GetComponent<MeshRenderer>().material.mainTexture;
        }

        public void DestroyFruit()
        {
            Object.Destroy(FruitObj);
        }
    }


    public class SnakeGame : MonoBehaviour
    {
        //-----------------------------------实例化 蛇--------------------------------------

        public GameObject snakePrefab; //引用Prefab,这个为什么不用private?
        private SnakeNode snakehead;//实例化一个snake

        //-----------------------------------实例化 水果------------------------------------
        public GameObject colorfulApplePrefab;
        public GameObject fruitPrefab;
        public Texture colorTexture;

        private List<Fruit> fruits;

        static public float xMax = 10.0f;
        static public float zMax = 10.0f;

        List<Fruit> CreateFruits()
        {
            fruits = new List<Fruit>
            {
                new Fruit("apple", new Vector3(Random.Range(-xMax, xMax), 0.5f, Random.Range(-zMax, zMax)), colorfulApplePrefab),
                new Fruit("mango", new Vector3(Random.Range(-xMax, xMax), 0.5f, Random.Range(-zMax, zMax)), fruitPrefab),
                new Fruit("strawberry", new Vector3(Random.Range(-xMax, xMax), 0.5f, Random.Range(-zMax, zMax)), fruitPrefab),
                new Fruit("strawberry", new Vector3(Random.Range(-xMax, xMax), 0.5f, Random.Range(-zMax, zMax)), fruitPrefab),
                new Fruit("peach", new Vector3(Random.Range(-xMax, xMax), 0.5f, Random.Range(-zMax, zMax)), fruitPrefab),
                new Fruit("peach", new Vector3(Random.Range(-xMax, xMax), 0.5f, Random.Range(-zMax, zMax)), fruitPrefab),
                new Fruit("peach", new Vector3(Random.Range(-xMax, xMax), 0.5f, Random.Range(-zMax, zMax)), fruitPrefab),
                new Fruit("watermelon", new Vector3(Random.Range(-xMax, xMax), 0.5f, Random.Range(-zMax, zMax)), fruitPrefab)
            };
            return fruits;
        }


        //-----------------------------------函数------------------------------------------
        void CreateSnake()
        {
            snakehead = new SnakeNode(snakePrefab, new Vector3(3, 0.5f, 0), Color.red,null);
            snakehead.Grow(Color.gray,null);//body
            snakehead.Grow(new Color(148, 0, 211),null);//tail
        }

        public void CheckEat(SnakeNode _snake, List<Fruit> _fruits)
        {
            for (int i = 0; i < _fruits.Count; i++)
            {

                float dis = Vector3.Distance(_snake.GetPosition(), _fruits[i].GetPosition());

                if (dis <= 1.0f)
                {
                    if(SnakeNode.AteRainbow == true)
                    {
                        _snake.Grow(Color.white, colorTexture);
                    }
                    else
                    {
                        if (_fruits[i].GetTexture() != null)
                        {
                            SnakeNode.AteRainbow = true;
                            _snake.EatFood(fruits[i]);
                        }
                        else
                        {
                            _snake.Grow(Color.gray, null);
                        }
                    }
                    _fruits[i].DestroyFruit();
                    _fruits.RemoveAt(i);
                    Debug.Log(fruits.Count);
                }
            }
        }

        void UpdateFruit()
        {
            if (fruits.Count < 1)
            {
                CreateFruits();
            }
        }

        void Start()
        {
            CreateSnake();
            CreateFruits();
        }

        // Update is called once per frame
        void Update()
        {
            snakehead.Update();
            snakehead.PlayerInput();
            CheckEat(snakehead,fruits);
            UpdateFruit();
        }
    }

}
