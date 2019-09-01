using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class geek : MonoBehaviour
{

    public GameObject bodyPrefab;
    public GameObject head;
   // head.transform.position = new Vector3(1, 2, 3); 

        

private int length;
	private Vector3 up = new Vector3(0, 0, 1);
	private Vector3 down = new Vector3(0, 0, -1);
	private Vector3 left = new Vector3(-1, 0, 0);
	private Vector3 right = new Vector3(1, 0, 0);

	private Vector3 Dir;
	private float timer;
	public float threshold;  //yuzhi



	void Start()
	{
        // 第一针开始 初始化
        head.transform.position = new Vector3(1, 2, 3);
        length = 3;
		Dir = up;
		timer = 0;

		for (int n = 0; n < length; n++)
		{
			GameObject body = Instantiate(bodyPrefab, transform);   //生成一个body的子物体 (gameobject original,transform parent)
			body.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - (n + 1)); //更改物体的位置 初始化生成的三个物体在头的后面
		}

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))

		{
			Dir = up;
		}

		else if (Input.GetKeyDown(KeyCode.S))

		{
			Dir = down;

		}

		else if (Input.GetKeyDown(KeyCode.A))

		{
			Dir = left;
		}

		else if (Input.GetKeyDown(KeyCode.D))

		{
			Dir = right;
		}

		if (timer > threshold)
		{
			for (int n = length - 1; n > 0; n--)
			{
				transform.GetChild(n).transform.position = transform.GetChild(n - 1).transform.position; //后面一格走到前面一格去 ????


			}
			transform.GetChild(0).transform.position = head.transform.position;
			head.transform.position += Dir;
			timer = 0;
		}

		timer += Time.deltaTime; //timer=1 的时候 过去了一秒 作为正常的计时





	}

	public void getApple()   //苹果来判断 我有没有被吃 让苹果的函数来调用 if applecontroller find the snake attach to apple active this function
	{
		GameObject body = Instantiate(bodyPrefab, transform);
		body.transform.position = transform.GetChild(length - 1).position;
		length++;
	}

}
