using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace MengMeng
{
    public class SnakeNode
    {
        private GameObject snakeObj;
        private float speed;
        private Vector3 dir;
        private float passTime;
        private Color Bodycolor;


        private SnakeNode nextNode;

        public SnakeNode(GameObject _snakePrefab, Vector3 _pos, Color _bodycolor)
        {
            speed = 1.0f;
            dir = new Vector3(-1, 0, 0);
            Bodycolor = _bodycolor;
            snakeObj = GameObject.Instantiate(_snakePrefab, _pos, Quaternion.identity);
            MeshRenderer renderer = snakeObj.GetComponent<MeshRenderer>();
            renderer.sharedMaterial.color = _bodycolor;
        }

        public void Update()
        {
            passTime += Time.deltaTime;
            if (passTime > 0.1f)
            {
                passTime = 0.0f;

                Move(nextNode, snakeObj.transform.position);
                Vector3 newPos = snakeObj.transform.position + (dir * speed);

                if (newPos.x > SnakeGame.xMax)
                {
                    newPos.x = SnakeGame.xMax;
                }

                if (newPos.x < -SnakeGame.xMax)
                {
                    newPos.x = -SnakeGame.xMax;
                }

                if (newPos.z > SnakeGame.zMax)
                {
                    newPos.z = SnakeGame.zMax;
                }

                if (newPos.z < -SnakeGame.zMax)
                {
                    newPos.z = -SnakeGame.zMax;
                }

                snakeObj.transform.position = newPos;
            }

        }

        public bool Move(SnakeNode node, Vector3 _pos)
        {
            if (node == null)
            {
                return false;
            }
            if (node.snakeObj.transform.position == _pos)
            {
                return false;
            }
            Move(node.nextNode, node.snakeObj.transform.position);
            node.snakeObj.transform.position = _pos;
            return true;
        }

        public void UpdateInput()
        {
            //if(Input.GetKeyUp(KeyCode.Space))
            //{
            //    eatFood(this);
            //}

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

        public void Check()
        {
            //if(snakeObj.GetComponent<MeshCollider>().)
        }

        public void eatFood(SnakeNode node, Fruit fruit = null)
        {
            if (fruit)
            {
                fruit.DestroyFruit();
            }
            Grow(Bodycolor);
        }

        public void Grow(Color _bodycolor)
        {
            if (this.nextNode == null)
                this.nextNode = new SnakeNode(snakeObj, snakeObj.transform.position, _bodycolor);
            else
                this.nextNode.Grow(_bodycolor);
        }
    }
}
