using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zzlesson13
{

    public class zzlesson13Q4 : MonoBehaviour
    {
        //Q4
        public class Bird
        {
            public string birdname;
            public int flyspeed;
            public string wingcolor;
            public string favoritefood;

            public Bird(string n, int s, string c, string f)
            {
                birdname = n;
                flyspeed = s;
                wingcolor = c;
                favoritefood = f;
            }

        }

        public class Haiyan : Bird
        {
            public Haiyan(string n, int s, string c, string f) : base(n, s, c, f)
            {

            }
        }

        public class Haiou : Bird
        {
            public Haiou(string n, int s, string c, string f) : base(n, s, c, f)
            {

            }
        }
        public class Tuoniao : Bird
        {
            public Tuoniao(string n, int s, string c, string f) : base(n, s, c, f)
            {

            }
        }


        private void Start()
        {
             
            Haiou haiou = new Haiou("海鸥", 20, "灰色", "沙丁鱼");
            Haiyan haiyan = new Haiyan("海燕", 80, "棕色", "小虾");
            Tuoniao tuoniao = new Tuoniao("鸵鸟", 30, "褐色", "苹果");

            Debug.Log(haiou.birdname + "飞行的速度是" + haiou.flyspeed + "翅膀颜色是" + haiou.wingcolor + "最喜欢的食物是" + haiou.favoritefood);
            Debug.Log(haiyan.birdname + "飞行的速度是" + haiyan.flyspeed + "翅膀颜色是" + haiyan.wingcolor + "最喜欢的食物是" + haiyan.favoritefood);
            Debug.Log(tuoniao.birdname + "飞行的速度是" + tuoniao.flyspeed + "翅膀颜色是" + tuoniao.wingcolor + "最喜欢的食物是" + tuoniao.favoritefood);
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}

