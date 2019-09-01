using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private FruitManager fruitManager;

    void Start()
    {
        InitiateScene();
        SnakeManager.Manager.Initiate();

        Debug.Log("按空格键开始游戏");
    }

    void Update()
    {
        SnakeManager.Manager.Update();

    }

    void InitiateScene()
    {
        //初始化水果管理器
        fruitManager = new FruitManager();
        fruitManager.Initiate();
        fruitManager.GenerateFruits();
    }

}
