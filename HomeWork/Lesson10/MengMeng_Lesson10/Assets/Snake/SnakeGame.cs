﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//习题：
//艾希被女巫施了魔法，强大的黑魔法，让艾希变成了一条灰色的方块蛇。
//邪恶的女巫对艾希下了这样咒语：
//“除非你能吃到七彩苹果，否则谁也救不了你！”
//某天，英雄Hank路过，看到一条灰色的蛇安静地躺在草丛里，Hank觉得小蛇应该多点色彩才好看，于是用七彩笔画了一只七彩苹果扔给了小蛇。
//小蛇吃了七彩苹果后，还吃了一个芒果，二个草莓，三个水蜜桃，最后还吃了一个大大的西瓜。
//小蛇每吃一个水果，身体都会长出一节，长出身体不再是往常的灰色，而是漂亮鲜艳的颜色。
//最终，小蛇变成了七彩艾希，像彩虹一般出现在Hank眼前。


//1. 实例化一条蛇，有三节身体，头部显示为暗红色，身体为灰色，尾巴为暗紫色。
//2. 实例化一颗七彩苹果，一个芒果，二个草莓，三个水蜜桃，还有一个大西瓜显示在场景中。
//3. 实现如下逻辑：
//    * 如果小蛇吃到了七彩苹果，接下来小蛇吃到的任意水果，长出的身体都是彩色。
//    * 如果小蛇没有吃到七彩苹果，接下来小蛇吃到的任意水果，长出的身体都是灰色。
//4. 当小蛇七节身体呈现彩虹颜色时，小蛇消失，打印日志：“小蛇变成了七彩艾希，像彩虹一般出现在Hank眼前。”
namespace MengMeng
{
    public class SnakeGame : MonoBehaviour
    {
        public GameObject snakePrefab;
        public GameObject FruitPrefab;
        public GameObject ColorfulApple;
        private SnakeNode snakeNode;

        static public float xMax = 10.0f;
        static public float zMax = 10.0f;
        // Start is called before the first frame update
        void Start()
        {
            snakeNode = CreateSnake();
            //CreateFruits();
        }

        // Update is called once per frame
        void Update()
        {
            snakeNode.Update();
            snakeNode.UpdateInput();
        }

        SnakeNode CreateSnake()
        {
            SnakeNode snakehead = new SnakeNode(snakePrefab, new Vector3(3, 0.5f, 0), new Color(0.5f, 0, 0));
            snakehead.Grow(Color.gray);
            snakehead.Grow(new Color(0.5f, 0, 0.5f));
            return snakehead;
        }


        List<Fruit> CreateFruits()
        {
            List<Fruit> Snacks = new List<Fruit>();
            Snacks.Add(new Fruit("apple", "colorful", new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax)), ColorfulApple));
            Snacks.Add(new Fruit("mango", "yellow", new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax)), FruitPrefab));
            Snacks.Add(new Fruit("strawberry", "red", new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax)), FruitPrefab));
            Snacks.Add(new Fruit("strawberry", "red", new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax)), FruitPrefab));
            Snacks.Add(new Fruit("peach", "pink", new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax)), FruitPrefab));
            Snacks.Add(new Fruit("peach", "pink", new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax)), FruitPrefab));
            Snacks.Add(new Fruit("peach", "pink", new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax)), FruitPrefab));
            Snacks.Add(new Fruit("watermelon", "green", new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax)), FruitPrefab));
            return Snacks;
        }
    }

}



