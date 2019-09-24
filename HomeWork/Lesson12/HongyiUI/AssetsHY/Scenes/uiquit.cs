using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiquit : MonoBehaviour
{

    //网上查的自动推出功能，放在一个脚本里可以运行，分开放就不行，为什么？


    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
