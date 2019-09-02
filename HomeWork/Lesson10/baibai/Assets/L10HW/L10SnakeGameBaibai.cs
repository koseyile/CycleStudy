using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;

namespace BBBB { 

    // 尝试把SnakeNode Class 写在另外一个cs文件，当指向这个Class时需要在Inspector中拖入？或者find这个Class？。。遂弃。
    public class SnakeNode
    {
        private GameObject node;
        private float speed;
        private Vector3 direction;
        private float passTime;

        static public float xMax = 10.0f - 0.5f;
        static public float zMax = 10.0f - 0.5f;

        static public int RainbowCount = 0;

        private SnakeNode nextNode;


        Renderer rend;

        static bool _ateRainbow;

        static public bool AteRainbow
        {
            get
            {
                return _ateRainbow;
            }
            set {
                _ateRainbow = value;
            }
        }



        public SnakeNode(GameObject _snakeprefab, Vector3 _pos, Color clr, Texture t)
        {
            speed = 1.0f;
            direction = new Vector3(-1, 0, 0);
            node = Object.Instantiate(_snakeprefab, _pos, Quaternion.identity);
            rend = node.GetComponent<Renderer>();
            rend.material.color = clr;
            rend.material.mainTexture = t;
        }

        public void Update()
        {
            passTime += Time.deltaTime;
            if (passTime > 0.2f)
            {
                Vector3 newPos = node.transform.position + speed * direction;
                newPos = BoundaryCheck(newPos);
                Move(this, newPos);
                passTime = 0f;
            }
        }

        public void Move(SnakeNode nd, Vector3 pos)
        {

            if (nd == null)
            {
            }
            else
            {
                Move(nd.nextNode, nd.node.transform.position);
                nd.node.transform.position = pos;
            }


        }

        Vector3 BoundaryCheck(Vector3 pos)
        {
            if (pos.x > xMax)
            {
                pos.x = xMax;
            }
            if (pos.x < -xMax)
            {
                pos.x = -xMax;
            }
            if (pos.z > zMax)
            {
                pos.z = zMax;
            }
            if (pos.z < -zMax)
            {
                pos.z = -zMax;
            }

            return pos;
        }

        public void UpdateInput()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //EatFood(this, Color.gray);
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                direction = new Vector3(-1, 0, 0);

            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                direction = new Vector3(1, 0, 0);

            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                direction = new Vector3(0, 0, 1);

            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                direction = new Vector3(0, 0, -1);

            }
        }

        public void EatFood(SnakeNode nd, Color c, Texture t)
        {
            if (nd.nextNode == null)
            {
                nd.nextNode = new SnakeNode(node, node.transform.position, c, t);

                if (t != null)
                {
                    RainbowCount += 1;
                    Debug.Log(RainbowCount);
                }
            }
            else
            {
                EatFood(nd.nextNode, c, t);
            }
        }

        public Vector3 GetPosition()
        {
            return node.transform.position;
        }

        public void DestroySnake()
        {
            if(nextNode == null) {
                Object.Destroy(node);
                Debug.Log("Destroy!");
            }
            else {
                nextNode.DestroySnake();
                Object.Destroy(node);
            }
        }

    }
   

    public class Fruit
    {
        private GameObject fruit;
        bool isRainbow;

        public bool IsRainbow
        {
            get
            {
                return isRainbow;
            }
        }

        public Fruit(GameObject _fruitPrefab, Vector3 _pos, bool isR)
        {
            fruit = Object.Instantiate(_fruitPrefab, _pos, Quaternion.identity);
            isRainbow = isR;
        }

        public Vector3 GetPosition() {
            return fruit.transform.position;
        }

        public void ClearFruit() {
           Object.Destroy(fruit);
        }
    }
}



/*
 * 1. 实例化一条蛇，有三节身体，头部显示为暗红色，身体为灰色，尾巴为暗紫色。
2. 实例化一颗七彩苹果，一个芒果，二个草莓，三个水蜜桃，还有一个大西瓜显示在场景中。
3. 实现如下逻辑：
    * 如果小蛇吃到了七彩苹果，接下来小蛇吃到的任意水果，长出的身体都是彩色。
    * 如果小蛇没有吃到七彩苹果，接下来小蛇吃到的任意水果，长出的身体都是灰色。
4. 当小蛇七节身体呈现彩虹颜色时，小蛇消失，打印日志：“小蛇变成了七彩艾希，像彩虹一般出现在Hank眼前。”
 */


