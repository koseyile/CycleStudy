using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wuwu
{
    public class Wuwu138 : MonoBehaviour
    {
        public class Builder
        {
            public string name;
            protected Animation animation;
            public Builder(string _name)
            {
                name = _name;
            }
            public Builder()
            {

            }

            public void buildPartA(Builder builder, Animation animation)
            {
                Debug.Log(builder + "制作的部分是" + animation.partA);
            }
            public void buildPartB(Builder builder, Animation animation)
            {
                Debug.Log(builder + "制作的部分是" + animation.partB);
            }
            public void buildPartC(Builder builder, Animation animation)
            {
                Debug.Log(builder + "制作的部分是" + animation.partC);
            }
            public void buildPartD(Builder builder, Animation animation)
            {
                Debug.Log(builder + "制作的部分是" + animation.partD);
            }
            public void buildPartE(Builder builder, Animation animation)
            {
                Debug.Log(builder + "制作的部分是" + animation.partE);
            }
            public void buildPartF(Builder builder, Animation animation)
            {
                Debug.Log(builder + "制作的部分是" + animation.partF);
            }

        }
        public class BAIBAI
        {
            public string name;
            public Builder builder;
            public Animation animation;
            public BAIBAI(string _name)
            {
                name = _name;
            }
            public void Director(Animation animation)
            {
                Debug.Log(name + "要导演一部" + animation.name);
            }
            public void Construct(Animation animation)
            {
                Debug.Log(name + "邀请朋友们一起制作一部" + animation.name);
            }
        }


        public class Animation
        {
            //故事剧本，人物设计，场景设计，动画制作，音乐，配音等
            public string partA;
            public string partB;
            public string partC;
            public string partD;
            public string partE;
            public string partF;
            public string name;

            public Animation(string _name)
            {
                name = _name;
            }
            public void setPartA(Builder builder)
            {
                Debug.Log("由" + builder + "制作了" + partA);
            }
            public void setPartB(Builder builder)
            {
                Debug.Log("由" + builder + "制作了" + partB);
            }
            public void setPartC(Builder builder)
            {
                Debug.Log("由" + builder + "制作了" + partC);
            }
            public void setPartD(Builder builder)
            {
                Debug.Log("由" + builder + "制作了" + partD);
            }
            public void setPartE(Builder builder)
            {
                Debug.Log("由" + builder + "制作了" + partE);
            }
            public void setPartF(Builder builder)
            {
                Debug.Log("由" + builder + "制作了" + partF);
            }

        }


        public class Dalao
        {
            public string name;
            public Dalao(string _name)
            {
                name = _name;
            }
            public Animation animation;
            public void Getresult(Animation animation)
            {
                Debug.Log(name + "对" + animation.name + "很满意");
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            BAIBAI baibai = new BAIBAI("白白");

            Builder zz = new Builder("zz");
            Builder wuwu = new Builder("wuwu");
            Builder ningning = new Builder("ningning");
            Builder hongyi = new Builder("hongyi");
            Builder wupeng = new Builder("wupeng");
            Builder mengmeng = new Builder("mengmeng");

            Animation animation = new Animation("动画片");
            animation.partA = "script";
            animation.partB = "roledesign";
            animation.partC = "scencedesign";
            animation.partD = "production";
            animation.partE = "music";
            animation.partF = "voice";

            baibai.Director(animation);
            baibai.Construct(animation);

            animation.setPartA(zz);
            animation.setPartB(wuwu);
            animation.setPartC(ningning);
            animation.setPartD(hongyi);
            animation.setPartE(wupeng);
            animation.setPartF(mengmeng);

            //buildPartA(zz, animation);
            //buildPartB(wuwu, animation);
            //buildPartC(ningning, animation);
            //buildPartD(hongyi,animation);
            //buildPartE(wupeng, animation);
            //buildPartF(mengmeng, animation);

            Dalao dalao = new Dalao("大佬");
            dalao.Getresult(animation);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}