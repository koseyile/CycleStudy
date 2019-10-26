using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace ZCY
{
    public class zcyGameMain : MonoBehaviour
    {
        void Start()
        {
            GameFramework.singleton.Init(new zcyGameInput(), new zcyGameCore(), new zcyGameRender());
        }

        // Update is called once per frame
        void Update()
        {
            GameFramework.singleton.Update();
        }

        void OnDestroy()
        {
            GameFramework.singleton.Destroy();
        }
    }
}

