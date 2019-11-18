using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;
using WP;

public class wupGameMain : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameFramework.singleton.Init(new wupGameInput(), new wupGameCore(), new wupGameRender(800, 800));
    }

    // Update is called once per frame
    void Update()
    {
        GameFramework.singleton.Update();
    }

    private void OnDestroy()
    {
        GameFramework.singleton.Destroy();
    }
}
