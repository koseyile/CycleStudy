/*
 * 习题
基础题：
1. 在unity场景中制作一个2d gameobject卡片 。两面可见，每面可以显示一个文本字符。
2. 将此gameobject 拖成prefab。
3. 编写一个class A，输入为上述prefab和旋转速度，编写一个卡片绕X轴旋转的动画函数。
4. 场景里制作一个测试ui button，点击此button，测试此功能(点击按钮时调用动画函数，播放卡片旋转动画）。

5. 为class A编写设置文本函数，可改变正反两面的文本。ui上制作一个新测试按钮，测试此功能。

6. 编写一个class B继承自A，请自由发挥，为class B赋予这样的功能：每旋转一次，卡片的文本会变化。
7. 实例化8个B，分别代表小时，分钟，秒，毫秒（为方便制作，我们定义1秒= 60毫秒）。实现计时功能，毫秒卡片在飞速旋转变化，秒卡片每隔一秒旋转变化，分钟卡片每隔一分钟旋转变化，小时卡片每隔一小时旋转变化。
8. 编写一个class C继承自A，请自由发挥，为class B赋予这样的功能：每旋转一次，卡片的文本会自加一次。（假设文本只能显示数字和字母）
9. 实例化600个C，在屏幕上组成一个大矩形，所有卡面使用随机速度翻转。

进阶题：
1. 实现机场机械广告牌功能。完成如下要求：
    * 如视频展示的那样，部分区域快速翻转。部分区域则维持稳定状态。
    * 可进行微创新，像球场人浪那样，利用时间差，让部分区域展示规律渐进的翻转效果。
    * 自由发挥自己想要的效果。

                  可改变正反两面的文本                  */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ningning { 

public class Card_A
{
    public float speed;
    public GameObject TextCard;
    public float passTime;
    public int q;
    

    public Card_A(GameObject _Prefab, float _speed, Vector3 _Pos, int _q)   //speed 每秒转几圈 q 数字几到几
    {
        TextCard = GameObject.Instantiate(_Prefab, _Pos, Quaternion.identity);
        speed = _speed;
        int q = _q;
    }

   /* public void rotate() //?????
    {
        TextCard.transform.Rotate(360 * Time.deltaTime * speed, 0, 0, Space.World);  //每秒转speed下
        Debug.Log("rotate");
    }
    */
  

    public virtual void rotate()
    {
        TextCard.transform.Rotate(new Vector3(1, 0, 0), 360 * Time.deltaTime * speed, Space.World); //Time.deltaTime * speed
        Debug.Log("rotate2");



    }

    public void Change_text(int _newtext)  //把text换成_ newtext
    {
        string i= _newtext.ToString();  //将int convert to string
       TextCard.transform.Find("Front").GetComponent<TextMesh>().text = i;          
        TextCard.transform.Find("Back").GetComponent<TextMesh>().text = i;
    }

    public int n = 0;

    public void Update()
    {
        TextCard.transform.Rotate(new Vector3(1, 0, 0), 360 * Time.deltaTime * speed, Space.World); //Time.deltaTime * speed
        Debug.Log("rotate2");

        passTime += Time.deltaTime;
        if (passTime > (1/speed))
        {
            passTime = 0.0f;
            n++;

          Change_text(n);      
            Debug.Log("change to n");
            if (n >= 9)          //q=10 or 6
            {
                n = -1;
            }

        
        }
    }

}



public class Card_Timer : Card_A
{

    public Card_Timer(GameObject _Prefab, float _speed, Vector3 _Pos, int _q) : base(_Prefab, _speed, _Pos, _q)
    {
       
    }

    public override void rotate()
    {
        base.rotate(); //直接用基类的
        //TextCard.transform.Rotate(new Vector3(1, 0, 0), 360 * Time.deltaTime * speed, Space.Self);
        passTime += Time.deltaTime;
        if (passTime > (1 / speed))
        {
            passTime = 0.0f;
            n++;

            Change_text(n);       
            Debug.Log("change to n");
            if (n >= 9)          //q=10 or 6
            {
                n = -1;
            }

        }


    }
}

    

    /*

    public class Card_C {

    }

       */





    public class x_rotation : MonoBehaviour
    {



        public GameObject prefab;
        public float rotation_speed;

        public Card_Timer millisecond1;
        public Card_Timer millisecond2;
        public Card_Timer second1;
        public Card_Timer second2;
        public Card_Timer minute1;
        public Card_Timer minute2;
        public Card_Timer hour1;
        public Card_Timer hour2;

        public Card_Timer test;

    

    bool a = false;
    float y = 0.5f;



    // Start is called before the first frame update
    void Start()
        {
            
            millisecond1 = new Card_Timer(prefab, 60, new Vector3(-1, y, 0), 6);
            millisecond2 = new Card_Timer(prefab, 6, new Vector3(-2, y, 0), 9);

            second1 = new Card_Timer(prefab, 1f, new Vector3(-4, y, 0), 6);
            second2 = new Card_Timer(prefab, 0.1f, new Vector3(-5, y, 0), 9);

            minute1 = new Card_Timer(prefab, 1/60f, new Vector3(-7, y, 0), 6);
            minute2 = new Card_Timer(prefab, 1/600f, new Vector3(-8, y, 0), 9);

            hour1 = new Card_Timer(prefab, 1/3600f, new Vector3(-10, y, 0), 6);
            hour2 = new Card_Timer(prefab, 1/36000f, new Vector3(-11, y, 0), 9);

            test = new Card_Timer(prefab, 1 , new Vector3(-14, y, 0), 9);




        //题目9
        Card_Timer[] rectangle = new Card_Timer[600];
        float[] RandomSpeed = new float[600];
        int n = 0;
        for(int j=0;j<60;j++)
        {
            for(int k = 0; k < 10; k++) { 
            RandomSpeed[n] = Random.Range(0, 0.1f);
            rectangle[n] = new Card_Timer(prefab, RandomSpeed[n], new Vector3(j,k,0), 9);
                n++;
            }

        }

       
    }



    bool b = false;
    public void Click_test() //点一下转一圈
    {

        b = true;
        float t = 0;
        t+= Time.deltaTime;
        if (t > 1)
        {
            b = false;

        }
    }
    
        public void Click()
        {

            a = true;
        }

        public void Stop()
        {

            a = false;
        }

        public void Change()
        {
            millisecond1.Change_text(1);
            millisecond2.Change_text(2);

        }




        // Update is called once per frame
        void Update()
        {
        
            if (a)
            {
                

                millisecond1.rotate();
                millisecond2.rotate();
                second1.rotate();
                second2.rotate();
                minute1.rotate();
                minute2.rotate();
                hour1.rotate();
                hour2.rotate();
            
            //600个随机速度转动
            for (int i = 0; i < 60; i++)
            {

               // rectangle[i].rotate();   //为啥报错呀？？？

            }
                

        }

        if (b)
        {
            test.rotate();
            test.Update();
        }



           
        }
    }
}
