using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBHW14;
using Game2048Framework;

public class Run2048 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        // start a game grid of 4 x 4, with "3" initial cells
        GameGrid game2048 = new GameGrid(4,4,3);
        InputProtocol inputStep = InputProtocol.None;
    }

    // Update is called once per frame
    void Update()
    {
        //GameFramework.singleton.Update();
    }
}
