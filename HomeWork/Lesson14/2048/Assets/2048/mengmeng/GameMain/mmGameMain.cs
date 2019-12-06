using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;
using mm;

public class mmGameMain : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        GameFramework.singleton.Init(new mmGameInput(), new mmGameCore(), new mmGameRender());
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
