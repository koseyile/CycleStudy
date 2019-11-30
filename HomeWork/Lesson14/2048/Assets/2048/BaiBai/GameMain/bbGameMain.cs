using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;

namespace BBHW14 {
    public class bbGameMain : MonoBehaviour
    {
        void Start()
        {
            GameFramework.singleton.Init(new bbGameInput(), new bbGameCore(), new bbGameRender());
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

