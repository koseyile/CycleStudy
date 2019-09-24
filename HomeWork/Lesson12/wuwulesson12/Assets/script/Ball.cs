using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

   
    public Launcher launcher;
    public Vector3 velocity;

    private bool is_launched;
    public bool is_touched;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        this.launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Launcher>();

        // アルファーで見えなくしておく.

        Color color = this.GetComponent<Renderer>().material.color;
        color.a = 0.0f;

        this.GetComponent<Renderer>().material.color = color;
        this.GetComponent<Rigidbody>().useGravity = false;

        this.is_touched = false;
        this.is_launched = false;

        //this.time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.is_launched)//如果球不在floor上
        {

            float delay = 0.5f;//延迟0.5秒

            // アルファーでフェードインする.

            Color color = this.GetComponent<Renderer>().material.color;//为什么重复出现一句话


            float t = Mathf.InverseLerp(0.0f, delay, this.time);

            t = Mathf.Min(t, 1.0f);

            color.a = Mathf.Lerp(0.0f, 1.0f, t);

            this.GetComponent<Renderer>().material.color = color;

            if (this.time >= delay)
            {

                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().velocity = this.velocity;

                this.is_launched = true;
            }
        }

        this.time += Time.deltaTime;

        Debug.Log(this.GetComponent<Rigidbody>().velocity.ToString());
    }

    void OnBecameInvisible()//小球抛出画面外调用
     {
        
       this.launcher.OnBallDestroy();//调用launcher里面的onballdestroy方法

       if (!this.is_touched)
       {

            if (this.launcher != null)
            {

                this.launcher.setResult(false);
            }
        }
        Destroy(this.gameObject);//删除游戏对象 
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手がプレイヤーだったら…….
        if (collision.gameObject.tag == "Player")
        {

            if (collision.gameObject.GetComponent<Player>().isLanded())
            {

                // プレイヤーが着地中だったらミス.

                this.launcher.setResult(false);

                // プレイヤーが触ったことを覚えておく.
                this.is_touched = true;

            }
            else
            {

                // プレイヤーがジャンプ中だったら成功.

                this.launcher.setResult(true);
                this.is_touched = true;
            }
        }
    }
}