public class L10SnakeGameBaibai : MonoBehaviour
{

    public GameObject snakePrefab;
    public GameObject rainbowApple;
    public GameObject mangoPrefab;
    public GameObject strawbPrefab;
    public GameObject peachPrefab;
    public GameObject melonPrefab;

    public Texture snakeTexture;

    private BBBB.SnakeNode snakeNode;
    private List<BBBB.Fruit> fruits;
    private Vector3[] fruitspos;

    private Color[] iniColors;

    private bool GameWin = false;

    // Start is called before the first frame update
    void Start()
    {

        iniColors = new Color[3];
        iniColors[0].r = 0.23f;
        iniColors[0].g = 0.06f;
        iniColors[0].b = 0.31f;
        iniColors[1] = Color.gray;
        iniColors[0].r = 0.8f;
        iniColors[0].g = 0.1f;
        iniColors[0].b = 0.1f;

        InitiateSnake(iniColors);


        fruits = new List<BBBB.Fruit>();

        fruitspos = new Vector3[8];
        ScatterFruits(ref fruitspos, BBBB.SnakeNode.xMax, BBBB.SnakeNode.zMax);

        fruits.Add(new BBBB.Fruit(rainbowApple, fruitspos[0], true));
        fruits.Add(new BBBB.Fruit(mangoPrefab, fruitspos[1], false));
        fruits.Add(new BBBB.Fruit(strawbPrefab, fruitspos[2], false));
        fruits.Add(new BBBB.Fruit(strawbPrefab, fruitspos[3], false));
        fruits.Add(new BBBB.Fruit(peachPrefab, fruitspos[4], false));
        fruits.Add(new BBBB.Fruit(peachPrefab, fruitspos[5], false));
        fruits.Add(new BBBB.Fruit(peachPrefab, fruitspos[6], false));
        fruits.Add(new BBBB.Fruit(melonPrefab, fruitspos[7], false));

    }

    // Update is called once per frame
    void Update()
    {
        if (GameWin == false) {
            snakeNode.Update();
            snakeNode.UpdateInput();

            CheckEat(snakeNode, fruits);

            CheckSeven(snakeNode);
        }

    }


    void InitiateSnake(Color[] colors)
    {

        snakeNode = new BBBB.SnakeNode(snakePrefab, new Vector3(3, 0.5f, 0), colors[0], null);

        for (int i = 1; i < colors.Length; i++)
        {
            snakeNode.EatFood(snakeNode, colors[i], null);
        }
    }


    void ScatterFruits(ref Vector3[] pos, float xmax, float zmax) { 
        for (int i=0; i<pos.Length; i++) {
            float x = Random.Range(-xmax+1, xmax-1);
            float z = Random.Range(-zmax + 1, zmax - 1);
            pos[i] = new Vector3(x,0.5f,z);
        }
    }


    public void CheckEat(BBBB.SnakeNode sn, List<BBBB.Fruit> f)
    {
        for(int i =0; i < f.Count; i++) {

            float dis = Vector3.Distance(sn.GetPosition(), f[i].GetPosition());

            if (dis <= 1.5f)
            {
                if (BBBB.SnakeNode.AteRainbow == true)
                {
                    sn.EatFood(sn, Color.white, snakeTexture);
                }
                else
                {
                    if (f[i].IsRainbow == true)
                    {
                        BBBB.SnakeNode.AteRainbow = true;
                        // animation
                        sn.EatFood(sn, Color.white, snakeTexture);
                    }
                    else
                    {
                        sn.EatFood(sn, Color.gray, null);
                    }
                }

                // pop out the list
                f[i].ClearFruit();
                f.RemoveAt(i);


            }
        }
    }

    // 判断现在SnakeNode Class时，自己destroy自己的GameObject成员，就会Exception。。是为什么呢？
    public void CheckSeven(BBBB.SnakeNode sn)
    {

        if (BBBB.SnakeNode.RainbowCount == 7)
        {
            GameWin = true;
            sn.DestroySnake();
            Debug.Log("小蛇变成了七彩艾希，像彩虹一般出现在Hank眼前。");

            BBBB.SnakeNode.RainbowCount = 0;
        }
    }

}


