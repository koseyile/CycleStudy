
using UnityEngine;

public class Player : MonoBehaviour
{
   //private bool is_landed;

    protected float jump_speed=5.0f;

    public GameObject playerPrefab;

    private bool is_landed;//小方块是不是在floor上
    public float JumpHeight = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
       // this.is_landed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.is_landed)//在floor上的时候触发
        {
            if (Input.GetKey(KeyCode.Space))
            {
            this.is_landed = false;//在空中

            float y_speed = Mathf.Sqrt(2.0f * Mathf.Abs(Physics.gravity.y) * this.JumpHeight);
               this.GetComponent<Rigidbody>().velocity = Vector3.up * y_speed;
           }
        }
        Debug.Log(this.is_landed.ToString());
    }

    void OnCollisionEnter(Collision collision)//使用标签，区分对象 是不是撞的是地面

    {
        Debug.Log(collision.gameObject.ToString());
        if (collision.gameObject.tag == "Floor")
        {
            this.is_landed = true;
        }
    }
    public bool isLanded()
    {
        return (this.is_landed);
    }

}
