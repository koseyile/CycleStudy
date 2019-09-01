using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace MengMeng
{
    public class SnakeNode
    {
        private GameObject snakeObj;
        private float speed;
        private Vector3 dir;
        private float passTime;
        private bool _GrowColor = false;
        private SnakeNode nextNode;

        public bool GrowColor
        {
            get { return _GrowColor; }
        }
        private bool TryGetColor(out Color color)
        {
            MeshRenderer renderer = snakeObj.GetComponent<MeshRenderer>();
            if(renderer == null)
            {
                color = new Color(1, 1, 1);
                return false;
            }
            color = renderer.material.color;
            return true;
        }

        public SnakeNode(GameObject _snakePrefab, Vector3 _pos, Color _bodycolor)
        {
            speed = 1.0f;
            dir = new Vector3(-1, 0, 0);
            snakeObj = GameObject.Instantiate(_snakePrefab, _pos, Quaternion.identity);
            MeshRenderer renderer = snakeObj.GetComponent<MeshRenderer>();
            Material BodyMat =   new Material(Shader.Find("Standard"));
            BodyMat.color = _bodycolor;
            renderer.material = BodyMat;
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

        public Vector3 GetPosition()
        {
            return snakeObj.transform.position;
        }

        public void EatFood(Fruit fruit = null)
        {
            if (fruit != null)
            {
                fruit.DestroyFruit();
                if(fruit.Name == "apple")
                {
                    _GrowColor = true;
                }
            }
            if(!_GrowColor)
            {
                Grow(Color.gray);
            }
            else
            {
                Grow(fruit.GetObjColor());
            }
        }

        public void Grow(Color _bodycolor)
        {
            if (this.nextNode == null)
                this.nextNode = new SnakeNode(snakeObj, snakeObj.transform.position, _bodycolor);
            else
                this.nextNode.Grow(_bodycolor);
        }

        public void Gone()
        {
            this.snakeObj.SetActive(false);
            if (this.nextNode == null)
            {
                return;
            }
            this.nextNode.Gone();
        }

        public int GetGreyBodyCount()
        {
            int count = 0;
            if(nextNode!=null)
            {
                count += nextNode.GetGreyBodyCount();
            }
            Color color;
            if(TryGetColor(out color)&&color == Color.gray)
            {
                count++;
            }
            return count;
        }
    }
}
