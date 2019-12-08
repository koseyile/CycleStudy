using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WP;
using Game2048Framework;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Number number = new Number(4, Screen.width, Screen.height, this.gameObject);

        WPGameRender render = new WPGameRender();

        Number number = render.CreateObject(RenderProtocol.CreateNumberObject, 7) as Number;
        
        number.SetPosition(new Vector2(0, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
