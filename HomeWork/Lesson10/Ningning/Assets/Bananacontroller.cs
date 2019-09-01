using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananacontroller : MonoBehaviour
{
    public GameObject Snake;  // 把 snake 关联进来


    private void OnTriggerEnter(Collider col)  //触发器
    {
        if (col.name == "body(Clone)")
        {
            GameObject.Find("Plane").GetComponent<Game>().snakeNode.getBanana();
            //GetComponent<geek>().getApple();
            int x = Random.Range(0, 10);  //左开右闭
            int z = Random.Range(0, 10);

            transform.position = new Vector3(100, 100, 100);
        }



        // Start is called before the first frame update


    }


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }
}
