using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Launcher : MonoBehaviour
{

    public GameObject ball_prefab;

    private Player player;
    private bool is_launch_ball = false;

    private string result = "";
    private string[] good_mess;
    private int good_mess_index;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {

        //把这里的player和gameobject对等?
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        //实例化一个球
        GameObject ball = Instantiate(ball_prefab) as GameObject;
        ball.transform.position = new Vector3(5.0f, 2.0f, 0.0f);
        this.is_launch_ball = true;

        //this.good_mess = new string[4];

        //this.good_mess[0] = "Nice!";
        //this.good_mess[1] = "Okay!";
        //this.good_mess[2] = "Yatta!";
        //this.good_mess[3] = "*^o^*v";

        //this.good_mess_index = 0;

    }

    public void Begin(GameObject ball_prefab)
    {
        ball_prefab.GetComponent<Ball>().velocity = new Vector3(-8f, 8f, 0f);
    }
    //public void Jump()
    //{
    //    //ball_prefab.transform.position = new Vector3(5.0f, 2.0f, 0.0f);
    //    //   //在球发射的时候，以及cube在地面上的时候
    //    if (this.is_launch_ball && this.player.isLanded())//调用player里的islandend的方法
    //    {
    //        //不明白

    //        //float x_speed;
    //        //float y_speed;
    //        //float height;

    //        //　球的速度是随机的？
    //        //x_speed = -Random.Range(2, 7) * 2.5f;

    //        //height = Random.Range(2.0f, 3.0f);

    //        // ？
    //        //y_speed = this.calc_ball_y_speed(x_speed, height, ball.transform.position);
    //        //Vector3 velocity = new Vector3(x_speed, y_speed, 0.0f);


    //        // 「ボール発射して」フラグを下す.
    //        //this.is_launch_ball = false;
    //    }

    //}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("begin"))
        {
            Begin(ball_prefab);
        }
        

    }


    private float calc_ball_y_speed(float x_speed, float height, Vector3 ball_position)
    {
        float t;
        float y_speed;

        //？？？
        t = (this.player.transform.position.x - ball_position.x) / x_speed;

        // y = v*t - 0.5f*g*t*t
        // から v を求める.
        y_speed = ((height - ball_position.y) - 0.5f * Physics.gravity.y * t * t) / t;

        return (y_speed);
    }

    public void setResult(bool is_success)
    {
        if (is_success)
        {

            this.result = this.good_mess[this.good_mess_index];

            this.good_mess_index = (this.good_mess_index + 1) % 4;

        }
        else
        {

            this.result = "Miss!";
        }

        // 一定時間経過後に、結果表示を消す.
        StartCoroutine(clearResult());
    }

    private IEnumerator clearResult()
    {
        yield return new WaitForSeconds(0.5f);

        this.result = "";
    }
    public void OnGUI()
    {
        GUI.Label(new Rect(200, 200, 200, 20), this.result);
    }

    public void OnBallDestroy()
    {
        is_launch_ball = true;
    }
}

    

